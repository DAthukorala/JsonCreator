using Provider.Model.Common;
using System.Collections.Generic;

namespace Provider.Repository
{
    public interface ICrudRepository<T>
    {
        List<T> GetAll();
        CudResponse Create(T user);
        CudResponse Update(T user);
        CudResponse Delete(int id);
    }
}
