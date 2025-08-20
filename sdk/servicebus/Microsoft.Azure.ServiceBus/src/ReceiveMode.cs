// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    /// <summary>
    /// Specifies the behavior of the receiver.
    /// </summary>
    public enum ReceiveMode
    {
        /// <summary>Allows a message to be received, and only deleted from Service Bus when <see cref="Core.IReceiverClient.CompleteAsync(string)"/> is called.</summary>
        /// <remarks>This is the default value for <see cref="ReceiveMode" />, and should be used for guaranteed delivery.</remarks>
        PeekLock,

        /// <summary>ReceiveAndDelete will delete the message from Service Bus as soon as the message is delivered.</summary>
        ReceiveAndDelete
    }
}