using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ImportExcel.Models;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;

namespace ImportExcel.Data
{
    public class ImportExcelContext : DbContext
    {
        public ImportExcelContext(DbContextOptions<ImportExcelContext> options)
            : base(options)
        {
        }

        public DbSet<ImportExcel.Models.StudentList> StudentList { get; set; } = default!;

        //private readonly IConfiguration _configuration;
        //private readonly string connectionstring;

        //public ImportExcelContext(IConfiguration configuration)
        //{
        //    this._configuration = configuration;
        //    this.connectionstring = this._configuration.GetConnectionString("ImportExcelContext");
        //}
        //public IDbConnection CreateConnection() => new SqlConnection(connectionstring);
    }
}
