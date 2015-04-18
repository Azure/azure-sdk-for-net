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
using Microsoft.Rest;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure
{
    public static class AzureClientExtensions
    {
        public static async Task<AzureOperationResponse<T>> GetCreateOrUpdateOperationResult<T>(this IAzureClient client, 
            AzureOperationResponse<T> response,
            Func<Task<AzureOperationResponse<T>>> getOperationAction,
            CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : ResourceBase
        {
            Debug.Assert(response != null);
            Debug.Assert(response.Body != null);

            AzureOperationResponse<T> operationResponse = response;
            string status = response.Body.ProvisioningState;

            // Check provisioning state
            while (!AzureAsyncOperation.AzureAsyncOperationTerminalStates.Any(s => s.Equals(status,
                StringComparison.InvariantCultureIgnoreCase)))
            {
                // Reset operationResponse
                operationResponse = null;

                // Check Azure-AsyncOperation header
                if (response.Response.Headers.Contains("Azure-AsyncOperation"))
                {
                    string azureAsyncUrl = response.Response.Headers.GetValues("Azure-AsyncOperation").FirstOrDefault();
                    AzureOperationResponse<AzureAsyncOperation> asyncOperation =
                        await client.GetAsyncOperation(azureAsyncUrl, cancellationToken).ConfigureAwait(false);

                    status = asyncOperation.Body.Status;
                }
                else
                {
                    // use get getOperationAction
                    operationResponse = await getOperationAction().ConfigureAwait(false);

                    status = operationResponse.Body.ProvisioningState;
                }
            }

            if (operationResponse == null)
            {
                operationResponse = await getOperationAction().ConfigureAwait(false);
            }

            return operationResponse;
        }

        //public static async Task<AzureOperationResponse<object>> GetDeleteOperationResult<T>(this IAzureClient client,
        //    AzureOperationResponse<T> response,
        //    CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        //{
            
        //}

        public static async Task<AzureOperationResponse<AzureAsyncOperation>> GetAsyncOperation(this IAzureClient client,
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

            // Set Headers
            httpRequest.Headers.Add("x-ms-version", "2013-03-01");

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

            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.Accepted)
            {
                HttpOperationException<AzureAsyncOperation> ex = new HttpOperationException<AzureAsyncOperation>();
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                ex.Body = resultModel;
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
    }
}
