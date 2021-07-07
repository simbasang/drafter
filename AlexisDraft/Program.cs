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
            var turns = 9;
            var ppl = 9;
            var filledTurns = new List<int[]>();

            var posiblePositions = new List<int>();
            var exlude = new List<int>();

            for (int i = 0; i < ppl; i++)
            {
                posiblePositions.Add(i);
            }

            for (int i = 1; i < turns + 1; i++)
            {
                var turnSheat = new int[ppl];
                for (int j = 0; j < ppl; j++)
                {
                    turnSheat[j] = posiblePositions.Shuffle().FirstOrDefault(x => !turnSheat.Contains(x));
                }


                filledTurns.Add(turnSheat);
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

