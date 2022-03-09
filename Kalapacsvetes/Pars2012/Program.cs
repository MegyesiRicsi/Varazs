using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
class Versenyző
{
    public string nev, csoport, nemzetkod, nemzet,kod,d33;
    public double d1, d2, d3, max;
    public List<double> ls = new List<double>();
    public Versenyző(string sor)
    {
        var s = sor.Split(';');
        nev = s[0];
        csoport = s[1];
        nemzetkod = s[2];
        d33=s[5];
        var xd = nemzetkod.Split('(');
        nemzet = xd[0];
        kod = xd[1].Trim(')');
        
        for (int i = 3; i <6; i++)
        {
            if (s[i]=="X")
            {
                s[i] = "-1,0";
            }
            else if (s[i]=="-")
            {
                s[i] = "-2,0";
            }
            
           
        }
        d1 = double.Parse(s[3]);
        d2 = double.Parse(s[4]);
        d3 = double.Parse(s[5]);
        for (int i = 3; i < 6; i++)
        {
            ls.Add(double.Parse( s[i]));
        }
        max = ls.Max();
    }
}
namespace Pars2012
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader("Selejtezo2012.txt");
            var lista = new List<Versenyző>();
            var elso = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                lista.Add(new Versenyző(sr.ReadLine()));
            }
            Console.WriteLine($"5. feladat: Versenyzők száma a selejtezőben: {lista.Count()} fő");
            var tovab = (from sor in lista where sor.d1 > 78 || sor.d2 > 78 select sor).Count();
            Console.WriteLine($"6. feladat: 78,00 méter feletti eredménnyel továbbjutott {tovab}");
            var maxi = (from sor in lista orderby sor.max select sor).Last();
            Console.WriteLine($"Név: {maxi.nev}");
            Console.WriteLine($"Csoport: {maxi.csoport}");
            Console.WriteLine($"Nemzet: {maxi.nemzet}");
            Console.WriteLine($"Nemzet kód: {maxi.kod}");
           
            Console.WriteLine($"Sorozat: {maxi.d1}; {maxi.d2};{maxi.d33}");
            Console.WriteLine($"Eredmény: {maxi.max}");
            Console.ReadKey();
        }
    }
}
