using Geolite2_Api.Contracts;
using Geolite2_Api.Models;
using MaxMind.GeoIP2;
using MaxMind.GeoIP2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geolite2_Api.Services
{
	public class GeoLite2Service : IIPLookupService
	{
		private readonly string _geoLite2DbPath;

		/**
		 * dbPath: Path to maxmind database. Download from https://dev.maxmind.com/geoip/geoip2/geolite2/#MaxMind_APIs
		 */
		public GeoLite2Service(string dbPath)
		{
			_geoLite2DbPath = dbPath;
		}
		public Task<IpLookupResponse> PerformIpLookup(string ip)
		{
			using (var reader = new DatabaseReader(_geoLite2DbPath))
			{
				var result = new IpLookupResponse()
				{
					Attribution = "This product includes GeoLite2 data created by MaxMind, available from https://www.maxmind.com"
				};
				try
				{
					var dbResult = reader.Country(ip);

					result.CountryCode = dbResult.Country.IsoCode;
					result.Success = true;
				}
				catch (AddressNotFoundException)
				{
					result.Success = false;
				}
				catch (GeoIP2Exception)
				{
					result.Success = false;
				}
				return Task.FromResult(result);
			}
		}
	}
}
