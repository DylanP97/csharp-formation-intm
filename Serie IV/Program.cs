﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Exercice I - Code Morse
            Console.WriteLine("-----------------------");
            Console.WriteLine("Exercice I - Code Morse");
            Console.WriteLine("-----------------------");

            Morse m = new Morse();
            Console.WriteLine("Traduction Morse :");
            // Codes en morse
            string morse = "===.=.===.=...===.===.===...===.=.=...=.....===.===...===.===.===...=.===.=...=.=.=...=";
            string ilFaitBeau = "=.=...=.===.=.=.....=.=.===.=...=.===...=.=...===.....===.=.=.=...=...=.===...=.=.===";
            string error = "=...=.===.=...==...===.===.===...=.===.=";
            string imperfectMorse = "===..=..===..=....===.===.===...===.=.=...=.....";
            string sentence = "CODE MORSE";

            //Console.WriteLine($"{morse} : {m.MorseTranslation(morse)}");
            Console.WriteLine($"{morse} : {m.MorseTranslation(morse)}");
            Console.WriteLine(error + " : " + m.MorseTranslation(error));
            // Codes imparfaits en morse
            Console.WriteLine($"{morse} : {m.EfficientMorseTranslation(morse)}");
            Console.WriteLine($"{imperfectMorse} : {m.EfficientMorseTranslation(imperfectMorse)}");
            // Encodage en morse
            Console.WriteLine($"{sentence} : {m.MorseEncryption(sentence)}");
            #endregion

            Console.WriteLine();

            #region Exercice II - Contrôle des parenthèses
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Exercice II - Contrôle des parenthèses");
            Console.WriteLine("--------------------------------------");

            string brackets = "()";
            Console.WriteLine($"{brackets} : {(BracketsControl.BracketsControls(brackets) ? "OK" : "KO")}");
            brackets = "(]";
            Console.WriteLine($"{brackets} : {(BracketsControl.BracketsControls(brackets) ? "OK" : "KO")}");
            brackets = "{[]()}";
            Console.WriteLine($"{brackets} : {(BracketsControl.BracketsControls(brackets) ? "OK" : "KO")}");
            brackets = "{([]){((([])))}}";
            Console.WriteLine($"{brackets} : {(BracketsControl.BracketsControls(brackets) ? "OK" : "KO")}");
            brackets = "{Azerty[uiop]qsdfg(hkl<m(wxcvb)n&é\"'(-è_çà)=}";
            Console.WriteLine($"{brackets} : {(BracketsControl.BracketsControls(brackets) ? "OK" : "KO")}");
            #endregion

            Console.WriteLine();

            #region Exercice III - Liste des contacts téléphoniques
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Exercice III - Liste des contacts téléphoniques");
            Console.WriteLine("-----------------------------------------------");

            int numbers = 640081205;
            string[] names = new string[] { "aaron", "abby", "abdul", "abe", "abel", "abigail",
                "abraham", "adam", "adan", "adele", "adolfo", "adolph", "adrian" };

            PhoneBook pb = new PhoneBook();
            for (int i = 0; i < names.Length; i++)
            {
                pb.AddPhoneNumber("0" + numbers.ToString(), names[i]);
                numbers++;
            }
            pb.PhoneContact("0640081205");
            pb.DeletePhoneNumber("0640081205");
            pb.DisplayPhoneBook();
            #endregion

            Console.WriteLine();

            #region Exercice IV - Emploi du temps professionnel
            //Console.WriteLine("-------------------------------------------");
            //Console.WriteLine("Exercice IV - Emploi du temps professionnel");
            //Console.WriteLine("-------------------------------------------");

            //BusinessSchedule bs = new BusinessSchedule();
            //bs.SetRangeOfDates(new DateTime(2021, 4, 1), new DateTime(2021, 4, 30));
            //bs.AddBusinessMeeting(new DateTime(2021, 4, 21, 14, 0, 0), new TimeSpan(1, 0, 0));
            //bs.AddBusinessMeeting(new DateTime(2021, 4, 21, 15, 0, 0), new TimeSpan(1, 0, 0));
            //bs.AddBusinessMeeting(new DateTime(2021, 4, 21, 14, 30, 0), new TimeSpan(1, 0, 0));
            //bs.DisplayMeetings();
            #endregion

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
