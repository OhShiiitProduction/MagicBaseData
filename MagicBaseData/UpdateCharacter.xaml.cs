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
    /// Interaction logic for UpdateCharacter.xaml
    /// </summary>
    public partial class UpdateCharacter : Window
    {
        private MainWindow daddyWindow;
        private Magician UpdateMagician;
        bool indicatorErorr;
        public UpdateCharacter(MainWindow window, Magician magician)
        {
            InitializeComponent();

            daddyWindow = window;
            UpdateMagician = magician;
            name.Text = magician.Name;
            power.Text = magician.power.ToString();
            speed.Text = magician.Speed.ToString();
            hitPoint.Text = magician.HitPoints.ToString();
            kindOfMagic.Text = magician.KindOfMagic.ToString();
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (!indicatorErorr && power.Text != "" && name.Text !="" && speed.Text != "" && hitPoint.Text != "")
            {
                UpdateMagician = new Magician()
                {
                    Id = UpdateMagician.Id,
                    Name = name.Text,
                    power = double.Parse(power.Text),
                    Speed = double.Parse(speed.Text),
                    HitPoints = double.Parse(hitPoint.Text),
                    KindOfMagic = (KindOfMagic)Enum.Parse(typeof(KindOfMagic), kindOfMagic.Text)
                };
                daddyWindow.UpdateCharcter(UpdateMagician);
                Close();
            }
            else
            {
                ErrorWindow p = new()
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
                p.ShowDialog();
            }
        }

        private void Data_TextChanged(object sender, TextChangedEventArgs e)
        {
            indicatorErorr = false;
            textValidationStyle((TextBox)sender);
        }

        private void textValidationStyle(TextBox textBox)
        {
            indicatorErorr = false;
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
