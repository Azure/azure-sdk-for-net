// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TextAnalyticsDocument<T>
    {
        /// <summary>
        /// Gets or sets unique, non-empty document identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets recognized entities in the document.
        /// </summary>
        public List<T> Values { get; private set; }

        /// <summary>
        /// Gets or sets (Optional) if showStats=true was specified in the
        /// request this field will contain information about the document
        /// payload.
        /// </summary>
        public DocumentStatistics Statistics { get; set; }
    }
}
