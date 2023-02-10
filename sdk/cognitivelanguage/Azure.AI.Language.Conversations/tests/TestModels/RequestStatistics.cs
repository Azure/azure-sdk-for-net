// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> if showStats=true was specified in the request this field will contain information about the request payload. </summary>
    public partial class RequestStatistics
    {
        /// <summary> Initializes a new instance of RequestStatistics. </summary>
        /// <param name="documentsCount"> Number of documents submitted in the request. </param>
        /// <param name="validDocumentsCount"> Number of valid documents. This excludes empty, over-size limit or non-supported languages documents. </param>
        /// <param name="erroneousDocumentsCount"> Number of invalid documents. This includes empty, over-size limit or non-supported languages documents. </param>
        /// <param name="transactionsCount"> Number of transactions for the request. </param>
        public RequestStatistics(int documentsCount, int validDocumentsCount, int erroneousDocumentsCount, long transactionsCount)
        {
            DocumentsCount = documentsCount;
            ValidDocumentsCount = validDocumentsCount;
            ErroneousDocumentsCount = erroneousDocumentsCount;
            TransactionsCount = transactionsCount;
            AdditionalProperties = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary> Initializes a new instance of RequestStatistics. </summary>
        /// <param name="documentsCount"> Number of documents submitted in the request. </param>
        /// <param name="validDocumentsCount"> Number of valid documents. This excludes empty, over-size limit or non-supported languages documents. </param>
        /// <param name="erroneousDocumentsCount"> Number of invalid documents. This includes empty, over-size limit or non-supported languages documents. </param>
        /// <param name="transactionsCount"> Number of transactions for the request. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        internal RequestStatistics(int documentsCount, int validDocumentsCount, int erroneousDocumentsCount, long transactionsCount, IDictionary<string, object> additionalProperties)
        {
            DocumentsCount = documentsCount;
            ValidDocumentsCount = validDocumentsCount;
            ErroneousDocumentsCount = erroneousDocumentsCount;
            TransactionsCount = transactionsCount;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> Number of documents submitted in the request. </summary>
        public int DocumentsCount { get; set; }
        /// <summary> Number of valid documents. This excludes empty, over-size limit or non-supported languages documents. </summary>
        public int ValidDocumentsCount { get; set; }
        /// <summary> Number of invalid documents. This includes empty, over-size limit or non-supported languages documents. </summary>
        public int ErroneousDocumentsCount { get; set; }
        /// <summary> Number of transactions for the request. </summary>
        public long TransactionsCount { get; set; }
        /// <summary> Additional Properties. </summary>
        public IDictionary<string, object> AdditionalProperties { get; }
    }
}
