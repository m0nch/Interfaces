using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_L
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IEmployee> employeeList = new List<IEmployee>();
            employeeList.Add(new CasualEmployee());
            employeeList.Add(new ContractualEmployee());
            foreach (IEmployee e in employeeList)
            {
                e.GetEmployeeDetails(1245);
                if (e is IProject)
                {
                    IProject emp = e as IProject;
                    emp.GetProjectDetails(1245);
                }
            }

            Console.ReadKey();
        }
    }

    public interface IProject
    {
        void GetProjectDetails(int EmployeeId);
    }

    public interface IEmployee
    {
        void GetEmployeeDetails(int EmployeeId);
    }

    public class CasualEmployee : IProject, IEmployee
    {
        public void GetProjectDetails(int EmployeeId)
        {
            Console.WriteLine("Casual Project");
        }

        public void GetEmployeeDetails(int EmployeeId)
        {
            Console.WriteLine("Casual Employee");
        }
    }

    public class ContractualEmployee : IEmployee
    {
        public void GetEmployeeDetails(int EmployeeId)
        {
            Console.WriteLine("Contractual Project");
        }

        //public override string GetEmployeeDetails(int EmployeeId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
