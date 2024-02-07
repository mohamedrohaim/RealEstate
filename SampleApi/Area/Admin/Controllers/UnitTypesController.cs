using AutoMapper;
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
		private readonly IMapper _mapper;
		public UnitTypesController(IUnitTypeService unitTypeService, IMapper mapper)
		{
			_unitTypeService = unitTypeService;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetUnitTypes() {

			return Ok(await _unitTypeService.GetUnitTypes());
		}

		[HttpPost]
		public async Task<IActionResult> CreateUnitType(UnitTypeDto unitTypeDto) {

			if (ModelState.IsValid) {
				var unitType = await _unitTypeService.CreateAsync(_mapper.Map<UnitTypeDto, UnitType>(unitTypeDto));
				return Ok(unitType);
			}
			return BadRequest();

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUnitType(int id) {

			var unitType = await _unitTypeService.GetUnitAync(U => U.Id == id);
			return unitType == null ? NotFound() : Ok(unitType);


		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUnitType(int id,UnitTypeDto unitTypeDto) {
			if (ModelState.IsValid)
			{
				var unitType = await _unitTypeService.GetUnitAync(U => U.Id == id);
				if(unitType is not null)
				{
					unitType.TypeName= unitTypeDto.TypeName;
					unitType.UpdatedAt = DateTime.UtcNow;
					await _unitTypeService.Update(unitType);
					return Ok();
				}
				return NotFound();
			}
			return BadRequest();


		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUnitType(int id)
		{
			var unitType = await _unitTypeService.GetUnitAync(U => U.Id == id);
			if (unitType is not null)
			{
				_unitTypeService.Delete(unitType);
				return NoContent();
			}
			return NotFound();

		}



	}
}
