using OL;
using OL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.IServices
{
    public interface IShiftService :IService<Shifts>
    {
        Task<List<ShiftDto>> GetAllShiftsAsync();
        string ExportWeeklyShiftDataToExcelUsingClosedXML();
    }
}
