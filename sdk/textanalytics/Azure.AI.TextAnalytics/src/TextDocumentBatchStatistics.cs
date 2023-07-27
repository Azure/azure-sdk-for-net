// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A collection of statistics describing the batch of documents submitted
    /// to the service for analysis in a given request.  This information is
    /// provided on the result collection returned by an operation when the
    /// caller passes in a <see cref="TextAnalyticsRequestOptions"/> with
    /// IncludeStatistics set to true.
    /// </summary>
    [CodeGenModel("RequestStatistics")]
    public partial class TextDocumentBatchStatistics
    {
        internal TextDocumentBatchStatistics(int documentCount, int validDocumentCount, int invalidDocumentCount, long transactionCount)
        {
            DocumentCount = documentCount;
            ValidDocumentCount = validDocumentCount;
            InvalidDocumentCount = invalidDocumentCount;
            TransactionCount = transactionCount;
        }

        /// <summary>
        /// Gets the number of documents submitted in the request batch.
        /// </summary>
        [CodeGenMember("DocumentsCount")]
        public int DocumentCount { get; }

        /// <summary>
        /// Gets the number of valid documents submitted in the request batch.
        /// This number excludes empty documents, documents whose size exceeds
        /// the service's size limit, and documents in unsupported languages.
        /// </summary>
        [CodeGenMember("ValidDocumentsCount")]
        public int ValidDocumentCount { get; }

        /// <summary>
        /// Gets the number of invalid documents submitted in the request batch.
        /// This number includes empty documents, documents whose size exceeds
        /// the service's size limit, and documents in unsupported languages.
        /// </summary>
        [CodeGenMember("ErroneousDocumentsCount")]
        public int InvalidDocumentCount { get; }

        /// <summary>
        /// Gets the number of transactions required to complete the operation
        /// on all documents submitted in the request batch.
        /// </summary>
        [CodeGenMember("TransactionsCount")]
        public long TransactionCount { get; }
    }
}
