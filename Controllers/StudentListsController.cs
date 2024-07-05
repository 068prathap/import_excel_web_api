using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImportExcel.Data;
using ImportExcel.Models;
using OfficeOpenXml;
using System.Globalization;
using ImportExcel.Repo;

namespace ImportExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentListsController : ControllerBase
    {
        private readonly ImportExcelContext _context;
        private readonly IStudentRepo _StudentRepo;

        public StudentListsController(ImportExcelContext context, IStudentRepo StudentRepo)
        {
            _context = context;
            _StudentRepo= StudentRepo;
        }

        public StudentListsController()
        {
        }

        // GET: api/StudentLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentList>>> GetStudentList()
        {
            return await _context.StudentList.ToListAsync();
        }

        // GET: api/StudentLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentList>> GetStudentList(int id)
        {
            var studentList = await _context.StudentList.FindAsync(id);

            if (studentList == null)
            {
                return NotFound();
            }

            return studentList;
        }

        // PUT: api/StudentLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentList(int id, StudentList studentList)
        {
            if (id != studentList.stuId)
            {
                return BadRequest();
            }

            _context.Entry(studentList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentList>> PostStudentList(StudentList studentList)
        {
            _context.StudentList.Add(studentList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentList", new { id = studentList.stuId }, studentList);
        }

        // DELETE: api/StudentLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentList(int id)
        {
            var studentList = await _context.StudentList.FindAsync(id);
            if (studentList == null)
            {
                return NotFound();
            }

            _context.StudentList.Remove(studentList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //public async Task<List<StudentList>> UpdateDatabase()
        //{
        //    var pathfile = "D:\\Learning\\c#\\ImportExcel\\Assests\\studentList.xlsx";
        //    var studentList = new List<StudentList>();

        //    try
        //    {
        //        using (var package = new ExcelPackage(new FileInfo(pathfile)))
        //        {
        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //            var rowCount = worksheet.Dimension.Rows;

        //            for (int row = 2; row <= rowCount; row++)
        //            {
        //                if (int.TryParse(worksheet.Cells[row, 1].Value?.ToString(), out int stuId) &&
        //                    int.TryParse(worksheet.Cells[row, 3].Value?.ToString(), out int standard))
        //                {
        //                    studentList.Add(new StudentList
        //                    {
        //                        stuId = stuId,
        //                        name = worksheet.Cells[row, 2].Value?.ToString().Trim(),
        //                        standard = standard,
        //                        phone = worksheet.Cells[row, 4].Value?.ToString().Trim(),
        //                    });
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"Failed to parse student ID or standard on row {row}");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine("Error accessing Excel file: " + ex.Message);
        //    }

        //    return studentList;
        //}

        private bool StudentListExists(int id)
        {
            return _context.StudentList.Any(e => e.stuId == id);
        }
    }
}