using MagicBaseData.Controllers;
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
using MagicBaseData.Models;
using MagicBaseData.Interfaces;
namespace MagicBaseData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IController controller;
        public MainWindow()
        {
            InitializeComponent();
            //Login p = new();
            //p.ShowDialog();
            controller = Controller.GetInstance();
            controller.Read(@"\\Mac\Home\Documents\BNTU\VisualDevelopmentTools\Labs\LAB1-2\note.csv");
            listView.ItemsSource = controller.GetAll();
        }
        private void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            controller.Read(@"\\Mac\Home\Documents\BNTU\VisualDevelopmentTools\Labs\LAB1\note.csv");
            listView.ItemsSource=controller.GetAll();
            listView.Items.Refresh();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            controller.Write(@"\\Mac\Home\Documents\BNTU\VisualDevelopmentTools\Labs\LAB1\note.csv");
        }
        private void AddCharacter_Click(object sender, RoutedEventArgs e)
        {
            AddCharacter p = new AddCharacter(this);
            p.ShowDialog();
            listView.Items.Refresh();
        }
        private void DeleteCharacter_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem!=null)
            {
                controller.Delete(((Magician)listView.SelectedItem).Id);
            }
            listView.Items.Refresh();
        }
        private void UpdateCharacter_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                UpdateCharacter p = new UpdateCharacter(this,(Magician)listView.SelectedItem);
                p.ShowDialog();
                listView.Items.Refresh();
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
                listView.ItemsSource = controller.GetAll();
                listView.Items.Refresh();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchBox.ToolTip = null;
            searchBox.BorderBrush = Brushes.Blue;
            if (searchBox.Text.Length > 15)
            {


                Label label = new Label() {
                    Content = "Very long line!",
                    Margin = new Thickness(8, 20, 8, 20),
                    Foreground = Brushes.Orange,
                    FontWeight = FontWeights.Bold
                };
                ErrorWindow p = new();
                p.Content = label;
                p.ShowDialog();
                
                //searchBox.ToolTip = "Value cannot be longer than 15 characters!";
                //searchBox.BorderBrush = Brushes.Red;
            }
            if (searchBox.Text!=null)
            {
                listView.ItemsSource=controller.Search(searchBox.Text);
                listView.Items.Refresh();
            }
        }

        public void AddCharcter(Magician magician)
        {
            controller.Create(magician);
        }
        public void UpdateCharcter(Magician magician)
        {
            controller.Update(magician);
        }
    }
}
