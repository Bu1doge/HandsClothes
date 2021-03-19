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
    public partial class ListOfMaterialsPage : Page
    {
        private int PageNumber = 0;
        private int NumberOfPages;

        public ListOfMaterialsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MaterialLV.ItemsSource = Filter();
        }

        private void ListViewRefresh()
        {
            MaterialLV.ItemsSource = Filter();
        }

        private List<VW_MaterialSuplier> Filter()
        {
            List<VW_MaterialSuplier> MaterialList = DataFrame.Context.VW_MaterialSuplier.ToList();

            NumberOfPages = MaterialList.Count / 15 + (MaterialList.Count % 15 > 0 ? 1 : 0);
            MaterialList  = MaterialList.OrderBy(i => i.MaterialName).Skip(PageNumber * 15).Take(15).ToList();

            return MaterialList;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            PageNumber -= PageNumber == 0 ? 0 : 1;
            ListViewRefresh();
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            PageNumber += PageNumber == NumberOfPages - 1 ? 0 : 1;
            ListViewRefresh();
        }

        private void PageNum_Click(object sender, RoutedEventArgs e)
        {
            Button root = (Button)sender;

            PageNumber = int.Parse(root.Content.ToString()) - 1;
            ListViewRefresh();
        }
    }
}
