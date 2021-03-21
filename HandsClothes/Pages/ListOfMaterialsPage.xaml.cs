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
        private int PageNumber = 1;
        private int NumberOfPages;

        public ListOfMaterialsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> SortsList = new List<string>(){"Наименование убыв.",
                                                        "Наименование возр.",
                                                        "Остаток на складе убыв.",
                                                        "Остаток на складе возр.",
                                                        "Цена убыв.",
                                                        "Цена возр."};

            List<string> FilterList = new List<string>();
            FilterList.Add("Все типы");
            FilterList.AddRange(DataFrame.Context.MaterialType.Select(i => i.Type).ToList());

            SortCMB.ItemsSource = SortsList;
            SortCMB.SelectedItem = "Наименование возр.";
            FilterCMB.ItemsSource = FilterList;
            FilterCMB.SelectedItem = "Все типы";

            var x = FilterCMB.SelectedItem;
            var a = FilterCMB.SelectedIndex;
            var c = 1 + 1;

            MaterialLV.ItemsSource = Filter();
        }

        private void ListViewRefresh()
        {
            MaterialLV.ItemsSource = Filter();
        }

        private void SortCMB_SelectionChanged(object sender, EventArgs e)
        {
            PageNumber = 1;
            ListViewRefresh();
            PageNumContentUpdate();
        }

        private void FilterCMB_SelectionChanged(object sender, EventArgs e)
        {
            PageNumber = 1;
            ListViewRefresh();
            PageNumContentUpdate();
        }

        private List<VW_MaterialSuplier> Sort(List<VW_MaterialSuplier> List)
        {
            if (!(SortCMB.SelectedItem is null))
            {
                switch (SortCMB.SelectedItem.ToString())
                {
                    case "Наименование убыв.":
                        return List.OrderByDescending(i => i.MaterialName).ToList();
                    case "Наименование возр.":
                        return List.OrderBy(i => i.MaterialName).ToList();
                    case "Остаток на складе убыв.":
                        return List.OrderByDescending(i => i.QtyInStock).ToList();
                    case "Остаток на складе возр.":
                        return List.OrderBy(i => i.QtyInStock).ToList();
                    case "Цена убыв.":
                        return List.OrderByDescending(i => i.Price).ToList();
                    case "Цена возр.":
                        return List.OrderBy(i => i.Price).ToList();
                }
            }

            return List.OrderBy(i => i.MaterialName).ToList();
        }

        private List<VW_MaterialSuplier> TypeFilter(List<VW_MaterialSuplier> List)
        {
            if (FilterCMB.SelectedItem.ToString().Equals("Все типы"))
            {
                return List;
            }

            return List.Where(i => i.MaterialType.Equals(FilterCMB.SelectedItem.ToString())).ToList();
        }

        private List<VW_MaterialSuplier> Filter()
        {
            List<VW_MaterialSuplier> MaterialList = DataFrame.Context.VW_MaterialSuplier.ToList();

            //Фильтры 
            MaterialList = TypeFilter(MaterialList);

            //Сортировка
            MaterialList = Sort(MaterialList);

            //Выборка элементов для страниц
            NumberOfPages = MaterialList.Count / 15 + (MaterialList.Count % 15 > 0 ? 1 : 0);
            MaterialList = MaterialList.Skip((PageNumber - 1) * 15).Take(15).ToList();
    

            return MaterialList;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            PageNumber -= PageNumber == 1 ? 0 : 1;
            PageNumContentUpdate();
            ListViewRefresh();
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            PageNumber += PageNumber == NumberOfPages ? 0 : 1;
            PageNumContentUpdate();
            ListViewRefresh();
        }

        private void PageNum_Click(object sender, RoutedEventArgs e)
        {
            Button root = (Button)sender;

            PageNumber = int.Parse(root.Content.ToString());
            PageNumContentUpdate();
            ListViewRefresh();
        }

        private void PageNumContentUpdate()
        {
            if (NumberOfPages == 2)
            {
                BTN_PageFirst.Content = 1;
                BTN_PageSecond.Content = 2;
                BTN_PageThird.Content = "";
            }
            else if (NumberOfPages == 1)
            {
                BTN_PageFirst.Content = 1;
                BTN_PageSecond.Content = "";
                BTN_PageThird.Content = "";
            }
            else
            {
                if (PageNumber <= 2)
                {
                    BTN_PageFirst.Content = 1;
                    BTN_PageSecond.Content = 2;
                    BTN_PageThird.Content = 3;
                }
                else if (PageNumber >= NumberOfPages - 1)
                {
                    BTN_PageFirst.Content = NumberOfPages - 2;
                    BTN_PageSecond.Content = NumberOfPages - 1;
                    BTN_PageThird.Content = NumberOfPages;
                }
                else
                {
                    BTN_PageFirst.Content = PageNumber - 1;
                    BTN_PageSecond.Content = PageNumber;
                    BTN_PageThird.Content = PageNumber + 1;
                }

                int BTN_PageFirst_Cont = int.Parse(BTN_PageFirst.Content.ToString());
                int BTN_PageSecond_Cont = int.Parse(BTN_PageSecond.Content.ToString());
                int BTN_PageThird_Cont = int.Parse(BTN_PageThird.Content.ToString());
            }

            if (PageNumber == int.Parse(BTN_PageFirst.Content.ToString()))
            {
                BTN_PageFirst.Foreground = Brushes.Blue;
                BTN_PageSecond.Foreground = Brushes.Black;
                BTN_PageThird.Foreground = Brushes.Black;
            }
            else if (PageNumber == int.Parse(BTN_PageSecond.Content.ToString()))
            {
                BTN_PageFirst.Foreground = Brushes.Black;
                BTN_PageSecond.Foreground = Brushes.Blue;
                BTN_PageThird.Foreground = Brushes.Black;
            }
            else if (PageNumber == int.Parse(BTN_PageThird.Content.ToString()))
            {
                BTN_PageFirst.Foreground = Brushes.Black;
                BTN_PageSecond.Foreground = Brushes.Black;
                BTN_PageThird.Foreground = Brushes.Blue;
            }    
        }
    }
}
