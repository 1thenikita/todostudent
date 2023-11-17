using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoStudent.Server.Services;
using TodoStudent.Shared.EditModels;
using TodoStudent.Shared.ViewModels;

namespace TodoStudent.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private UserService Service;
    private IMapper Mapper;

    public UserController(UserService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<List<UserViewModel>>> GetAll()
    {
        var datas = Service.GetAll().Select(x => Mapper.Map<UserViewModel>(x)).ToList();
        return datas;
    }

    [HttpGet("full")]
    public async Task<ActionResult<List<UserViewModel>>> GetFull()
    {
        var datas = Service.GetAllFull().Select(x => Mapper.Map<UserViewModel>(x)).ToList();
        return Ok(datas);
    }

    // GET: api/User?id=5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserViewModel>> GetByID(Guid id)
    {
        var data = await Service.GetByID(id);
        if (data == null)
        {
            return NotFound();
        }

        return Ok(Mapper.Map<UserViewModel>(data));
    }

    // POST: api/User
    [HttpPost]
    public async Task<ActionResult<UserViewModel>> Create([FromBody] UserEditModel editModel)
    {
        var data = await Service.Create(editModel);
        if (data == null)
        {
            return NotFound();
        }

        return Ok(Mapper.Map<UserViewModel>(data));
    }

    // PUT: api/User/5
    [HttpPut("{id}")]
    public async Task<ActionResult<UserViewModel>> Edit(Guid id, [FromBody] UserEditModel editModel)
    {
        var data = await Service.Update(id, editModel);
        if (data == null)
        {
            return NotFound();
        }

        return Ok(Mapper.Map<UserViewModel>(data));
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var data = await Service.Delete(id);
        return data ? NoContent() : NotFound("Сущность не найдена");
    }
}