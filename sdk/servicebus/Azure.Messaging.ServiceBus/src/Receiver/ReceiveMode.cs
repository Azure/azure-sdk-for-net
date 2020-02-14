// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Receiver
{
    /// <summary>
    /// Specifies the behavior of the receiver.
    /// </summary>
    public enum ReceiveMode
    {
        /// <summary>Allows a message to be received, and only deleted from Service Bus when "Core.IReceiverClient.CompleteAsync(string)" is called.</summary>
        /// <remarks>This is the default value for <see cref="ReceiveMode" />, and should be used for guaranteed delivery.</remarks>
        PeekLock,

        /// <summary>ReceiveAndDelete will delete the message from Service Bus as soon as the message is delivered.</summary>
        ReceiveAndDelete,
    }
}
