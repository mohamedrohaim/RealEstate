using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Area.Admin.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UnitTypesController : ControllerBase
	{
		[HttpGet]
		public IActionResult hello() {
			return Ok("Hey i am ok :) ");
		}
	}
}
