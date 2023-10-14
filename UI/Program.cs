using BL.IServices;
using BL.Services;
using DAL;
using DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddDbContext<AppDbContext>();
                    services.AddScoped<IUnitOfWork, UnitOfWork>();
                    services.AddTransient<IEmployeeService, EmployeeService>();
                    services.AddTransient<IMachineService, MachineService>();
                    services.AddTransient<IShiftService, ShiftService>();

                    services.AddScoped<Form1>();
                    
                });
        }
    }
}