using Microsoft.AspNetCore.Mvc;
using UPB.CoreLogic.Managers;
using UPB.CoreLogic.Models;

namespace UPB.PracticeTwo.Controllers;

[ApiController] // Atributtes
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly StudentManager _studentManager;

    public StudentController(StudentManager studentManager)
    {
        _studentManager = studentManager;
    }

    [HttpGet]
    public List<Student> Get()
    {
         return _studentManager.GetAll();
    }

    [HttpGet]
    [Route("{id}")]
    public Student GetById([FromRoute] int id)
    {
       return _studentManager.GetById(id);
    }

    [HttpPut]
    [Route("{id}")]
    public Student Put([FromRoute]int id, [FromBody]Student studentToUpdate)
    {
       return _studentManager.Update(id);
    }

    [HttpPost]
    public Student Post([FromBody]Student studentToCreate)
    {
       return _studentManager.Create(studentToCreate.Name, studentToCreate.Age, studentToCreate.CI);
    }

    [HttpDelete]
    [Route("{id}")]
    public Student Delete([FromRoute] int id)
    {
       return _studentManager.Delete(id);
    }
}
