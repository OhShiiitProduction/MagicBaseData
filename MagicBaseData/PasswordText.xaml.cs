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

namespace MagicBaseData
{
    /// <summary>
    /// Interaction logic for PasswordText.xaml
    /// </summary>
    public partial class PasswordText : UserControl
    {
        string Output { get; set; }
        public string Value { get; set; }

        public PasswordText()
        {
            InitializeComponent();
            Value = string.Empty;
            Output = string.Empty;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox.TextChanged -= TextBox_TextChanged;
            textBox.Text = TextMasking(textBox.Text);
            textBox.TextChanged += TextBox_TextChanged;
            textBox.SelectionStart = textBox.Text.Length;
        }


        public string TextMasking(string inputString)
        {
            if (inputString == null)
            {
                Output = "";
            }
            else
            {

                if (inputString.Length < Value.Length)
                {
                    string buf = Value;
                    Value = string.Empty;
                    for (var i = 0; i < buf.Length - 1; i++)
                    {
                        Value += buf[i];
                    }
                }
                else
                {
                    Value += inputString[inputString.Length - 1];
                }

                Output = string.Empty;
                for (var i = 0; i < inputString.Length; i++)
                {
                    Output += '*';
                }
            }
            return Output;
        }
    }
}
