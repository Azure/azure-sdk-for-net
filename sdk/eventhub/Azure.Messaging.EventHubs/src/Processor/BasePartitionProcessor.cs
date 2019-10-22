// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Processes events received from the Azure Event Hubs service.  An instance of this class or of a derived class
    ///   will be created by the associated <see cref="EventProcessor" /> for every partition it owns.  This class does
    ///   not perform any kind of processing by itself and a useful partition processor is expected to be derived from it.
    /// </summary>
    ///
    public abstract class BasePartitionProcessor
    {
    }
}
