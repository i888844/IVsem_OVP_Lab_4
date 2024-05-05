using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab.__4
{
    public class Medicine
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double Price { get; set; }
        public string ApplicationType { get; set; }
        public string ReleaseForm { get; set; }
    }

    public class MedicineViewModel
    {
        private Dictionary<string, Medicine> medicines;

        public MedicineViewModel()
        {
            medicines = new Dictionary<string, Medicine>();
        }

        public void AddMedicine(Medicine medicine)
        {
            if (medicines.ContainsKey(medicine.Name))
            {
                medicines[medicine.Name] = medicine;
            }
            else
            {
                medicines.Add(medicine.Name, medicine);
            }
        }

        public List<Medicine> GetMedicinesByReleaseFormAndPrice(string releaseForm, double maxPrice)
        {
            return medicines.Values
                .Where(m => m.ReleaseForm == releaseForm && m.Price <= maxPrice)
                .OrderBy(m => m.ExpiryDate)
                .ToList();
        }

        public List<Medicine> GetMedicines()
        {
            return medicines.Values.ToList();
        }

        public List<Medicine> GetExpiredMedicines()
        {
            var expiredMedicines = medicines.Values
                .Where(m => m.ExpiryDate < DateTime.Now)
                .ToList();

            foreach (var medicine in expiredMedicines)
            {
                medicines.Remove(medicine.Name);
            }

            return expiredMedicines;
        }

        public void LoadFromFile(string filename)
        {
            medicines.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Medicine medicine = new Medicine
                    {
                        Name = parts[0].Split(':')[1],
                        ExpiryDate = DateTime.Parse(parts[1].Split(':')[1]),
                        Price = double.Parse(parts[2].Split(':')[1]),
                        ApplicationType = parts[3].Split(':')[1],
                        ReleaseForm = parts[4].Split(':')[1]
                    };
                    AddMedicine(medicine);
                }
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var medicine in medicines.Values)
                {
                    writer.WriteLine($"Название:{medicine.Name},СрокГодности:{medicine.ExpiryDate},Цена:{medicine.Price},ВидПрименения:{medicine.ApplicationType},ФормаВыпуска:{medicine.ReleaseForm}");
                }
            }
        }
    }
}
