﻿using Exam.Application.IRepository;
using Exam.Domain.Entities;
using Exam.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Exam.Infrastructure.Repository
{

	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		private DbSet<T> entities;
		public Repository(ApplicationDbContext context)
		{
			_context = context;
			entities = context.Set<T>();
		}
		public IEnumerable<T> GetAll()
		{
			return entities.AsEnumerable();
		}
		public void Delete(object id)
		{

			int entityId = (int)id;
			T exist = entities.Find(entityId);
			entities.Remove(exist);
			_context.SaveChanges();
		}



		public T GetById(object id)
		{

			return entities.Find(id);
			//return new FirstClass { id = 1, MyProperty = "dd", Name = "Mohamed" };

		}

		public void Insert(T obj)
		{
			entities.Add(obj);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(T obj)
		{
			_context.ChangeTracker.Clear();
			entities.Attach(obj);
			_context.Entry(obj).State = EntityState.Modified;
			_context.SaveChanges();
		}
		public void DeleteOption(T obj)
		{
			_context.ChangeTracker.Clear();
			_context.Entry(obj).State = EntityState.Deleted;
		}
		public void AddRange(IEnumerable<T> result)
		{
			entities.AddRange(result);
		}

		public void RemoveRange(IEnumerable<T> result)
		{
			entities.RemoveRange(result);
		}
		public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
		{
			return entities.Where(predicate);
		}
		public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = entities;
			if (includes != null)
			{
				foreach (Expression<Func<T, object>> include in includes)
				{
					query = query.Include(include);
				}
			}
			return query;
		}

		public Task<int> DeleteAsync(T entity)
		{
			// If entity is not tracked, attach it to the context
			if (_context.Entry(entity).State == EntityState.Detached)
			{
				_context.Set<T>().Attach(entity);
			}

			// Remove the entity and its related entities with cascading delete
			_context.Set<T>().Remove(entity);
			_context.SaveChanges();
			return null;
		}
		public bool DeleteAsynctrue(T entity)
		{
			// Remove the entity and its related entities with cascading delete
			_context.Set<T>().Remove(entity);
			_context.SaveChanges();
			return true;
		}

		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}


	}
}
