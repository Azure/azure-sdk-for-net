// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.SignalR;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal interface IInternalServiceHubContextStore : IServiceHubContextStore
    {
        AccessKey[] AccessKeys { get; }
    }
}