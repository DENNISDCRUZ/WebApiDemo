using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    [Table("tblEmp")]
    public class Employees
    {
        [Key]
        public Guid EmpID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
