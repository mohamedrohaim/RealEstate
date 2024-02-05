using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includePropererities = null);
		Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includePropererities = null);
		Task AddAsync(T entity);
		void Delete(T entity);
		void Update(T entity);




}
}
