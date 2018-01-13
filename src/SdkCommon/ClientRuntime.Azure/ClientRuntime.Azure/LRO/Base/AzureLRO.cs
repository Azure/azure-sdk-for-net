// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.LRO
{
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.Properties;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class AzureLRO<TResourceBody, TRequestHeaders> : IAzureLRO<TResourceBody, TRequestHeaders>
        where TResourceBody : class
        where TRequestHeaders : class
    {   
        public abstract string RESTOperationVerb { get; }

        #region fields
        protected AzureOperationResponse<TResourceBody, TRequestHeaders> InitialResponse;
        protected CancellationToken CancelToken;
        protected Dictionary<string, List<string>> CustomHeaders;
        protected LROPollState<TResourceBody, TRequestHeaders> CurrentPollingState;
        protected IAzureClient SdkClient;
        protected bool IsLROTaskCompleted { get; set; }
        protected string LROState { get; set; }

        private Task PollTask { get; set; }
        #endregion
        
        #region constructor
        protected AzureLRO(IAzureClient client,
            AzureOperationResponse<TResourceBody, TRequestHeaders> initialResponse, Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken)
        {
            InitialResponse = initialResponse;
            CustomHeaders = customHeaders;
            CancelToken = cancellationToken;
            SdkClient = client;
            ValidateInitialResponse();
        }
        #endregion

        #region Public functions
        /// <summary>
        /// Begin polling
        /// </summary>
        /// <returns></returns>
        public virtual async Task BeginLROAsync()
        {
            IsLROTaskCompleted = false;

            InitializeAsyncHeadersToUse();
            await StartPollingAsync();
            await PostPollingAsync();
            CheckForErrors();

            IsLROTaskCompleted = true;
        }

        /// <summary>
        /// Return results from LRO operation
        /// </summary>
        /// <returns></returns>
        public virtual async Task<AzureOperationResponse<TResourceBody, TRequestHeaders>> GetLROResults()
        {
            while (IsLROTaskCompleted == false)
            {
                await Task.Delay(CurrentPollingState.DelayBetweenPolling, CancelToken);
            }

            return CurrentPollingState.AzureOperationResponse;
        }
        #endregion

        #region Protected functions
        
        protected virtual void ValidateInitialResponse()
        {
            #region validate data
            if (InitialResponse == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "response");
            }

            if (InitialResponse.Response == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "response.Response");
            }

            if (InitialResponse.Request == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "response.Request");
            }

            if (InitialResponse.Request.Method == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "response.Request.Method");
            }

            if(InitialResponse.Request.RequestUri == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "response.Request.RequestUri");
            }
            #endregion
        }
        
        protected virtual void InitializeAsyncHeadersToUse()
        {
            if (CurrentPollingState == null)
            {
                CurrentPollingState = new LROPollState<TResourceBody, TRequestHeaders>(InitialResponse, SdkClient);

                if (!string.IsNullOrEmpty(CurrentPollingState.AzureAsyncOperationHeaderLink))
                {
                    CurrentPollingState.PollingUrlToUse = CurrentPollingState.AzureAsyncOperationHeaderLink;
                }

                if (string.IsNullOrEmpty(CurrentPollingState.PollingUrlToUse) && !string.IsNullOrEmpty(CurrentPollingState.LocationHeaderLink))
                {
                    CurrentPollingState.PollingUrlToUse = CurrentPollingState.LocationHeaderLink;
                }

                if (string.IsNullOrEmpty(CurrentPollingState.PollingUrlToUse))
                {
                    CurrentPollingState.PollingUrlToUse = string.Empty;
                }
            }
        }

        protected virtual async Task StartPollingAsync()
        {
            while (!AzureAsyncOperation.TerminalStatuses.Any(s => s.Equals(CurrentPollingState.Status, StringComparison.OrdinalIgnoreCase)))
            {
                await Task.Delay(CurrentPollingState.DelayBetweenPolling, CancelToken);
                await CurrentPollingState.Poll(CustomHeaders, CancelToken);
                UpdatePollingState();
                CheckForErrors();
                InitializeAsyncHeadersToUse();
            }
        }

        protected virtual void UpdatePollingState()
        {
            #region Check provisionState
            CurrentPollingState.CurrentStatusCode = CurrentPollingState.Response.StatusCode;

            if (!string.IsNullOrEmpty(CurrentPollingState.AsyncOperationResponseBody?.Status) && (!string.IsNullOrEmpty(CurrentPollingState.AzureAsyncOperationHeaderLink)))
            {
                CurrentPollingState.Status = CurrentPollingState.AsyncOperationResponseBody.Status;
            }
            else
            {
                if (CurrentPollingState.CurrentStatusCode == HttpStatusCode.Accepted)
                {
                    CurrentPollingState.Status = AzureAsyncOperation.InProgressStatus;
                }
                else if (IsCheckingProvisioningStateApplicable())
                {
                    // We check if we got provisionState and we get the status from provisioning state

                    // In 202 pattern ProvisioningState may not be present in 
                    // the response. In that case the assumption is the status is Succeeded.
                    if (CurrentPollingState.RawBody != null &&
                        CurrentPollingState.RawBody["properties"] != null &&
                        CurrentPollingState.RawBody["properties"]["provisioningState"] != null)
                    {
                        CurrentPollingState.Status = (string)CurrentPollingState.RawBody["properties"]["provisioningState"];
                    }
                    else
                    {
                        CurrentPollingState.Status = AzureAsyncOperation.SuccessStatus;
                    }
                }
                else
                {
                    throw new CloudException("The response from long running operation does not have a valid status code.");
                }
            }
            #endregion
        }

        /// <summary>
        /// Each verb will override to define if checking provisioning state is applicable
        /// </summary>
        /// <returns>true: if it's applicable, false: if not applicable</returns>
        protected virtual bool IsCheckingProvisioningStateApplicable()
        {
            return true;
        }

        protected virtual async Task PostPollingAsync()
        {
            return;
        }

        protected virtual void CheckForErrors()
        {
            // Check if operation failed
            if (AzureAsyncOperation.FailedStatuses.Any(
                        s => s.Equals(CurrentPollingState.Status, StringComparison.OrdinalIgnoreCase)))
            {
                throw CurrentPollingState.CloudException;
            }

            if (CurrentPollingState.PollingUrlToUse.Equals(CurrentPollingState.AzureAsyncOperationHeaderLink, StringComparison.OrdinalIgnoreCase))
            {
                if (CurrentPollingState.AsyncOperationResponseBody?.Status == null || CurrentPollingState.RawBody == null)
                {
                    throw new CloudException(Resources.NoBody);
                }

                if (!string.IsNullOrEmpty(CurrentPollingState.LastSerializationExceptionMessage))
                {
                    throw new CloudException(string.Format(Resources.BodyDeserializationError, CurrentPollingState.LastSerializationExceptionMessage));
                }
            }
        }

        protected virtual string GetValidAbsoluteUri(string url, bool throwForInvalidUri = false)
        {
            string absoluteUri = string.Empty;
            Uri givenUri = null;
            if (Uri.TryCreate(url, UriKind.Absolute, out givenUri))
            {
                absoluteUri = givenUri.AbsoluteUri;
            }

            if(throwForInvalidUri)
            {
                if(string.IsNullOrEmpty(absoluteUri))
                {
                    throw new CloudException(Resources.InValidUri);
                }
            }

            return absoluteUri;
        }
        #endregion
    }
}
