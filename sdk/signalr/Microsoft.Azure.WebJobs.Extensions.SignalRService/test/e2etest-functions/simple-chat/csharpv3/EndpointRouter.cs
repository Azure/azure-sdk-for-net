// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.SignalR;

namespace SimpleChatV3
{
    //router code
    public class EndpointRouter : EndpointRouterDecorator
    {
        public override ServiceEndpoint GetNegotiateEndpoint(HttpContext context, IEnumerable<ServiceEndpoint> endpoints)
        {
            //var location = context.Request.Query["location"].Single();
            return endpoints.First();
        }
    }
}