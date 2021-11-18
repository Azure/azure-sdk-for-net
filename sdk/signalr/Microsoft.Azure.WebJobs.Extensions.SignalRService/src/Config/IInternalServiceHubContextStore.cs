// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal interface IInternalServiceHubContextStore : IServiceHubContextStore
    {
        AccessKey[] AccessKeys { get; }

        ValueTask<ServiceHubContext<T>> GetAsync<T>(string hubName) where T : class;
    }
}