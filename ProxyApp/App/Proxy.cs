using ProxyApp.App.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyApp.App
{
    static class Proxy
    {
        static Website website = new Website();
        public static List<Website> BlockedSites = new List<Website>();
        private static TcpListener listener;
        public static bool ProxyActive = false;
        public static List<Website> ReadCsvFile(string path)
        {
            List<Website> list = new List<Website>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    Website website = new Website();
                    website.DomainName = values[0];
                    website.Category = values[1];
                    website.Ip = new List<string>();

                    for(int i = 2; i < values.Length; i++)
                    {
                        website.Ip.Add(values[i]);
                    }
                    list.Add(website);
                }
            }
            return list;
        }
        public static void AddNewWebsite(string domainName)
        {
            BlockedSites.Clear();
            BlockedSites = Proxy.GetBlockedSitesWithIps();
            Website w = website.NewWebsite(domainName);
            BlockedSites.Add(w);
            BlockedSites.ToTextFile<Website>();
        }

        public static void AddNewWebsite(string domainName, string category)
        {
            BlockedSites.Clear();
            BlockedSites = Proxy.GetBlockedSitesWithIps();
            Website w = website.NewWebsite(domainName, category);
            BlockedSites.Add(w);
            BlockedSites.ToTextFile<Website>();
        }

        public static void RemoveWebsite(int i)
        {
            string path = @".\\Blocked.txt";
            if (File.Exists(path))
            {
                List<Website> list = ReadCsvFile(path);
                if (list.Count > 0 && i >= 0)
                {
                    list.RemoveAt(i);
                    list.ToTextFile<Website>();
                }
            }
        }

        public static List<WebsiteDTO> GetBlockedSites()
        {
            List<WebsiteDTO> webSiteNames = new List<WebsiteDTO>();
            string path = @".\\Blocked.txt";
            if (File.Exists(path)){
                List<Website> blockedTxt = ReadCsvFile(path);
                foreach (Website website in blockedTxt)
                {
                    if (website != null)
                    {
                        WebsiteDTO websiteDTO = new WebsiteDTO(website.DomainName, website.Category);
                        webSiteNames.Add(websiteDTO);
                    }
                }
            }
           
            return webSiteNames;
        }
        public static List<Website> GetBlockedSitesWithIps()
        {
            List<Website> webSiteNames = new List<Website>();
            string path = @".\\Blocked.txt";
            if (File.Exists(path))
            {
                List<Website> blockedTxt = ReadCsvFile(path);
                foreach (Website website in blockedTxt)
                {
                    if (website != null)
                    {
                        Website websites = new Website(website.DomainName, website.Category);
                        webSiteNames.Add(websites);
                    }
                }
            }

            return webSiteNames;
        }

        public static async void StartProxyListener()
        {
            listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();
            ProxyActive = true;
            Console.WriteLine("Proxy server started. Listening on port 8888...");
            
            while (ProxyActive)
            {
                Application.DoEvents();
                using (TcpClient tcpClient = await listener.AcceptTcpClientAsync())
                {
                    HandleClientRequest(tcpClient);
                }
            }
        }
        public static void StopProxyListener()
        {
            listener.Stop();
            ProxyActive = false;

        }

        private static void HandleClientRequest(TcpClient tcpClient)
        {
            using (NetworkStream clientStream = tcpClient.GetStream())
            {
                byte[] buffer = new byte[4096];
                int bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                string request = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                string requestedHost = GetRequestedHost(request);

                if(IsBlockedWebsite(requestedHost))
                {
                    Console.WriteLine("Blocked website: " + requestedHost);

                    string response = "HTTP/1.1 403 Forbidden\r\nContent-Type: text/html\r\n\r\n<h1>Website Blocked</h1>";
                    byte[] responseBytes = Encoding.ASCII.GetBytes(response);
                    clientStream.Write(responseBytes, 0, responseBytes.Length);
                }
                else
                {
                    using (TcpClient server = new TcpClient(requestedHost, 80))
                        using(NetworkStream serverStream = server.GetStream())
                    {
                        serverStream.Write(buffer, 0, bytesRead);

                        serverStream.CopyTo(clientStream);
                    }
                }
                
            }
        }

        private static bool IsBlockedWebsite(string requestedHost)
        {
            try
            {
                IPAddress[] ipAddress = Dns.GetHostAddresses(requestedHost);
                List<string> BlockedSitesIps = BlockedSites.SelectMany(x => x.Ip).ToList();
                foreach (IPAddress ip in ipAddress)
                {
                    if (BlockedSitesIps.Contains(ip.ToString()))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error while looking up IP addresses: {ex.Message}");
            }
        }

        private static string GetRequestedHost(string request)
        {
            string hostStartTag = "Host: ";
            int hostStartIndex = request.IndexOf(hostStartTag) + hostStartTag.Length;
            int hostEndIndex = request.IndexOf('\r', hostStartIndex);
            string requestedHost = request.Substring(hostStartIndex, hostEndIndex - hostStartIndex);

            return requestedHost;
        }


    }
}
