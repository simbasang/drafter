using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AlexisDraft
{
    static class Program
    {
        private static Random rng = new Random();

        static void Main(string[] args)
        {
            var turns = 0;
            var ppl = 0;

            while (true)
            {

                try
                {
                    Console.WriteLine("how many player?");
                    ppl = int.Parse(Console.ReadLine());
                    Console.WriteLine("how many turns?");
                    turns = int.Parse(Console.ReadLine());

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("not legit input only numbers");
                }

            }

            var filledTurns = new List<int[]>();
            var extra = turns % ppl;
            var timesToRun = extra > 0 ? (turns / ppl) + 1 : turns / ppl;
            var posiblePositions = new List<int>();
            var exlude = new List<int>();


            for (int i = 1; i < ppl + 1; i++)
            {
                posiblePositions.Add(i);

            }



            while (filledTurns.Any(x => x.Contains(0)) || !filledTurns.Any())
            {
                var counter = 1;
                for (int i = 1; i < turns + 1; i++)
                {

                    var turnSheat = new int[ppl];

                    for (int j = 0; j < ppl; j++)
                    {
                        turnSheat[j] = posiblePositions.Shuffle()
                            .FirstOrDefault(x => !turnSheat.Contains(x)
                                                 && filledTurns.Select(z => z[j]).Count(c => c == x) < counter);
                    }

                    if (i % ppl == 0)
                        counter++;

                    filledTurns.Add(turnSheat);
                }
                if (filledTurns.Any(x => x.Contains(0)))
                    filledTurns.Clear();

            }


            //ska exporteras till en csv fil 
            for (int i = 0; i < ppl; i++)
            {
                var t = filledTurns.Select(x => x[i]);
                var result = "";
                foreach (var positoin in t)
                {
                    result += $"{positoin}, ";

                }

                Console.WriteLine($"person: {i} ");
                Console.WriteLine($"Positions: {result}");
            }

        }


        public static List<T> Shuffle<T>(this List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}

