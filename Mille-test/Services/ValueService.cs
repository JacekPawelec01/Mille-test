using Mille_test.Models;

namespace Mille_test.Services
{
    public class ValueService : IValueService
    {
        private static List<SimpleModel> _sampleData;

        public ValueService()
        {
            if (!(_sampleData?.Count > 0))
            {
                _sampleData = new List<SimpleModel>()
                {
                    new SimpleModel {Id = 1, Name = "first" },
                    new SimpleModel {Id = 2, Name = "second" }
                };
            }
        }

        public void Delete(int id)
        {
            var toDelete = GetById(id);
            _sampleData.Remove(toDelete);
        }

        public List<SimpleModel> GetAll()
        {
            return _sampleData;
        }

        public SimpleModel GetById(int id)
        {
            var result = _sampleData.Where(v => v.Id == id).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentOutOfRangeException("id");
            }
            return result;
        }

        public void Insert(SimpleModel model)
        {
            model.Id = _sampleData.Max(v => v.Id) + 1;
            _sampleData.Add(model);
        }

        public void Update(int id, SimpleModel model)
        {
            var toUpdate = GetById(id);
            toUpdate.Name = model.Name;
            toUpdate.Description = model.Description;
        }
    }
}
