using Geolite2_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geolite2_Api.Contracts
{
	public interface IIPLookupService
	{
		Task<IpLookupResponse> PerformIpLookup(string ip);
	}
}
