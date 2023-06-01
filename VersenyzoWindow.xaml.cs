using Futoverseny.adatok;
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
using System.Windows.Shapes;

namespace Futoverseny
{
    /// <summary>
    /// Interaction logic for VersenyzoWindow.xaml
    /// </summary>
    public partial class VersenyzoWindow : Window
    {
        FutoversenyContext context = new FutoversenyContext();

        public VersenyzoModel Versenyzo { get; private set; }

        public VersenyzoWindow(VersenyzoModel model)
        {
            InitializeComponent();

            Loaded += (sender, e) =>
            {
                cboTavolsag.ItemsSource = context.Set<TavolsagModel>().ToList();
                cboTavolsag.DisplayMemberPath = "Megnevezes";
                cboTavolsag.SelectedValuePath = "Id";
                DataContext = Versenyzo;
            };
            Versenyzo = model;
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            if (Kotelezomezok())
            {
                try
                {
                    if (Versenyzo.Id == 0)
                    {
                        context.Set<VersenyzoModel>().Add(Versenyzo);
                        context.SaveChanges();
                    }
                    else
                    {
                        context.Entry(Versenyzo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                    DialogResult = true;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba: {ex.Message}");
                }
            }
        }

        private bool Kotelezomezok()
        {
            if (Versenyzo.Rajtszam == 0 || Validation.GetHasError(txtRajtszam))
            {
                txtRajtszam.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(Versenyzo.Nev))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Versenyzo.Neme))
            {
                return false;
            }

            if (cboTavolsag.SelectedValue == null)
            {
                cboTavolsag.IsDropDownOpen = true;
                return false;
            }
            return true;
        }

        private void Megsem_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
