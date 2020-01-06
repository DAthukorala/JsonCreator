using Provider.Model.Common;
using Provider.Model.Usernformation;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Utilities;

namespace Provider.Repository
{
    public class UserInformationRepository : ICrudRepository<UserInformation>
    {
        public List<UserInformation> GetAll()
        {
            var json = JsonFileUtilities.ReadData("UserInformation");
            var data = JsonSerializer.Deserialize<List<UserInformation>>(json, JsonFileUtilities.SerializerOptions);
            return data;
        }

        public CudResponse Create(UserInformation user)
        {
            try
            {
                var allUsers = GetAll();
                allUsers.Add(user);
                JsonFileUtilities.WriteToFile<UserInformation>("UserInformation", allUsers);
                return new CudResponse { Id = 0, Status = 0 };
            }
            catch
            {
                return new CudResponse { Id = 1, Status = -1 };
            }
        }

        public CudResponse Update(UserInformation user)
        {
            try
            {
                var allUsers = GetAll();
                //find and replace the old user information object with the new one and recreate the file
                var oldUser = allUsers.FirstOrDefault(x => x.Id == user.Id);
                var index = allUsers.IndexOf(oldUser);
                if (index != -1)
                {
                    allUsers[index] = user;
                }
                JsonFileUtilities.WriteToFile<UserInformation>("UserInformation", allUsers);
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
                var allUsers = GetAll();
                //remove the user information object with the provided id and recreate the file
                allUsers.RemoveAll(x => x.Id == id);
                JsonFileUtilities.WriteToFile<UserInformation>("UserInformation", allUsers);
                return new CudResponse { Id = 0, Status = 0 };
            }
            catch
            {
                return new CudResponse { Id = 2, Status = -1 };
            }
        }
    }
}
