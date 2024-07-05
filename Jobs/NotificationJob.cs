using ImportExcel.Controllers;
using Quartz;
using Microsoft.AspNetCore.Mvc;
using ImportExcel.Data;

namespace ImportExcel.Jobs
{
    public class NotificationJob : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            //StudentListsController obj = new StudentListsController();
            //obj.UpdateDatabase();

            Console.WriteLine($"Notify user at {DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}