using MagicBaseData.Controllers;
using MagicBaseData.Enums;
using MagicBaseData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MagicBaseData
{
    /// <summary>
    /// Interaction logic for AddCharacter.xaml
    /// </summary>
    public partial class AddCharacter : Window
    {
        readonly Random rnd;
        Magician magician;
        private readonly MainWindow daddyWindow;
        bool indicatorErorr;
        TextBox textBox;
        public AddCharacter(MainWindow window)
        {
            InitializeComponent();
            daddyWindow = window;
            rnd = new Random();
        }


        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (!indicatorErorr && power.Text !="" && name.Text !="" && speed.Text != "" && hitPoint.Text != "")
            {
                magician = new Magician()
                {
                    Id = rnd.Next(0, 100000000),
                    Name = name.Text,
                    power = double.Parse(power.Text),
                    Speed = double.Parse(speed.Text),
                    HitPoints = double.Parse(hitPoint.Text),
                    KindOfMagic = (KindOfMagic)Enum.Parse(typeof(KindOfMagic), kindOfMagic.Text)
                };
                daddyWindow.AddCharcter(magician);
                Close();
            }
            else
            {
                ErrorWindow p = new ErrorWindow();
                p.ShowDialog();
            }
        }

        private void Data_TextChanged(object sender, TextChangedEventArgs e)
        {
            indicatorErorr = false;

            textBox = (TextBox)sender;
            textBox.BorderBrush = Brushes.Blue;
            textBox.ToolTip = null;

            if (textBox.Text == "")
            {
                textBox.ToolTip = "Value cannot be empty!";
                textBox.BorderBrush = Brushes.Red;
                indicatorErorr = true;
            }
            else if (textBox.Text.Length > 15)
            {
                textBox.ToolTip = "Value cannot be longer than 15 characters!";
                textBox.BorderBrush = Brushes.Red;
                indicatorErorr = true;
            }
            else if (textBox.Name != "name")
            {
                if (!double.TryParse(textBox.Text, out _))
                {
                    textBox.ToolTip = "only numeric value!";
                    textBox.BorderBrush = Brushes.Red;
                    indicatorErorr = true;
                }
            }
        }
    }
}
