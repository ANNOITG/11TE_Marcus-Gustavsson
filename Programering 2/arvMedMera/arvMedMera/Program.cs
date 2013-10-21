using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arvMedMera
{
    class Program
    {
        static void Main(string[] args)
        {
            Lärare l = new Lärare();
            l.setLön(23000);
            

            Lärare l2 = new Lärare();
            l2.setLön(32000);            

            Console.WriteLine(l.getLön());
            Console.WriteLine(l2.getLön());
            
            l.höjLön(123);

            Console.WriteLine(l.getLön());
            Console.WriteLine(l2.getLön());

            Elev e = new Elev();
            Console.WriteLine("\n\n\n" + e.getBetyg());

            e.fåBetygAvLärare("A");//, "Matematik");

            Console.WriteLine("\n\n\n" + e.getBetyg());  
            

            Console.ReadKey();
        }
    }

    class Person
    {
        private string namn;
        private string pNr;
        private string telNr;
        private string adress;

        public string getNamn() { return namn; }
        public void setNamn(string namn) 
        { 
            this.namn = namn; 
        }

        public string getPNr() { return pNr; }
        public void setPNr(string personnummer) 
        { 
            this.pNr = personnummer; 
        }

        public string getTelNr() { return telNr; }
        public void setTelNr(string telefonnummer) 
        { 
            this.telNr = telefonnummer; 
        }

        public string getAdress() { return adress; }
        public void setAdress(string adress) 
        { 
            this.adress = adress; 
        }
    }

    class Lärare : Person
    {
        private int lön;

        public int getLön() { return lön; }
        public void setLön(int lön)
        {
            this.lön = lön;
        }

        public void höjLön(int lönändring)
        {
            lön = lön + lönändring;
        }
    }    

    class Elev : Person
    {
        private string klass;
        private string betyg = "0";

        public string getKlass() { return klass; }
        public void setKlass(string klass)
        {
            this.klass = klass;
        }

        public string getBetyg() { return betyg; }
        public void setBetyg(string betyg)
        {
            this.betyg = betyg;
        }

        public void fåBetygAvLärare(string angivetBetyg)
        {
            this.betyg = angivetBetyg;
        }
    }

    class Kurser
    {
        public List<Elev> elevLista = new List<Elev>();
        public Lärare läraren;
        
        public Kurser(Elev elev, Lärare lärare)
        {
            this.elevLista.Add(elev);
            this.läraren = lärare;
        }
    }

}
