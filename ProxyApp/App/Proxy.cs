using ProxyApp.App.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProxyApp.App
{
    static class Proxy
    {
        static Website website = new Website();
        public static List<Website> BlockedSites = new List<Website>();
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
    }
}
