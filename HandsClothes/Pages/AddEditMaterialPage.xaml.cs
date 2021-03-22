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
        private VW_MaterialDetails2 MaterialItem;
        private NavigationService Nav;

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
            MaterialItem = material;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Nav = NavigationService.GetNavigationService(this);

            HeaderTXTB.Text    = (PageMode == 1 ? "Добавление" : "Изменение") + HeaderTXTB.Text;
            Accept_BTN.Content = (PageMode == 1 ? "Добавить материал" : "Применить изменения") + HeaderTXTB.Text;

            MaterialTypeCMB.ItemsSource = DataFrame.Context.Unit.Select(i => i.UnitName).ToList();
        }

        private void FieldsFill()
        {
            if (PageMode == 2)
            {
                MaterialNameTXT.Text = MaterialItem.MaterialName;
                MaterialTypeCMB.SelectedItem = MaterialItem.UnitName;
                QTYInStockTXT.Text = MaterialItem.QtyInStock.ToString();
                UnitNameTXT.Text = MaterialItem.UnitName;
                InPackAmountTXT.Text = MaterialItem.InPackAmount.ToString();
                MinimalAmountTXT.Text = MaterialItem.MinimalAmount.ToString();
                PriceTXT.Text = MaterialItem.Price.ToString();
                DescriptionTXT.Text = MaterialItem.Description;
            }
            else
            {
                MaterialNameTXT.Text = "";
                MaterialTypeCMB.SelectedItem = null;
                QTYInStockTXT.Text = "";
                UnitNameTXT.Text = "";
                InPackAmountTXT.Text = "";
                MinimalAmountTXT.Text = "";
                PriceTXT.Text = "";
                DescriptionTXT.Text = "";
            }
        }

        private void Decline_BTN_Click(object sender, RoutedEventArgs e)
        {
            Nav.GoBack();
        }

        private void Refill_BTN_Click(object sender, RoutedEventArgs e)
        {
            FieldsFill();
        }

        private void Accept_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (PageMode == 2)
            {
                Material pickedMaterial = DataFrame.Context.Material.Find(MaterialItem.Id);

                pickedMaterial.MaterialName = MaterialNameTXT.Text;
                pickedMaterial.MaterialTypeId = DataFrame.Context.MaterialType.Where(j => j.Type.Equals(MaterialTypeCMB.SelectedItem)).Select(i => i.Id).FirstOrDefault(); 
                pickedMaterial.QtyInStock = int.Parse(QTYInStockTXT.Text.Trim());
                pickedMaterial.UnitId = DataFrame.Context.Unit.Where(j => j.UnitName.Equals(UnitNameTXT.Text)).Select(i => i.Id).FirstOrDefault();
                pickedMaterial.InPackAmount = int.Parse(InPackAmountTXT.Text.Trim());
                pickedMaterial.MinimalAmount = int.Parse(MinimalAmountTXT.Text.Trim());
                pickedMaterial.Price = decimal.Parse(PriceTXT.Text.Trim());
                pickedMaterial.Description = DescriptionTXT.Text;
            }
            else
            {
                MaterialNameTXT.Text = "";
                MaterialTypeCMB.SelectedItem = null;
                QTYInStockTXT.Text = "";
                UnitNameTXT.Text = "";
                InPackAmountTXT.Text = "";
                MinimalAmountTXT.Text = "";
                PriceTXT.Text = "";
                DescriptionTXT.Text = "";
            }

            DataFrame.Context.SaveChanges();
            Nav.GoBack();
        }
    }
}
