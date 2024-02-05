using BusinessAccessLayer.IServices;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Area.Admin.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UnitTypesController : ControllerBase
	{
		private readonly IUnitTypeService _unitTypeService;
		public UnitTypesController(IUnitTypeService unitTypeService)
		{
			_unitTypeService= unitTypeService;
		}
		[HttpPost]
		public async Task<IActionResult> CreateUnitType(UnitTypeDto unitTypeDto) {
			UnitType unitType = new UnitType() {
				TypeName=unitTypeDto.TypeName,
				CreatedAt=DateTime.UtcNow,
			};
			await _unitTypeService.CreateAsync(unitType);
			
			return Ok();
			
		}
	}
}
