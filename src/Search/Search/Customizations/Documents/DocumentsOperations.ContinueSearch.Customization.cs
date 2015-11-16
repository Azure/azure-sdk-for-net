// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;

    internal partial class DocumentsOperations
    {
        public Task<AzureOperationResponse<DocumentSearchResult>> ContinueSearchWithHttpMessagesAsync(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            string invocationId;
            string clientRequestId;
            bool shouldTrace = 
                ValidateAndTraceContinueSearch(
                    continuationToken, 
                    searchRequestOptions,
                    cancellationToken, 
                    out invocationId,
                    out clientRequestId);

            return DoContinueSearchWithHttpMessagesAsync<DocumentSearchResult, SearchResult, Document>(
                continuationToken.NextLink,
                continuationToken.NextPageParameters,
                clientRequestId,
                customHeaders,
                continuationToken.NextPageParameters == null,
                shouldTrace,
                invocationId,
                cancellationToken,
                DeserializeForSearch);
        }

        public Task<AzureOperationResponse<DocumentSearchResult<T>>> ContinueSearchWithHttpMessagesAsync<T>(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            string invocationId;
            string clientRequestId;
            bool shouldTrace = 
                ValidateAndTraceContinueSearch(
                    continuationToken,
                    searchRequestOptions,
                    cancellationToken,
                    out invocationId,
                    out clientRequestId);

            return DoContinueSearchWithHttpMessagesAsync<DocumentSearchResult<T>, SearchResult<T>, T>(
                continuationToken.NextLink,
                continuationToken.NextPageParameters,
                clientRequestId,
                customHeaders,
                continuationToken.NextPageParameters == null,
                shouldTrace,
                invocationId,
                cancellationToken,
                DeserializeForSearch<T>);
        }

        private bool ValidateAndTraceContinueSearch(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions,
            CancellationToken cancellationToken,
            out string invocationId,
            out string clientRequestId)
        {
            // Validate
            if (this.Client.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.ApiVersion");
            }
            if (continuationToken == null)
            {
                throw new ArgumentNullException("continuationToken");
            }

            clientRequestId = null;
            if (searchRequestOptions != null)
            {
                clientRequestId = searchRequestOptions.ClientRequestId;
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("continuationToken", continuationToken);
                tracingParameters.Add("clientRequestId", clientRequestId);
                tracingParameters.Add("cancellationToken", cancellationToken);

                ServiceClientTracing.Enter(invocationId, this, "ContinueSearch", tracingParameters);
            }

            return shouldTrace;
        }
    }
}
