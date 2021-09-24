// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public class SignalRAttribute : Attribute
    {
        public string ConnectionStringSetting { get; set; } = Constants.AzureSignalRConnectionStringName;

        [AutoResolve]
        public string HubName { get; set; }
    }
}