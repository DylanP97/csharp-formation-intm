﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            #region Exercice I - Opérations élémentaires
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Exercice I - Opérations élémentaires");
            Console.WriteLine("------------------------------------");

            Console.WriteLine();

            //Opérations de base
            ElementaryOperations.BasicOperation(3, 4, '+');
            ElementaryOperations.BasicOperation(6, 2, '/');
            ElementaryOperations.BasicOperation(3, 0, '/');
            ElementaryOperations.BasicOperation(6, 9, 'L');

            // Add a blank line after the operation result
            Console.WriteLine();

            //Division entière
            ElementaryOperations.IntegerDivision(12, 4);
            ElementaryOperations.IntegerDivision(13, 4);
            ElementaryOperations.IntegerDivision(12, 0);

            Console.WriteLine();

            //Puissance entière
            ElementaryOperations.Pow(3, 4);
            ElementaryOperations.Pow(2, 0);
            ElementaryOperations.Pow(6, -2);

            Console.WriteLine();

            #endregion

            #region Exercice II - Horloge parlante
            Console.WriteLine("------------------------------");
            Console.WriteLine("Exercice II - Horloge parlante");
            Console.WriteLine("------------------------------");

            Console.WriteLine();
            Console.WriteLine(SpeakingClock.GoodDay(DateTime.Now.Hour));
            Console.WriteLine();
            #endregion

            #region Exercice III - Construction d'une pyramide
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Exercice III - Construction d'une pyramide");
            Console.WriteLine("------------------------------------------");

            Console.WriteLine();

            Pyramid.PyramidConstruction(10, true);
            Pyramid.PyramidConstruction(10, false);
            Pyramid.PyramidConstruction(0, true);

            Console.WriteLine();
            #endregion

            #region Exercice IV - Factorielle
            Console.WriteLine("-------------------------");
            Console.WriteLine("Exercice IV - Factorielle");
            Console.WriteLine("-------------------------");

            Console.WriteLine();

            int number;
            do
            {
                Console.WriteLine("Saisir un nombre");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out number));

            Console.WriteLine($"Factorielle de {number} : {Factorial.Factorial_(number)}");
            Console.WriteLine($"Factorielle de {number} : {Factorial.FactorialRecursive(number)} [R]");

            Console.WriteLine();

            #endregion

            #region Exercice V - Les nombres premiers
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Exercice V - Les nombres premiers");
            Console.WriteLine("---------------------------------");

            Console.WriteLine();

            PrimeNumbers.DisplayPrimes();

            Console.WriteLine();

            #endregion

            #region Exercice VI - Algorithme d'Euclide
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Exercice VI - Algorithme d'Euclide");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------------------------------");

            int a, b;
            do
            {
                Console.WriteLine("Saisir le premier nombre :");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out a));
            do
            {
                Console.WriteLine("Saisir le second nombre :");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out b));

            Console.WriteLine($"PGCD de {a} et {b} : {Euclide.Pgcd(a, b)}");
            Console.WriteLine($"PGCD de {a} et {b} : {Euclide.PgcdRecursive(a, b)} [R]");
            #endregion

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
