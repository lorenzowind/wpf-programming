using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GenericCRUD.Models
{
    class Persistence
    {
        public string FilePath { get; }
        private List<Employee> _list = new List<Employee>();
        
        public Persistence(string filePath)
        {
            FilePath = filePath;
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
        public async Task Save()
        {
            var employeesJSON = JsonConvert.SerializeObject(_list);
            JsonSerializer serializer = new JsonSerializer();
            
            using (var sr = new StreamWriter(employeesJSON))
            using (var writer = new JsonTextWriter(sr))
            {
                await Task.Run(() => serializer.Serialize(writer, employeesJSON));
            }
        }

        public async Task Load()
        {
            JsonSerializer serializer = new JsonSerializer();

            using (var sr = new StreamReader(FilePath))
            using (var reader = new JsonTextReader(sr))
            {
                var result = await Task.Run(() => serializer.Deserialize(reader));
                _list = (List<Employee>) result;
            }
        }
    }
}
