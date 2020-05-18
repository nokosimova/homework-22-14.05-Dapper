using System;
using Dapper;
using System.Data;
using hw22_Dapper.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace hw22_Dapper.Repositories
{
    class StudentRepository : RepositoryBase<StudentList>
    {
        public StudentRepository():base()
        {}

        public List<StudentList>Read()
        {
            try
            {
                using (IDbConnection con = new SqlConnection(ConnectionString))
                {
                    return con.Query<StudentList>($"select * from {typeof(StudentList).Name?.ToUpper()}").ToList();
                }
            }
            catch (SqlException x)
            {
                Console.WriteLine($"Error:{x.Message}");
                return null;
            }
        }

        public int? Create(StudentList student)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(ConnectionString))
                {
                    string newCommand = $"insert into StudentListVALUES('{student.StudentId}',{student.FirstName}" +
                        $"{student.LastName}, {student.MidName}, {student.BirthDate}, {student.Telephone})";
                    return con.Query<int>(newCommand).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        public int? Update(StudentList student, int Id)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(ConnectionString))
                {
                    string newCommand = $"update StudentList set FisrtName = {student.FirstName}," +                                                              
                                                               $"LastName = {student.LastName}, " +
                                                               $"MidName = {student.MidName}, " +
                                                               $"BirthDate = {student.BirthDate}," +
                                                               $"Telephone = {student.Telephone} " +
                                                               $"where StudentId = {student.StudentId}";
                    return con.Query<int>(newCommand).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error found: {ex.Message}");
                return null;
            }
        }
        public int? Delete(int Id)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(ConnectionString))
                {
                    string newCommand = $"delete from StudentList where StudentId = {Id}";
                    return con.Query<int>(newCommand).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error found: {ex.Message}");
                return null;
            }
        }
    }
}
