using ProxyApp.App.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProxyApp.App
{
    static class Proxy
    {
        static Website website = new Website();
        private static List<Website> BlockedSites = new List<Website>()
        {
        new Website("google.com", "what the hell"), 
        new Website("www.youtube.com"),
        new Website("runescape.com")
    };


        public static void AddNewWebsite(string domainName)
        {
            Website w = website.NewWebsite(domainName);
            BlockedSites.Add(w);
            BlockedSites.ToTextFile<Website>();
        }

        public static void AddNewWebsite(string domainName, string category)
        {
            Website w = website.NewWebsite(domainName, category); 
            BlockedSites.Add(w);
            BlockedSites.ToTextFile<Website>();
        }

        public static void RemoveWebsite(int i) 
        {
            if (BlockedSites.Count > i && i >= 0)
            {
                BlockedSites.RemoveAt(i);
            }
        }

        public static List<WebsiteDTO> GetBlockedSites()
        {
            List<WebsiteDTO> webSiteNames = new List<WebsiteDTO>();
            foreach(var w in BlockedSites)
            {
                if (w != null)
                {
                    WebsiteDTO website = new WebsiteDTO(w.DomainName, w.Category);
                    webSiteNames.Add(website);
                }
            }
            return webSiteNames;
        }

        public static void BlockAllListedWebsites()
        {
            
            foreach(var w in BlockedSites)
            {

            }
        }
    }
}
