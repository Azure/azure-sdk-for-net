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
    using System.Text;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    /// <summary>
    /// Represents a message in the Windows Azure Queue service.
    /// </summary>
    public sealed partial class CloudQueueMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueueMessage"/> class with the given byte array.
        /// </summary>
        /// <param name="content">The content of the message as a byte array.</param>
        /// <returns>The new message as a <see cref="CloudQueueMessage"/> object.</returns>
        public static CloudQueueMessage CreateCloudQueueMessageFromByteArray([ReadOnlyArray] byte[] content)
        {
            CloudQueueMessage message = new CloudQueueMessage(null);
            message.SetMessageContent(content);
            return message;
        }

        /// <summary>
        /// Sets the content of this message.
        /// </summary>
        /// <param name="content">The new message content.</param>
        [Windows.Foundation.Metadata.DefaultOverloadAttribute]
        public void SetMessageContent([ReadOnlyArray] byte[] content)
        {
            this.RawString = Convert.ToBase64String(content);
            this.MessageType = QueueMessageType.Base64Encoded;
        }
    }
}
