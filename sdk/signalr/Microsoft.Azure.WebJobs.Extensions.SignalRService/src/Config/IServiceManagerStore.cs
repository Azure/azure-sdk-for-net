// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal interface IServiceManagerStore : IAsyncDisposable, IDisposable
    {
        IInternalServiceHubContextStore GetOrAddByConnectionStringKey(string connectionStringKey);
    }
}