using Provider.Model.TaskInformation;
using Provider.Model.Usernformation;
using System;
using Utilities;

namespace JsonCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var isContinue = false;
            do
            {
                PerformDataCreation();
                Console.WriteLine("Continue? Y/N");
                var response = Console.ReadLine();
                isContinue = response.ToUpper() == "Y";
            } while (isContinue);
        }

        public static void PerformDataCreation()
        {
            Console.WriteLine("Please enter a model name to serialize");
            var modelName = Console.ReadLine();

            Console.WriteLine("If you want to build a list, please enter the size, otherwise just press enter");
            var sizeEntered = Console.ReadLine();
            var listSize = 0;
            if (string.IsNullOrWhiteSpace(sizeEntered) || Int32.TryParse(sizeEntered, out listSize))
            {
                Console.WriteLine($"A list will be created for {modelName}");
            }
            else
            {
                Console.WriteLine($"A single object will be created for {modelName}");
            }

            try
            {
                switch (modelName)
                {
                    case "TaskInformation":
                        var taskData = Seeder.GetTaskInformationList(listSize);
                        JsonFileUtilities.WriteToFile<TaskInformation>("TaskInformation", taskData);
                        break;
                    case "UserInformation":
                        var userData = Seeder.GetUserInformationList(listSize);
                        JsonFileUtilities.WriteToFile<UserInformation>("UserInformation", userData);
                        break;
                    case "TaskResult":
                        var taskResultData = Seeder.GetListOf<TaskResult>(listSize);
                        JsonFileUtilities.WriteToFile<TaskResult>("TaskResult", taskResultData);
                        break;
                }
                Console.WriteLine("File Created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
