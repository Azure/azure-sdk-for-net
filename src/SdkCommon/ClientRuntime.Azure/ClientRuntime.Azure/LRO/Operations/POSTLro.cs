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
    /// POST Azure LRO operation
    /// </summary>
    /// <typeparam name="TResourceBody"></typeparam>
    /// <typeparam name="TRequestHeaders"></typeparam>
    internal class POSTLro<TResourceBody, TRequestHeaders> : AzureLRO<TResourceBody, TRequestHeaders>
            where TResourceBody : class
            where TRequestHeaders : class
    {
        /// <summary>
        /// REST Operation Verb
        /// </summary>
        public override string RESTOperationVerb { get => "POST"; }

        /// <summary>
        /// Initializes POST LRO Operation
        /// </summary>
        /// <param name="client"></param>
        /// <param name="response"></param>
        /// <param name="customHeaders"></param>
        /// <param name="cancellationToken"></param>
        public POSTLro(IAzureClient client, AzureOperationResponse<TResourceBody, TRequestHeaders> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) : base(client, response, customHeaders, cancellationToken)
        { }

        /// <summary>
        /// First response status is 201
        /// Location header is required and we will throw if not provided
        /// 
        /// First response status is 202
        /// We prefer Async-Operation, if not provided we will fall back on Location header
        /// 
        /// If we get both headers, we will use Location header to do the final GET at the end of the LRO operation
        /// </summary>
        protected override void InitializeAsyncHeadersToUse()
        {
            base.InitializeAsyncHeadersToUse();

            // 201
            // We are being extra permissible, we will not throw if RP sends 201 + location header, we will treat it similarly as 202+location
            if (CurrentPollingState.CurrentStatusCode == System.Net.HttpStatusCode.Created)
            {
                if (!string.IsNullOrEmpty(CurrentPollingState.LocationHeaderLink))
                {
                    CurrentPollingState.PollingUrlToUse = CurrentPollingState.LocationHeaderLink;
                    CurrentPollingState.FinalGETUrlToUser = CurrentPollingState.LocationHeaderLink;
                }
                else
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "Recommended pattern POST-201-LocationHeader");
                }
            }

            // For 202, we prefer AzureAsyncOperation header, else we fallback on LocationHeader
            if (CurrentPollingState.CurrentStatusCode == System.Net.HttpStatusCode.Accepted)
            {
                if (!string.IsNullOrEmpty(CurrentPollingState.AzureAsyncOperationHeaderLink))
                {
                    CurrentPollingState.PollingUrlToUse = CurrentPollingState.AzureAsyncOperationHeaderLink;
                }

                if (!string.IsNullOrEmpty(CurrentPollingState.LocationHeaderLink))
                {
                    if (string.IsNullOrEmpty(CurrentPollingState.AzureAsyncOperationHeaderLink))
                    {
                        CurrentPollingState.PollingUrlToUse = CurrentPollingState.LocationHeaderLink;
                    }

                    // During polling if we get location header, that needs to be used to get result for the final GET
                    CurrentPollingState.FinalGETUrlToUser = CurrentPollingState.LocationHeaderLink;
                }

                if (string.IsNullOrEmpty(CurrentPollingState.PollingUrlToUse))
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "Recommended patterns: POST-202-LocationHeader(Prefered)/AzureAsyncOperationHeader");
                }
            }
        }

        /// <summary>
        /// Check if Provisioning state needs to be checked
        /// </summary>
        /// <returns></returns>
        protected override bool IsCheckingProvisioningStateApplicable()
        {
            // For POST check Provisioning for 200 and 204
            return ((CurrentPollingState.CurrentStatusCode == HttpStatusCode.OK) ||
                     (CurrentPollingState.CurrentStatusCode == HttpStatusCode.NoContent));
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
                if ((!string.IsNullOrEmpty(CurrentPollingState.LocationHeaderLink)))
                {
                    // We want to call the one last time the original URI that will give you the required resource
                    if (!string.IsNullOrEmpty(CurrentPollingState.FinalGETUrlToUser))
                    {
                        CurrentPollingState.PollingUrlToUse = GetValidAbsoluteUri(CurrentPollingState.FinalGETUrlToUser, throwForInvalidUri: true);
                        await CurrentPollingState.UpdateResourceFromPollingUri(CustomHeaders, CancelToken);
                    }
                }
            }
#if DEBUG
            RemoveLroHeaders(removeOperation: true);
#endif
        }
    }
}
