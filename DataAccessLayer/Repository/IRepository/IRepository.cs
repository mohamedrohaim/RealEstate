﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		T? GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includePropererities = null);
		IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includePropererities = null);
		void Add(T entity);
		void Delete(T entity);
		void Update(T entity);




}
}
