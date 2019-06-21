// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.LRO
{
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// PATCH Azure LRO operation
    /// </summary>
    /// <typeparam name="TResourceBody"></typeparam>
    /// <typeparam name="TRequestHeaders"></typeparam>
    internal class PATCHLro<TResourceBody, TRequestHeaders> : AzureLRO<TResourceBody, TRequestHeaders>
            where TResourceBody : class
            where TRequestHeaders : class
    {
        /// <summary>
        /// REST Operation Verb
        /// </summary>
        public override string RESTOperationVerb { get => "PATCH"; }

        /// <summary>
        /// Initializes PATCH LRO Operation
        /// </summary>
        /// <param name="client"></param>
        /// <param name="response"></param>
        /// <param name="customHeaders"></param>
        /// <param name="cancellationToken"></param>
        public PATCHLro(IAzureClient client, AzureOperationResponse<TResourceBody, TRequestHeaders> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) : base(client, response, customHeaders, cancellationToken)
        { }

        /// <summary>
        /// Initialize which URL to use for polling
        /// 
        /// First responose status code 201
        /// Either we use Async-operatino header for polling
        /// Or fall back on original URL to poll
        /// 
        /// First response status code 202
        /// We prefer Async-operation
        /// or we will fall back on location header
        /// 
        /// At the end of the polling we will use the original URL to do the final GET
        /// </summary>
        protected override void InitializeAsyncHeadersToUse()
        {
            base.InitializeAsyncHeadersToUse();

            // Default polling URI for PATCH request does not necessary need to have Async operation/location headers

            if (string.IsNullOrEmpty(CurrentPollingState.PollingUrlToUse))
            {
                CurrentPollingState.PollingUrlToUse = GetValidAbsoluteUri(InitialResponse.Request.RequestUri.AbsoluteUri);
            }

            if (string.IsNullOrEmpty(CurrentPollingState.FinalGETUrlToUser))
            {
                CurrentPollingState.FinalGETUrlToUser = GetValidAbsoluteUri(InitialResponse.Request.RequestUri.AbsoluteUri);
            }

            // 201
            if (CurrentPollingState.CurrentStatusCode == System.Net.HttpStatusCode.Created)
            {
                if (!string.IsNullOrEmpty(CurrentPollingState.AzureAsyncOperationHeaderLink))
                {
                    CurrentPollingState.PollingUrlToUse = CurrentPollingState.AzureAsyncOperationHeaderLink;
                }
                else
                {
                    if (string.IsNullOrEmpty(CurrentPollingState.PollingUrlToUse))
                    {
                        throw new ValidationException(ValidationRules.CannotBeNull, "201 status code requires AzureAsyncOperationHeader/RequestUri");
                    }
                }
            }

            // For 202, we prefer AzureAsyncOperation header, else we fallback on LocationHeader
            if (CurrentPollingState.CurrentStatusCode == System.Net.HttpStatusCode.Accepted)
            {
                if (!string.IsNullOrEmpty(CurrentPollingState.AzureAsyncOperationHeaderLink))
                {
                    CurrentPollingState.PollingUrlToUse = CurrentPollingState.AzureAsyncOperationHeaderLink;
                }
                else if (!string.IsNullOrEmpty(CurrentPollingState.LocationHeaderLink))
                {
                    CurrentPollingState.PollingUrlToUse = GetValidAbsoluteUri(CurrentPollingState.LocationHeaderLink);
                }

                if (string.IsNullOrEmpty(CurrentPollingState.PollingUrlToUse))
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "AzureAsyncOperationHeader/LocationHeader");
                }
            }
        }

        /// <summary>
        /// Function to check if checking provisioning state is applicable during polling
        /// </summary>
        /// <returns></returns>
        protected override bool IsCheckingProvisioningStateApplicable()
        {
            // For PATCH check Provisioning for 200 and 201
            return ((CurrentPollingState.CurrentStatusCode == HttpStatusCode.OK) ||
                     (CurrentPollingState.CurrentStatusCode == HttpStatusCode.Created));
        }

        /// <summary>
        /// Function that allows you to make tweaks before finishing LRO operation and return back to the client
        /// </summary>
        /// <returns></returns>
        protected override async Task PostPollingAsync()
        {
            // We do an additional Get to get the resource for PATCH requests
            if (AzureAsyncOperation.SuccessStatus.Equals(CurrentPollingState.Status, StringComparison.OrdinalIgnoreCase))
            {
                if ((!string.IsNullOrEmpty(CurrentPollingState.AzureAsyncOperationHeaderLink) || CurrentPollingState.Resource == null))
                {
                    CurrentPollingState.PollingUrlToUse = GetValidAbsoluteUri(CurrentPollingState.InitialResponse.Request.RequestUri.AbsoluteUri, throwForInvalidUri: true);
                    await CurrentPollingState.UpdateResourceFromPollingUri(CustomHeaders, CancelToken);
                }
            }
#if DEBUG
            RemoveLroHeaders(removeOperation: true);
#endif
        }
    }
}
