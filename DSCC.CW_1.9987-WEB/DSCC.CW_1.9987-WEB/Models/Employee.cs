using System;
using System.ComponentModel;

namespace DSCC.CW_1._9987_WEB.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Position { get; set; }
        [DisplayName("Reports To")]
        public int? ReportsTo { get; set; }
        [DisplayName("Birth Date")]
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
    }
}