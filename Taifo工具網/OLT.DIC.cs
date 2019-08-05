﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;


namespace Taifo工具網
{
    public class OLT_DIC
    {
        public OLT_DIC()
        {
            CreateDictionary();
        }


        Dictionary<string, string> Area = new Dictionary<string, string>();

        public string Find_DIC(string data)
        {
            //Console.WriteLine(Area[data]);
            if (Area.ContainsKey(data) == true)
            {
                return Area[data];
            }
            else
            {
                return "Not Found";
            }

        }



        public void CreateDictionary()
        {
            Area.Add("T100-011", "172.19.100.5");
            Area.Add("T100-021", "172.19.100.9");
            Area.Add("T100-031", "172.19.100.13");
            Area.Add("T100-041", "172.19.100.17");
            Area.Add("T100-061", "172.19.100.25");
            Area.Add("T100-071", "172.19.100.29");
            Area.Add("T103-001", "172.19.103.1");
            Area.Add("T103-011", "172.19.103.5");
            Area.Add("T103-021", "172.19.103.9");
            Area.Add("T103-031", "172.19.103.13");
            Area.Add("T103-041", "172.19.103.17");
            Area.Add("T103-051", "172.19.103.21");
            Area.Add("T104-001", "172.19.104.1");
            Area.Add("T104-011", "172.19.114.49)");
            Area.Add("T104-031", "172.19.104.13");
            Area.Add("T104-041", "172.19.104.17");
            Area.Add("T104-051", "172.19.104.21");
            Area.Add("T104-061", "172.19.114.53");
            Area.Add("T104-071", "172.19.104.29");
            Area.Add("T104-081", "172.19.104.33");
            Area.Add("T105-001", "172.19.105.1");
            Area.Add("T105-011", "172.19.105.5");
            Area.Add("T105-021", "172.19.105.9");
            Area.Add("T105-031", "172.19.105.13");
            Area.Add("T105-041", "172.19.105.17");
            Area.Add("T105-051", "172.19.105.21");
            Area.Add("T105-061", "172.19.105.25");
            Area.Add("T105-071", "172.19.105.29");
            Area.Add("T105-081", "172.19.105.33");
            Area.Add("T106-001", "172.19.106.1");
            Area.Add("T106-011", "172.19.106.5");
            Area.Add("T106-021", "172.19.106.9");
            Area.Add("T106-031", "172.19.106.13");
            Area.Add("T106-041", "172.19.106.17");
            Area.Add("T106-051", "172.19.106.21");
            Area.Add("T106-061", "172.19.106.25");
            Area.Add("T106-071", "172.19.106.29");
            Area.Add("T106-081", "172.19.106.33");
            Area.Add("T106-101", "172.19.106.41");
            Area.Add("T106-121", "172.19.106.49");
            Area.Add("T108-011", "172.19.108.5");
            Area.Add("T108-021", "172.19.108.9");
            Area.Add("T108-031", "172.19.108.13");
            Area.Add("T108-041", "172.19.108.17");
            Area.Add("T108-051", "172.19.108.21");
            Area.Add("T108-061", "172.19.108.25");
            Area.Add("T110-001", "172.19.110.1");
            Area.Add("T110-021", "172.19.110.9");
            Area.Add("T110-031", "172.19.110.13");
            Area.Add("T110-041", "172.19.110.17");
            Area.Add("T110-051", "172.19.110.21");
            Area.Add("T110-061", "172.19.110.25");
            Area.Add("T110-081", "172.19.110.33");
            Area.Add("T110-091", "172.19.110.37");
            Area.Add("T110-101", "172.19.110.41");
            Area.Add("T111-001", "172.19.111.1");
            Area.Add("T111-011", "172.19.111.5");
            Area.Add("T111-021", "172.19.111.9");
            Area.Add("T111-031", "172.19.111.13");
            Area.Add("T111-041", "172.19.111.17");
            Area.Add("T111-061", "172.19.111.25");
            Area.Add("T111-071", "172.19.111.29");
            Area.Add("T111-081", "172.19.111.33");
            Area.Add("T111-091", "172.19.111.37");
            Area.Add("T111-101", "172.19.111.41");
            Area.Add("T111-111", "172.19.111.45");
            Area.Add("T112-001", "172.19.112.1");
            Area.Add("T112-011", "172.19.112.5");
            Area.Add("T112-031", "172.19.112.13");
            Area.Add("T112-041", "172.19.112.17");
            Area.Add("T112-051", "172.19.112.21");
            Area.Add("T112-061", "172.19.112.25");
            Area.Add("T112-071", "172.19.112.29");
            Area.Add("T112-081", "172.19.112.33");
            Area.Add("T114-001", "172.19.114.1");
            Area.Add("T114-002", "172.19.114.2");
            Area.Add("T114-004", "172.19.114.4");
            Area.Add("T114-011", "172.19.114.5");
            Area.Add("T114-021", "172.19.114.9");
            Area.Add("T114-031", "172.19.114.13");
            Area.Add("T114-041", "172.19.114.17");
            Area.Add("T114-051", "172.19.114.21");
            Area.Add("T114-061", "172.19.114.25");
            Area.Add("T114-071", "172.19.114.29");
            Area.Add("T114-081", "172.19.114.33");
            Area.Add("T114-091", "172.19.114.37");
            Area.Add("T114-101", "172.19.114.41");
            Area.Add("T115-011", "172.19.115.5");
            Area.Add("T115-021", "172.19.115.9");
            Area.Add("T115-031", "172.19.115.13");
            Area.Add("T115-041", "172.19.115.17");
            Area.Add("T115-051", "172.19.115.21");
            Area.Add("T115-061", "172.19.115.25");
            Area.Add("T116-011", "172.19.116.5");
            Area.Add("T116-021", "172.19.116.9");
            Area.Add("T116-031", "172.19.116.13");
            Area.Add("T116-041", "172.19.116.17");
            Area.Add("T116-051", "172.19.116.21");
            Area.Add("T116-061", "172.19.116.25");
            Area.Add("T116-071", "172.19.116.29");
            Area.Add("T116-081", "172.19.116.33");
            Area.Add("T116-091", "172.19.116.37");
            Area.Add("T116-101", "172.19.116.41");

        }

    }
}