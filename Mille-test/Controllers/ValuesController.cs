using System;
using Microsoft.AspNetCore.Mvc;
using Mille_test.Models;
using Mille_test.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mille_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IValueService _valueService;

        public ValuesController(
                IValueService valueService,
                ILogger<ValuesController> logger
            )
        {
            _valueService = valueService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all existing items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<SimpleModel> Get()
        {
            return _valueService.GetAll();
        }

        /// <summary>
        /// Gets single existing item or throws 404
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public SimpleModel Get(int id)
        {
            try
            {
                return _valueService.GetById(id);
            }
            catch (ArgumentOutOfRangeException e)
            {
                HttpContext.Response.StatusCode = 404;
                HttpContext.Response.Headers.Clear();
                _logger.Log(LogLevel.Error, $"item not found for {id}");
                return null;
            }
        }

        /// <summary>
        /// Inserts a new item
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] SimpleModel value)
        {
            _valueService.Insert(value);
        }

        /// <summary>
        /// Updates existing item or throws 404
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SimpleModel value)
        {
            try
            {
                _valueService.Update(id, value);
            }
            catch (ArgumentOutOfRangeException e)
            {
                HttpContext.Response.StatusCode = 404;
                HttpContext.Response.Headers.Clear();
                _logger.Log(LogLevel.Error, $"item not found for {id}");
            }
        }

        /// <summary>
        /// Deletes existing item or throws 404
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _valueService.Delete(id);
            }
            catch (ArgumentOutOfRangeException e)
            {
                HttpContext.Response.StatusCode = 404;
                HttpContext.Response.Headers.Clear();
                _logger.Log(LogLevel.Error, $"item not found for {id}");
            }
        }
    }
}
