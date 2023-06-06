using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ProxyApp.App
{
    class Website
    {
        public string DomainName { get; set; }
        public List<string> Ip { get; set; }
        public string Category { get; set; }

        public Website() { }
        public Website(string domainName)
        {
            try
            {
                DomainName = domainName.ToLower();
                Ip = GetIp(DomainName);
                Category = "Ingen kategori angivet";
            }catch (Exception)
            {
                throw new Exception("Domain name cant be found");
            }
        }
        public Website(string domainName, string category)
        {
            try
            {
                DomainName = domainName.ToLower();
                Ip = GetIp(DomainName);
                Category = category;
            }
            catch (Exception)
            {
                throw new Exception("Domain name cant be found");
            }
        }

        private List<string> GetIp(string domainName)
        {
            IPAddress[] domainNameIP = Dns.GetHostAddresses(domainName);
            List<string> ipList = new List<string>();

            if (domainNameIP != null && domainNameIP.Length > 0)
            {
                foreach (IPAddress ip in domainNameIP)
                {
                    ipList.Add(ip.ToString());
                }
            }

            return ipList;
            
        }

        public Website NewWebsite(string domainName)
        {
            Website w = new Website(domainName);
            return w;
        }

        public Website NewWebsite(string domainName, string category)
        {
            Website w = new Website(domainName, category);
            return w;
        }

        public override string ToString()
        {
            string result = $"{DomainName},{Category}";
            for (int i = 0; i < Ip.Count(); i++)
            {
               result += $",{Ip[i]}";
            }

            return result;
        }
    }
}
