using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace ProxyApp.App
{
    class WebsiteDTO
    {
        public string DomainName { get; set; }
        
        public string Category { get; set; }

        public WebsiteDTO() { }
        public WebsiteDTO(string domainNames)
        {
            try
            {
                DomainName = domainNames.ToLower();
                Category = "Ingen kategori angivet";
            }catch (Exception)
            {
                throw new Exception("Domain name cant be found");
            }
        }
        public WebsiteDTO(string domainName, string category) : this(domainName)
        {
            Category = category;
        }

        public WebsiteDTO NewWebsiteDTO(string domainName, string category)
        {
            WebsiteDTO w = new WebsiteDTO(domainName, category);
            return w;
        }
    }
}
