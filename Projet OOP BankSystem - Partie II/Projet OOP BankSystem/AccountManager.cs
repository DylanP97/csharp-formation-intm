﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_OOP_BankSystem
{
    class AccountManager
    {
        public int AccManagerId { get; set; }
        public string ClientType { get; set; }
        public int TransactionsCount { get; set; }
        public decimal ManagementFees { get; set; }
        public List<BankAccount> AffiliatedBankAccounts { get; set; }

        // Constructor
        public AccountManager(int accId, string cType, int trCount)
        {
            AccManagerId = accId;
            ClientType = cType;
            TransactionsCount = trCount;
            ManagementFees = CalculateManagementFees(cType);
            AffiliatedBankAccounts = new List<BankAccount>();
        }

        public decimal CalculateManagementFees(string clientType)
        {
            if (clientType == "Entreprise") return 10.00M;
            else if (clientType == "Particulier") return 0.01M; // calculate as a % 
            else return 0.00M;
        }

        public BankAccount CreateBankAccount(int bankAccNbr, decimal initialBalance)
        {
            BankAccount accExisting = AffiliatedBankAccounts.Find(acc => acc.AccountNumber == bankAccNbr);
            if (accExisting == null)
            {
                BankAccount newAcc = new BankAccount(bankAccNbr, initialBalance, 1000);
                AffiliatedBankAccounts.Add(newAcc);
                return newAcc;
            }
            else
            {
                Console.WriteLine($"Le compte bancaire n°{bankAccNbr} existe déjà chez le gestionnaire {AccManagerId}! Création de compte bancaire avortée");
                return null;
            }
        }

        public bool TerminateBankAccount(int bankAccNbr)
        {
            bool exist = AffiliatedBankAccounts.Any(acc => acc.AccountNumber == bankAccNbr);

            if (exist)
            {
                BankAccount accToDelete = AffiliatedBankAccounts.Find(acc => acc.AccountNumber == bankAccNbr);
                AffiliatedBankAccounts.Remove(accToDelete);
                Console.WriteLine($"Le compte bancaire n°{bankAccNbr} a été supprimé avec succès.");
                return true;
            }
            else
            {
                Console.WriteLine($"Le compte bancaire n°{bankAccNbr} n'appartient pas au gestionnaire de compte n°{AccManagerId}.");
                return false;
            }
        }

        public bool InitiateTransferBankAccountOwnershipRequest(AccountManager targetNewOwner, int targetBankAccNbr)
        {
            List<BankAccount> newOwnerBankAccounts = targetNewOwner.AffiliatedBankAccounts;
            newOwnerBankAccounts.Any(acc => acc.AccountNumber == targetBankAccNbr);
            BankAccount targetedBankAcc = newOwnerBankAccounts.Find(acc => acc.AccountNumber == targetBankAccNbr);
            if (targetedBankAcc != null)
            {
                targetNewOwner.ApproveTransferBankAccountOwnershipRequest(targetedBankAcc);
                return true;
            }
            else
            {
                Console.WriteLine($"Le gestionnaire n°{targetNewOwner.AccManagerId} n'est pas propriétaire du compte bancaire n°{targetBankAccNbr}. Changement de gestionnaire avorté.");
                return false;
            }
        }

        public void ApproveTransferBankAccountOwnershipRequest(BankAccount targetedBankAcc)
        {
            targetedBankAcc.AccountNumber = AccManagerId;
            Console.WriteLine($"Transfert de gestionnaire effectué! Le gestionnaire {AccManagerId} est le nouveau propriétaire du compte n°{targetedBankAcc.AccountNumber}");
        }
    }

}
