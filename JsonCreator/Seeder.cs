using FizzWare.NBuilder;
using Provider.Model.TaskInformation;
using Provider.Model.Usernformation;
using System.Collections.Generic;
using System.Linq;

namespace JsonCreator
{
    /// <summary>
    /// Create mock data for provided data models
    /// Uses NBuilder to create mock collections and Faker to get realistic data
    /// </summary>
    static class Seeder
    {
        /// <summary>
        /// Get a list of mock objects for the given type
        /// </summary>
        /// <typeparam name="T">Model type to mock</typeparam>
        /// <param name="size">Number of mock objects needed</param>
        /// <returns>A list of mock objects</returns>
        public static List<T> GetListOf<T>(int size)
        {
            var data = Builder<T>.CreateListOfSize(size).Build().ToList();
            return data;
        }

        /// <summary>
        /// Get a mock object for the given type
        /// </summary>
        /// <typeparam name="T">Model type to mock</typeparam>
        /// <returns>A mocked object</returns>
        public static T GetObjectOf<T>() {
            var data = Builder<T>.CreateNew().Build();
            return data;
        }

        /// <summary>
        /// Get a list of mock TaskInformation objects
        /// </summary>
        /// <param name="size">Number of TaskInformation objects needed</param>
        /// <returns>A list of TaskInformation objects</returns>
        public static List<TaskInformation> GetTaskInformationList(int size)
        {
            var data = Builder<TaskInformation>.CreateListOfSize(size)
                .All()
                .With(x => x.Name = Faker.TextFaker.Sentence())
                .With(x => x.Description = Faker.TextFaker.Sentences(3))
                .With(x => x.ItsNumber = Faker.NumberFaker.Number())
                .With(x => x.StartDate = Faker.DateTimeFaker.DateTimeBetweenYears(2, 1))
                .With(x => x.EndDate = Faker.DateTimeFaker.DateTimeBetweenYears(1, 2))
                .With(x => x.AngularDeveloperName = Faker.NameFaker.Name())
                .With(x => x.CSharpDeveloperName = Faker.NameFaker.Name())
                .With(x => x.DbDeveloperName = Faker.NameFaker.Name())
                .With(x => x.QaPersonName = Faker.NameFaker.Name())
                .Build().ToList();
            return data;
        }

        /// <summary>
        /// Get a list of mock UserInformation objects
        /// </summary>
        /// <param name="size">Number of UserInformation objects needed</param>
        /// <returns>A list of UserInformation objects</returns>
        public static List<UserInformation> GetUserInformationList(int size)
        {
            var data = Builder<UserInformation>.CreateListOfSize(size)
                .All()
                .With(x => x.Id = Faker.NumberFaker.Number())
                .With(x => x.Name = Faker.NameFaker.Name())
                .With(x => x.Type = (int)Faker.EnumFaker.SelectFrom<ResourceType>())
                .Build().ToList();
            return data;
        }
    }
}
