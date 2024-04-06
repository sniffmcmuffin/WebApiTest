using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models;

public class UserRequestModel
{
	[Required(ErrorMessage = "Du måste ange ett gilitigt förnamn")]
	[MinLength(2)]
	public string FirstName { get; set; } = null!;

	[Required(ErrorMessage = "Du måste ange ett gilitigt efternamn")]
	[MinLength(2)]
	public string LastName { get; set; } = null!;

	[Required(ErrorMessage = "Du måste ange en giltig e-post")]
	[EmailAddress]
	public string Email { get; set; } = null!;
}
