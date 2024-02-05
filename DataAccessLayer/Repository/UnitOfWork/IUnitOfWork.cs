using DataAccessLayer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.UnitOfWork
{
	public interface IUnitOfWork
	{
		IUnitTypeRepository unitType { get; }
		
		public Task SaveAsync();
	}
}
