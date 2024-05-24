using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcMovie.Data;
using MvcMovie.Models;
using SQLitePCL;
using System.Diagnostics.SymbolStore;
using System.Linq.Expressions;
using MvcMovie.Models.Process;
using X.PagedList;

namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbcontext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();
        public PersonController(ApplicationDbcontext context)
        {
            _context = context;
        }
     public async Task<IActionResult> Index(int? page, int? PageSize)
{
    ViewBag.PageSize = new List<SelectListItem>()
    {
        new SelectListItem() {Value="3", Text= "3"},
        new SelectListItem() {Value="5", Text= "5"},
        new SelectListItem() {Value="10", Text= "10"},
        new SelectListItem() {Value="15", Text= "15"},
        new SelectListItem() {Value="25", Text= "25"},
        new SelectListItem() {Value="50", Text= "50"},
    };
    int pagesize = (PageSize ?? 3);
    ViewBag.psize = pagesize;
    var model = _context.Person.ToList().ToPagedList(page ?? 1, pagesize);
    return View(model);
}
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,Fullname,Address")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,Fullname,Address")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));

            }
            return View(person);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }
            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>    DeleteConfirmed(string id)
        {
            if (_context.Persons == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.Person' is null.");
            } 
            var person  = await _context.Persons.FindAsync(id);  
            if (person != null) 
            {
            _context.Persons.Remove(person);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "plese upload excel!");
                }
                else
                // rename to sever
                {
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to sever
                        await file.CopyToAsync(stream);
                        //read data from excel to file from dt
                        var  dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //using for loop  to read date from dt
                        for (int  i = 0;  i < dt.Rows.Count ;  i++)
                        {
                            //create new  person project 
                            var ps = new Person();
                            //set value attributes
                            ps.PersonID = dt.Rows[i][0].ToString();
                            ps.Fullname = dt.Rows[i][1].ToString();
                            ps.Address = dt.Rows[i][2].ToString();
                            //add object to context
                            _context.Add(ps);
                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));

                    }
                }
            }
            return View();

        }
        private bool PersonExists(string id)
        {
            return (_context.Persons?.Any(e => e.PersonID == id)).GetValueOrDefault();
        }
        [HttpPost]
        public IActionResult Index(Person ps)
        {
            string strOutput = "xin chào" + ps.PersonID + "_" + ps.Fullname + "_" + ps.Address;
            ViewBag.infoPerson = strOutput;
            return View();
        }
          public IActionResult Download()
            {
                        //tên file cần dowload
                    var fileName = "PersonList.xlsx";
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                        excelWorksheet.Cells["A1"].Value = "PersonID";
                        excelWorksheet.Cells["B1"].Value = "FullName";
                        excelWorksheet.Cells["C1"].Value = "Address";
                        //get all person
                        var psList = _context.Person.ToList();
                        //fill data worksheet
                        excelWorksheet.Cells["A2"].LoadFromCollection(psList);
                        var stream = new MemoryStream(excelPackage.GetAsByteArray());
                        //dowload file
                        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                    }
                }  
    }   
}
