using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPDataPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args?.Length != 2)
            {
                Console.WriteLine("Please provide input and output file path.");
                return;
            }
            string ipath = args[0];
            string opath = args[1];
            using (FileStream fs = File.Open(ipath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                StringBuilder sb = new StringBuilder();
                OpenNLPCleaner cleaner = new OpenNLPCleaner();
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //first do code cleanup...remove 
                    string cleantxt = cleaner.Clean(line);
                    sb.AppendLine(cleantxt);
                    i++;
                    if (i == 500)
                    {
                        //write to outputfile..
                        WritetoFile(opath, sb.ToString());
                        sb.Clear();
                        i = 0;
                    }
                }
            }
        }

        private static void WritetoFile(string opath, string v)
        {
            StreamWriter file2 = new StreamWriter(opath, true);
            file2.WriteLine(v);
            file2.Close();
        }
    }
}