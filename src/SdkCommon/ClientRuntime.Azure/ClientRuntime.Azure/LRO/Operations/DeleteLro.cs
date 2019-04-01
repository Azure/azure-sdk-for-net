// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Rest.ClientRuntime.Azure.LRO
{
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// DELETE Azure LRO Operation
    /// </summary>
    /// <typeparam name="TResourceBody"></typeparam>
    /// <typeparam name="TRequestHeaders"></typeparam>
    internal class DeleteLro<TResourceBody, TRequestHeaders> : AzureLRO<TResourceBody, TRequestHeaders>
            where TResourceBody : class
            where TRequestHeaders : class
    {
        // Flag to indicate if final GET is set with call back
        private bool SetFinalGetCallback;

        /// <summary>
        /// REST Operation Verb
        /// </summary>
        public override string RESTOperationVerb { get => "DELETE"; }

        /// <summary>
        /// Initializes DELETE LRO Operation
        /// </summary>
        /// <param name="client"></param>
        /// <param name="response"></param>
        /// <param name="customHeaders"></param>
        /// <param name="cancellationToken"></param>
        public DeleteLro(IAzureClient client, AzureOperationResponse<TResourceBody, TRequestHeaders> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) : base(client, response, customHeaders, cancellationToken)
        {
            SetFinalGetCallback = false;
        }

        /// <summary>
        /// For DELETE
        /// In absence of Async-operation, fall back on location header
        /// 
        /// If both (Async-Operation, LocationHeader) provided, we will use Async-Operation for driving LRO
        /// Will perform final GET on the provided LocationHeader to get calculation results.
        /// 
        /// If first response status code is 201 and location header is not provided, we throw
        /// 
        /// if first response status code is 202, we prefer Async-operation, else we will use Location header
        /// </summary>
        protected override void InitializeAsyncHeadersToUse()
        {
            base.InitializeAsyncHeadersToUse();
            
            // 201 (status code)
            // We are being extra permissible, we will not throw if RP sends 201 + location header, we will treat it similarly as 202+location
            if (CurrentPollingState.CurrentStatusCode == System.Net.HttpStatusCode.Created)
            {
                if (!string.IsNullOrEmpty(CurrentPollingState.LocationHeaderLink))
                {
                    CurrentPollingState.PollingUrlToUse = CurrentPollingState.LocationHeaderLink;
                    CurrentPollingState.FinalGETUrlToUser = CurrentPollingState.LocationHeaderLink;
                    SetFinalGetCallback = true;                    
                }
                else
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "Recommended pattern DELETE-201-LocationHeader");
                }
            }

            // For 202 (status code), we prefer AzureAsyncOperation header, else we fallback on LocationHeader
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

                    // During polling if we get location header in addtion to AsyncOperation header, that needs to be used to get result for the final GET
                    CurrentPollingState.FinalGETUrlToUser = GetValidAbsoluteUri(CurrentPollingState.LocationHeaderLink);
                    SetFinalGetCallback = true;
                }

                if (string.IsNullOrEmpty(CurrentPollingState.PollingUrlToUse))
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "Recommended patterns: DELETE-202-LocationHeader(Prefered)/AzureAsyncOperationHeader");
                }
            }
        }

        /// <summary>
        /// Is checking provisioning state applicable for DELTE during LRO operation
        /// If response code is 200/204 (regardless of header and first response code)
        /// 
        /// This does not mean that for 200/204 the response WILL have provisioning state
        /// This function only says to check provisioning state that is all.
        /// </summary>
        /// <returns></returns>
        protected override bool IsCheckingProvisioningStateApplicable()
        {
            // For DELETE check Provisioning for 200 and 204
            return ((CurrentPollingState.CurrentStatusCode == HttpStatusCode.OK) ||
                     (CurrentPollingState.CurrentStatusCode == HttpStatusCode.NoContent));
        }

        /// <summary>
        /// If Azure Async-Operation URL is being used to poll and if the final response or any response returned Location header
        /// We assume a final GET has to be done on provided location header
        /// 
        /// This funciton allows to make any tweaks to the final GET if applicable
        /// In this case, using Location header to do the final GET
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
                        if (SetFinalGetCallback)
                        {
                            // Initialize callback for final GET
                            CurrentPollingState.IgnoreOperationErrorStatusCallBack = (httpRequest) => IgnoreResponseStatus(httpRequest);
                        }

                        CurrentPollingState.PollingUrlToUse = GetValidAbsoluteUri(CurrentPollingState.FinalGETUrlToUser, throwForInvalidUri: true);
                        await CurrentPollingState.UpdateResourceFromPollingUri(CustomHeaders, CancelToken);
                    }
                }
            }
#if DEBUG
            RemoveLroHeaders(removeOperation: true);
#endif
        }

        /// <summary>
        /// Flag if NotFound status should be ignored during DELETE polling
        /// Enable legacy behavior for certain RPs that are sending resource URI as part of location
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        internal bool IgnoreResponseStatus(HttpResponseMessage response)
        {
            bool ignoreCheckingErrorStatus = false;
            HttpStatusCode statusCode = response.StatusCode;

            if (statusCode == HttpStatusCode.NoContent)
                ignoreCheckingErrorStatus = true;
            else if(statusCode == HttpStatusCode.PreconditionFailed)
                ignoreCheckingErrorStatus = true;
            else if (statusCode == HttpStatusCode.NotFound)
                ignoreCheckingErrorStatus = true;

            return ignoreCheckingErrorStatus;
        }
    }
}
