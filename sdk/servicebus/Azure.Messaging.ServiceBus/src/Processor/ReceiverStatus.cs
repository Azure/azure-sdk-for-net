// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Provides status information for a message receiver.
    /// </summary>
    public class ReceiverStatus
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ReceiverStatus()
        {
            CanReceive = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the receiver can currently receive messages.
        /// </summary>
        public bool CanReceive { get; set; }
    }
}
