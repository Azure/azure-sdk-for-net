// -----------------------------------------------------------------------------------------
// <copyright file="CloudQueueMessage.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Queue
{
    using System;

    /// <summary>
    /// Represents a message in the Windows Azure Queue service.
    /// </summary>
    public sealed partial class CloudQueueMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueueMessage"/> class with the given byte array.
        /// </summary>
        /// <param name="content">The content of the message as a byte array.</param>
        public CloudQueueMessage(byte[] content)
        {
            this.SetMessageContent(content);

            // While binary messages will be Base64-encoded and we could validate the message size here,
            // for consistency, we leave it to CloudQueue so that we have a central place for this logic.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueueMessage"/> class with the message's ID and pop receipt.
        /// </summary>
        /// <remarks>
        /// This can be used to reconstitute the CloudQueueMessage.
        /// </remarks>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        public CloudQueueMessage(string messageId, string popReceipt)
        {
            this.Id = messageId;
            this.PopReceipt = popReceipt;
        }

        /// <summary>
        /// Sets the content of this message.
        /// </summary>
        /// <param name="content">The new message content.</param>
        public void SetMessageContent(byte[] content)
        {
            this.RawString = Convert.ToBase64String(content);
            this.MessageType = QueueMessageType.Base64Encoded;
        }
    }
}
