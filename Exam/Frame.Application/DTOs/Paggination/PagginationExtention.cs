
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs.Paggination
{

    public static class PagginationExtention
	{
		public static PagedList<T> ToPagedList<T>(this IQueryable<T> source,int pageNumber, int pageSize) where T : class
		{
			var count = source.Count();
			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
			PagedList<T> results = new PagedList<T>(items, count, pageNumber, pageSize);
			
			return results;
		}
		
	}
}
