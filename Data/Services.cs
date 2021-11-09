using coursedb.Data.db;
using Microsoft.EntityFrameworkCore;

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
			var a = await _context.Clients.ToListAsync();
			var today = DateTime.Today;
			foreach (var client in a)
			{
				client.OrderCount = _context.Orders.Where(e => e.Clientid == client.Clientid).Count();
				client.HasActive = _context.Orders.Where(e => e.Clientid == client.Clientid && e.Startdate <= today && today <= e.Enddate).Any();
			}
			return a;
		}

		public Task<Clients> CreateClient(string name)
		{
			Clients client = new();
			client.Clientname = name;

			_context.Clients.Add(client);
			_context.SaveChanges();
			return Task.FromResult(client);
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
			var a = await _context.Types.ToListAsync();
			foreach (var t in a)
			{
				t.AvgEff = _context.Orders.Where(e => e.Typeid == t.Typeid && e.Eff != null).Average(e => e.Eff);
			}
			return a;

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

		public async Task<List<Orders>> GetOrdersAsync()
		{
			var a = await _context.Orders.ToListAsync();
			foreach (var o in a)
			{
				o.Client = _context.Clients.Where(e => e.Clientid == o.Clientid).FirstOrDefault();
				o.Type = _context.Types.Where(e => e.Typeid == o.Typeid).FirstOrDefault();
				o.Docs = _context.Docs.Where(e => e.Orderid == o.Orderid).FirstOrDefault();
			}
			return a;
		}

		public Task<Orders> CreateOrder(Orders order)
		{
			_context.Orders.Add(order);
			_context.SaveChanges();
			_context.Docs.Add(new Docs(order.Orderid));

			return Task.FromResult(order);
		}

		public Task<bool> AddDocs(byte[] file, int orderid)
		{
			var editing = _context.Docs.Where(e => e.Orderid == orderid).FirstOrDefault();

			if (editing != null)
			{
				editing.Terms = file;
				_context.SaveChanges();
				return Task.FromResult(true);
			}
			else
				return Task.FromResult(false);
		}

		public Task<bool> SetEff(byte eff, int orderid)
		{
			var editing = _context.Orders.Where(e => e.Orderid == orderid).FirstOrDefault();
			if (editing != null)
			{
				editing.Eff = eff;
				_context.SaveChanges();
				return Task.FromResult(true);
			}
			else
				return Task.FromResult(false);
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
