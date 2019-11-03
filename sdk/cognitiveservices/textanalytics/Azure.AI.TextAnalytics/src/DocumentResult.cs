// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class DocumentResult<T>
    {
        /// <summary>
        /// Gets or sets unique, non-empty document identifier.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// Gets or sets a list of extracted languages.
        /// </summary>
        public List<T> Predictions { get; internal set; } = new List<T>();

        /// <summary>
        /// Gets or sets (Optional) if showStats=true was specified in the
        /// request this field will contain information about the document
        /// payload.
        /// </summary>
        public DocumentStatistics Statistics { get; internal set; }
    }
}
