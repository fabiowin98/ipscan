using System;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.Collections.Generic;

namespace org.dgl.ipscan
{
    class Program
    {

        const int DEFAULT_TIMEOUT = 1000;

        static void Main(string[] args)
        {
            IPAddress[] addresses;
            String ip;
            String[] ipSections;
            Ping pinger;
            PingReply reply;
            Console.WriteLine("org.dgl.ipscan - v1.0.0.0 13 Jan 2015");
            Console.WriteLine("(c) 2015 fabiowin98 fabiowin98.blogspot.com");
            Console.WriteLine("Apache 2.0 license");
            Console.WriteLine("");
            Console.WriteLine("start scanning...");
            addresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            foreach (IPAddress a in addresses)
            {
                ip = a.ToString();
                if (ip.Length > 15) continue;
                ipSections = ip.Split('.');
                for (int i = 0; i < 256; i++)
                {
                    ip = ipSections[0] + "." + ipSections[1] + "." + ipSections[2] + "." + i;
                    pinger = new Ping();
                    reply = pinger.Send(ip, DEFAULT_TIMEOUT);
                    if (reply.Status == IPStatus.Success) Console.WriteLine(ip + " is reachable");
                }
            }
            Console.WriteLine("scan completed");
            Console.ReadKey();
        }

    }
}
