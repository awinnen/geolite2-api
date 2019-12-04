using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geolite2_Api.Models
{
	public class IpLookupQuery: IRequest<IpLookupResponse>
	{
		public string IpAddress { get; set; }
	}

	public class IpLookupQueryValidator: AbstractValidator<IpLookupQuery>
	{
		public IpLookupQueryValidator()
		{
			RuleFor(x => x.IpAddress).NotEmpty().WithMessage("IpAddress cannot be empty");
		}
	}
}
