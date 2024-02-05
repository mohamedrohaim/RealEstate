using DataAccessLayer.Data;
using DataAccessLayer.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext _context;
		internal DbSet<T> dbSet;

		public Repository(AppDbContext context)
		{
			_context = context;
			this.dbSet = _context.Set<T>();

		}
		public async Task AddAsync(T entity)
		{
			await dbSet.AddAsync(entity);
			
		}

		public void Delete(T entity)
		{
			dbSet.Remove(entity);
		}

		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includePropererities = null)
		{
			IQueryable<T> query = dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			if (includePropererities != null)
			{
				foreach (var includeProp in includePropererities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			var result=await query.ToListAsync();
			return result;
		}

		public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includePropererities = null)
		{
			IQueryable<T> query = dbSet;
			if (includePropererities != null)
			{
				foreach (var includeProp in includePropererities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					if (includeProp.Contains("."))
					{
						string[] nestedProperties = includeProp.Split('.');
						var currentQuery = query;
						foreach (var nestedProp in nestedProperties)
						{
							currentQuery = currentQuery.Include(nestedProp);
						}
					}
					else
					{
						query = query.Include(includeProp);
					}
				}
			}
			query = query.Where(filter);

			var result= await query.FirstOrDefaultAsync();
			return result;
		}

		public void Update(T entity)
		{
			dbSet.Update(entity);

			
		}
	}
}
