using DataLayer.Output;
using ExportLibrary.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportLibrary
{
    public class Loader<T>
    {
        private IDataInput _input;
        private IDataRepository<T> _output;

        public Loader(IDataInput input, IDataRepository<T> output)
        {
            if (input == null)
                throw new ArgumentNullException("Input null");

            if (output == null)
                throw new ArgumentNullException("Output null");

            _input = input;
            _output = output;

            
        }

        public bool Load()
        {
            IEnumerable<T> inputCollection= _input.GetData<T>();
            return _output.UpdateData(inputCollection);
        }

    }
}
