// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    // can be removed once the SDK is upgraded to the version that supports the message state
    enum ServiceBusMessageState
    {
        Active = 0,
        Deferred = 1,
        Scheduled = 2,
    }
}