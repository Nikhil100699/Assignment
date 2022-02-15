using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        AssignmentEntities obj = new AssignmentEntities();


        public ActionResult Index()
        {
            var obj1 = obj.Assignment.ToList();
            return View(obj1);
        }
        [HttpGet]
        public ActionResult Add(int? Id)
        {

            AssignmentVM objmodel = new AssignmentVM();
            var data = obj.Assignment.Where(x => x.Id == Id).FirstOrDefault();
            if(data!=null)
            {
                objmodel.FirstName = data.FirstName;
                objmodel.LastName = data.LastName;
                objmodel.ClassName = data.ClassName;
                objmodel.Percentage = data.Percentage;
                objmodel.RollNo = data.RollNo;
            }

            return View(objmodel);
        }
        [HttpPost]
        public ActionResult Add(AssignmentVM objAsign)
        {
            Assignment asgntbl = new Assignment();
            var data = obj.Assignment.Where(x => x.Id == objAsign.Id).FirstOrDefault();
            if (data != null)
            {
                data.Id = objAsign.Id;
                data.FirstName = objAsign.FirstName;
                data.LastName = objAsign.LastName;
                data.ClassName = objAsign.ClassName;
                data.Percentage = objAsign.Percentage;
                data.RollNo = objAsign.RollNo;
                obj.SaveChanges();
                TempData["message"] = "Data added";
                return RedirectToAction("Index");
            }
            else
            {

                asgntbl.FirstName = objAsign.FirstName;
                asgntbl.LastName = objAsign.LastName;
                asgntbl.ClassName = objAsign.ClassName;
                asgntbl.Percentage = objAsign.Percentage;
                asgntbl.RollNo = objAsign.RollNo;
                obj.Assignment.Add(asgntbl);
                obj.SaveChanges();
                return RedirectToAction("Index");

            }
        }


        public ActionResult Delete(int ID)
        {
            var Result = obj.Assignment.Where(x => x.Id == ID).FirstOrDefault();
            obj.Assignment.Remove(Result);
            return RedirectToAction("Index");
        }
    }
}