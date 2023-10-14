using BL.IServices;
using DAL.UnitOfWork;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class EmployeeService : Service<Employees>, IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<string>> GetAllEmployeeNamesAsync()
        {
            List<string> employeeNames = new List<string>();
            var data = await _unitOfWork.GetRepository<Employees>().GetAllAsync();
            foreach (var employee in data)
            {
                employeeNames.Add(employee.EmployeeName);
            }
            return employeeNames;
        }
    }
}
