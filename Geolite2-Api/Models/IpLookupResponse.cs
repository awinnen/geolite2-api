using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geolite2_Api.Models
{
	public class IpLookupResponse
	{
		public bool Success { get; set; }
		public string CountryCode { get; set; }
		public string Attribution { get; set; }
	}
}
