// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    enum DispositionStatus
    {
        Completed = 1,
        Defered = 2,
        Suspended = 3,
        Abandoned = 4,
        Renewed = 5,
    }
}