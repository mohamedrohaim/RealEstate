using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
	public class UnitTypes:BaseEntity<int>
	{
		public string TypeName { get; set; }
	}
}
