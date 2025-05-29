using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BudgetSimulator.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.IO;

namespace BudgetSimulator.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<Transaction> Transactions { get; set; }
        public string NouvelleDescription { get; set; } = "";
        public string NouvelleCategorie { get; set; } = "";
        public decimal NouveauMontant { get; set; }
        public OperationType NouveauType { get; set; } = OperationType.Depense;

        public DateTime NouvelleDate { get; set; } = DateTime.Now;


        private readonly string filePath = "transactions.json";

        private string filtreType = "Tous";
        public string FiltreType
        {
            get => filtreType;
            set
            {
                if (filtreType != value)
                {
                    filtreType = value;
                    OnPropertyChanged(nameof(FiltreType));
                    OnPropertyChanged(nameof(TransactionsFiltrees)); 
                }
            }
        }

        public ObservableCollection<string> Categories { get; }

        private string selectedCategory = "";
        public string SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (selectedCategory != value)
                {
                    selectedCategory = value;
                    OnPropertyChanged();
                }
            }
        }



        public IEnumerable<Transaction> TransactionsFiltrees =>
        FiltreType == "Tous"
        ? Transactions
        : Transactions.Where(t => t.Type.ToString() == FiltreType);

        private Transaction selectedTransaction;
        public Transaction SelectedTransaction
        {
            get => selectedTransaction;
            set
            {
                selectedTransaction = value;
                if (selectedTransaction != null)
                {
                    NouvelleDate = selectedTransaction.Date;
                    NouvelleDescription = selectedTransaction.Description;
                    NouvelleCategorie = selectedTransaction.Categorie;
                    NouveauMontant = selectedTransaction.Montant;
                    NouveauType = selectedTransaction.Type;

                    OnPropertyChanged(nameof(SelectedTransaction));
                    OnPropertyChanged(nameof(NouvelleDate));
                    OnPropertyChanged(nameof(NouvelleDescription));
                    OnPropertyChanged(nameof(NouvelleCategorie));
                    OnPropertyChanged(nameof(NouveauMontant));
                    OnPropertyChanged(nameof(NouveauType));
                }
            }
        }





        public MainViewModel()
        {
            Transactions = new ObservableCollection<Transaction>
            {
                new Transaction { Description = "Salaire", Categorie = "Revenus", Montant = 2500, Type = OperationType.Revenu },
                new Transaction { Description = "Loyer", Categorie = "Logement", Montant = 750, Type = OperationType.Depense }
            };

            Categories = new ObservableCollection<string>
            {
                "Salaire",
                "Prime / Bonus",
                "Investissements",
                "Loyer",
                "Assurance habitation",
                "Courses",
                "Restaurants",
                "Carburant",
                "Transports en commun",
                "Épargne",
                "Abonnements",
                "Loisirs",
                "Santé",
                "Dons"
            };
        }
        public void AjouterTransaction()
        {
            Transactions.Add(new Transaction
            {
                Description = NouvelleDescription,
                Categorie = SelectedCategory,
                Montant = NouveauMontant,
                Type = NouveauType,
                Date = NouvelleDate
            });

            
            OnPropertyChanged(nameof(Solde));

            NouvelleDescription = "";
            NouvelleCategorie = "";
            NouveauMontant = 0;
            NouveauType = OperationType.Revenu; 
            NouvelleDate = DateTime.Now;

            OnPropertyChanged(nameof(NouvelleDescription));
            OnPropertyChanged(nameof(NouvelleCategorie));
            OnPropertyChanged(nameof(NouveauMontant));
            OnPropertyChanged(nameof(NouveauType));
            OnPropertyChanged(nameof(NouvelleDate));

            
            if (!Categories.Contains(SelectedCategory) && !string.IsNullOrWhiteSpace(SelectedCategory))
            {
                Categories.Add(SelectedCategory);
            }

        }


        public decimal Solde =>
            Transactions
                .Where(t => t.Type == OperationType.Revenu).Sum(t => t.Montant)
            -
            Transactions
                .Where(t => t.Type == OperationType.Depense).Sum(t => t.Montant);


        public void Sauvegarder()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Transactions, options);
            File.WriteAllText(filePath, json);
        }

        public void Charger()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var liste = JsonSerializer.Deserialize<ObservableCollection<Transaction>>(json);
                if (liste != null)
                {
                    Transactions = liste;
                    OnPropertyChanged(nameof(Transactions));
                    OnPropertyChanged(nameof(Solde));
                }
            }
        }

        public void SupprimerTransaction(Transaction transaction)
        {
            if (transaction != null)
            {
                Transactions.Remove(transaction);
                Sauvegarder(); // on met à jour le fichier JSON
                OnPropertyChanged(nameof(Solde));
                OnPropertyChanged(nameof(TransactionsFiltrees));
            }
        }

        public void ModifierTransaction()
        {
            if (SelectedTransaction == null) return;


            SelectedTransaction.Date = NouvelleDate;
            SelectedTransaction.Description = NouvelleDescription;
            SelectedTransaction.Categorie = NouvelleCategorie;
            SelectedTransaction.Montant = NouveauMontant;
            SelectedTransaction.Type = NouveauType;

            OnPropertyChanged(nameof(Transactions));
            OnPropertyChanged(nameof(TransactionsFiltrees)); 
            OnPropertyChanged(nameof(Solde));
            Sauvegarder();
        }






    }
}
