using System;

namespace Operatorok
{
    class Program
    {
        static List<Operator> lista = new List<Operator>();
        static void Main(string[] args)
        {
            //1.
            StreamReader sr = new StreamReader("kifejezesek.txt");
            while (!sr.EndOfStream)
            {
                var mezok = sr.ReadLine().Split(' ');

                lista.Add(new Operator(int.Parse(mezok[0]), mezok[1], int.Parse(mezok[2])));

            }
            sr.Close();

            //2.
            Console.WriteLine($"2. feladat: Kifejezések száma: {lista.Count()}");

            //3.
            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {lista.Where(x => x.Oper == "mod").Count()}");

            //4.
            Console.WriteLine("4. feladat: " + (lista.Any(x => x.Szam1 % 10 == 0 && x.Szam2 % 10 == 0) ? "Van ilyen kifejezés!" : "Nincs ilyen kifejezés!"));

            //5.
            Console.WriteLine("5. feladat: Statisztika");

            lista.Where(x => new string[6] { "mod", "/", "div", "-", "*", "+" }.Contains(x.Oper)).GroupBy(x => x.Oper).ToList().ForEach(x => Console.WriteLine($"\t{x.Key} -> {x.Count()} db"));

            //6.
            string Eval(Operator muvelet)
            {
                try
                {
                    switch (muvelet.Oper)
                    {
                        case "div":
                            return (muvelet.Szam1 / muvelet.Szam2).ToString();
                            break;
                        case "/":
                            return (Convert.ToDouble(muvelet.Szam1) / muvelet.Szam2).ToString();
                            break;
                        case "mod":
                            return (muvelet.Szam1 % muvelet.Szam2).ToString();
                            break;
                        case "-":
                            return (muvelet.Szam1 - muvelet.Szam2).ToString();
                            break;
                        case "*":
                            return (muvelet.Szam1 * muvelet.Szam2).ToString();
                            break;
                        case "+":
                            return (muvelet.Szam1 + muvelet.Szam2).ToString();
                            break;
                        default:
                            return "Hibás operátor!";
                    }

                }
                catch (ArithmeticException)
                {

                    return "Egyéb hiba";
                }
                catch (FormatException)
                {

                    return "Egyéb hiba";
                }
            }

        }
    }
}