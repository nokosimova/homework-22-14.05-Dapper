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


    }
}
