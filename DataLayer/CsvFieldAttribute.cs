using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportLibrary
{
    public class CsvFieldAttribute : Attribute
    {
       
        public int CsvFieldLocation { get; set; }

        public CsvFieldAttribute(int location)
        {
            CsvFieldLocation = location;
        }


    }
}
