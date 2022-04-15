// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal enum HubProtocol
    {
        /// <summary>
        /// Implements the SignalR Hub Protocol using System.Text.Json.
        /// </summary>
        SystemTextJson,

        /// <summary>
        /// Implements the SignalR Hub Protocol using Newtonsoft.Json.
        /// </summary>
        NewtonsoftJson
    }
}