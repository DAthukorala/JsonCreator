using Provider.Model.Common;
using Provider.Model.TaskInformation;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Utilities;

namespace Provider.Repository
{
    public class TaskInformationRepository : ICrudRepository<TaskInformation>
    {
        public List<TaskInformation> GetAll()
        {
            var json = JsonFileUtilities.ReadData("TaskInformation");
            var data = JsonSerializer.Deserialize<List<TaskInformation>>(json, JsonFileUtilities.SerializerOptions);
            return data;
        }

        public CudResponse Create(TaskInformation task)
        {
            try
            {
                var allTasks = GetAll();
                allTasks.Add(task);
                JsonFileUtilities.WriteToFile<TaskInformation>("TaskInformation", allTasks);
                return new CudResponse { Id = 0, Status = 0 };
            }
            catch
            {
                return new CudResponse { Id = 1, Status = -1 };
            }
        }

        public CudResponse Update(TaskInformation task)
        {
            try
            {
                var allTasks = GetAll();
                //find and replace the old task object with the new one and recreate the file
                var oldTask = allTasks.FirstOrDefault(x => x.Id == task.Id);
                var index = allTasks.IndexOf(oldTask);
                if (index != -1)
                {
                    allTasks[index] = task;
                }
                JsonFileUtilities.WriteToFile<TaskInformation>("TaskInformation", allTasks);
                return new CudResponse { Id = 0, Status = 0 };
            }
            catch
            {
                return new CudResponse { Id = 2, Status = -1 };
            }
        }

        public CudResponse Delete(int id)
        {
            try
            {
                var allTasks = GetAll();
                //remove the task object with the provided id and recreate the file
                allTasks = allTasks.Where(x => x.Id != id).ToList();
                JsonFileUtilities.WriteToFile<TaskInformation>("TaskInformation", allTasks);
                return new CudResponse { Id = 0, Status = 0 };
            }
            catch (System.Exception ex)
            {
                return new CudResponse { Id = 2, Status = -1 };
            }
        }
    }
}
