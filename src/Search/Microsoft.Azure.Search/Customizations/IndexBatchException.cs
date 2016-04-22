// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Exception thrown when an indexing operation only partially succeeds.
    /// </summary>
    public class IndexBatchException : CloudException
    {
        private const string MessageFormat =
            "{0} of {1} indexing actions in the batch failed. The remaining actions succeeded and modified the " +
            "index. Check the IndexResponse property for the status of each index action.";

        private readonly IList<IndexingResult> _indexingResults;

        /// <summary>
        /// Initializes a new instance of the IndexBatchException class.
        /// </summary>
        /// <param name="documentIndexResult">The deserialized response from the index request.</param>
        public IndexBatchException(DocumentIndexResult documentIndexResult) : base(CreateMessage(documentIndexResult))
        {
            // Null check in CreateMessage().
            _indexingResults = documentIndexResult.Results;

            this.Body = new CloudError() { Code = String.Empty, Message = this.Message };
        }

        /// <summary>
        /// Gets the results for the index batch that contains the status for each individual index action.
        /// </summary>
        public IList<IndexingResult> IndexingResults
        {
            get { return _indexingResults; }
        }

        /// <summary>
        /// Finds all index actions in the given batch that failed and need to be retried, and returns them in a
        /// new batch.
        /// </summary>
        /// <param name="originalBatch">The batch that partially failed indexing.</param>
        /// <param name="keyFieldName">The name of the key field from the index schema.</param>
        /// <returns>
        /// A new batch containing all the actions from the given batch that failed and should be retried.
        /// </returns>
        public IndexBatch FindFailedActionsToRetry(IndexBatch originalBatch, string keyFieldName)
        {
            Func<Document, string> getKey = d => d[keyFieldName].ToString();
            IEnumerable<IndexAction> failedActions = 
                this.DoFindFailedActionsToRetry<IndexBatch, IndexAction, Document>(originalBatch, getKey);
            return IndexBatch.New(failedActions);
        }

        /// <summary>
        /// Finds all index actions in the given batch that failed and need to be retried, and returns them in a
        /// new batch.
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="originalBatch">The batch that partially failed indexing.</param>
        /// <param name="keySelector">A lambda that retrieves a key value from a given document of type T.</param>
        /// <returns>
        /// A new batch containing all the actions from the given batch that failed and should be retried.
        /// </returns>
        public IndexBatch<T> FindFailedActionsToRetry<T>(IndexBatch<T> originalBatch, Func<T, string> keySelector)
            where T : class
        {
            IEnumerable<IndexAction<T>> failedActions = 
                this.DoFindFailedActionsToRetry<IndexBatch<T>, IndexAction<T>, T>(originalBatch, keySelector);
            return IndexBatch.New(failedActions);
        }

        private IEnumerable<TAction> DoFindFailedActionsToRetry<TBatch, TAction, TDoc>(
            TBatch originalBatch,
            Func<TDoc, string> keySelector)
            where TBatch : IndexBatchBase<TAction, TDoc>
            where TAction : IndexActionBase<TDoc>
            where TDoc : class
        {
            IEnumerable<string> allRetriableKeys = 
                this.IndexingResults.Where(r => ShouldRetry(r.StatusCode)).Select(r => r.Key);

            var uniqueRetriableKeys = new HashSet<string>(allRetriableKeys);

            Func<TAction, bool> shouldRetry = 
                a => a.Document != null && uniqueRetriableKeys.Contains(keySelector(a.Document));

            return originalBatch.Actions.Where(shouldRetry);
        }

        private static string CreateMessage(DocumentIndexResult documentIndexResult)
        {
            Throw.IfArgumentNull(documentIndexResult, "documentIndexResult");

            return String.Format(
                MessageFormat, 
                documentIndexResult.Results.Count(r => !r.Succeeded),
                documentIndexResult.Results.Count);
        }

        private static bool ShouldRetry(int statusCode)
        {
            switch (statusCode)
            {
                case 200:
                case 201:
                    return false;   // Don't retry on success.

                case 404:
                case 400:
                    return false;   // Don't retry on user error.

                case 500:
                    return false;   // Don't retry when something unexpected happened.

                case 422:
                case 409:
                case 503:
                    return true;    // The above cases might succeed on a subsequent retry.

                default:
                    // If this happens, it's a bug. Safest to assume no retry.
                    return false;
            }
        }
    }
}
