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
using System.Windows.Shapes;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        public Task Result { get; set; }

        public NewTaskWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox != null)
            {            
                Task t = new Task();
                t.Name = nameTextBox.Text;
                t.isCompleted = isCompletedCheckBox.IsChecked.Value;
                t.Description = DescriptionTextBox.Text;
                Result= t;

                DialogResult = true;
            }
            else
            {
                nameTextBox.Background = Brushes.Red;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }

        private void SaveButton_MouseEnter(object sender, MouseEventArgs e)
        {
            SaveButton.Foreground = Brushes.DarkBlue;
        }

        private void SaveButton_MouseLeave(object sender, MouseEventArgs e)
        {
            SaveButton.Foreground = Brushes.WhiteSmoke;
        }

        private void CancelButton_MouseEnter(object sender, MouseEventArgs e)
        {
            CancelButton.Foreground = Brushes.DarkBlue;
        }

        private void CancelButton_MouseLeave(object sender, MouseEventArgs e)
        {
            CancelButton.Foreground = Brushes.WhiteSmoke;
        }
    }
}
