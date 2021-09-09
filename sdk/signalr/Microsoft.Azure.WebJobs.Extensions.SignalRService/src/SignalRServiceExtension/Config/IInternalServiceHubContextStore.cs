// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.SignalR;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal interface IInternalServiceHubContextStore : IServiceHubContextStore
    {
        AccessKey[] AccessKeys { get; }
    }
}