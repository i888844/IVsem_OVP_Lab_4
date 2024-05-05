using System;
using System.Windows;

namespace Lab.__4
{
    public partial class AddMedicineWindow : Window
    {
        public Medicine Medicine { get; private set; }

        public AddMedicineWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Medicine = new Medicine
            {
                Name = NameTextBox.Text,
                ExpiryDate = (DateTime)ExpiryDatePicker.SelectedDate,
                Price = double.Parse(PriceTextBox.Text),
                ApplicationType = ApplicationTypeTextBox.Text,
                ReleaseForm = ReleaseFormTextBox.Text
            };

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
