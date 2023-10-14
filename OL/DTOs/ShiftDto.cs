using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL.DTOs
{
    public class ShiftDto : BaseEntity
    {
        public DateTime ShiftDate { get; set; }
        public int EmployeeId { get; set; }
        public int MachineId { get; set; }
        public string Employee { get; set; }
        public string Machine { get; set; }
    }
}
