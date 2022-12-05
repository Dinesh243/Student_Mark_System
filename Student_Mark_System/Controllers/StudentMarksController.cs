using Student_Mark_System.Entity;
using Student_Mark_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Mark_System.Controllers
{
    public class StudentMarksController : Controller
    {
        #region Declration for studentMark
        private StudentsMark studentMark = new StudentsMark();
        #endregion

        #region Student Mark List 
        [HttpGet]
        public ActionResult GetStudentRecordList()
        {
            List<GetStudentData> list = new List<GetStudentData>();
            list = studentMark.StudentList();
            return View(list);
        }
        #endregion

        #region Add and Edit Student Result

        [HttpGet]
        public ActionResult Addstudentresult(int? studentId)
        {            
            GetStudentData addEdit = new GetStudentData();
            if(studentId!= null)
            {
                addEdit.Student_Id = (int)studentId;
                addEdit = studentMark.AddandEdit(studentId);
                return View(addEdit);
            }
            return View();
        }
        [HttpPost]
        public ActionResult SaveStudentRresult(GetStudentData studentDetail)
        {           
             studentMark.SaveStudentResult(studentDetail);
            return RedirectToAction("GetStudentRecordList");
        }
        #endregion

        #region Delete the student marks
        public ActionResult DeleteStudentMarks(int studentId)
        {
            studentMark.DeleteMarks(studentId);
            return RedirectToAction("GetStudentRecordList");
        }
        #endregion
    }
}