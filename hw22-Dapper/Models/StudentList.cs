using System;
using System.Collections.Generic;
using System.Text;

namespace hw22_Dapper.Models
{
    public partial class StudentList
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Telephone { get; set; }

    }
}
