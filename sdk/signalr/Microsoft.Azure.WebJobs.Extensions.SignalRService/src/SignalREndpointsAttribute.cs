// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class SignalREndpointsAttribute : Attribute
    {
        public string ConnectionStringSetting { get; set; } = Constants.AzureSignalRConnectionStringName;

        [AutoResolve]
        public string HubName { get; set; }
    }
}