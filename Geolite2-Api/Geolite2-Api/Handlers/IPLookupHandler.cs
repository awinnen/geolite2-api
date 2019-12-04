using FluentValidation;
using Geolite2_Api.Contracts;
using Geolite2_Api.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Geolite2_Api.Handlers
{
	public class IPLookupHandler : IRequestHandler<IpLookupQuery, IpLookupResponse>
	{
		private readonly IIPLookupService _lookupService;
		private readonly IValidator<IpLookupQuery> _validator;

		public IPLookupHandler(IIPLookupService lookupService, IValidator<IpLookupQuery> validator)
		{
			_lookupService = lookupService;
			_validator = validator;
		}
		public Task<IpLookupResponse> Handle(IpLookupQuery request, CancellationToken cancellationToken)
		{
			var validationResult = _validator.Validate(request);
			if(!validationResult.IsValid)
			{
				throw new ArgumentException(string.Join(",", validationResult.Errors.Select(e => e.ErrorMessage)));
			}
			return _lookupService.PerformIpLookup(request.IpAddress);

		}
	}
}
