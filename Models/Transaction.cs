using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BudgetSimulator.Models
{
    public enum OperationType
    {
        Revenu,
        Depense
    }

    public class Transaction : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private DateTime date = DateTime.Now;
        public DateTime Date
        {
            get => date;
            set { date = value; OnPropertyChanged(); }
        }

        private string description = "";
        public string Description
        {
            get => description;
            set { description = value; OnPropertyChanged(); }
        }

        private string categorie = "";
        public string Categorie
        {
            get => categorie;
            set { categorie = value; OnPropertyChanged(); }
        }

        private decimal montant;
        public decimal Montant
        {
            get => montant;
            set { montant = value; OnPropertyChanged(); }
        }

        private OperationType type;
        public OperationType Type
        {
            get => type;
            set { type = value; OnPropertyChanged(); }
        }
    }

}

