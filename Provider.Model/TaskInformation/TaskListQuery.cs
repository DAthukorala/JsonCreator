using System;

namespace Provider.Model.TaskInformation
{
    public class TaskListQuery
    {
        public string Name { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
