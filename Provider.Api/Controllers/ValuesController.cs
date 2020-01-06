using Provider.Model.Common;
using Provider.Model.TaskInformation;
using Provider.Model.Usernformation;
using Provider.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace Provider.Api.Controllers
{
    public class ValuesController : ApiController
    {
        private ICrudRepository<TaskInformation> _taskRepository;
        private ICrudRepository<UserInformation> _userRepository;

        public ValuesController(ICrudRepository<TaskInformation> taskRepository, ICrudRepository<UserInformation> userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public List<TaskInformation> GetDBTaskList(TaskListQuery query)
        {
            var allTasks = _taskRepository.GetAll();
            //TODO: implement proper filtering logic here if needed, for now returning all the tasks in the file
            //var filteredData = allTasks.Where(x => x.Name == query.Name || x.StartDate > query.FromDate || x.EndDate < query.ToDate).ToList();
            var filteredData = allTasks;
            return filteredData;
        }

        [HttpPost]
        public CudResponse InsertDBTaskInformation(TaskInformation task)
        {
            var result = _taskRepository.Create(task);
            return result;
        }
        
        public CudResponse DeleteDBTaskInformation(int id)
        {
            var result = _taskRepository.Delete(id);
            return result;
        }
    }
}
