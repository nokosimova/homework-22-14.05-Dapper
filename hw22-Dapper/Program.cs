using System;
using System.Data;
using Dapper;
using hw22_Dapper.Repositories;
using hw22_Dapper.Models;

namespace hw22_Dapper
{
    class Program
    {
        static int id = 10;
        static void Main(string[] args)
        {
            bool act = true;
            while (act)
            {
                Console.Clear();
                //Thread.Sleep(1000);
                Console.WriteLine("Choose command to table StudentList:");
                Console.WriteLine("1 - Create data");
                Console.WriteLine("2 - Read data");
                Console.WriteLine("3 - Update data");
                Console.WriteLine("4 - Delete data");
                Console.WriteLine("5 - Exit");
                var command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        Read();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                    case 5:
                        act = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void Read(object mess = null)
        {
            try
            {
                var list = new StudentRepository().Read();
                foreach (var i in list)
                    Console.WriteLine($"{i.StudentId}|{i.FirstName} {i.LastName} {i.MidName} |{i.BirthDate} |{i.Telephone}");
            }
            catch (Exception x)
            {
                Console.WriteLine($"Fail:{x.Message}");
            }
            finally
            {
                if (mess == null)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        public static void Create()
        {
            try
            {
                StudentList newStud = new StudentList();
                
                Console.Write("Firstname: ");
                newStud.FirstName = Console.ReadLine();

                Console.Write("Lastname");
                newStud.LastName = Console.ReadLine();

                Console.Write("Midname");
                newStud.MidName = Console.ReadLine();

                Console.Write("Day of birth:");
                int day = int.Parse(Console.ReadLine());

                Console.Write("Month:");
                int month = int.Parse(Console.ReadLine());

                Console.Write("Year:");
                int year = int.Parse(Console.ReadLine());

                newStud.BirthDate = new DateTime(year, month, day);

                Console.Write("Telephone: ");
                newStud.Telephone = Console.ReadLine();

                var command = new StudentRepository().Create(newStud);
            }
            catch (Exception x)
            {
                    Console.WriteLine($"Fail:{x.Message}");
            }
            finally
            {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
            }
            }
            public static void Update()
            {
                try
                {
                    Read("tochange");
                    Console.WriteLine("Choose ID to update");
                    var studId = int.Parse(Console.ReadLine());
                    StudentList newStud = new StudentList();
                    Console.Write("Firstname: ");
                    newStud.FirstName = Console.ReadLine();

                    Console.Write("Lastname");
                    newStud.LastName = Console.ReadLine();

                    Console.Write("Midname");
                    newStud.MidName = Console.ReadLine();

                    Console.Write("Day of birth:");
                    int day = int.Parse(Console.ReadLine());

                    Console.Write("Month:");
                    int month = int.Parse(Console.ReadLine());

                    Console.Write("Year:");
                    int year = int.Parse(Console.ReadLine());

                    newStud.BirthDate = new DateTime(year, month, day);

                    Console.Write("Telephone: ");
                    newStud.Telephone = Console.ReadLine();

                    var command = new StudentRepository().Update(newStud,studId);
            }

            catch (Exception x)
                {
                    Console.WriteLine($"Fail:{x.Message}");
                }
                finally
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            public static void Delete()
            {
                try
                {
                    Read("tochange");
                    Console.Write("Choose ID to delete:");
                    var studId = int.Parse(Console.ReadLine());
                    Console.Write("Are you sure? Y(yes)/N(no):");
                    var confirm = Console.ReadLine();
                if (confirm.ToUpper() == "Y")                    
                    if (new StudentRepository().Delete(studId) != null)
                                Console.WriteLine("Data was successfully deleted!");
                            else
                                Console.WriteLine("Fail! Data wasn't deleted!");
                }
                catch (Exception x)
                {
                    Console.WriteLine($"Fail:{x.Message}");
                }
                finally
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

            }
        }
}
