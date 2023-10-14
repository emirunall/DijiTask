using BL.IServices;
using DAL;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using OL;
using OL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ShiftService : Service<Shifts>, IShiftService
    {
        private readonly AppDbContext _context;
        public ShiftService(IUnitOfWork unitOfWork, AppDbContext context) : base(unitOfWork)
        {
            _context = context;
        }

        public async Task<List<ShiftDto>> GetAllShiftsAsync()
        {
            List<ShiftDto> dtos = await _context.Shifts
                   .Include(s => s.Employee)
                   .Include(s => s.Machine)
                   .Select(s => new ShiftDto
                   {
                       ShiftDate = s.ShiftDate,
                       EmployeeId = s.EmployeeId,
                       MachineId = s.MachineId,
                       Employee = s.Employee.EmployeeName, // EmployeeName'i çekiyoruz
                       Machine = s.Machine.MachineName, // MachineName'i çekiyoruz
                   })
                   .ToListAsync();

            return dtos;
        }
    }
}
