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
namespace ToDoListWPF
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private string tempDesc;
        public EditWindow(ToDoItem item)
        {
            InitializeComponent();
            this.DataContext = item;
            this.tempDesc = item.ToDoDescription;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool result = DialogResult ?? false;
            if (!result)
                (DataContext as ToDoItem).ToDoDescription = this.tempDesc;
        }
    }
}


