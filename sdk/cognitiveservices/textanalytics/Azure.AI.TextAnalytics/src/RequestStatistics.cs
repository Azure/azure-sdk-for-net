// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct RequestStatistics
    {
        /// <summary>
        /// Initializes a new instance of the RequestStatistics class.
        /// </summary>
        /// <param name="documentsCount">Number of documents submitted in the
        /// request.</param>
        /// <param name="validDocumentsCount">Number of valid documents. This
        /// excludes empty, over-size limit or non-supported languages
        /// documents.</param>
        /// <param name="erroneousDocumentsCount">Number of invalid documents.
        /// This includes empty, over-size limit or non-supported languages
        /// documents.</param>
        /// <param name="transactionsCount">Number of transactions for the
        /// request.</param>
        public RequestStatistics(int? documentsCount = default, int? validDocumentsCount = default, int? erroneousDocumentsCount = default, long? transactionsCount = default)
        {
            DocumentsCount = documentsCount;
            ValidDocumentsCount = validDocumentsCount;
            ErroneousDocumentsCount = erroneousDocumentsCount;
            TransactionsCount = transactionsCount;
        }

        /// <summary>
        /// Gets or sets number of documents submitted in the request.
        /// </summary>
        public int? DocumentsCount { get; set; }

        /// <summary>
        /// Gets or sets number of valid documents. This excludes empty,
        /// over-size limit or non-supported languages documents.
        /// </summary>
        public int? ValidDocumentsCount { get; set; }

        /// <summary>
        /// Gets or sets number of invalid documents. This includes empty,
        /// over-size limit or non-supported languages documents.
        /// </summary>
        public int? ErroneousDocumentsCount { get; set; }

        /// <summary>
        /// Gets or sets number of transactions for the request.
        /// </summary>
        public long? TransactionsCount { get; set; }
    }
}
