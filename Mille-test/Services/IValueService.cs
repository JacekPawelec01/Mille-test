using Mille_test.Models;

namespace Mille_test.Services
{
    public interface IValueService
    {
        List<SimpleModel> GetAll();
        SimpleModel GetById(int id);
        void Insert(SimpleModel model);
        void Update(int id, SimpleModel model);
        void Delete(int id);

    }
}
