using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace TurtleReplicator
{
    class Program
    {
        private static long diresize(string fp)
        {
            DirectoryInfo size = new DirectoryInfo(fp);
            return size.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
        }
        static void Main(string[] args)
        {
            //variables and other goodies
            string dire = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))+@"\container";
            int counter = 0; 
            long counter2 = 0;
            WebClient spider = new WebClient();
            //create the directory
            Directory.CreateDirectory(dire);
            while (Directory.Exists(dire))
            {
                counter2 = diresize(dire);
                spider.DownloadFile("https://p7.hiclipart.com/preview/111/174/442/turtle-emoji-android-oreo-turtle.jpg", dire+@"\turtle"+counter+".png");
                counter++;
                counter2 = counter2 / 1048576;
                Console.WriteLine("You have gifted the turtles "+counter2.ToString()+"MiB of storage");
            }
        }
    }
}
