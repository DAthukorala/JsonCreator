using System;

namespace Provider.Model.TaskInformation
{
    public class TaskInformation
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItsNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? AngularDeveloperId { get; set; }
        public string AngularDeveloperName { get; set; }
        public int? CSharpDeveloperId { get; set; }
        public string CSharpDeveloperName { get; set; }
        public int? DbDeveloperId { get; set; }
        public string DbDeveloperName { get; set; }
        public int? QaPersonId { get; set; }
        public string QaPersonName { get; set; }
    }
}
