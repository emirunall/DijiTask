using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class Shifts : BaseEntity
    {
        public DateTime ShiftDate { get; set; }
        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }
        public int MachineId { get; set; }
        public Machines Machine { get; set; }
    }
}
