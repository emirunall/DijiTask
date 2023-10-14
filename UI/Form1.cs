using BL.IServices;
using OL;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMachineService _machineService;
        private readonly IShiftService _shiftService;
        public Form1(IEmployeeService employeeService, IMachineService machineService, IShiftService shiftService)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _machineService = machineService;
            _shiftService = shiftService;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await _employeeService.GetAllAsync();
            dataGridView2.DataSource = await _machineService.GetAllAsync();
            dataGridView3.DataSource = await _shiftService.GetAllShiftsAsync();
            cmbEmployees.DataSource = await _employeeService.GetAllEmployeeNamesAsync();
            cmbMachines.DataSource = await _machineService.GetAllMachineNamesAsync();
            dataGridView3.Columns["Id"].Visible = false;
            dataGridView2.Columns["Id"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView3.Columns["EmployeeId"].Visible = false;
            dataGridView3.Columns["MachineId"].Visible = false;

            dataGridView1.Columns["EmployeeName"].HeaderText = "Ad Soyad";
            dataGridView2.Columns["MachineName"].HeaderText = "Makine";
            dataGridView3.Columns["ShiftDate"].HeaderText = "Tarih";
            dataGridView3.Columns["Employee"].HeaderText = "Ad Soyad";
            dataGridView3.Columns["Machine"].HeaderText = "Makine";

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Employees employee = new Employees();
            employee.EmployeeName = txtNameSurname.Text;

            await _employeeService.CreateAsync(employee);
            dataGridView1.DataSource = await _employeeService.GetAllAsync();
            cmbEmployees.DataSource = await _employeeService.GetAllEmployeeNamesAsync();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private async void btnAddMachine_Click(object sender, EventArgs e)
        {
            Machines machine = new Machines();
            machine.MachineName = txtMachineName.Text;

            await _machineService.CreateAsync(machine);
            dataGridView2.DataSource = await _machineService.GetAllAsync();
            cmbMachines.DataSource = await _machineService.GetAllMachineNamesAsync();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var selectedMachine = await _machineService.GetByFilterAsync(x => x.MachineName == cmbMachines.SelectedValue);
            var selectedEmployee = await _employeeService.GetByFilterAsync(x => x.EmployeeName == cmbEmployees.SelectedValue);
            Shifts shift = new Shifts();
            shift.ShiftDate = dateTimePicker1.Value.Date;
            shift.MachineId = selectedMachine.Id;
            shift.EmployeeId = selectedEmployee.Id;

            await _shiftService.CreateAsync(shift);
            dataGridView3.DataSource = await _shiftService.GetAllShiftsAsync();
        }
    }
}