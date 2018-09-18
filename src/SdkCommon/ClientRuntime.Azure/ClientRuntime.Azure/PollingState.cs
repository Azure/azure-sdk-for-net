// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Azure
{
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Rest.ClientRuntime.Azure.Properties;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    /// <summary>
    /// Defines long running operation polling state.
    /// </summary>
    /// <typeparam name="TBody">Type of resource body.</typeparam>
    /// <typeparam name="THeader">Type of resource header.</typeparam>
    internal class PollingState<TBody, THeader> where TBody : class where THeader : class
    {
#if DEBUG
        const int TEST_MIN_DELAY_SECONDS = 0;
        const int DEFAULT_MIN_DELAY_SECONDS = 0;
        const int DEFAULT_MAX_DELAY_SECONDS = 40;
#else
        // Delay values are in seconds
        const int TEST_MIN_DELAY_SECONDS = 0;
        const int DEFAULT_MIN_DELAY_SECONDS = 10;
        const int DEFAULT_MAX_DELAY_SECONDS = 600;
#endif

        private int _retryAfterInSeconds;
        private int _clientLongRunningOperationRetryTimeout;
        private bool _isRunningUnderPlaybackMode;


        /// <summary>
        /// Initializes an instance of PollingState.
        /// </summary>
        /// <param name="response">First operation response.</param>
        /// <param name="retryTimeout">Default timeout.</param>
        public PollingState(HttpOperationResponse<TBody, THeader> response, int? retryTimeout)
        {
            // Due to test/playback scenario, we prioritze retryTimeout set by Client (client.LongRunningOperationRetryTimeout property)
            // So LROTimeoutsetbyClient needs to be set first before we set the generic RetryAfterInSeconds value
            LROTimeoutSetByClient = retryTimeout.HasValue ? retryTimeout.Value : AzureAsyncOperation.DefaultDelay;
            RetryAfterInSeconds = retryTimeout.HasValue ? retryTimeout.Value : AzureAsyncOperation.DefaultDelay;
            Response = response.Response;
            Request = response.Request;
            Resource = response.Body;
            ResourceHeaders = response.Headers;
            _isRunningUnderPlaybackMode = false;

            string raw = response.Response.Content == null ? null : response.Response.Content.AsString();

            JObject resource = null;
            if (!string.IsNullOrEmpty(raw))
            {
                try
                {
                    resource = JObject.Parse(raw);
                }
                catch (JsonException)
                {
                    // failed to deserialize, return empty body
                }
            }

            Status = GetProvisioningStateFromBody(resource, Response.StatusCode);

            #region old code
            //switch (Response.StatusCode)
            //{
            //    case HttpStatusCode.Accepted:
            //        Status = AzureAsyncOperation.InProgressStatus;
            //        break;
            //    case HttpStatusCode.OK:
            //        if (resource != null && resource["properties"] != null &&
            //            resource["properties"]["provisioningState"] != null)
            //        {
            //            Status = (string)resource["properties"]["provisioningState"];
            //        }
            //        else
            //        {
            //            Status = AzureAsyncOperation.SuccessStatus;
            //        }
            //        break;
            //    case HttpStatusCode.Created:
            //        if (resource != null && resource["properties"] != null &&
            //            resource["properties"]["provisioningState"] != null)
            //        {
            //            Status = (string) resource["properties"]["provisioningState"];
            //        }
            //        else
            //        {
            //            Status = AzureAsyncOperation.InProgressStatus;
            //        }
            //        break;
            //    case HttpStatusCode.NoContent:
            //        Status = AzureAsyncOperation.SuccessStatus;
            //        break;
            //    default:
            //        Status = AzureAsyncOperation.FailedStatus;
            //        break;
            //}
            #endregion
        }

        public virtual string GetProvisioningStateFromBody(JObject body, HttpStatusCode statusCode)
        {
            // We check if we got provisionState and we get the status from provisioning state

            // In 202 pattern ProvisioningState may not be present in 
            // the response. In that case the assumption is the status is Succeeded.

            // We call IsCheckingProvisioning here just to make sure this code should be treated as one unit, you always check for provisioning state only if it's applicable

            string localStatus = ((string)body?["properties"]?["provisioningState"])?.Trim();

            switch (statusCode)
            {
                case HttpStatusCode.Accepted:
                    localStatus = AzureAsyncOperation.InProgressStatus;
                    break;

                case HttpStatusCode.OK:
                    if (string.IsNullOrEmpty(localStatus))
                    {
                        localStatus = AzureAsyncOperation.SuccessStatus;
                    }
                    break;

                case HttpStatusCode.Created:
                    if (string.IsNullOrEmpty(localStatus))
                    {
                        localStatus = AzureAsyncOperation.InProgressStatus;    //Checked with ARM and it is confirmed that in the case of Created, provisioning state will always be sent, if not it's a success
                    }
                    break;

                case HttpStatusCode.NoContent:
                    localStatus = AzureAsyncOperation.SuccessStatus;
                    break;

                default:
                    localStatus = AzureAsyncOperation.FailedStatus;
                    break;
            }

            return localStatus;
        }

        public string GetProvisioningStateFromBody(JObject body, HttpStatusCode statusCode, Func<bool> checkProvisioningState)
        {
            string localStatus = string.Empty;
            if (checkProvisioningState())
            {
                //localStatus = GetProvisioningStateFromBody(body, statusCode);
                localStatus = ((string)body?["properties"]?["provisioningState"])?.Trim();

                if (string.IsNullOrEmpty(localStatus))
                {
                    localStatus = AzureAsyncOperation.SuccessStatus;
                }
            }

            return localStatus;
        }


        string GetPS(JObject body)
        {
            string provisioningState = string.Empty;
            provisioningState = ((string)body?["properties"]?["provisioningState"])?.Trim();

            if (string.IsNullOrEmpty(provisioningState))
            {
                provisioningState = AzureAsyncOperation.SuccessStatus.ToString();
            }

            return provisioningState;
        }

        private string _status;

        private CloudException _cloudException;

        /// <summary>
        /// Gets or sets polling status.
        /// </summary>
        public string Status {
            get
            {
                return _status;
            }
            set
            {
                if (value == null)
                {
                    throw new CloudException(Resources.NoProvisioningState);
                }
                _status = value;
            }
        }

        /// <summary>
        /// Gets or sets the latest value captured from Azure-AsyncOperation header.
        /// </summary>
        public string AzureAsyncOperationHeaderLink { get; set; }

        /// <summary>
        /// Gets or sets the latest value captured from Location header.
        /// </summary>
        public string LocationHeaderLink { get; set; }

        private HttpResponseMessage _response;

        /// <summary>
        /// Gets or sets last operation response. 
        /// </summary>
        public HttpResponseMessage Response
        {
            get { return _response; }
            set
            {
                _response = value;
                if (_response != null)
                {
                    if (_response.Headers.Contains("azSdkTestPlayBackMode"))
                    {
                        _isRunningUnderPlaybackMode = bool.Parse(_response.Headers.GetValues("azSdkTestPlayBackMode").FirstOrDefault());
                    }
                    if (_response.Headers.Contains("Azure-AsyncOperation"))
                    {
                        AzureAsyncOperationHeaderLink = _response.Headers.GetValues("Azure-AsyncOperation").FirstOrDefault();
                    }
                    if (_response.Headers.Contains("Location"))
                    {
                        LocationHeaderLink = _response.Headers.GetValues("Location").FirstOrDefault();
                    }
                    if (_response.Headers.Contains("Retry-After"))
                    {
                        string retryValue = _response.Headers.GetValues("Retry-After").FirstOrDefault();
                        RetryAfterInSeconds = int.Parse(retryValue, CultureInfo.InvariantCulture);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets last operation request.
        /// </summary>
        public HttpRequestMessage Request { get; set; }

        /// <summary>
        /// Gets or sets cloud error.
        /// </summary>
        public CloudError Error { get; set; }

        /// <summary>
        /// Gets or sets resource.
        /// </summary>
        public TBody Resource { get; set; }

        /// <summary>
        /// Gets or sets resource header.
        /// </summary>
        public THeader ResourceHeaders { get; set; }

        /// <summary>
        /// This timeout is set by client during client construction
        /// This is useful to detect if we are running in test/playback mode
        /// </summary>
        private int LROTimeoutSetByClient
        {
            get
            {
                return _clientLongRunningOperationRetryTimeout;
            }
            set
            {
                _clientLongRunningOperationRetryTimeout = value;
            }
        }

        /// <summary>
        /// Gets long running operation delay in milliseconds.
        /// </summary>
        [Obsolete("DelayInMilliseconds property will be deprecated in future releases. You should start using DelayBetweenPolling")]
        public int DelayInMilliseconds
        {
            get
            {
                return RetryAfterInSeconds * 1000;
            }
        }

        /// <summary>
        /// Long running operation polling delay
        /// </summary>
        public TimeSpan DelayBetweenPolling
        {
            get
            {
                return TimeSpan.FromSeconds(RetryAfterInSeconds);
            }
        }

        /// <summary>
        /// Initially this is initialized with LongRunningOperationRetryTimeout value
        /// Verify min/max allowed value according to ARM spec (especially minimum value for throttling at ARM level)
        /// We want this to be int value and not int? because this value will always have a default non-zero/non-null value
        /// </summary>
        internal int RetryAfterInSeconds
        {
            get
            {
                return _retryAfterInSeconds;
            }

            set
            {
                _retryAfterInSeconds = ValidateRetryAfterValue(value);
            }
        }

        /// <summary>
        /// Test hook to determine if running under Playback mode (test mode)
        /// </summary>
        internal bool IsRunningUnderPlaybackMode
        {
            get
            {
                if (Response != null)
                {
                    if (Response.Headers.Contains("azSdkTestPlayBackMode"))
                    {
                        _isRunningUnderPlaybackMode = bool.Parse(Response.Headers.GetValues("azSdkTestPlayBackMode").FirstOrDefault());
                    }
                }

                return _isRunningUnderPlaybackMode;
            }
        }

        private int ValidateRetryAfterValue(int? currentValue)
        {
            if (currentValue.HasValue)
            {
                if (currentValue <= TEST_MIN_DELAY_SECONDS)
                    currentValue = TEST_MIN_DELAY_SECONDS;
                else if (currentValue < DEFAULT_MIN_DELAY_SECONDS)
                    currentValue = DEFAULT_MIN_DELAY_SECONDS;
                else if (currentValue > DEFAULT_MAX_DELAY_SECONDS)
                    currentValue = DEFAULT_MAX_DELAY_SECONDS;

                if (IsRunningUnderPlaybackMode)
                {
                    currentValue = TEST_MIN_DELAY_SECONDS;
                }
                else
                {
                    if (LROTimeoutSetByClient == TEST_MIN_DELAY_SECONDS)    // we assume playback mode (test mode)
                    {
                        if (currentValue != LROTimeoutSetByClient)  //Case where Retry-After is set to non zero, we set it to 0 in playback mode
                        {
                            currentValue = TEST_MIN_DELAY_SECONDS;
                        }
                    }
                }
            }
            else
            {
                currentValue = AzureAsyncOperation.DefaultDelay;
            }

            return currentValue.Value;
        }

        /// <summary>
        /// Gets CloudException from current instance.  
        /// </summary>
        public CloudException CloudException
        {
            get
            {
                if(_cloudException == null)
                {
                    _cloudException = new CloudException(string.Format(CultureInfo.InvariantCulture,
                                            Resources.LongRunningOperationFailed, Status))
                    {
                        Body = Error,
                        Request = new HttpRequestMessageWrapper(Request, Request.Content.AsString()),
                        Response = new HttpResponseMessageWrapper(Response, Response.Content.AsString())
                    };
                }

                return _cloudException;
            }

            internal set
            {
                _cloudException = value;
            }
        }

        /// <summary>
        /// Gets AzureOperationResponse from current instance. 
        /// </summary>
        public AzureOperationResponse<TBody, THeader> AzureOperationResponse
        {
            get
            {
                return new AzureOperationResponse<TBody, THeader>
                {
                    Body = Resource,
                    Headers = ResourceHeaders,
                    Request = Request,
                    Response = Response
                };
            }
        }
    }
}
