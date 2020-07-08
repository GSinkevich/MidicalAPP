using Controll.Model;
using Controll.Services;
using Controll.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Controll
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {

       
            

        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";

        private FileIOService _fileIOService;

        private BindingList<TodoModel> _todoDataList;


        


        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);

            try
            {
                _todoDataList = _fileIOService.LoadData();
               
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message);
            }
                                 

            dgTodoList.ItemsSource = _todoDataList;
            _todoDataList.ListChanged += _todoDataList_ListChanged;
        }
        
      


        private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                _fileIOService.SaveData(sender);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void AddPerson(object sender, RoutedEventArgs e)
        {
            var AddPersonPage = new AddPersonPage();
            AddPersonPage.Show();
           

        }

        private void AddPerson2(object sender, RoutedEventArgs e)
        {

            var AddPersonPage = new AddPersonPage();
            var b = new TodoModel() 
                { FirstName = AddPersonPage.EnterFirstName.Text};
            _todoDataList.Add(b);

        }
    }
}

