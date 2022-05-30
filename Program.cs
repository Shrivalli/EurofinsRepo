using System;

namespace ADONETEg
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDAL obj = new EmployeeDAL();
            //Console.WriteLine("Enter eid,ename,salary");
            //int eid = Convert.ToInt32(Console.ReadLine());
            //string ename = Console.ReadLine();
            //float salary = float.Parse(Console.ReadLine());
            //DateTime doj = DateTime.Now;
            //obj.InsertData(eid, ename, salary, doj);
            obj.DisconSelect();
        }
    }
}
