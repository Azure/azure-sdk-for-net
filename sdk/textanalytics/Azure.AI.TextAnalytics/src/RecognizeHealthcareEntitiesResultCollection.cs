// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="DocumentHealthcareResult"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    public class RecognizeHealthcareEntitiesResultCollection : ReadOnlyCollection<DocumentHealthcareResult>
    {
        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="statistics"></param>
        /// <param name="modelVersion"></param>
        internal RecognizeHealthcareEntitiesResultCollection(IList<DocumentHealthcareResult> list, TextDocumentBatchStatistics statistics, string modelVersion) : base(list)
        {
            Statistics = statistics;
            ModelVersion = modelVersion;
        }

        /// <summary>
        /// Gets statistics about the documents batch and how it was processed
        /// by the service.  This property will have a value when IncludeStatistics
        /// is set to true in the client call.
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }

        /// <summary>
        /// Gets the version of the Text Analytics model used by this operation
        /// on this batch of documents.
        /// </summary>
        public string ModelVersion { get; }
    }
}
