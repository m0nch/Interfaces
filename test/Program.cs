using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    class Program
    {
        static void Main()
        {
            CRSReportGeneration crs = new CRSReportGeneration();
            crs.GenerateReport(new Employee());
            PDFReportGeneration pdf = new PDFReportGeneration();
            pdf.GenerateReport(new Employee());

            List<IReportGeneration> report = new List<IReportGeneration>();
            report.Add(pdf);
            report.Add(crs);
            for (int i = 0; i < report.Count; i++)
            {
                report[i].GenerateReport(new Employee());
            }
            Console.ReadKey();
        }
    }
    public interface IReportGeneration
    {
        void GenerateReport(Employee employee);
    }

    public class CRSReportGeneration : IReportGeneration
    {
        public void GenerateReport(Employee employee)
        {
            Console.WriteLine("Generate CRS report");
        }
    }

    public class PDFReportGeneration : IReportGeneration
    {
        public void GenerateReport(Employee employee)
        {
            Console.WriteLine("Generate PDF report");
        }
    }
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }

        /// <summary>
        /// This method used to insert into employee table
        /// </summary>
        /// <param name="em">Employee object</param>
        /// <returns>Successfully inserted or not</returns>
        public bool InsertIntoEmployeeTable(Employee em)
        {
            // Insert into employee table.
            return true;
        }
        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public void GenerateReport(Employee em)
        {
            // Report generation with employee data using crystal report.
        }
    }

}