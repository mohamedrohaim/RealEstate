using DataAccessLayer.Models;
using DataAccessLayer.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.IServices
{
	public interface IUnitTypeService
	{
		public Task<IEnumerable<UnitType>> GetUnitTypes();
		public Task<UnitType?> GetUnitAync(Expression<Func<UnitType,bool>> expression);
		public Task<UnitType> CreateAsync(UnitType unitType);
		public Task Delete(UnitType unitType);
		public Task Update(UnitType unitType);
	}
	
}
