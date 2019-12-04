using Geolite2_Api.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable

namespace Geolite2_Api.Controllers
{
	[ApiController]
	[Route("")]
	public class IPLookupController: ControllerBase
	{
		private readonly IMediator _mediatr;
		private readonly ILogger<IPLookupController> _logger;

		public IPLookupController(IMediator mediatr, ILogger<IPLookupController> logger)
		{
			_mediatr = mediatr;
			_logger = logger;
		}

		public async Task<IActionResult> Get(string? ip)
		{
			try
			{
				ip ??= Request.HttpContext.Connection.RemoteIpAddress.ToString();
				_logger.LogInformation("Requesting Lookup for " + ip);
				var result = await _mediatr.Send(new IpLookupQuery()
				{
					IpAddress = ip
				});
				return Ok(result);
			}
			catch (ArgumentException ae)
			{
				_logger.LogDebug(ae, "Invalid or malformed request.");
				return BadRequest(ae.Message);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "An Unknown Error occured");
				return new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
