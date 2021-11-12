using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Models;
using MyDB.DbOperation;

namespace TaskMVC11.Content
{
    public class HomeController : Controller
    {
        StudentRepository repository = null;
        public HomeController()
        {
            repository = new StudentRepository();
        }
        // GET: Home
        public ActionResult Create()
        {
            var list = new List<string>() { "Male", "Female", "Transgender" };
            ViewBag.list = list;
            var list1 = new List<string>() { "India", "Afghanistan", "Albania", "Algeria", "Bangladesh", "Austria" };
            ViewBag.list1=list1;
            return View();
        }
        [HttpPost]
        public ActionResult Create(RegStudent model)
        {

            if (ModelState.IsValid)
            {
                int Id=repository.AddStudent(model);
                if(Id>0)
                {
                    ModelState.Clear();
                    ViewBag.Issuccess = "Data Added";
                }


            }
            return View();
        }

        public ActionResult getallStudents()
        {
            var list = new List<string>() { "Male", "Female", "Transgender" };
            ViewBag.List = list;
            var list1 = new List<string>() {"India", "Afghanistan", "Albania", "Algeria", "Bangladesh", "Austria" }; 
            var result = repository.getallStudents();
            return View(result);
        }
        public ActionResult Details(int Id)

        {
            var students = repository.getStudent(Id);
            return View(students);

        }
        public ActionResult Edit(int Id)

        {
            var students = repository.getStudent(Id);
            return View(students);

        }
        [HttpPost]
        public ActionResult Edit(RegStudent model)

        {
            if(ModelState.IsValid)
            {
                repository.UpdateStudent(model.Id, model);
                return RedirectToAction("getallStudents");
            }
            return View();

        }
        
        public ActionResult Delete(int Id)
        {
            repository.DeleteStudent(Id);
            return RedirectToAction("getallStudents");
        }



    }
}