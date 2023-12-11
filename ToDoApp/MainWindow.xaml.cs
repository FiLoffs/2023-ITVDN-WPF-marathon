using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Task> tasksList = new ObservableCollection<Task>();
        public MainWindow()
        {
            InitializeComponent();

            ToDoListBox.ItemsSource = tasksList;
            ToDoListBox.DisplayMemberPath= "Name";

        }

        private void ToDoListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Task selected = ToDoListBox.SelectedItem as Task;
            if (selected != null)
            {
                MessageBox.Show(selected.Description);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NewTaskWindow window = new NewTaskWindow();
            window.Owner= this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if(window.ShowDialog() == true)
            {
                Task newTask = window.Result;
                tasksList.Add(newTask);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ToDoListBox.SelectedIndex;
            if (index != -1)
            {
                tasksList.RemoveAt(index);
            }
        }

        private void completeButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ToDoListBox.SelectedIndex;
            if (index != -1)
            {
                tasksList[index].isCompleted = true;
            }
        }

        private void allRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ToDoListBox.ItemsSource = tasksList;
        }

        private void notCompletedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Task> filtered = new ObservableCollection<Task>();
            for (int i = 0; i < tasksList.Count; i++)
            {
                Task current = tasksList[i];
                if (current.isCompleted == false)
                {
                    filtered.Add(current);
                }
            }
            ToDoListBox.ItemsSource = filtered;
        }

        private void completedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Task> filtered = new ObservableCollection<Task>();
            for (int i = 0; i < tasksList.Count; i++)
            {
                Task current = tasksList[i];
                if (current.isCompleted == true)
                {
                    filtered.Add(current);
                }
            }
            ToDoListBox.ItemsSource = filtered;
        }

        string fileName = "data.bin";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(fileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream file = File.OpenRead(fileName);
                tasksList = formatter.Deserialize(file) as ObservableCollection<Task>;
                file.Close();
                ToDoListBox.ItemsSource = tasksList;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            BinaryFormatter formatter= new BinaryFormatter();
            Stream file = File.OpenWrite(fileName);
            formatter.Serialize(file, tasksList);
            file.Close();

        }

        private void addButton_MouseEnter(object sender, MouseEventArgs e)
        {
            addButton.Foreground = Brushes.DarkBlue;
        }

        private void addButton_MouseLeave(object sender, MouseEventArgs e)
        {
            addButton.Foreground = Brushes.WhiteSmoke;
        }

        private void completeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            completeButton.Foreground = Brushes.DarkBlue;
        }

        private void completeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            completeButton.Foreground = Brushes.WhiteSmoke;
        }

        private void deleteButton_MouseEnter(object sender, MouseEventArgs e)
        {
            deleteButton.Foreground = Brushes.DarkBlue;
        }

        private void deleteButton_MouseLeave(object sender, MouseEventArgs e)
        {
            deleteButton.Foreground = Brushes.WhiteSmoke;
        }

        private void ToDoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
