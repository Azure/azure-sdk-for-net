// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class DocumentResult<T> : Collection<T>
    {
        /// <summary>
        /// </summary>
        internal DocumentResult()
        {
        }

        /// <summary>
        /// Gets unique, non-empty document identifier.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// Gets (Optional) if showStatistics=true was specified in the
        /// request this field will contain information about the document
        /// payload.
        /// </summary>
        public DocumentStatistics Statistics { get; internal set; }
    }
}
