// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.using System;

namespace Microsoft.Azure.EventHubs.ServiceFabricProcessor
{
    /// <summary>
    /// Why the event processor is being shut down.
    /// </summary>
    public enum CloseReason
    {
        /// <summary>
        /// It was cancelled by Service Fabric.
        /// </summary>
        Cancelled,

        /// <summary>
        /// There was an event hubs failure.
        /// </summary>
        Failure
    }
}
