using DataLayer.Output;
using ExportLibrary;
using ExportLibrary.Input;
using System;
using System.Collections.Generic;

namespace CSVToEntity
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.Write("Enter CSV file path:");
            string filePath=Console.ReadLine();

            try
            {
                //Initialize source and destination strategies
                IDataInput dataInput = new FileInput(filePath);
                IDataRepository<Student> dataOutput = new SqlRepository<Student>((new StudentTestCSVEntities()));

                Loader<Student> loader = new Loader<Student>(dataInput,dataOutput);
                loader.Load();

                Console.WriteLine("Import finished");
                Console.ReadLine();

            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            
        }

    }
}
