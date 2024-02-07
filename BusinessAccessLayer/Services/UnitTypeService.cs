using BusinessAccessLayer.IServices;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
	public class UnitTypeService : IUnitTypeService
	{
		public readonly IUnitOfWork _unitOfWork;
		public UnitTypeService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

		}

		public async Task<UnitType> CreateAsync(UnitType unitType)
		{
			await _unitOfWork.unitType.AddAsync(unitType);
			await _unitOfWork.SaveAsync();
			return unitType;
		}

		public async Task Delete(UnitType unitType)
		{

			_unitOfWork.unitType.Delete(unitType);
			await _unitOfWork.SaveAsync();
		}

		public async Task<UnitType?> GetUnitAync(Expression<Func<UnitType, bool>> expression)
		{
			var unitType=await _unitOfWork.unitType.GetFirstOrDefaultAsync(expression);
			return unitType;
		}

		public async Task<IEnumerable<UnitType>> GetUnitTypes()
		{
			var unitTypes=await _unitOfWork.unitType.GetAllAsync();
			return unitTypes;
		}

		public async Task Update(UnitType unitType)
		{
			_unitOfWork.unitType.Update(unitType);
			await _unitOfWork.SaveAsync();
		}
			
		
	}
}
