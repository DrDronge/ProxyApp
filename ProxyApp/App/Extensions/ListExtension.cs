using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProxyApp.App.Extensions
{
    public static class ListExtension
    {
        public static void ToTextFile<T>(this List<T> list)
        { 
            using(TextWriter tw = new StreamWriter(@".\\Blocked.txt"))
            {
                for(int i = 0; i < list.Count; i++)
                {
                    tw.WriteLine(list[i].ToString());
                }
                tw.Close();
            }

        }
    }
}
