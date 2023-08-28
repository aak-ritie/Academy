using Microsoft.AspNetCore.Mvc;
using System;

namespace BuilderAcademy.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public StudentController(AppDbContext _appDbContext)
        {
            this._appDbContext = _appDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _appDbContext.studentsTable;
            return View(objStudentList);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {

            if (ModelState.IsValid)
            {
                _appDbContext.studentsTable.Add(obj);
                _appDbContext.SaveChanges();
                TempData["success"] = "Student Created sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var StudentFromDb = _appDbContext.studentsTable.Find(id);//Aba once we retrieve the object tyo janxa var wala variable ma
            if (StudentFromDb == null)
            {
                return NotFound();
            }

            return View(StudentFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {

            if (ModelState.IsValid)
            {
                _appDbContext.studentsTable.Update(obj);
                _appDbContext.SaveChanges();
                TempData["success"] = "Student Updated sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var StudentFromDb = _appDbContext.studentsTable.Find(id);//Aba once we retrieve the object tyo janxa var wala variable ma
            if (StudentFromDb == null)
            {
                return NotFound();
            }

            return View(StudentFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _appDbContext.studentsTable.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _appDbContext.studentsTable.Remove(obj);
            _appDbContext.SaveChanges();
            TempData["success"] = "Student Deleted sucessfully";
            return RedirectToAction("Index");


        }
    }
}
