using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Services.lmpl
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public int Create(Department data) { throw new NotImplementedException(); }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Department data)
        {
            throw new NotImplementedException();
        }

        IList IRepository<Department, Guid>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
