using ImportExcel.Models;

namespace ImportExcel.Repo
{
    public interface IStudentRepo
    {
        Task<List<StudentList>> UpdateDatabase();
    }
}