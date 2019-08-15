using System;
using System.Linq;
using System.Threading.Tasks;
using XamarinApp.DatabaseAccess;
using XamarinApp.Models;

namespace XamarinApp.BusinessLogic
{
    public class StudentBusiness
    {
        public async Task<StudentsDTO> Get_Students_Async()
        {
            StudentsDTO studentsData = new StudentsDTO();
            try
            {
                using (StudentsDatabaseAccess studentDb = new StudentsDatabaseAccess())
                {
                    studentsData =await studentDb.Get_Students_Async();
                }
            }
            catch (Exception ex)
            {
                studentsData.ErrorCode = "Error while Retrieving Data";
            }
            return studentsData;
        }

        public async Task Get_Student_Async(Student studentData)
        {
            try
            {
                using (StudentsDatabaseAccess studentDb = new StudentsDatabaseAccess())
                {
                    await studentDb.Get_Student_Async(studentData);
                }
            }
            catch (Exception ex)
            {
                studentData.ErrorCode = "Error while Retrieving Data";
            }
        }
        public async Task Save_Student_Async(Student student)
        {
            try
            {
                using (StudentsDatabaseAccess studentDb = new StudentsDatabaseAccess())
                {
                    await studentDb.Save_Student_Async(student);
                }
                student.ErrorCode = "Ok";
            }
            catch (Exception ex)
            {
                student.ErrorCode = "Error while Saving Data";
            }
            return;
        }
    }
}
