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
            List <Website> list = new List<Website>();
            Website w = website.NewWebsite(domainName);
            list.ToTextFile<Website>();
        }

        public static void AddNewWebsite(string domainName, string category)
        {
            List<Website> list = new List<Website>();
            Website w = website.NewWebsite(domainName, category);
            list.ToTextFile<Website>();
        }

        public static void RemoveWebsite(int i)
        {
            string path = "...\\ProxyApp\\App\\Blocked.txt";
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
            string path = "...\\ProxyApp\\App\\Blocked.txt";
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

    }
}
