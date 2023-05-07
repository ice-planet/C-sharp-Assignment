using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Xml.Linq;

namespace Employee_Database
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Load xml file
            XDocument xmlDoc = XDocument.Load("employees.xml");

            // To find the maximum CTC
            var maxCTC = xmlDoc.Descendants("Employee")
                                    .Select(emp => new {
                                        Id = (int)emp.Element("Id"),
                                        Name = (string)emp.Element("Name"),
                                        CTC = (int)emp.Element("CTC")
                                    })
                                    .OrderByDescending(e => e.CTC)
                                    .FirstOrDefault();
           
            Console.WriteLine("Employee with maximum CTC:");
            Console.WriteLine("ID: " + maxCTC.Id);
            Console.WriteLine("Name: " + maxCTC .Name);
            Console.WriteLine("CTC: " + maxCTC.CTC);


            //Employess name based on the alphabetical order
            var names = xmlDoc.Descendants("Employee")
                                  .Select(e => (string)e.Element("Name"))
                                  .OrderBy(n => n);
            Console.WriteLine("===============================================================================");
            Console.WriteLine("Employee names in alphabetical order:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }


            // Employee who has maximum years of experience
            var maxExperience = xmlDoc.Descendants("Employee")
                                              .Select(e => new {
                                                  Id = (int)e.Element("Id"),
                                                  Name = (string)e.Element("Name"),
                                                  doj = (DateTime)e.Element("DOJ")
                                              })
                                              .OrderBy(e => e.doj)
                                              .FirstOrDefault();

            // Display the details of the employee with the maximum years of experience
            Console.WriteLine("=================================================================================");
            Console.WriteLine("Employee with maximum years of experience:");
            Console.WriteLine("ID: " + maxExperience.Id);
            Console.WriteLine("Name: " + maxExperience.Name);
            
                
            Console.WriteLine("Date of joining: "+maxExperience.doj);
            Console.WriteLine("date now: " + DateTime.Now);

            int exp = DateTime.Now.Year - maxExperience.doj.Year;
            Console.WriteLine("Experience: " + exp);

            // Age difference between the youngest and the next youngest employee
            var ageDiff = xmlDoc.Descendants("Employee")
                                      .Select(e => new
                                      {
                                          Age = (int)e.Element("Age")
                                      }).OrderBy(e => e.Age)
                                        .Take(2);
            int diff = ageDiff.Last().Age - ageDiff.First().Age;
            Console.WriteLine("==================================================================================");
            Console.WriteLine("The age difference between the youngest and the next youngest employee: "+diff);


        }
    }
}
