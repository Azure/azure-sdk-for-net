//-----------------------------------------------------------------------
// <copyright file="CloudQueueMessage.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the CloudQueueMessage class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Globalization;
    using System.Text;
    using Protocol;

    /// <summary>
    /// Enum for Queue message type.
    /// </summary>
    internal enum QueueMessageType
    {
        /// <summary>
        /// Indicates the message object stores the raw text string.
        /// </summary>
        RawString,

        /// <summary>
        /// Indicates the message object stores the Base64-Encoded representation of the raw data. 
        /// </summary>
        Base64Encoded
    }

    /// <summary>
    /// Represents a message in a queue.
    /// </summary>
    public class CloudQueueMessage
    {
        /// <summary>
        /// The maximum message size in bytes.
        /// </summary>
        public static readonly long MaxMessageSize = 64 * Constants.KB;

        /// <summary>
        /// The maximum amount of time a message is kept in the queue.
        /// </summary>
        public static readonly TimeSpan MaxTimeToLive = TimeSpan.FromDays(7);

        /// <summary>
        /// The maximum number of messages that can be peeked at a time.
        /// </summary>
        public static readonly int MaxNumberOfMessagesToPeek = 32;

        /// <summary>
        /// Custom UTF8Encoder to throw exception in case of invalid bytes.
        /// </summary>
        private static UTF8Encoding utf8Encoder = new UTF8Encoding(false, true);

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
        /// Initializes a new instance of the <see cref="CloudQueueMessage"/> class with the given string.
        /// </summary>
        /// <param name="content">The content of the message as a string of text.</param>
        public CloudQueueMessage(string content)
        {
            this.SetMessageContent(content);

            // At this point, without knowing whether or not the message will be Base64 encoded, we can't fully validate the message size.
            // So we leave it to CloudQueue so that we have a central place for this logic.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueueMessage"/> class with the given Base64 encoded string.
        /// This method is only used internally.
        /// </summary>
        /// <param name="content">The text string.</param>
        /// <param name="isBase64Encoded">Whether the string is Base64 encoded.</param>
        internal CloudQueueMessage(string content, bool isBase64Encoded)
        {
            if (content == null)
            {
                content = string.Empty;
            }

            this.RawString = content;
            this.MessageType = isBase64Encoded ? QueueMessageType.Base64Encoded : QueueMessageType.RawString;
        }

        /// <summary>
        /// Gets the content of the message as a byte array.
        /// </summary>
        /// <value>The content of the message as a byte array.</value>
        public byte[] AsBytes
        {
            get
            {
                if (this.MessageType == QueueMessageType.RawString)
                {
                    return Encoding.UTF8.GetBytes(this.RawString);
                }
                else
                {
                    return Convert.FromBase64String(this.RawString);
                }
            }
        }

        /// <summary>
        /// Gets or sets the message ID.
        /// </summary>
        /// <value>The message ID.</value>
        public string Id { get; protected internal set; }

        /// <summary>
        /// Gets or sets the message's pop receipt.
        /// </summary>
        /// <value>The pop receipt value.</value>
        public string PopReceipt { get; protected internal set; }

        /// <summary>
        /// Gets or sets the time that the message was added to the queue.
        /// </summary>
        /// <value>The time that that message was added to the queue.</value>
        public DateTime? InsertionTime { get; protected internal set; }

        /// <summary>
        /// Gets or sets the time that the message expires.
        /// </summary>
        /// <value>The time that the message expires.</value>
        public DateTime? ExpirationTime { get; protected internal set; }

        /// <summary>
        /// Gets or sets the time that the message will next be visible.
        /// </summary>
        /// <value>The time that the message will next be visible.</value>
        public DateTime? NextVisibleTime { get; protected internal set; }

        /// <summary>
        /// Gets the content of the message, as a string.
        /// </summary>
        /// <value>The message content.</value>
        public string AsString
        {
            get
            {
                if (this.MessageType == QueueMessageType.RawString)
                {
                    return this.RawString;
                }
                else
                {
                    return utf8Encoder.GetString(Convert.FromBase64String(this.RawString));
                }
            }
        }

        /// <summary>
        /// Gets or sets the number of times this message has been dequeued.
        /// </summary>
        /// <value>The number of times this message has been dequeued.</value>
        public int DequeueCount { get; protected internal set; }
        
        /// <summary>
        /// Gets message type that indicates if the RawString is the original message string or Base64 encoding of the original binary data.
        /// </summary>
        internal QueueMessageType MessageType { get; private set; }

        /// <summary>
        /// Gets or sets the original message string or Base64 encoding of the original binary data.
        /// </summary>
        /// <value>The original message string.</value>
        protected internal string RawString { get; set; }

        /// <summary>
        /// Sets the content of this message.
        /// </summary>
        /// <param name="content">The new message content.</param>
        public void SetMessageContent(string content)
        {
            if (content == null)
            {
                // Protocol will return null for empty content
                content = string.Empty;
            }

            this.RawString = content;
            this.MessageType = QueueMessageType.RawString;
        }

        /// <summary>
        /// Sets the content of this message.
        /// </summary>
        /// <param name="content">The new message content.</param>
        public void SetMessageContent(byte[] content)
        {
            CommonUtils.AssertNotNull("content", content);

            this.RawString = Convert.ToBase64String(content);
            this.MessageType = QueueMessageType.Base64Encoded;
        }
    }
}
