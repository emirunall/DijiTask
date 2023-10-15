using BL.IServices;
using OL;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMachineService _machineService;
        private readonly IShiftService _shiftService;
        int selectedEmployeeId;
        int selectedMachineId;
        int selectedShiftId;
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
            dataGridView3.Columns["ShiftId"].Visible = false;
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

            // Önce ayný personele ayný gün içinde atanan iþleri kontrol edin
            bool isDuplicate = false;
            var existingShifts = await _shiftService.GetAllShiftsAsync();
            foreach (var existingShift in existingShifts)
            {
                if (existingShift.EmployeeId == selectedEmployee.Id && existingShift.ShiftDate == dateTimePicker1.Value.Date)
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (isDuplicate)
            {
                // Eðer personele ayný gün içinde iþ atanmýþsa bu durumu iþleyin (örneðin, bir hata mesajý gösterin).
                MessageBox.Show("Bu personele ayný gün içinde iki farklý iþ atanamaz.");
            }
            else
            {
                // Eðer ayný personele ayný gün içinde iþ atanmamýþsa yeni vardiya oluþturun
                Shifts shift = new Shifts();
                shift.ShiftDate = dateTimePicker1.Value.Date;
                shift.MachineId = selectedMachine.Id;
                shift.EmployeeId = selectedEmployee.Id;

                await _shiftService.CreateAsync(shift);
                dataGridView3.DataSource = await _shiftService.GetAllShiftsAsync();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = _shiftService.ExportWeeklyShiftDataToExcelUsingClosedXML();
            MessageBox.Show(result);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var foundData = await _employeeService.GetByFilterAsync(x => x.Id == selectedEmployeeId);
            if (foundData != null)
            {
                Employees employee = foundData;
                employee.EmployeeName = txtNameSurname.Text;
                var empresult = await _employeeService.UpdateAsync(employee);
                if (empresult)
                {
                    dataGridView1.DataSource = await _employeeService.GetAllAsync();
                    dataGridView3.DataSource = await _shiftService.GetAllShiftsAsync();
                    MessageBox.Show("Personel verisi güncellendi.");
                }
            }
            else
                MessageBox.Show("Personel verisi bulunamadý.");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtNameSurname.Text = selectedRow.Cells[0].Value.ToString();
                selectedEmployeeId = Convert.ToInt32(selectedRow.Cells[1].Value.ToString());
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                txtMachineName.Text = selectedRow.Cells[0].Value.ToString();
                selectedMachineId = Convert.ToInt32(selectedRow.Cells[1].Value.ToString());
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            var foundData = await _machineService.GetByFilterAsync(x => x.Id == selectedMachineId);
            if (foundData != null)
            {
                Machines machine = foundData;
                machine.MachineName = txtMachineName.Text;
                var macresult = await _machineService.UpdateAsync(machine);
                if (macresult)
                {
                    dataGridView2.DataSource = await _machineService.GetAllAsync();
                    dataGridView3.DataSource = await _shiftService.GetAllShiftsAsync();
                    MessageBox.Show("Makine verisi güncellendi.");
                }
            }
            else
                MessageBox.Show("Makine verisi bulunamadý.");
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];
                cmbEmployees.Text = selectedRow.Cells[4].Value.ToString();
                cmbMachines.Text = selectedRow.Cells[5].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells[1].Value.ToString());
                selectedShiftId = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var foundData = await _shiftService.GetByFilterAsync(x => x.Id == selectedShiftId);
            if (foundData != null)
            {
                var selectedMachine = await _machineService.GetByFilterAsync(x => x.MachineName == cmbMachines.SelectedValue);
                var selectedEmployee = await _employeeService.GetByFilterAsync(x => x.EmployeeName == cmbEmployees.SelectedValue);
                Shifts shift = foundData;
                shift.ShiftDate = dateTimePicker1.Value;
                shift.MachineId = selectedMachine.Id;
                shift.EmployeeId = selectedEmployee.Id;
                var shresult = await _shiftService.UpdateAsync(shift);
                if (shresult)
                {
                    dataGridView3.DataSource = await _shiftService.GetAllShiftsAsync();
                    MessageBox.Show("Shift verisi güncellendi.");
                }
            }
            else
                MessageBox.Show("Shift verisi bulunamadý.");
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            var foundData = await _shiftService.GetByFilterAsync(x => x.Id == selectedShiftId);
            if (foundData != null)
            {
                await _shiftService.RemoveAsync(foundData.Id);
                dataGridView3.DataSource = await _shiftService.GetAllShiftsAsync();
                MessageBox.Show("Shift verisi silindi.");
            }

        }

        private async void button8_Click(object sender, EventArgs e)
        {
            var foundData = await _machineService.GetByFilterAsync(x => x.Id == selectedMachineId);
            if (foundData != null)
            {
                await _machineService.RemoveAsync(foundData.Id);
                dataGridView2.DataSource = await _machineService.GetAllAsync();
                dataGridView3.DataSource = await _shiftService.GetAllShiftsAsync();
                MessageBox.Show("Makine verisi silindi.");
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            var foundData = await _employeeService.GetByFilterAsync(x => x.Id == selectedEmployeeId);
            if (foundData != null)
            {
                await _employeeService.RemoveAsync(foundData.Id);
                dataGridView1.DataSource = await _employeeService.GetAllAsync();
                dataGridView3.DataSource = await _shiftService.GetAllShiftsAsync();
                MessageBox.Show("Personel verisi silindi.");
            }
        }
    }
}