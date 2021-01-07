using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210107_2
{
    class Jarmu
    {
        public string RendSzam { get; set; } = null;
        private bool _engedely = false;
        protected bool Engedely
        {
            get
            {
                return _engedely;
            }
            private set
            {
                if (value && RendSzam is null) throw new Exception("rsz nélküli autót nem lehetr engedelyeztetni");
                _engedely = value;
            }
        }
        public void ForgalombaHelyez()
        {
            Engedely = true;
            Console.WriteLine($"A {RendSzam} rendszámú járműt sikeresen forgalomba helyeztük!");
        }
    }

    class Szemelygepjarmu : Jarmu
    {
        public int MotorMeret { get; set; }

        public void getEngedely()
        {
            Console.WriteLine((Engedely ? "van" : "nincs") + " engedélye");
        }

    }
    class ViziJarmu : Jarmu
    {
        public int Vizkiszoritas { get; set; }
    }

    class Szemelygepkocsi : Szemelygepjarmu
    {
        public int AjtokSzama { get; set; }
    }

    class Teherauto: Szemelygepjarmu
    {
        public int RakterMeret { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var auto = new Szemelygepjarmu()
            {
                RendSzam = "ABC-123",
                MotorMeret = 1200,
            };

            var hajo = new ViziJarmu()
            {
                RendSzam = "HAJ-321",
                Vizkiszoritas = 3200,
            };

            var motor = new Jarmu()
            {
                RendSzam = "MOT-666",
            };

            var jarmuvek = new List<Jarmu>()
            {
                auto, hajo, motor
            };

            foreach (var j in jarmuvek)
            {
                j.ForgalombaHelyez();
                if (j is ViziJarmu) 
                    Console.WriteLine($"Ennek a hajónak a vízkiszorítása: {(j as ViziJarmu).Vizkiszoritas} m^3");
            }


            var gepkocsi = new Szemelygepkocsi();

            gepkocsi.getEngedely();

            //gepkocsi.ForgalombaHelyez();


            Console.WriteLine();

            gepkocsi.getEngedely();


            Jarmu k = new Szemelygepkocsi()
            {
                MotorMeret = 2000,
                AjtokSzama = 5,
                RendSzam = "XXX-111",
            };

            object o1 = 16;
            object o2 = "papucs";
            object o3 = k;

            Console.WriteLine(16.Equals(o2));

            Console.ReadKey();
        }
    }
}
