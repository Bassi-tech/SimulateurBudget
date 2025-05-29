using BudgetSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BudgetSimulator.Models;
using System.IO;
using Microsoft.Win32;




namespace BudgetSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel vm;
        private Transaction transactionSelectionnee;


        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            vm = new MainViewModel();
            DataContext = vm;
            vm.Charger();
        }
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            vm.AjouterTransaction();
            vm.Sauvegarder(); // sauvegarde après ajout
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            transactionSelectionnee = dataGrid.SelectedItem as Transaction;
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (transactionSelectionnee != null)
            {
                vm.SupprimerTransaction(transactionSelectionnee);
                transactionSelectionnee = null;
            }
        }

        private void ExporterExcel_Click(object sender, RoutedEventArgs e)
        {
            var workbook = new ClosedXML.Excel.XLWorkbook();
            var feuille = workbook.Worksheets.Add("Transactions");
            feuille.Cell(1, 1).Value = "Date";
            feuille.Cell(1, 2).Value = "Description";
            feuille.Cell(1, 3).Value = "Catégorie";
            feuille.Cell(1, 4).Value = "Montant";
            feuille.Cell(1, 5).Value = "Type";

            int row = 2;
            foreach (var t in vm.Transactions)
            {
                feuille.Cell(row, 1).Value = t.Date.ToString("dd/MM/yyyy");
                feuille.Cell(row, 2).Value = t.Description;
                feuille.Cell(row, 3).Value = t.Categorie;
                feuille.Cell(row, 4).Value = t.Montant;
                feuille.Cell(row, 5).Value = t.Type.ToString();
                row++;
            }
            feuille.Cell(row + 1, 1).Value = "Solde :";
            feuille.Cell(row + 1, 4).Value = vm.Solde;
            feuille.Cell(row + 1, 4).Style.Font.Bold = true;
            feuille.Cell(row + 1, 4).Style.NumberFormat.Format = "#,##0.00 €";

            var dlg = new SaveFileDialog
            {
                FileName = "BudgetExport",
                DefaultExt = ".xlsx",
                Filter = "Fichier Excel (*.xlsx)|*.xlsx"
            };

            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string chemin = dlg.FileName;
                feuille.Columns().AdjustToContents();
                workbook.SaveAs(chemin);
                MessageBox.Show($"Exporté avec succès :\n{chemin}",
                                "Export terminé",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            vm.ModifierTransaction();
        }






    }
}
