using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WindowsPhone.Resources;
using PortableClassLibrary;

namespace WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            //this.DataContext = new TodoViewModel();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is TodoViewModel)
            {
                var todoVm = DataContext as TodoViewModel;
                var newTodo = await todoVm.Add(new Todo {Text = todoVm.NewTodoText});
                todoVm.NewTodoText = "";
                todoVm.Todos.Add(newTodo);
            }
        }

        private async void CompleteChecked(object sender, RoutedEventArgs e)
        {
            var todo = ((System.Windows.FrameworkElement)(sender)).DataContext as Todo;
            if (DataContext is TodoViewModel)
            {
                var todoVm = DataContext as TodoViewModel;
                await todoVm.Update(todo);
            }
        }

        private void refreshClick(object sender, EventArgs e)
        {
            if (DataContext is TodoViewModel)
            {
                var todoVm = DataContext as TodoViewModel;
                todoVm.Refresh();
            }
        }
    }
}