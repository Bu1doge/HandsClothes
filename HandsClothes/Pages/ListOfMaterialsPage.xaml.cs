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
using HandsClothes.EFData;
using HandsClothes.HelperClasses;

namespace HandsClothes.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListOfMaterialsPage.xaml
    /// </summary>
    public partial class ListOfMaterialsPage : Page
    {
        public ListOfMaterialsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MaterialLV.ItemsSource = Filter();

            //SearchTxt.Text = MaterialHelperClass.StringOfMeterialSupliers(2);
        }

        private List<Material> Filter()
        {
            List<Material> FilterResult = MaterialHelperClass.GetAllMaterias();



            return FilterResult;
        }
    }
}
