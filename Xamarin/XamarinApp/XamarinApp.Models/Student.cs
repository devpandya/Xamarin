using SQLite;
using System;

namespace XamarinApp.Models
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int? StudentId { get; set; }
        public string Name { get; set; }
        public string GaurdianName { get; set; }
        public string SchoolName { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public double TotalFees { get; set; }
        public double FeesBalance { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        [Ignore]
        public string ErrorCode { get; set; }
    }
}
