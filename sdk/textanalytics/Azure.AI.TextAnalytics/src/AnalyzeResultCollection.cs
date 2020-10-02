// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="JobMetadata"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    public class AnalyzeResultCollection : ReadOnlyCollection<JobMetadata>
    {
        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="statistics"></param>
        internal AnalyzeResultCollection(IList<JobMetadata> list, TextDocumentBatchStatistics statistics) : base(list)
        {
            Documents = list;
            Statistics = statistics;
        }

        /// <summary>
        /// Documents.
        /// </summary>
        public IList<JobMetadata> Documents { get; }

        /// <summary>
        /// Gets statistics about the documents batch and how it was processed
        /// by the service.  This property will have a value when IncludeStatistics
        /// is set to true in the client call.
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }
    }
}
