using ConsoleTestReport;

namespace ProcessReportConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, Report!");
            try
            {
                RunReport rpt = new RunReport();
                rpt.ProccesReport();
                Console.WriteLine("Report generated Ok!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex}");
            }
        }
    }
}