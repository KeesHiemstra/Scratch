using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLog.Models
{
	class QLog
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int Count { get; set; }
		public string Comment { get; set; }
	}
}
