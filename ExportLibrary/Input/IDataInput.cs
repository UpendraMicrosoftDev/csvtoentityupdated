using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportLibrary.Input
{
    public interface IDataInput
    {
        IEnumerable<T> GetData<T>();
    }
}
