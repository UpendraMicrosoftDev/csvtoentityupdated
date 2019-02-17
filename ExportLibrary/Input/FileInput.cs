using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportLibrary.Input
{
    public class FileInput : IDataInput
    {
        private string _filePath;
        public FileInput(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<T> GetData<T>()
        {
            byte[] data = System.IO.File.ReadAllBytes(_filePath);
            string[] inputData=Encoding.Default.GetString(data, 0, data.Length - 1).Split(new string[] { "\n" }, StringSplitOptions.None);
     
            List<T> studentCollection = new List<T>();

            foreach (string temp in inputData)
            {
                string[] csvFields = temp.Split(',');
                studentCollection.Add(CSVToObjectLoad.loadEntity<T>(csvFields));

            }

            return studentCollection;

        }
        
    }
}
