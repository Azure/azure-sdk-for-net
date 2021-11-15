// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Configuration options for SignalR extensions.
    /// </summary>
    /// <remarks>
    /// Most properties here can be configured in <see cref="IConfiguration"/>, except JSON serialization.
    /// </remarks>
    public class SignalROptions
    {
        /// <summary>
        /// Gets or sets the service endpoints.
        /// </summary>
        public ServiceEndpoint[] ServiceEndpoints { get; set; }

        /// <summary>
        /// Gets or sets the service transport type.
        /// </summary>
        public ServiceTransportType? ServiceTransportType { get; set; }

        /// <summary>
        /// Use Newtonsoft.Json as the JSON serialization library.
        /// </summary>
        /// <param name="configure">Configure the Newtonsoft Json service hub protocol options.</param>
        public void UseNewtonsoftJson(Action<NewtonsoftServiceHubProtocolOptions> configure)
        {
            NewtonsoftOptionsAction = configure;
        }

        internal Action<NewtonsoftServiceHubProtocolOptions> NewtonsoftOptionsAction { get; set; }
    }
}
