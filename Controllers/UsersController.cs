using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;

namespace TestWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
	private static List<UserModel> _users =
		[
			new UserModel { FirstName = "Jimmy", LastName = "Seastream", Email = "jimmy@domain.nu" },
			new UserModel { FirstName = "Katrin", LastName = "Seastreeam", Email = "kattis@domain.nu"},
		];

	[HttpGet]
	public IActionResult GetAll()
	{
		return Ok(_users);
	}

	[HttpGet("{id}")]
	public IActionResult GetOne(string id)
	{
		var user = _users.FirstOrDefault(x => x.Id == id);

		if (user != null)
		{
			return Ok(user);	
		}

		return NotFound();
	}

	[HttpPost]
	public IActionResult CreateOne(UserRequestModel model)
	{
		if (ModelState.IsValid)
		{
			var userModel = new UserModel
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email
			};

			return Created("", model);
		}

		return BadRequest(model);
	}
}