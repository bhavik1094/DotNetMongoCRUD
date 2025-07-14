using Microsoft.AspNetCore.Mvc;
using TestApp1.Models;
using TestApp1.Services;
using TestApp1.Services;

namespace TestApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeesController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<TestData>> Get()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<TestData> Get(string id)
        {
            var emp = _service.GetById(id);
            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Create(TestData emp)
        {
            try
            {
                _service.Create(emp);
                return Ok(new { message = "Data inserted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to insert data", details = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] TestData emp)
        {
            if (string.IsNullOrEmpty(emp.Id))
                return BadRequest(new { message = "Id is required in the body." });

            var existing = _service.GetById(emp.Id);
            if (existing == null)
                return NotFound();

            _service.Update(emp.Id, emp);
            return Ok(new { message = "Data updated successfully" });
        }
                
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var existing = _service.GetById(id);
                if (existing == null)
                    return NotFound(new { message = "Record not found with the given id." });

                _service.Delete(id);
                return Ok(new { message = "Data deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to delete data", details = ex.Message });
            }
        }

    }
}
