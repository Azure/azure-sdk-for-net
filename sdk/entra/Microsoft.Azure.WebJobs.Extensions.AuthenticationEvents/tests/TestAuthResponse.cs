using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using System.Net.Http;
using System.Net;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{

	internal class TestAuthResponse : AuthenticationEventResponse
	{
		internal TestAuthResponse(HttpStatusCode code, string content)
		: this(code)
		{
			Content = new StringContent(content);
		}

		internal TestAuthResponse(HttpStatusCode code)
		{
			StatusCode = code;
		}

		internal override void Invalidate()
		{ }

		internal override void ValidateActions()
		{ }
	}
}
