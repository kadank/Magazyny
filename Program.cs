using System;

namespace Magazyny
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] dane = System.IO.File.ReadAllLines("dane.txt");     //<----------- tu ścieżkę do danych
            string mariusz = System.IO.File.ReadAllText("dane.txt");


            // 1.Wypisz na ekranie zawartość pliku dane.txt numerując każdy wiersz i zamieniając średniki na spacje.
            Console.WriteLine("Zadanie 1");

            int numer = 1;
            foreach (string line in dane)
            {

                Console.WriteLine(numer +". "+ line.Replace(";", " "));
                numer++;
            }



            // 2.Wyznacz liczbę wolnych magazynów oraz ich dane (id. magazynu, powierzchnia).
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Zadanie 2");

            int ilosc = 0;
            foreach (string line in dane)
            {
                if (line.Contains("#") == true)
                {
                    ilosc ++;
                    Console.WriteLine(line.Replace(";", " ").Replace("#",null));
                }
            }
            Console.WriteLine("Ilość pustych magazynów:" + ilosc);



            //3.Wyznacz całkowitą powierzchnię magazynową w m2.
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Zadanie 3");

            string[] separatory = new string[] { ";", " ", "\r", "\n" };
            string[] dis = mariusz.Split(separatory, StringSplitOptions.RemoveEmptyEntries);
            int i = 2;
            double suma = 0;
            foreach (var marek in dis)
            {
                if (i%3 == 0)
                {
                    suma = suma + double.Parse(marek);
                }
                i++;
            }
            Console.WriteLine(suma + "m2");



            //4.Wyznacz Wolną powierzchnię magazynową w m2
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Zadanie 4");


            string[] arr = { };

            char[] tstart = { 'A', 'B', 'C', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            char[] tend = { '#'};

            foreach (string line in dane)
            {
                if (line.Contains("#") == true)
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = line.TrimStart(tstart).TrimEnd(tend).Replace(";", null);
                }
            }

            double pustem2 = 0;

            foreach (string line in arr)
            {
                pustem2 = pustem2 + double.Parse(line);
            }
            Console.WriteLine(pustem2 + "m2");





        }
    }
}
