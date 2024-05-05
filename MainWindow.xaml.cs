using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Lab.__4;

namespace Lab.__4
{
    public partial class MainWindow : Window
    {
        private readonly MedicineViewModel _medicineViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _medicineViewModel = new MedicineViewModel();
            DataContext = _medicineViewModel;
        }

        private void LoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                _medicineViewModel.LoadFromFile(openFileDialog.FileName);
                dataGrid.ItemsSource = _medicineViewModel.GetMedicines();
            }
        }

        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                _medicineViewModel.SaveToFile(saveFileDialog.FileName);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddMedicineWindow();
            if (addWindow.ShowDialog() == true)
            {
                _medicineViewModel.AddMedicine(addWindow.Medicine);
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = _medicineViewModel.GetMedicines();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
