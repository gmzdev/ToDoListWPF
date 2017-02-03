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
namespace ToDoListWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ToDoList tdl;
        public MainWindow()
        {
            InitializeComponent();
            tdl = new ToDoList();
            this.DataContext = tdl;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!txtListItem.Text.Trim().Equals(string.Empty))
            {
                tdl.Add(txtListItem.Text.Trim());
                txtListItem.Focus();
            }
            txtListItem.Clear();
            lstTodo.Items.Refresh();
        }
        private void EditMenu_Click(object sender, RoutedEventArgs e)
        {
            if (lstTodo.SelectedItem != null)
            {
                EditWindow editWindow = new EditWindow((ToDoItem)lstTodo.SelectedItem);
                editWindow.Owner = this;
                editWindow.ShowDialog();
            }
            lstTodo.Items.Refresh();
        }
        private void DoneMenu_Click(object sender, RoutedEventArgs e)
        {
            if (lstTodo.SelectedItem != null)
            {
                ((ToDoItem)lstTodo.SelectedItem).DoneDate = DateTime.Now.ToString();
            }
            lstTodo.Items.Refresh();
        }
        private void DeleteMenu_Click(object sender, RoutedEventArgs e)
        {
            if (lstTodo.SelectedItem != null)
            {
                MessageBoxResult delMsg = MessageBox.Show("Delete this item?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (delMsg == MessageBoxResult.Yes)
                {
                    tdl.Delete(lstTodo.SelectedItem as ToDoItem);
                }
                lstTodo.Items.Refresh();
            }

        }
        private void txtListItem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;
            btnAdd_Click(sender, e);
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tdl.Save();
        }

    }
}