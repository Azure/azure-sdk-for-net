// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Batching
{
    internal partial class Publisher<T>
    {
        /// <summary>
        /// Types of operations that can be sent from writers to a reader in a
        /// publisher.
        /// </summary>
        private enum MessageOperation
        {
            Publish,
            Flush
        }
    }
}
