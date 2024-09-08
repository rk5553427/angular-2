using Employee_Angular_WebAPI_2.Data;
using Employee_Angular_WebAPI_2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Angular_WebAPI_2.Controllers
{
  [Route("api/employee")]
  [ApiController]
  public class EmployeeController : Controller
  {
    private readonly ApplicationDbContext _context;
    public EmployeeController(ApplicationDbContext context)
    {
      _context = context;
    }
    [HttpGet]
    public IActionResult GetEmployee()
    {
      return Ok(_context.Employees.ToList());
    }
    [HttpPost]
    public IActionResult SaveEmployee([FromBody]Employee employee)
    {
      if(employee == null) return NotFound();
      if(!ModelState.IsValid) return BadRequest(ModelState);
      _context.Employees.Add(employee);
      _context.SaveChanges();
      return Ok();
    }
    [HttpPut]
    public IActionResult UpdateEmployee([FromBody]Employee employee)
    {
      if(employee == null) return NotFound();
      if(!ModelState.IsValid) return BadRequest(ModelState);
      _context.Employees.Update(employee);
      _context.SaveChanges();
      return Ok();
    }
    [HttpDelete("{id:int}")]
    public IActionResult DeleteEmployee(int id)
    {
      var employeeInDb = _context.Employees.Find(id);
      if(employeeInDb == null) return NotFound();
      _context.Employees.Remove(employeeInDb);
      _context.SaveChanges();
      return Ok();
    }
  }
}
