using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GenericCRUD.Models
{
    public class Persistence
    {
        private List<Employee> _list = new List<Employee>();

        public List<Employee> List
        {
            get
            {
                return _list;
            }
        }

        public Persistence()
        {
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

        public void ClearList()
        {
            _list.Clear();
        }
        
        private string _filename;

        public string Filename
        {
            get { return _filename; }
        }

        public void ClearFileName()
        {
            _filename = "";
        }

        public async Task SaveFileAs(SaveFileDialog saveFileDialog)
        {
            if (saveFileDialog != null)
            {
                await Task.Run(() => File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(_list)));

                _filename = saveFileDialog.FileName;
            }
        }

        public async Task SaveFile()
        {
            await Task.Run(() => File.WriteAllText(Filename, JsonConvert.SerializeObject(_list)));
        }

        public async Task LoadFile(OpenFileDialog openFileDialog)
        {
            if (openFileDialog != null)
            {
                await Task.Run(() => _list = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(openFileDialog.FileName)));

                _filename = openFileDialog.FileName;
            }
        }
    }
}
