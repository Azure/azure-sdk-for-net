// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.AspNetCore.Http;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    ///  A configuration abstraction for configuring SignalR connection information
    /// </summary>
    public interface ISignalRConnectionInfoConfigurer
    {
        /// <summary>
        /// Configuring SignalR access token from a given Azure function access token result, http request, SignalR connection detail, and return a new SignalR connection detail for generating access token to access SignalR service.
        /// </summary>
        Func<SecurityTokenResult, HttpRequest, SignalRConnectionDetail, SignalRConnectionDetail> Configure { get; set; }
    }
}