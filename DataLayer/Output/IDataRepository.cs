using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Output
{
    public interface IDataRepository<T>
    {
        bool UpdateData(IEnumerable<T> dataCollection);
    }
}
