﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_OOP_BankSystem
{
    class Program
    {
        static List<BankAccount> accountsList = new List<BankAccount>();
        static List<int> transactionIdList = new List<int>();

        static void Main(string[] args)
        {
            #region Files
            string acctPath = Directory.GetCurrentDirectory() + @"\Comptes_1.txt";
            string trxnPath = Directory.GetCurrentDirectory() + @"\Transactions_1.txt";
            string sttsPath = Directory.GetCurrentDirectory() + @"\Transactions_Status_1.csv";
            #endregion

            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Project OOP");
            Console.WriteLine("Banking System");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine();

            ReadAndDisplayCsvFile(acctPath);
            Console.WriteLine();
            ReadAndDisplayCsvFile(trxnPath);
            Console.WriteLine();
            ReadAndDisplayCsvFile(sttsPath);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            DisplayAccountsList();
            Console.WriteLine();
            Console.ReadLine();
        }

        static void ReadAndDisplayCsvFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] values = line.Split(';');
                            Console.WriteLine(line);

                            if (filePath.Contains("Comptes_1.txt")) InstanciateAccounts(values);
                            else if (filePath.Contains("Transactions_1.txt")) InstanciateTransactions(values);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("The CSV file does not exist.");
            }
        }

        static void InstanciateAccounts(string[] values)
        {
            int.TryParse(values[0], out int accountNumber);
            decimal.TryParse(values[1], out decimal balance); // if field is empty, the balance will go to 0
            bool accountNumberAlreadyExists = accountsList.Any(acc => acc.AccountNumber == accountNumber);

            if (accountNumberAlreadyExists)
            {
                Console.WriteLine("Le numéro de compte existe déjà.");
            }
            else
            {
                if (balance >= 0)
                {
                    string formattedBalance = balance.ToString("0.00");
                    BankAccount bankAccount = new BankAccount(accountNumber, decimal.Parse(formattedBalance), 1000);
                    if (bankAccount != null) accountsList.Add(bankAccount);
                }
                else
                {
                    Console.WriteLine("La balance du compte ne peut pas être négative.");
                }
            }

        }

        static void InstanciateTransactions(string[] values)
        {
            if (int.TryParse(values[0], out int transactionId) &&
                decimal.TryParse(values[1], out decimal amount) &&
                int.TryParse(values[2], out int senderAccountNumber) &&
                int.TryParse(values[3], out int recipientAccountNumber))
            {
                BankAccount senderAccount = FindAccountByNumber(senderAccountNumber);
                BankAccount recipientAccount = FindAccountByNumber(recipientAccountNumber);

                string status = "KO";

                bool idAlreadyExists = transactionIdList.Any(id => id == transactionId);

                if (senderAccountNumber == 0 && recipientAccountNumber == 0)
                {
                    Console.WriteLine("Double Zéro, erreur.");
                }
                else
                {
                    if (!idAlreadyExists && !(senderAccountNumber == 0 && recipientAccountNumber == 0))
                    {
                        if ((senderAccount != null || senderAccountNumber == 0) && (recipientAccount != null || recipientAccountNumber == 0))
                        {
                            if (amount > 0)
                            {
                                transactionIdList.Add(transactionId);
                                bool res;
                                if (recipientAccountNumber == 0)
                                {
                                    res = senderAccount.Withdraw(amount);
                                }
                                else if (senderAccountNumber == 0)
                                {
                                    res = recipientAccount.Deposit(amount);
                                }
                                else
                                {
                                    new Transaction(transactionId, amount, senderAccountNumber, recipientAccountNumber);
                                    res = senderAccount.Transfer(recipientAccount, amount);
                                }
                                if (res) status = "OK";
                            }
                            else
                            {
                                Console.WriteLine("Le montant de la transaction doit être un nombre positif");
                            }
                        }
                        else
                        {
                            if (senderAccount == null)
                            {
                                Console.WriteLine($"Compte expéditeur non-trouvé. Compte n°{senderAccountNumber}");
                            }
                            if (recipientAccount == null)
                            {
                                Console.WriteLine($"Compte destinataire non-trouvé. Compte n°{recipientAccountNumber}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Le transactionId {transactionId} a déjà été utilisé.");
                    }
                }
                string statusLine = $"{transactionId};{status}";
                File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Transactions_Status_1.csv"),
                    Environment.NewLine + statusLine);
            }
            else
            {
                Console.WriteLine("Invalid data format in CSV values for transactions.");
            }
        }

        static BankAccount FindAccountByNumber(int accountNumber)
        {
            return accountsList.Find(account => account.AccountNumber == accountNumber);
        }

        static void DisplayAccountsList()
        {
            Console.WriteLine("Accounts List after treatment:");
            foreach (var account in accountsList)
            {
                Console.WriteLine($"Account N°: {account.AccountNumber}, Balance: {account.GetBalance()}");
            }
        }
    }
}
