// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.LRO
{
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.Properties;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for driving Azure LRO operation
    /// </summary>
    /// <typeparam name="TResourceBody"></typeparam>
    /// <typeparam name="TRequestHeaders"></typeparam>
    internal abstract class AzureLRO<TResourceBody, TRequestHeaders> : IAzureLRO<TResourceBody, TRequestHeaders>
        where TResourceBody : class
        where TRequestHeaders : class
    {   
        public abstract string RESTOperationVerb { get; }

        #region fields
        protected AzureOperationResponse<TResourceBody, TRequestHeaders> InitialResponse;
        protected CancellationToken CancelToken;
        protected Dictionary<string, List<string>> _customHeaders;
        protected LROPollState<TResourceBody, TRequestHeaders> CurrentPollingState;
        protected IAzureClient SdkClient;
        protected bool IsLROTaskCompleted { get; set; }
        #endregion
        
        #region constructor
        /// <summary>
        /// Constructor for creating Azure LRO
        /// LRO starts after the first response is returned to Azure ClientRuntime.
        /// This will validate the initial response for missing data.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="initialResponse"></param>
        /// <param name="customHeaders"></param>
        /// <param name="cancellationToken"></param>
        protected AzureLRO(IAzureClient client,
            AzureOperationResponse<TResourceBody, TRequestHeaders> initialResponse, Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken)
        {
            InitialResponse = initialResponse;
            CustomHeaders = customHeaders;
            CancelToken = cancellationToken;
            SdkClient = client;
            ValidateInitialResponse();
#if DEBUG
            lroPollingCount = 1;
#endif
        }
        #endregion

        protected Dictionary<string, List<string>> CustomHeaders
        {
            get
            {
                if (_customHeaders == null)
                    _customHeaders = new Dictionary<string, List<string>>();

                return _customHeaders;
            }

            set
            {
                _customHeaders = value;
            }
        }

        #region Public functions
        /// <summary>
        /// Begin polling
        /// This will drive the entire LRO process of polling and checking for error during LRO
        /// </summary>
        /// <returns></returns>
        public virtual async Task BeginLROAsync()
        {
            IsLROTaskCompleted = false;

            InitializeAsyncHeadersToUse();
            await StartPollingAsync();
            await PostPollingAsync();
            CheckFinalErrors();

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

        /// <summary>
        /// Check for errors at the end of LRO operation
        /// Last chance to check any final errors
        /// </summary>
        protected virtual void CheckFinalErrors()
        {
            if (!string.IsNullOrEmpty(CurrentPollingState.LastSerializationExceptionMessage))
            {
                // Let empty/null body return back to the client.
                // throw new CloudException(string.Format(Resources.BodyDeserializationError, CurrentPollingState.LastSerializationExceptionMessage));
            }
        }


        /// <summary>
        /// Does basic validation on initial response from RP, prior to start LRO process
        /// </summary>
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
        
        /// <summary>
        /// Initialize pollingUrl to use depending upon the headers passed back from RP
        /// This function will be called after each response received during LRO
        /// Each REST verb will override for specific requirements
        /// </summary>
        protected virtual void InitializeAsyncHeadersToUse()
        {
            if (CurrentPollingState == null)
            {
                CurrentPollingState = new LROPollState<TResourceBody, TRequestHeaders>(InitialResponse, SdkClient);
#if DEBUG
                InitLroSession();
#endif

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

        /// <summary>
        /// Performs polling
        /// Workflow:
        /// Depends on an internal structure CurrentPollingState for driving the LRO operation
        /// 1) Depending upon the initial response status (starts/exits polling)
        /// 2) Reson for making Poll function part of CurrentPollingState because there can be scenario we might have to enabled to serialize polling state (user can save and drive polling operation)
        /// 3) Update polling state after each polling iteration
        /// 4) Check for errors on each reponse we recieve during LRO
        /// 5) Initialize polling URL to use based on the headers received in each polling response
        /// </summary>
        /// <returns></returns>
        protected virtual async Task StartPollingAsync()
        {
#if DEBUG
            InitPollingSession();
#endif
            while (!AzureAsyncOperation.TerminalStatuses.Any(s => s.Equals(CurrentPollingState.Status, StringComparison.OrdinalIgnoreCase)))
            {
                await Task.Delay(CurrentPollingState.DelayBetweenPolling, CancelToken);
#if DEBUG
                UpdatePollingSessionIds();
#endif
                await CurrentPollingState.Poll(CustomHeaders, CancelToken);
                UpdatePollingState();
                CheckForErrors();
                InitializeAsyncHeadersToUse();
            }
#if DEBUG
            RemoveLroHeaders(removePerfImapact: true);
#endif
        }

        /// <summary>
        /// Updates polling state strcture
        /// </summary>
        protected virtual void UpdatePollingState()
        {
            #region Check provisionState
            CurrentPollingState.CurrentStatusCode = CurrentPollingState.Response.StatusCode;

            if (IsAzureAsyncOperationResponseStateValid() == true)
            {
                CurrentPollingState.Status = GetAzureAsyncResponseState();
            }
            else // we assume the polling is happening on locaiton header
            {
                if (CurrentPollingState.CurrentStatusCode == HttpStatusCode.Accepted)
                {
                    CurrentPollingState.Status = AzureAsyncOperation.InProgressStatus;
                }
                else
                {
                    CurrentPollingState.Status = CurrentPollingState.GetProvisioningStateFromBody(CurrentPollingState.RawBody, CurrentPollingState.CurrentStatusCode, () => IsCheckingProvisioningStateApplicable());
                }

                if (string.IsNullOrEmpty(CurrentPollingState.Status))
                {
                    throw new CloudException("The response from long running operation does not have a valid status code.");
                }

                #region old code
                //else if (IsCheckingProvisioningStateApplicable() == true) //Each verb can decide if Provisioning state is applicable and if it needs to be checked
                //{
                //    CurrentPollingState.Status = GetProvisioningStateFromRawBody();                   
                //}
                //else
                //{
                //    throw new CloudException("The response from long running operation does not have a valid status code.");
                //}
                #endregion
            }
            #endregion
        }

        string GetPSFromRawBody()
        {
            string provisioningState = string.Empty;

            // We check if we got provisionState and we get the status from provisioning state

            // In 202 pattern ProvisioningState may not be present in 
            // the response. In that case the assumption is the status is Succeeded.

            // We call IsCheckingProvisioning here just to make sure this code should be treated as one unit, you always check for provisioning state only if it's applicable
            if (IsCheckingProvisioningStateApplicable() == true)  // Each verb can decide if Provisioning state is applicable and if it needs to be checked
            {
                if (CurrentPollingState.RawBody != null &&
                        CurrentPollingState.RawBody["properties"] != null &&
                        CurrentPollingState.RawBody["properties"]["provisioningState"] != null)
                {
                    provisioningState = ((string)CurrentPollingState?.RawBody?["properties"]?["provisioningState"])?.Trim();
                }
            }

            if(string.IsNullOrEmpty(provisioningState))
            {
                provisioningState = AzureAsyncOperation.SuccessStatus.ToString();
            }

            return provisioningState;

            #region old code
            //// We check if we got provisionState and we get the status from provisioning state

            //// In 202 pattern ProvisioningState may not be present in 
            //// the response. In that case the assumption is the status is Succeeded.
            //if (CurrentPollingState.RawBody != null &&
            //    CurrentPollingState.RawBody["properties"] != null &&
            //    CurrentPollingState.RawBody["properties"]["provisioningState"] != null &&
            //    CurrentPollingState?.RawBody?["properties"]?["provisioningState"]?.HasValues == true)
            //{
            //    provisioningState = ((string)CurrentPollingState?.RawBody?["properties"]?["provisioningState"])?.Trim();
            //}

            //if (string.IsNullOrEmpty(provisioningState))
            //{
            //    provisioningState = AzureAsyncOperation.SuccessStatus;
            //}

            //CurrentPollingState.Status = provisioningState;
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

        /// <summary>
        /// Each verb will override depending upon the requirements
        /// </summary>
        /// <returns></returns>
        protected virtual async Task PostPollingAsync()
        {
            return;
        }

        /// <summary>
        /// Check for error codition during LRO
        /// Each verb can participate in deciding if certain response results in error
        /// </summary>
        protected virtual void CheckForErrors()
        {
            // Check if operation failed
            if (AzureAsyncOperation.FailedStatuses.Any(
                        s => s.Equals(CurrentPollingState.Status, StringComparison.OrdinalIgnoreCase)))
            {
                throw CurrentPollingState.CloudException;
            }

            //If Async-Operation header used, body has to be not null
            if (CurrentPollingState.PollingUrlToUse.Equals(CurrentPollingState.AzureAsyncOperationHeaderLink, StringComparison.OrdinalIgnoreCase))
            {
                if (CurrentPollingState.AsyncOperationResponseBody?.Status == null || CurrentPollingState.RawBody == null)
                {
                    throw new CloudException(Resources.NoBody);
                }

                //if (!string.IsNullOrEmpty(CurrentPollingState.LastSerializationExceptionMessage))
                //{
                //    throw new CloudException(string.Format(Resources.BodyDeserializationError, CurrentPollingState.LastSerializationExceptionMessage));
                //}
            }
        }

        /// <summary>
        /// Validate passed URL
        /// </summary>
        /// <param name="url">Url to be validated</param>
        /// <param name="throwForInvalidUri">True: throws expception, False: does not throw exception</param>
        /// <returns></returns>
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

        #region Private functions

#if DEBUG
        const string Header_LroSessionId = "LroSessionId";
        const string Header_LroPollingId = "LroPollingId";
        const string Header_RecordPlaybackPerfImpact = "RecordPlaybackPerfImpact";
        const string Header_LroOperation = "LroOperation";
        const int perfImpactCount = 3;

        private long lroSessionId { get; set; }

        private long lroPollingId { get; set; }

        private long lroPollingCount { get; set; }

        private string lroSessionPollingId { get; set; }

        
        private void InitLroSession()
        {
            this.lroPollingCount = 1;
            this.lroSessionId = DateTime.Now.Ticks;
            this.CustomHeaders.Add(Header_LroOperation, new List<string>() { this.RESTOperationVerb });
        }

        private void InitPollingSession()
        {
            this.lroPollingId = DateTime.Now.Ticks;
        }

        private void UpdatePollingSessionIds()
        {
            RemoveLroHeaders();
            this.lroSessionPollingId = string.Format("{0}.{1}.{2}", this.lroSessionId.ToString(), this.lroPollingId.ToString(), this.lroPollingCount.ToString());
            this.CustomHeaders.Add(Header_LroSessionId, new List<string>() { this.lroSessionId.ToString() });
            this.CustomHeaders.Add(Header_LroPollingId, new List<string>() { this.lroSessionPollingId.ToString() });
            if(this.lroPollingCount >= perfImpactCount)
            {
                if(!this.CustomHeaders.TryGetValue(Header_RecordPlaybackPerfImpact, out List<string> playBackImpact))
                {
                    this.CustomHeaders.Add(Header_RecordPlaybackPerfImpact, new List<string>() { "true" });
                }
            }

            this.lroPollingCount = this.lroPollingCount + 1;
        }

        protected void RemoveLroHeaders(bool removePerfImapact = false, bool removeOperation = false)
        {
            if(this.CustomHeaders.TryGetValue(Header_LroSessionId, out List<string> lroSessionIdList))
            {
                if(lroSessionIdList.Any())
                {
                    this.CustomHeaders.Remove(Header_LroSessionId);
                }
            }

            if (this.CustomHeaders.TryGetValue(Header_LroPollingId, out List<string> lroPollingIdList))
            {
                if (lroPollingIdList.Any())
                {
                    this.CustomHeaders.Remove(Header_LroPollingId);
                }
            }

            if (removePerfImapact)
            {
                if (this.CustomHeaders.TryGetValue(Header_RecordPlaybackPerfImpact, out List<string> recPerfImpactList))
                {
                    if (recPerfImpactList.Any())
                    {
                        this.CustomHeaders.Remove(Header_RecordPlaybackPerfImpact);
                    }
                }
            }

            if(removeOperation)
            { 
                if (this.CustomHeaders.TryGetValue(Header_LroOperation, out List<string> restOperation))
                {
                    if (restOperation.Any())
                    {
                        this.CustomHeaders.Remove(Header_LroOperation);
                    }
                }
            }
        }

#endif

        /// <summary>
        /// Get Valid status
        /// There are cases where there is an error sent from the service and in that case, the status should be one of the valid FailedStatuses
        /// But there are cases where there is a customized error sent by service and they do not fall under Failed/Success statuses, in that case we fall back on response status
        /// 
        /// e.g. The response status is OK, but the error body has the status as "TestFailed" (which do not fall under valid failed status, so we fall back to OK)
        /// </summary>
        /// <returns></returns>
        private string GetAzureAsyncResponseState()
        {
            string validStatus = string.Empty;
            if (!string.IsNullOrEmpty(CurrentPollingState.AsyncOperationResponseBody?.Status))
            {
                if (AzureAsyncOperation.FailedStatuses.Any(
                        s => s.Equals(CurrentPollingState.AsyncOperationResponseBody.Status, StringComparison.OrdinalIgnoreCase)))
                {
                    validStatus = CurrentPollingState.AsyncOperationResponseBody.Status;
                }
                else if (AzureAsyncOperation.TerminalStatuses.Any(s => s.Equals(CurrentPollingState.AsyncOperationResponseBody.Status, StringComparison.OrdinalIgnoreCase)))
                {
                    validStatus = CurrentPollingState.AsyncOperationResponseBody.Status;
                }
                else if (string.IsNullOrEmpty(validStatus))
                {
                    validStatus = CurrentPollingState.Response.StatusCode.ToString();
                }
            }

            return validStatus;
        }

        /// <summary>
        /// This function determines if you are running your polling under Azure-Async header or if the response status falls under terminal/failed status
        /// </summary>
        /// <returns></returns>
        private bool IsAzureAsyncOperationResponseStateValid()
        {
            if (CurrentPollingState?.AsyncOperationResponseBody != null && !string.IsNullOrEmpty(CurrentPollingState.AsyncOperationResponseBody?.Status))
            {
                if (AzureAsyncOperation.FailedStatuses.Any(
                            s => s.Equals(CurrentPollingState.AsyncOperationResponseBody.Status, StringComparison.OrdinalIgnoreCase)))
                {
                    return true;
                }
                else if (AzureAsyncOperation.TerminalStatuses.Any(s => s.Equals(CurrentPollingState.AsyncOperationResponseBody.Status, StringComparison.OrdinalIgnoreCase)))
                {
                    return true;
                }
                else if(IsUriEqual(CurrentPollingState.PollingUrlToUse, CurrentPollingState.AzureAsyncOperationHeaderLink))
                {   
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check URI for equality including differences in trailing slash and compare case insensitive 
        /// </summary>
        /// <param name="leftUrl">Url</param>
        /// <param name="rightUrl">Url to compare against</param>
        /// <returns></returns>
        private bool IsUriEqual(string leftUrl, string rightUrl)
        {
            if (string.IsNullOrEmpty(leftUrl)) return false;
            if (string.IsNullOrEmpty(rightUrl)) return false;

            Uri left = new Uri(leftUrl);
            Uri right = new Uri(rightUrl);

            int result = Uri.Compare(left, right, UriComponents.Fragment, UriFormat.SafeUnescaped, StringComparison.OrdinalIgnoreCase);
            return (result == 0);
        }

        #endregion
    }
}
