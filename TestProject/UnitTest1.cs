using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Mille_test.Controllers;
using Mille_test.Models;
using Mille_test.Services;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace TestProject
{
    public class Tests
    {
        private ILogger<ValuesController> _logger;
        private IValueService _valueService;
        private ValuesController _valuesController;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<ValuesController>>();
            _valueService = Substitute.For<IValueService>();
            _valuesController = new ValuesController(_valueService, _logger);
        }

        [Test]
        public void Get_Should_Call_GetAll()
        {
            _valuesController.Get();
            _valueService.Received().GetAll();
        }

        [Test]
        public void GetWithId_Should_Call_GetById()
        {
            var id = 1;
            _valuesController.Get(id);
            _valueService.Received().GetById(Arg.Is(id));
        }

        [Test]
        public void Post_Should_Call_Insert()
        {
            var value = new SimpleModel()
            {
                Id = 0,
                Description = "description",
                Name = "name",
            };

            _valuesController.Post(value);
            _valueService.Received().Insert(Arg.Is(value));
        }

        [Test]
        public void Delete_Should_Call_Delete()
        {
            var id = 1;

            _valuesController.Delete(id);
            _valueService.Received().Delete(Arg.Is(id));
        }

        [Test]
        public void Put_Should_Call_Update()
        {
            var id = 1;
            var value = new SimpleModel()
            {
                Id = 0,
                Description = "description",
                Name = "name",
            };

            _valuesController.Put(id, value);
            _valueService.Received().Update(Arg.Is(id), Arg.Is(value));
        }
    }
}