﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal interface IEventProcessorFactory
    {
        IEventProcessor CreateEventProcessor();
    }
}
