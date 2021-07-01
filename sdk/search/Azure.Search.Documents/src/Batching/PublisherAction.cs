// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.Search.Documents.Batching
{
    /// <summary>
    /// Tracks actions that the publisher hasn't submitted yet.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema.  Instances of this
    /// type can be retrieved as documents from the index.
    /// </typeparam>
    internal struct PublisherAction<T>
    {
        /// <summary>
        /// Gets the action to submit.
        /// </summary>
        public T Document { get; }

        /// <summary>
        /// The key used to identify the document.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets the number of retry attempts.
        /// </summary>
        public int RetryAttempts { get; set; }

        // TODO: Add the serialized payload in an ArrayPool buffer

        /// <summary>
        /// Creates a new PublisherAction.
        /// </summary>
        /// <param name="document">The action to submit.</param>
        /// <param name="key">Key of the action's document.</param>
        public PublisherAction(T document, string key)
        {
            Debug.Assert(document != null);
            Debug.Assert(key != null);
            Document = document;
            Key = key;
            RetryAttempts = 0;
        }
    }
}
