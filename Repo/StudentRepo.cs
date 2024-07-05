using ImportExcel.Data;
using ImportExcel.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace ImportExcel.Repo
{
    public class StudentRepo: ControllerBase, IStudentRepo
    {
        private static ImportExcelContext _context;

        public StudentRepo(ImportExcelContext context)
        {
            _context = context;
        }

        public StudentRepo()
        {
        }

        public async Task<List<StudentList>> UpdateDatabase()
        {
            var pathfile = "D:\\Learning\\c#\\ImportExcel\\Assests\\studentList.xlsx";
            var studentList = new List<StudentList>();

            try
            {
                using (var package = new ExcelPackage(new FileInfo(pathfile)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (int.TryParse(worksheet.Cells[row, 1].Value?.ToString(), out int stuId) &&
                            int.TryParse(worksheet.Cells[row, 3].Value?.ToString(), out int standard))
                        {
                            DateTime dobDateTime;
                            if (DateTime.TryParse(worksheet.Cells[row, 5].Value?.ToString(), out dobDateTime))
                            {
                                studentList.Add(new StudentList
                                {
                                    stuId = stuId,
                                    name = worksheet.Cells[row, 2].Value?.ToString().Trim(),
                                    standard = standard,
                                    phone = worksheet.Cells[row, 4].Value?.ToString().Trim(),
                                });
                                Console.WriteLine(studentList.Last().name);
                            }
                            else
                            {
                                Console.WriteLine($"Failed to parse date on row {row}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Failed to parse student ID or standard on row {row}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error accessing Excel file: " + ex.Message);
            }

            return studentList;
        }
    }
}
