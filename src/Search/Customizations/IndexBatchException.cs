// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Hyak.Common;
using Microsoft.Azure.Search.Models;

namespace Microsoft.Azure.Search
{
    /// <summary>
    /// Exception thrown when an indexing operation only partially succeeds.
    /// </summary>
    public class IndexBatchException : CloudException
    {
        private const string MessageFormat =
            "{0} of {1} indexing actions in the batch failed. The remaining actions succeeded and modified the " +
            "index. Check the IndexResponse property for the status of each index action.";

        private readonly DocumentIndexResponse _indexResponse;

        /// <summary>
        /// Initializes a new instance of the IndexBatchException class.
        /// </summary>
        /// <param name="httpRequest">The original HTTP index request.</param>
        /// <param name="httpResponse">The original HTTP index response.</param>
        /// <param name="indexResponse">The deserialized response from the index request.</param>
        public IndexBatchException(
            HttpRequestMessage httpRequest, 
            HttpResponseMessage httpResponse, 
            DocumentIndexResponse indexResponse) : base(CreateMessage(indexResponse))
        {
            // Null check in CreateMessage().
            _indexResponse = indexResponse;

            Error =
                new CloudError()
                {
                    Code = String.Empty,
                    Message = this.Message,
                    OriginalMessage = this.Message,
                    ResponseBody = String.Empty
                };

            Request = CloudHttpRequestErrorInfo.Create(httpRequest);
            Response = CloudHttpResponseErrorInfo.Create(httpResponse);
        }

        /// <summary>
        /// Gets the response for the index batch that contains the status for each individual index action.
        /// </summary>
        public DocumentIndexResponse IndexResponse
        {
            get { return _indexResponse; }
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
                DoFindFailedActionsToRetry<IndexBatch, IndexAction, Document>(originalBatch, getKey);
            return new IndexBatch(failedActions);
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
                DoFindFailedActionsToRetry<IndexBatch<T>, IndexAction<T>, T>(originalBatch, keySelector);
            return IndexBatch.Create(failedActions);
        }

        private IEnumerable<TAction> DoFindFailedActionsToRetry<TBatch, TAction, TDoc>(
            TBatch originalBatch,
            Func<TDoc, string> keySelector)
            where TBatch : IndexBatchBase<TAction, TDoc>
            where TAction : IndexActionBase<TDoc>
            where TDoc : class
        {
            var failedKeys = new HashSet<string>(IndexResponse.Results.Where(r => !r.Succeeded).Select(r => r.Key));
            Func<TAction, bool> isFailed = a => a.Document != null && failedKeys.Contains(keySelector(a.Document));
            return originalBatch.Actions.Where(isFailed);
        }

        private static string CreateMessage(DocumentIndexResponse indexResponse)
        {
            if (indexResponse == null)
            {
                throw new ArgumentNullException("indexResponse");
            }

            return String.Format(
                MessageFormat, 
                indexResponse.Results.Count(r => !r.Succeeded),
                indexResponse.Results.Count);
        }
    }
}
