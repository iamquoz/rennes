using coursedb.Data.db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course.Data
{
	public class ClientsService
	{
		private readonly CoursedbContext _context;

		public ClientsService(CoursedbContext context)
		{
			_context = context;
		}

		public async Task<List<Clients>> GetClientsAsync()
		{
			return await _context.Clients.ToListAsync();
		}

		public Task<Clients> CreateClient(Clients client)
		{
			_context.Clients.Add(client);
			_context.SaveChanges();
			return Task.FromResult(client);
		}

		public Task<bool> EditClient(Clients client)
		{
			var editing = _context.Clients.Where(e => e.Clientid == client.Clientid).FirstOrDefault();
			if (editing != null)
			{
				editing.Clientname = client.Clientname;
				_context.SaveChanges();
				return Task.FromResult(true);
			}
			else
				return Task.FromResult(false);
		}
	}

	public class TypesService
	{
		private readonly CoursedbContext _context;

		public TypesService(CoursedbContext context)
		{
			_context = context;
		}

		public async Task<List<Types>> GetTypesAsync()
		{
			return await _context.Types.ToListAsync();
		}

		public Task<Types> CreateType(Types type)
		{
			_context.Types.Add(type);
			_context.SaveChanges();
			return Task.FromResult(type);
		}

		public Task<bool> EditType(Types type)
		{
			var editing = _context.Types.Where(e => e.Typeid == type.Typeid).FirstOrDefault();
			if (editing != null)
			{
				editing.Typename = type.Typename; 
				editing.Price = type.Price;
				editing.Billedper = type.Billedper;
				_context.SaveChanges();
				return Task.FromResult(true);
			}
			else 
				return Task.FromResult(false);
		}
	}

	public class OrdersService
	{
		private readonly CoursedbContext _context;

		public OrdersService(CoursedbContext context)
		{
			_context = context;
		}

		public async Task<List<Orders>> GetTypesAsync()
		{
			return await _context.Orders.ToListAsync();
		}

		public Task<Orders> CreateOrder(Orders order)
        {
			_context.Orders.Add(order);
			_context.SaveChanges();
			return Task.FromResult(order);
        }

		public Task<bool> EditOrder(Orders order)
        {
			var editing = _context.Orders.Where(e => e.Orderid == order.Orderid).FirstOrDefault();
			if (editing != null)
			{
				editing.Clientid = order.Clientid;
				editing.Startdate = order.Startdate;
				editing.Enddate = order.Enddate;
				editing.Eff = order.Eff;
				_context.SaveChanges();
				return Task.FromResult(true);
			}
			else
				return Task.FromResult(false);
        }
	}
}
