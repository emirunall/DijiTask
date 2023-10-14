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
    public class MachineService : Service<Machines>, IMachineService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MachineService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<string>> GetAllMachineNamesAsync()
        {
            List<string> machineNames = new List<string>();
            var data = await _unitOfWork.GetRepository<Machines>().GetAllAsync();
            foreach (var machine in data)
            {
                machineNames.Add(machine.MachineName);
            }
            return machineNames;
        }
    }
}
