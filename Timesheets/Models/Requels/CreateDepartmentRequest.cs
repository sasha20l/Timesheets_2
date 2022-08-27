using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Request
{
    public class CreateDepartmentRequest
    {
        public Guid Id { get; set; }

        public int Description { get; set; }
    }
}
