using Microsoft.EntityFrameworkCore;

using QuickLog.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLog.Data
{
	class QLogDbContext : DbContext
	{
		string ConnectString = "Data Source=QLog.db";
		public DbSet<QLog> Logs { get; set; }
	}
}
