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

namespace HandsClothes.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditMaterialPage.xaml
    /// </summary>
    public partial class AddEditMaterialPage : Page
    {
        private int PageMode; // 1 - Добавление, 2 - Изменение
        private VW_MaterialDetails2 Material;

        public AddEditMaterialPage()
        {
            InitializeComponent();
        }

        public AddEditMaterialPage(int pageMode)
        {
            PageMode = pageMode;
            InitializeComponent();
        }

        public AddEditMaterialPage(int pageMode, VW_MaterialDetails2 material)
        {
            PageMode = pageMode;
            Material = material;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            HeaderTXTB.Text = (PageMode == 1 ? "Добавление" : "Изменение") + HeaderTXTB.Text;
            
            if (PageMode == 1)
            {

            }
            else if(PageMode == 2)
            {
                MaterialNameTXT.Text = Material.MaterialName;
                MaterialTypeTXT.Text = Material.Type;
                QTYInStockTXT.Text = Material.QtyInStock.ToString();
                UnitNameTXT.Text = Material.UnitName;
                InPackAmountTXT.Text = Material.InPackAmount.ToString();
                MinimalAmountTXT.Text = Material.MinimalAmount.ToString();
                PriceTXT.Text = Material.Price.ToString();
                DescriptionTXT.Text = Material.Description;
            }
        }
    }
}
