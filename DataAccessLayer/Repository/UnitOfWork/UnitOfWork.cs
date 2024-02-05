using DataAccessLayer.Data;
using DataAccessLayer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.UnitOfWork
{
	public class UnitOfWork:IUnitOfWork 
	{
		private readonly AppDbContext _context;
		public UnitOfWork(AppDbContext context)
		{
			_context = context;
			this.unitType = new UnitTypeRepository(_context);

		}


	   public IUnitTypeRepository unitType { get; private set; }


		public void Save()
		{
			_context.SaveChanges();

		}

		void IUnitOfWork.Save()
		{
			throw new NotImplementedException();
		}
	}
}
