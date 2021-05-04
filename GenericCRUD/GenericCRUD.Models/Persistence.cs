using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GenericCRUD.Models
{
    public class Persistence
    {
        public List<Employee> _list = new List<Employee>();

        public Persistence()
        {
            _list.Add(new Employee("test", "test", "test", "test", "test"));
        }

        public void Add(Employee employee)
        {
            _list.Add(employee);
        }

        public void Save(Employee employee, int index)
        {
            _list[index] = employee;
        }

        public void Remove(int index)
        {
            _list.RemoveAt(index);
        }

        public Employee this[int index] => _list[index];

        private SaveFileDialog _saveFileDialog;

        public SaveFileDialog SaveFileDialog
        {
            get { return _saveFileDialog; }
            set
            {
                _saveFileDialog = value;
            }
        }

        public async Task SaveFileAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text file(*.json)|*.json",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }

                await Task.Run(() => File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(_list)));

                SaveFileDialog = saveFileDialog;
            }
        }

        public async Task SaveFile()
        {
            await Task.Run(() => File.WriteAllText(SaveFileDialog.FileName, JsonConvert.SerializeObject(_list)));
        }

        public async Task LoadFile(string filePath)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (var sr = new StreamReader(filePath))
            using (var reader = new JsonTextReader(sr))
            {
                var result = await Task.Run(() => serializer.Deserialize(reader));
                _list = (List<Employee>) result;
            }
        }
    }
}
