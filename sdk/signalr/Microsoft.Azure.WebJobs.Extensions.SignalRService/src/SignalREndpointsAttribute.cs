// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Attribute used to bind a list of SignalR Service endpoints to the parameter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class SignalREndpointsAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the app setting name that contains the Azure SignalR connection string.
        /// </summary>
        public string ConnectionStringSetting { get; set; } = Constants.AzureSignalRConnectionStringName;

        /// <summary>
        /// Gets or sets the hub name.
        /// </summary>
        [AutoResolve]
        public string HubName { get; set; }
    }
}