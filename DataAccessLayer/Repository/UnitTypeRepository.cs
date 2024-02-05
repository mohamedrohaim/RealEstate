using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class UnitTypeRepository : Repository<UnitType>, IUnitTypeRepository
	{
		public UnitTypeRepository(AppDbContext context) : base(context)
		{
		}
	}
}
