﻿using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;

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
    }
}
