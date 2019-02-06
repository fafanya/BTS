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
using BTS.Common;
using System.Windows.Forms;

namespace BTS.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RouteMark RootObject
        {
            get
            {
                return DataContext as RouteMark;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new RouteMark();
            Refresh();
        }

        private void Refresh(object selectedValue = null)
        {
            dgRouteSheet.ItemsSource = TrackingClient.Instance.LoadRouteSheetList();
            if (selectedValue != null)
            {
                dgRouteSheet.SelectedValue = selectedValue;
            }
        }

        private void RefreshRouteMarkList(object selectedValue = null)
        {
            RouteSheet rs = dgRouteSheet.SelectedItem as RouteSheet;
            if (rs != null)
            {
                dgRouteMark.ItemsSource = TrackingClient.Instance.LoadRouteMarkList(
                    new Dictionary<string, object>()
                    {
                        { RouteMark.BarcodeParm.Key, rs.Key }
                    }).OrderBy(x => x.Stamp);
                if(selectedValue != null)
                {
                    dgRouteMark.SelectedValue = selectedValue;
                }
            }
            else
            {
                dgRouteMark.ItemsSource = null;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            object selectedRouteSheet = RootObject.Barcode;
            object selectedRouteMark = TrackingClient.Instance.CreateRouteMark(RootObject);
            Refresh(selectedRouteSheet);
            RefreshRouteMarkList(selectedRouteMark);
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                FileName = "report",
                DefaultExt = ".xlsx",
                Filter = "Excel (.xlsx)|*.xlsx"
            };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TrackingClient.Instance.DownloadReport(dialog.FileName);
            }
        }

        private void DgRouteSheet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshRouteMarkList();
        }
    }
}
