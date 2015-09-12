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
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Search.Models;

namespace Microsoft.Azure.Search
{
    internal partial class DocumentOperations
    {
        public Task<DocumentSearchResponse> ContinueSearchAsync(
            SearchContinuationToken continuationToken,
            CancellationToken cancellationToken)
        {
            string invocationId;
            bool shouldTrace = ValidateAndTraceContinueSearch(continuationToken, out invocationId);

            return DoContinueSearchAsync<DocumentSearchResponse, SearchResult, Document>(
                continuationToken.NextLink,
                continuationToken.NextPageParameters,
                continuationToken.NextPageParameters == null,
                shouldTrace,
                invocationId,
                cancellationToken,
                DeserializeForSearch);
        }

        public Task<DocumentSearchResponse<T>> ContinueSearchAsync<T>(
            SearchContinuationToken continuationToken,
            CancellationToken cancellationToken) where T : class
        {
            string invocationId;
            bool shouldTrace = ValidateAndTraceContinueSearch(continuationToken, out invocationId);

            return DoContinueSearchAsync<DocumentSearchResponse<T>, SearchResult<T>, T>(
                continuationToken.NextLink,
                continuationToken.NextPageParameters,
                continuationToken.NextPageParameters == null,
                shouldTrace,
                invocationId,
                cancellationToken,
                DeserializeForSearch<T>);
        }

        private bool ValidateAndTraceContinueSearch(
            SearchContinuationToken continuationToken, 
            out string invocationId)
        {
            // Validate
            if (continuationToken == null)
            {
                throw new ArgumentNullException("continuationToken");
            }

            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("continuationToken", continuationToken);

                TracingAdapter.Enter(invocationId, this, "ContinueSearchAsync", tracingParameters);
            }

            return shouldTrace;
        }
    }
}
