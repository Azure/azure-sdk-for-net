// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.LRO
{
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.Properties;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// PUT Azure Lro operation
    /// </summary>
    /// <typeparam name="TResourceBody"></typeparam>
    /// <typeparam name="TRequestHeaders"></typeparam>
    internal class PutLRO<TResourceBody, TRequestHeaders> : AzureLRO<TResourceBody, TRequestHeaders>
            where TResourceBody : class
            where TRequestHeaders : class
    {
        /// <summary>
        /// REST Operation Verb
        /// </summary>
        public override string RESTOperationVerb { get => "PUT"; }

        /// <summary>
        /// Initializes PUT LRO Operation
        /// </summary>
        /// <param name="client"></param>
        /// <param name="response"></param>
        /// <param name="customHeaders"></param>
        /// <param name="cancellationToken"></param>
        public PutLRO(IAzureClient client, AzureOperationResponse<TResourceBody, TRequestHeaders> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) : base(client, response, customHeaders, cancellationToken)
        { }

        /// <summary>
        /// Check if Provisioning state needs to be checked
        /// </summary>
        /// <returns></returns>
        protected override bool IsCheckingProvisioningStateApplicable()
        {
            // check Provisioning for 200 and 201
            return ((CurrentPollingState.CurrentStatusCode == HttpStatusCode.OK) ||
                     (CurrentPollingState.CurrentStatusCode == HttpStatusCode.Created));
        }

        /// <summary>
        /// Function that allows you to make tweaks before finishing LRO operation and return back to the client
        /// </summary>
        /// <returns></returns>
        protected override async Task PostPollingAsync()
        {
            //We do an additional Get to get the resource for PUT requests
            if (AzureAsyncOperation.SuccessStatus.Equals(CurrentPollingState.Status, StringComparison.OrdinalIgnoreCase))
            {
                if ((!string.IsNullOrEmpty(CurrentPollingState.AzureAsyncOperationHeaderLink) || CurrentPollingState.Resource == null))
                {
                    // We want to call the one last time the original URI that will give you the required resource
                    CurrentPollingState.PollingUrlToUse = GetValidAbsoluteUri(CurrentPollingState.FinalGETUrlToUser, throwForInvalidUri: true);
                    await CurrentPollingState.UpdateResourceFromPollingUri(CustomHeaders, CancelToken);
                }
            }
#if DEBUG
            RemoveLroHeaders(removeOperation:true);
#endif
        }

        protected override void CheckForErrors()
        {
            base.CheckForErrors();

            // with 200 without any headers, if body is null, fail
            if ((string.IsNullOrEmpty(CurrentPollingState.AzureAsyncOperationHeaderLink)) &&
                (string.IsNullOrEmpty(CurrentPollingState.LocationHeaderLink)))
            {
                if (CurrentPollingState.AzureOperationResponse == null || CurrentPollingState.AzureOperationResponse.Body == null)  // this happens when you there is immediate Success without going through LRO
                {
                    if (CurrentPollingState.RawBody == null)
                    {
                        throw new CloudException(Resources.NoBody);
                    }
                }
            }
        }

        /// <summary>
        /// Initialize with the right URI to use for polling LRO opertion
        /// Depending upon the return status code and the header provided, we initialize PollingUrlToUse with the right URI
        /// Also verify if the right headers are provided, if not throw validation exception
        /// </summary>
        protected override void InitializeAsyncHeadersToUse()
        {
            base.InitializeAsyncHeadersToUse();
            
            // Default polling URI for PUT request does not necessary need to have Async operation/location headers
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
                    CurrentPollingState.PollingUrlToUse = CurrentPollingState.LocationHeaderLink;
                }

                if (string.IsNullOrEmpty(CurrentPollingState.PollingUrlToUse))
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "202 status code requires AzureAsyncOperationHeader/LocationHeader");
                }
            }
        }
    }
}