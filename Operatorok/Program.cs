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
                            if (muvelet.Szam2 == 0) return "Egyéb hiba!";
                            return (muvelet.Szam1 / muvelet.Szam2).ToString();
                            break;
                        case "/":
                            if (muvelet.Szam2 == 0) return "Egyéb hiba!";
                            return (Convert.ToDouble(muvelet.Szam1) / muvelet.Szam2).ToString();
                            break;
                        case "mod":
                            if (muvelet.Szam2 == 0) return "Egyéb hiba!";
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

                    return "Egyéb hiba!";
                }
                catch (FormatException)
                {

                    return "Egyéb hiba!";
                }

            }

            //7.
            string muvelet = "";
            while (muvelet.ToLower() != "vége")
            {
                Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                muvelet = Console.ReadLine();
                if (muvelet.ToLower() == "vége") break;
                Operator temp = new Operator(int.Parse(muvelet.Split(' ')[0]), muvelet.Split(' ')[1], int.Parse(muvelet.Split(' ')[2]));
                Console.WriteLine($"\t{muvelet} = {Eval(temp)}");
            }

            //8.
            StreamWriter sw = new StreamWriter("eredmenyek.txt");
            lista.ForEach(x => sw.WriteLine($"{x.Szam1} {x.Oper} {x.Szam2} = {Eval(x)}"));

            Console.WriteLine("8. feladat: eredmenyek.txt");

        }
    }
}