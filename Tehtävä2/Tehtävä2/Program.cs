using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tehtävä2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Piste> pistelista = new List<Piste>();
            Piste eka = new Piste();
            Piste toka = new Piste();
            pistelista.Add(eka);
            pistelista.Add(toka);

            KirjoitaTiedostoon(pistelista);

            string s = JsonConvert.SerializeObject(pistelista);
            Console.WriteLine(s);

            List<Piste> binääripistelista = new List<Piste>();
            LueBinääriTiedosto(binääripistelista);

            StreamWriter sw = new StreamWriter(@"C:\tmp\binääripisteet.txt");
            foreach (Piste item in binääripistelista)
            {
                sw.WriteLine(item.ToString());
            }
            sw.Close();

            string ss = JsonConvert.SerializeObject(binääripistelista);
            Console.WriteLine(ss);

            Console.ReadLine();


        }

        static void KirjoitaTiedostoon(List<Piste> pisteet)
        {
            StreamWriter sw = new StreamWriter(@"C:\tmp\pisteet.txt");
            foreach (Piste item in pisteet)
            {
                sw.WriteLine(item.ToString());
            }
            sw.Close();
        }

        static List<Piste> LueBinääriTiedosto(List<Piste> binääripistelista)
        {
            FileStream stream = new FileStream("C:\\tmp\\bindataTentti.bin",
                FileMode.Open);

            BinaryReader reader = new BinaryReader(stream);

            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            string nimi1 = reader.ReadString();
            double x1 = reader.ReadDouble();
            double y1 = reader.ReadDouble();

            Piste eka = new Piste(nimi1, x1, y1);
            binääripistelista.Add(eka);

            string nimi2 = reader.ReadString();
            double x2 = reader.ReadDouble();
            double y2 = reader.ReadDouble();

            Piste toka = new Piste(nimi2, x2, y2);
            binääripistelista.Add(toka);

            Console.WriteLine(nimi1);
            Console.WriteLine(x1);
            Console.WriteLine(y1);
            Console.WriteLine(nimi2);
            Console.WriteLine(x2);
            Console.WriteLine(y2);

            reader.Close();
            stream.Close();

            return binääripistelista;
            
        }
    }
}
