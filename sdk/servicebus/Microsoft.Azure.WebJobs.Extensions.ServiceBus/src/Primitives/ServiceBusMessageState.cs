// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    enum ServiceBusMessageState
    {
        Active = 0,
        Deferred = 1,
        Scheduled = 2,
    }
}