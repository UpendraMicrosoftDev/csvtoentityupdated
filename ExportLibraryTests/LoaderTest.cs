using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExportLibrary;
using CSVToEntity;
using Rhino.Mocks;
using ExportLibrary.Input;
using System.Collections.Generic;
using DataLayer.Output;

namespace ExportLibraryTests
{
    [TestClass]
    public class LoaderTest
    {
        [TestMethod]
        public void outputrepository_return_true_loader_return_true()
        {
            //Arrange
            IDataInput inputData = MockRepository.GenerateStub<IDataInput>();
            IDataRepository<Student> output = MockRepository.GenerateStub<IDataRepository<Student>>();

            List<Student> testData = new List<Student>();
            testData.Add(new Student() { Name = "test", Location = "test2", SchoolName = "test3" });

            inputData.Expect(x => x.GetData<Student>()).Return(testData);
            output.Expect(x => x.UpdateData(testData)).Return(true);

            Loader<Student> loader = new Loader<Student>(inputData,output);

            //Act
            bool status=loader.Load();

            //Assert
            Assert.AreEqual(true, status);

        }

        [TestMethod]
        public void outputrepository_return_false_loader_return_false()
        {
            //Arrange
            IDataInput inputData = MockRepository.GenerateStub<IDataInput>();
            IDataRepository<Student> output = MockRepository.GenerateStub<IDataRepository<Student>>();

            List<Student> testData = new List<Student>();
            testData.Add(new Student() { Name = "test", Location = "test2", SchoolName = "test3" });

            inputData.Expect(x => x.GetData<Student>()).Return(testData);
            output.Expect(x => x.UpdateData(testData)).Return(false);

            Loader<Student> loader = new Loader<Student>(inputData, output);

            //Act
            bool status = loader.Load();

            //Assert
            Assert.AreEqual(false, status);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void inputdata_throw_exception_loader_Throw_exception()
        {
            //Arrange
            IDataInput inputData = MockRepository.GenerateStub<IDataInput>();
            IDataRepository<Student> output = MockRepository.GenerateStub<IDataRepository<Student>>();

            List<Student> testData = new List<Student>();
            testData.Add(new Student() { Name = "test", Location = "test2", SchoolName = "test3" });

            inputData.Expect(x => x.GetData<Student>()).Throw(new Exception());
            output.Expect(x => x.UpdateData(testData)).Return(false);

            Loader<Student> loader = new Loader<Student>(inputData, output);

            //Act
            bool status = loader.Load();

          

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void input_null_ctor_throw_argumentnullexception()
        {
            //Arrange
            IDataRepository<Student> output = MockRepository.GenerateStub<IDataRepository<Student>>();
           

            List<Student> testData = new List<Student>();
            testData.Add(new Student() { Name = "test", Location = "test2", SchoolName = "test3" });

            output.Expect(x => x.UpdateData(testData)).Return(false);

            Loader<Student> loader = new Loader<Student>(null, output);

            //Act
            bool status = loader.Load();



        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void output_null_ctor_throw_argumentnullexception()
        {
            //Arrange
            IDataInput inputData = MockRepository.GenerateStub<IDataInput>();

            List<Student> testData = new List<Student>();
            testData.Add(new Student() { Name = "test", Location = "test2", SchoolName = "test3" });

            Loader<Student> loader = new Loader<Student>(inputData, null);

            //Act
            bool status = loader.Load();

        }

    }
}
