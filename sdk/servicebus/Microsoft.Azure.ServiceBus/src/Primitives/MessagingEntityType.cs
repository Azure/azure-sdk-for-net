﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    internal enum MessagingEntityType
    {
        Queue = 0,
        Topic = 1,
        Subscriber = 2,
        Filter = 3,
    }
}