// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.SignalR;

namespace SignalRServiceExtension.Tests.Utils
{
    /// <summary>
    /// A Router never throw exceptions even endpoints are offline.
    /// </summary>
    public class TestRouter : EndpointRouterDecorator
    {
        public override ServiceEndpoint GetNegotiateEndpoint(HttpContext context, IEnumerable<ServiceEndpoint> endpoints)
        {
            return endpoints.ElementAt(0);
        }
    }
}