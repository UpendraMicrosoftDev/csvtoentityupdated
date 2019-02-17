using CSVToEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataLayer.Output
{
    public class SqlRepository<T> : IDataRepository<T> where T:class
    {
        private StudentTestCSVEntities _dbContext;
        private IDbSet<T> _entity;

        public SqlRepository(StudentTestCSVEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public bool UpdateData(IEnumerable<T> entity)
        {
            try
            {
                foreach(var tempEntity in entity)
                    Entities.Add(tempEntity);

                _dbContext.SaveChanges();

                return true;
                
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                _dbContext.Dispose();
            }

        }

        private IDbSet<T> Entities
        {
            get
            {
                if (_entity == null)
                    _entity = _dbContext.Set<T>();

                return _entity;
            }
        }

    }
}
