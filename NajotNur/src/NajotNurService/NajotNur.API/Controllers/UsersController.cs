using Microsoft.AspNetCore.Mvc;
using NajotNur.Application.Interfaces.Users;
using NajotNur.Domain.Entities.Users;

namespace NajotNur.API.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
     => Ok(await _service.GetAllAsnyc());

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(User dto)
        => Ok(await _service.CreateAsnyc(dto));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsnyc(int userId, User dto)
        => Ok(await _service.UpdateAsnyc(userId, dto));

    [HttpDelete("{userId}")]
    public async ValueTask<IActionResult> DeleteAsync(int userId)
        => Ok(await _service.DeleteAsnyc(userId));
}
