// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Properties;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure
{
    public static class AzureClientLongRunningOperationExtensions
    {
        public static async Task<AzureOperationResponse<T>> GetCreateOrUpdateOperationResult<T>(this IAzureClient client, 
            AzureOperationResponse<T> response,
            Func<Task<AzureOperationResponse<T>>> getOperationAction,
            CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : ResourceBase
        {
            Debug.Assert(response != null);
            Debug.Assert(response.Body != null);

            AzureOperationResponse<T> responseWithResource = response;
            AzureOperationResponse<AzureAsyncOperation> responseWithOperationStatus = null;
            string status = response.Body.ProvisioningState;
            CloudError cloudError = null;

            // Check provisioning state
            while (!AzureAsyncOperation.AzureAsyncOperationTerminalStates.Any(s => s.Equals(status,
                StringComparison.InvariantCultureIgnoreCase)))
            {
                // Check Azure-AsyncOperation header
                if (response.Response.Headers.Contains("Azure-AsyncOperation"))
                {
                    // Reset operationResponse
                    responseWithResource = null;

                    string azureAsyncUrl = response.Response.Headers.GetValues("Azure-AsyncOperation").FirstOrDefault();
                    // TODO: Add wait time between polling attempts
                    responseWithOperationStatus = await client.GetAsyncOperation(azureAsyncUrl, 
                        cancellationToken).ConfigureAwait(false);

                    status = responseWithOperationStatus.Body.Status;
                    cloudError = responseWithOperationStatus.Body.Error;
                }
                else
                {
                    // use get getOperationAction if Azure-AsyncOperation header is not present
                    // TODO: Add wait time between polling attempts
                    responseWithResource = await getOperationAction().ConfigureAwait(false);

                    status = responseWithResource.Body.ProvisioningState;
                    cloudError = new CloudError()
                    {
                        Code = status,
                        Message = Resources.LongRunningOperationFailed
                    };
                }
            }

            if (AzureAsyncOperation.AzureAsyncOperationFailedStates.Any(
                        s => s.Equals(status, StringComparison.InvariantCultureIgnoreCase)))
            {
                CloudException exception = new CloudException(Resources.LongRunningOperationFailed)
                {
                    Body = cloudError
                };

                if (responseWithOperationStatus != null)
                {
                    exception.Request = responseWithOperationStatus.Request;
                    exception.Response = responseWithOperationStatus.Response;
                }
                else if (responseWithResource != null)
                {
                    exception.Request = responseWithResource.Request;
                    exception.Response = responseWithResource.Response;
                }
                throw exception;
            }

            if (responseWithResource == null)
            {
                responseWithResource = await getOperationAction().ConfigureAwait(false);
            }

            return responseWithResource;
        }

        public static async Task<AzureOperationResponse> GetDeleteOperationResult(this IAzureClient client,
            AzureOperationResponse response,
            CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Debug.Assert(response != null);
            Debug.Assert(response.Response != null);
            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                         response.Response.StatusCode == HttpStatusCode.Accepted ||
                         response.Response.StatusCode == HttpStatusCode.NoContent);

            AzureOperationResponse responseFromLocation = response;
            AzureOperationResponse<AzureAsyncOperation> responseWithOperationStatus = null;
            string status = response.Response.StatusCode == HttpStatusCode.Accepted ? "Deleting" : "Succeeded";
            CloudError cloudError = null;

            // Check provisioning state
            while (!AzureAsyncOperation.AzureAsyncOperationTerminalStates.Any(s => s.Equals(status,
                StringComparison.InvariantCultureIgnoreCase)))
            {
                // Check Azure-AsyncOperation header
                if (response.Response.Headers.Contains("Azure-AsyncOperation"))
                {
                    // Reset operationResponse
                    responseFromLocation = null;

                    string azureAsyncUrl = response.Response.Headers.GetValues("Azure-AsyncOperation").FirstOrDefault();
                    // TODO: Add wait time between polling attempts
                    responseWithOperationStatus = await client.GetAsyncOperation(azureAsyncUrl,
                        cancellationToken).ConfigureAwait(false);

                    status = responseWithOperationStatus.Body.Status;
                    cloudError = responseWithOperationStatus.Body.Error;
                }
                else
                {
                    string locationUrl = response.Response.Headers.GetValues("Location").FirstOrDefault();
                    // use get getOperationAction if Azure-AsyncOperation header is not present
                    // TODO: Add wait time between polling attempts
                    responseFromLocation = await client.GetAsyncOperationFromLocation(locationUrl, cancellationToken).ConfigureAwait(false);

                    status = response.Response.StatusCode == HttpStatusCode.Accepted ? "Deleting" : "Succeeded";
                    cloudError = new CloudError()
                    {
                        Code = status,
                        Message = Resources.LongRunningOperationFailed
                    };
                }
            }

            if (AzureAsyncOperation.AzureAsyncOperationFailedStates.Any(
                    s => s.Equals(status, StringComparison.InvariantCultureIgnoreCase)))
            {
                CloudException exception = new CloudException(Resources.LongRunningOperationFailed)
                {
                    Body = cloudError
                };

                // Azure terminal state is only possible from Azure-AsyncOperation
                if (responseWithOperationStatus != null)
                {
                    exception.Request = responseWithOperationStatus.Request;
                    exception.Response = responseWithOperationStatus.Response;
                }

                throw exception;
            }

            // TODO: Response can be from responseWithOperationStatus or responseFromLocation. Handle! 

            return responseFromLocation;
        }

        public static async Task<AzureOperationResponse<AzureAsyncOperation>> GetAsyncOperation(
            this IAzureClient client,
            string operationStatusLink, 
            CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (operationStatusLink == null)
            {
                throw new ArgumentNullException("operationStatusLink");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("operationStatusLink", operationStatusLink);
                ServiceClientTracing.Enter(invocationId, client, "GetLongRunningOperationStatusAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + operationStatusLink;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            AzureAsyncOperation resultModel = null;
            if (!string.IsNullOrEmpty(responseContent))
            {
                resultModel = new AzureAsyncOperation();
                JToken responseDoc = null;
                responseDoc = JToken.Parse(responseContent);

                if (responseDoc != null)
                {
                    resultModel.DeserializeJson(responseDoc);
                }
            }

            if (statusCode != HttpStatusCode.OK && resultModel == null)
            {
                CloudError cloudError = new CloudError(responseContent);
                CloudException ex = new CloudException(cloudError.Message);
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                ex.Body = cloudError;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<AzureAsyncOperation> result = new AzureOperationResponse<AzureAsyncOperation>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            result.Body = resultModel;

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        public static async Task<AzureOperationResponse> GetAsyncOperationFromLocation(
            this IAzureClient client,
            string locationUrl,
            CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (locationUrl == null)
            {
                throw new ArgumentNullException("operationStatusLink");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("operationStatusLink", locationUrl);
                ServiceClientTracing.Enter(invocationId, client, "GetLongRunningOperationStatusAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + locationUrl;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();

            if (statusCode != HttpStatusCode.OK && 
                statusCode != HttpStatusCode.Accepted &&
                statusCode != HttpStatusCode.NoContent)
            {
                CloudException ex = new CloudException(Resources.LongRunningOperationFailed);
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
    }
}
