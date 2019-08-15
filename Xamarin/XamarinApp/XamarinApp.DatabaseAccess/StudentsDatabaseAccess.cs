using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinApp.Models;

namespace XamarinApp.DatabaseAccess
{
    public class StudentsDatabaseAccess:IDisposable
    {
        public void Dispose()
        {
            
        }

        /// <summary>
        /// Get Students data
        /// </summary>
        /// <returns></returns>
        public async Task<StudentsDTO> Get_Students_Async()
        {
            StudentsDTO studentsData = new StudentsDTO { Students = new List<Student>() };
            studentsData.Students = await (await DatabaseConnection.GetSqlConnectionAsync()).Table<Student>().ToListAsync();
            studentsData.ErrorCode = "OK";
            return studentsData;
        }

        /// <summary>
        /// Get Student data
        /// </summary>
        /// <param name="studentId">student Id</param>
        /// <returns></returns>
        public async Task<Student> Get_Student_Async(Student studenData)
        {
            studenData =  await (await DatabaseConnection.GetSqlConnectionAsync()).Table<Student>().FirstOrDefaultAsync(x => x.StudentId == studenData.StudentId);
            studenData.ErrorCode = "OK";
            return studenData;
        }

        /// <summary>
        /// Save Student Data
        /// </summary>
        /// <param name="student">Student Data to be saved</param>
        /// <returns></returns>
        public async Task Save_Student_Async(Student student)
        {
            await (await DatabaseConnection.GetSqlConnectionAsync()).RunInTransactionAsync(transaction =>
            {
                var studentData = transaction.FindWithQuery<Student>($"SELECT * FROM Student WHERE StudentId = ?", student.StudentId);
                if (studentData == null)
                {
                    studentData = student;
                    studentData.AddedOn = DateTime.Now;
                }
                else
                {
                    studentData.TotalFees = student.TotalFees;
                    studentData.FeesBalance = student.FeesBalance;
                    studentData.Class = student.Class;
                    studentData.Age = student.Age;
                }
                studentData.ModifiedOn = DateTime.Now;
                transaction.InsertOrReplace(studentData);
            });
            student.ErrorCode = "OK";
            return;
        }
    }
}
