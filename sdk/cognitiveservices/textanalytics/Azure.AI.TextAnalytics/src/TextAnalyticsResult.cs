// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    // TODO: can we merge this with ResultBatch<T>?
    /// <summary>
    /// </summary>
    public class TextAnalyticsResult<T>
    {
        /// <summary>
        /// </summary>
        public List<DocumentResult<T>> DocumentResults { get; } = new List<DocumentResult<T>>();

        /// <summary>
        /// Errors and Warnings by document.
        /// </summary>
        public List<DocumentError> Errors { get; } = new List<DocumentError>();

        /// <summary>
        /// Gets (Optional) if showStats=true was specified in the request this
        /// field will contain information about the request payload.
        /// </summary>
        public RequestStatistics Statistics { get; internal set; }

        /// <summary>
        /// </summary>
        public string ModelVersion { get; internal set; }
    }
}
