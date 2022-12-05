using Student_Mark_System.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Mark_System.Models
{
    public class StudentsMark
    {
        #region MarkList
        public List<GetStudentData> StudentList()
        {
            List<GetStudentData> studentData = new List<GetStudentData>();
            using (var Entity = new Student_DetailsEntities2())
            {
                var GetMarks = Entity.Student_Records.Where(x => !x.Is_Deleted).ToList();
                if (GetMarks.Count() > 0)
                {
                    foreach (var item in GetMarks)
                    {
                        GetStudentData StudentMark = new GetStudentData();
                        StudentMark.Student_Id = item.Student_Id;
                        StudentMark.Roll_No = item.Roll_No;
                        StudentMark.Name = item.Name;
                        StudentMark.Tamil = item.Tamil;
                        StudentMark.English = item.English;
                        StudentMark.Maths = item.Maths;
                        StudentMark.Science = item.Science;
                        StudentMark.Social = item.Social;
                        StudentMark.Total = item.Total;
                        StudentMark.Avarge = item.Avarge;
                        studentData.Add(StudentMark);
                    }
                }
            }

                return studentData;
        }
        #endregion

        #region Add and edit student marks
        public GetStudentData AddandEdit(int? studentId)
        {
            
            GetStudentData studentData = new GetStudentData();
            
            if (studentId != null && studentId > 0)
            {
                using (var Entity = new Student_DetailsEntities2())
                {
                    var StudentMarks = Entity.Student_Records.Where(x => x.Student_Id == studentId && !x.Is_Deleted).SingleOrDefault();
                    if (StudentMarks != null)
                    {
                        studentData.Student_Id = StudentMarks.Student_Id;
                        studentData.Roll_No = StudentMarks.Roll_No;
                        studentData.Name = StudentMarks.Name;
                        studentData.Tamil = StudentMarks.Tamil;
                        studentData.English = StudentMarks.English;
                        studentData.Maths = StudentMarks.Maths;
                        studentData.Science = StudentMarks.Science;
                        studentData.Social = StudentMarks.Science;                        
                    }                                    
                }               
            }
            return studentData;
        }
        public GetStudentData SaveStudentResult(GetStudentData studentData)
        {
            if (studentData != null)
            {
                using (var Entity = new Student_DetailsEntities2())
                {
                    bool isRecordExist = false;
                    Student_Records studentRecords = null;
                    studentRecords = Entity.Student_Records.Where(x => x.Student_Id == studentData.Student_Id && !x.Is_Deleted).SingleOrDefault();
                    if (studentRecords != null)
                    {
                        isRecordExist = true;
                    }
                    else
                    {
                        studentRecords = new Student_Records();
                    }
                    studentRecords.Roll_No = studentData.Roll_No;
                    studentRecords.Name = studentData.Name;
                    studentRecords.Tamil = studentData.Tamil;
                    studentRecords.English = studentData.English;
                    studentRecords.Maths = studentData.Maths;
                    studentRecords.Science = studentData.Science;
                    studentRecords.Social = studentData.Social;
                    studentRecords.Total = studentData.Tamil + studentData.English + studentData.Maths + studentData.Science + studentData.Social;
                    studentRecords.Avarge = (studentRecords.Total / 5);
                    studentRecords.Updated_Time_Stamp = DateTime.Now;
                    if (!isRecordExist)
                    {
                        studentRecords.Created_Time_Stamp = DateTime.Now;
                        Entity.Student_Records.Add(studentRecords);
                    }
                    Entity.SaveChanges();                   
                }
            }
            return studentData;
        }
        #endregion

        #region Delete mark deatails
        public GetStudentData DeleteMarks(int studentId)
        {
            GetStudentData Data = new GetStudentData();
            if (studentId > 0)
            {
                using (var Entity = new Student_DetailsEntities2())
                {
                    var marksDelete = Entity.Student_Records.Where(x => x.Student_Id == studentId).SingleOrDefault();
                    marksDelete.Is_Deleted = true;
                    Entity.SaveChanges();
                }
            }
            return Data;
        }
        #endregion
    }
}