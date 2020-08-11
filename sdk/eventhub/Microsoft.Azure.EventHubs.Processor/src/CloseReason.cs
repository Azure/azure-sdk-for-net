// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    /// <summary>
    /// Reason for closing an <see cref="EventProcessorHost"/>.
    /// </summary>
    public enum CloseReason
    {
        /// <summary>
        /// The lease was lost or transitioned to a new processor instance. 
        /// </summary>
        LeaseLost,

        /// <summary>
        /// The <see cref="EventProcessorHost"/> was shutdown.
        /// </summary>
        Shutdown
    }
}