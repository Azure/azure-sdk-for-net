// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class DocumentResultCollection<T> : Collection<DocumentResult<T>>
    {
        /// <summary>
        /// </summary>
        public DocumentResultCollection()
        {
        }

        /// <summary>
        /// Errors and Warnings by document.
        /// </summary>
        public List<DocumentError> Errors { get; } = new List<DocumentError>();

        /// <summary>
        /// Gets (Optional) if showStats=true was specified in the request this
        /// field will contain information about the request payload.
        /// </summary>
        public DocumentBatchStatistics Statistics { get; internal set; }

        /// <summary>
        /// </summary>
        public string ModelVersion { get; internal set; }
    }
}
