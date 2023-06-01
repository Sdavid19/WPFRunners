using Futoverseny.adatok;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Futoverseny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<VersenyzoModel> versenyzok = new ObservableCollection<VersenyzoModel>();
        FutoversenyContext context = new FutoversenyContext();


        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, e) =>
            {
                cboTavolsag.ItemsSource = context.Set<TavolsagModel>().ToList();
                cboTavolsag.DisplayMemberPath = "Megnevezes";
                cboTavolsag.SelectedValuePath = "Id";
            };
            dgList.ItemsSource = versenyzok;
        }

        private void FeltTorles_Click(object sender, RoutedEventArgs e)
        {
            versenyzok = new ObservableCollection<VersenyzoModel>();
            dgList.ItemsSource = versenyzok;
            txtNev.Text = "";
            cboTavolsag.SelectedIndex = -1;
        }

        private void Kereses_Click(object sender, RoutedEventArgs e)
        {
            versenyzok = new ObservableCollection<VersenyzoModel>
                (
                    context.Set<VersenyzoModel>().Include(v => v.Tavolsag).Where(v => v.Nev.Contains(txtNev.Text) && (cboTavolsag.SelectedValue == null || v.TavolsagId == (int)cboTavolsag.SelectedValue))
                );
            dgList.ItemsSource = versenyzok;
        }

        private void Uj_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new VersenyzoWindow(new VersenyzoModel());
            if (wnd.ShowDialog() == true)
            {
                versenyzok.Add(wnd.Versenyzo);
            }
        }

        private void Modositas_Click(object sender, RoutedEventArgs e)
        {
            if (dgList.SelectedItem != null)
            {
                var versenyzo = (VersenyzoModel)dgList.SelectedItem;
                var wnd = new VersenyzoWindow(versenyzo);
                if (wnd.ShowDialog() != true)
                {
                    context.Entry(versenyzo).State = EntityState.Unchanged;
                    dgList.Items.Refresh();
                }

            }
        }

        private void Torles_Click(object sender, RoutedEventArgs e)
        {

            if (dgList.SelectedItem != null)
            {
                var versenyzo = (VersenyzoModel)dgList.SelectedItem;
                if (MessageBox.Show("Biztos?", "Kérdés", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    context.Set<VersenyzoModel>().Remove(versenyzo);
                    context.SaveChanges();
                    versenyzok.Remove(versenyzo);
                }

            }
        }
    }
}
