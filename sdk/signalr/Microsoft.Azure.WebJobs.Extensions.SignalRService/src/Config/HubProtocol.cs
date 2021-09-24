// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
#if NETCOREAPP3_1
using Microsoft.AspNetCore.SignalR.Protocol;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal enum HubProtocol
    {
        /// <summary>
        /// Implements the SignalR Hub Protocol using System.Text.Json.
        /// <see cref="JsonHubProtocol"/>
        /// </summary>
        SystemTextJson,

        /// <summary>
        /// Implements the SignalR Hub Protocol using Newtonsoft.Json.
        /// <see cref="NewtonsoftJsonHubProtocol "/>
        /// </summary>
        NewtonsoftJson
    }
}
#endif