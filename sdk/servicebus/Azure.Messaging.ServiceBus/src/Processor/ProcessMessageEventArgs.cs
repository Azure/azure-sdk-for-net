// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    public class ProcessMessageEventArgs
    {
        /// <summary>
        ///
        /// </summary>
        public ServiceBusReceivedMessage Message { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ServiceBusReceiver Receiver { get; set; }
    }
}
