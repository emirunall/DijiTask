using BL.IServices;
using ClosedXML.Excel;
using DAL;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using OL;
using OL.DTOs;

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
                       ShiftId = s.Id,
                       ShiftDate = s.ShiftDate,
                       EmployeeId = s.EmployeeId,
                       MachineId = s.MachineId,
                       Employee = s.Employee.EmployeeName, // EmployeeName'i çekiyoruz
                       Machine = s.Machine.MachineName, // MachineName'i çekiyoruz
                   })
                   .ToListAsync();

            return dtos;
        }


        //public void ExportWeeklyShiftDataToExcelUsingInterop()
        //{
        //    // Excel uygulamasını başlatın.
        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = true; // Excel penceresini görünür yapabilirsiniz.

        //    // Yeni bir çalışma kitabı oluşturun.
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();
        //    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

        //    // Haftalık veriyi çekmek için LINQ sorgusu oluşturun ve verileri alın.
        //    DateTime startDate = DateTime.Now.Date;
        //    DateTime endDate = startDate.AddDays(6);

        //    var weeklyShiftData = _context.Shifts
        //        .Include(s => s.Employee)
        //        .Include(s => s.Machine)
        //        .Where(s => s.ShiftDate >= startDate && s.ShiftDate <= endDate)
        //        .ToList();

        //    // Başlık satırını ekleyin.
        //    worksheet.Cells[1, 2] = "Gün / Makine";
        //    for (int day = 0; day < 7; day++)
        //    {
        //        worksheet.Cells[1, day + 3] = startDate.AddDays(day).ToShortDateString();
        //    }

        //    // Makineleri ve personelleri doldurun.
        //    int row = 2;
        //    foreach (var machine in weeklyShiftData.Select(s => s.Machine.MachineName).Distinct())
        //    {
        //        worksheet.Cells[row, 2] = machine;

        //        for (int day = 0; day < 7; day++)
        //        {
        //            var date = startDate.AddDays(day);
        //            var employeesForMachineAndDay = weeklyShiftData
        //                .Where(s => s.Machine.MachineName == machine && s.ShiftDate.Date == date)
        //                .Select(s => s.Employee.EmployeeName);

        //            worksheet.Cells[row, day + 3] = string.Join(", ", employeesForMachineAndDay);
        //        }

        //        row++;
        //    }

        //    // Excel dosyasını kaydedin.
        //    string excelFilePath = "C:\\Users\\yunus\\OneDrive\\Masaüstü\\ExcelFile.xlsx"; // Dosya yolunu uygun şekilde değiştirin.
        //    workbook.SaveAs(excelFilePath);

        //    // Temizlik işlemleri yapın.
        //    Marshal.ReleaseComObject(worksheet);
        //    Marshal.ReleaseComObject(workbook);
        //    Marshal.ReleaseComObject(excelApp);

        //    // Excel uygulamasını kapatın.
        //    excelApp.Quit();
        //}

        public string ExportWeeklyShiftDataToExcelUsingClosedXML()
        {
            // Hafta sayacı
            int weekCounter = 1;

            // Haftalık veriyi çekmek için başlangıç tarihi belirleyin.
            DateTime startDate = DateTime.Now.Date;

            while (startDate.DayOfWeek != DayOfWeek.Monday)
            {
                startDate = startDate.AddDays(-1);
            }

            using (var workbook = new XLWorkbook())
            {
                while (startDate.Month == DateTime.Now.Month)
                {
                    DateTime endDate = startDate.AddDays(6);

                    // Haftalık veriyi çekmek için LINQ sorgusu oluşturun ve verileri alın.
                    var weeklyShiftData = _context.Shifts
                        .Include(s => s.Employee)
                        .Include(s => s.Machine)
                        .Where(s => s.ShiftDate >= startDate && s.ShiftDate <= endDate)
                        .ToList();

                    // Excel sayfası oluşturun ve adını haftanın başlangıç ve bitiş tarihleri olarak ayarlayın.
                    var worksheet = workbook.Worksheets.Add($"Hafta_{weekCounter}_{startDate.ToShortDateString()}_{endDate.ToShortDateString()}");

                    // Başlık satırını ekleyin.
                    worksheet.Cell(1, 2).Value = "Gün / Makine";
                    for (int day = 0; day < 7; day++)
                    {
                        worksheet.Cell(1, day + 3).Value = startDate.AddDays(day).ToShortDateString();
                    }

                    // Makineleri ve personelleri doldurun.
                    int row = 2;
                    foreach (var machine in weeklyShiftData.Select(s => s.Machine.MachineName).Distinct())
                    {
                        worksheet.Cell(row, 2).Value = machine;

                        for (int day = 0; day < 7; day++)
                        {
                            var date = startDate.AddDays(day);
                            var employeesForMachineAndDay = weeklyShiftData
                                .Where(s => s.Machine.MachineName == machine && s.ShiftDate.Date == date)
                                .Select(s => s.Employee.EmployeeName);

                            worksheet.Cell(row, day + 3).Value = string.Join(", ", employeesForMachineAndDay);
                        }

                        row++;
                    }

                    // Hafta sayacını ve başlangıç tarihini güncelle
                    weekCounter++;
                    startDate = endDate.AddDays(1);

                    // Excel dosyasını kaydetmek yerine her hafta için yeni bir sayfa oluşturun
                }

                // Excel dosyasını kaydedin.
                string excelFilePath = "C:\\Users\\yunus\\OneDrive\\Masaüstü\\MonthlyMachineList.xlsx"; // Dosya yolunu uygun şekilde değiştirin.
                workbook.SaveAs(excelFilePath);

                return "Excel dosyası oluşturuldu. Dosya konumu: " + excelFilePath;
            }
        }
    }
}
