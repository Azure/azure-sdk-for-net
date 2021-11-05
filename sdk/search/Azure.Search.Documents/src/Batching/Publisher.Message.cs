// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Search.Documents.Batching
{
    internal partial class Publisher<T>
    {
        /// <summary>
        /// A publishing message passed from a writer to a reader in a Channel.
        /// </summary>
        private class Message
        {
            /// <summary>
            /// Gets the type of operation.
            /// </summary>
            public MessageOperation Operation { get; private set; }

            /// <summary>
            /// Gets any documents to be published.  Could be null depending on
            /// the operation.
            /// </summary>
            public IEnumerable<T> Documents { get; private set; }

            /// <summary>
            /// Create a message to publish documents.
            /// </summary>
            /// <param name="documents">The documents to publish.</param>
            /// <returns>A message to publish documents.</returns>
            public static Message Publish(IEnumerable<T> documents) =>
                new Message
                {
                    Operation = MessageOperation.Publish,
                    Documents = documents
                };

            /// <summary>
            /// Create a message to flush the publisher.
            /// </summary>
            /// <returns>A message to flush the publisher.</returns>
            public static Message Flush() =>
                new Message { Operation = MessageOperation.Flush };
        }
    }
}
