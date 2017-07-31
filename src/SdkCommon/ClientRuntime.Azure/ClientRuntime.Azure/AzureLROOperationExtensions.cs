﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Azure
{
    using Microsoft.Rest.ClientRuntime.Azure.Properties;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public static partial class AzureClientExtensions
    {
        /// <summary>
        /// Updates PollingState from Location header.
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body.</typeparam>
        /// <typeparam name="THeader">Type of the resource header.</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="pollingState">Current polling state.</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="method">Http method of the initial long running operation request</param>
        /// <returns>Task.</returns>
        private static async Task UpdateStateFromLocationHeader<TBody, THeader>(
           IAzureClient client,
           PollingState<TBody, THeader> pollingState,
           Dictionary<string, List<string>> customHeaders,
           CancellationToken cancellationToken,
           HttpMethod method) where TBody : class where THeader : class
        {
            AzureAsyncOperation asyncOperation = null;

            AzureOperationResponse<JObject, JObject> responseWithResource = await client.GetRawAsync(
                pollingState.LocationHeaderLink,
                customHeaders,
                cancellationToken).ConfigureAwait(false);

            string responseContent = await responseWithResource.Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            pollingState.Response = responseWithResource.Response;
            pollingState.Request = responseWithResource.Request;
            pollingState.Resource = responseWithResource.Body == null ? null : responseWithResource.Body.ToObject<TBody>(JsonSerializer
                    .Create(client.DeserializationSettings));
            pollingState.ResourceHeaders = responseWithResource.Headers.ToObject<THeader>(JsonSerializer
                .Create(client.DeserializationSettings));

            // We try to check if the response had status/error returned
            // the reason we deserialize it as AsyncOperation is simply because we are trying to reuse the AsyncOperation model for deserialization (which has Error, Code and Message model types)
            // which is exacly how the response is returned
            try
            {
                asyncOperation = responseWithResource.Body.ToObject<AzureAsyncOperation>(JsonSerializer.Create(client.DeserializationSettings));
                if(asyncOperation?.Status == null)
                {
                    asyncOperation = null;
                }
            }
            catch { }

            pollingState = GetUpdatedPollingStatus<TBody, THeader>(asyncOperation, responseWithResource, pollingState, responseContent, method);

        }


        /// <summary>
        /// Updates PollingState from GET operations.
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body.</typeparam>
        /// <typeparam name="THeader">Type of the resource header.</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="pollingState">Current polling state.</param>
        /// <param name="getOperationUri">Uri for the get operation</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task.</returns>
        private static async Task UpdateStateFromGetResourceOperation<TBody, THeader>(
            IAzureClient client,
            PollingState<TBody, THeader> pollingState,
            Uri getOperationUri,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) where TBody : class where THeader : class
        {
            AzureAsyncOperation asyncOperation = null;

            AzureOperationResponse<JObject, JObject> responseWithResource = await GetRawAsync(client,
                getOperationUri.AbsoluteUri, customHeaders, cancellationToken).ConfigureAwait(false);

            if (responseWithResource.Body == null)
            {
                throw new CloudException(Resources.NoBody);
            }

            string responseContent = await responseWithResource.Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            pollingState.Response = responseWithResource.Response;
            pollingState.Request = responseWithResource.Request;
            pollingState.Resource = responseWithResource.Body.ToObject<TBody>(JsonSerializer
                .Create(client.DeserializationSettings));
            pollingState.ResourceHeaders = responseWithResource.Headers.ToObject<THeader>(JsonSerializer
                .Create(client.DeserializationSettings));

            // Check if Error/Status was returned in the response
            try
            {
                asyncOperation = responseWithResource.Body.ToObject<AzureAsyncOperation>(JsonSerializer.Create(client.DeserializationSettings));
                if (asyncOperation?.Status == null)
                {
                    asyncOperation = null;
                }
            }
            catch { }

            pollingState = GetUpdatedPollingStatus<TBody, THeader>(asyncOperation, responseWithResource, pollingState, responseContent, null);
        }


        /// <summary>
        /// Updates PollingState from Azure-AsyncOperation header.
        /// </summary>
        /// <typeparam name="TBody">Type of the resource body.</typeparam>
        /// <typeparam name="THeader">Type of the resource header.</typeparam>
        /// <param name="client">IAzureClient</param>
        /// <param name="pollingState">Current polling state.</param>
        /// <param name="customHeaders">Headers that will be added to request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task.</returns>
        private static async Task UpdateStateFromAzureAsyncOperationHeader<TBody, THeader>(
            IAzureClient client,
            PollingState<TBody, THeader> pollingState,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) where TBody : class where THeader : class
        {
            string errMessage = string.Empty;

            AzureOperationResponse<AzureAsyncOperation, object> asyncOperationResponse =
                await client.GetAsync<AzureAsyncOperation, object>(
                    pollingState.AzureAsyncOperationHeaderLink,
                    customHeaders,
                    cancellationToken).ConfigureAwait(false);

            if (asyncOperationResponse.Body == null || asyncOperationResponse.Body.Status == null)
            {
                throw new CloudException(Resources.NoBody);
            }

            string responseContent = await asyncOperationResponse.Response.Content.ReadAsStringAsync().ConfigureAwait(false);

            pollingState.Response = asyncOperationResponse.Response;
            pollingState.Request = asyncOperationResponse.Request;
            pollingState.Resource = null;

            pollingState = GetUpdatedPollingStatus<TBody, THeader>(asyncOperationResponse.Body, 
                                                                    null, pollingState, responseContent, null);
            

            //Try to de-serialize to the response model. (Not required for "PutOrPatch" 
            //which has the fallback of invoking generic "resource get".)
            //string responseContent = await pollingState.Response.Content.ReadAsStringAsync();
            var responseHeaders = pollingState.Response.Headers.ToJson();
            try
            {
                pollingState.Resource = JObject.Parse(responseContent)
                    .ToObject<TBody>(JsonSerializer.Create(client.DeserializationSettings));
                pollingState.ResourceHeaders =
                    responseHeaders.ToObject<THeader>(JsonSerializer.Create(client.DeserializationSettings));
            }
            catch { };
        }
        
            /// <summary>
            /// The primary purpose for this function is to get status and if there is any error
            /// Update error information to pollingState.Error and pollingState.Exception
            /// 
            /// We have on a very high level two cases
            /// 1) Regardless what kind of LRO operation it is (AzureAsync, locaiton header) either we get error or we dont
            /// 2) If we get error object, this function expects that information in the form of AzureAsyncOperation model type
            /// 3) We get status and error information from AzureAsyncOperation modele and update PollingState accordingly.
            /// 3) If AzureAsyncOperation is null, we assume there was no error retruned in the response
            /// 4) And we get the status from provisioningState and update pollingState accordinly
            /// </summary>
            /// <typeparam name="TBody"></typeparam>
            /// <typeparam name="THeader"></typeparam>
            /// <param name="asyncOperation"></param>
            /// <param name="azureResponse"></param>
            /// <param name="pollState"></param>
            /// <param name="responseContent"></param>
            /// <param name="method"></param>
            /// <returns></returns>
        private static PollingState<TBody, THeader> GetUpdatedPollingStatus<TBody, THeader>(
                        AzureAsyncOperation asyncOperation,
                        AzureOperationResponse<JObject, JObject> azureResponse, 
                        PollingState<TBody, THeader> pollState, 
                        string responseContent,
                        HttpMethod method)
            where TBody: class
            where THeader: class
        {
            PollingState<TBody, THeader> pollingState = pollState;
            HttpStatusCode statusCode;

            if (asyncOperation != null)
            {
                pollingState.Status = asyncOperation.Status;

                if (AzureAsyncOperation.FailedStatuses.Any(
                        s => s.Equals(pollingState.Status, StringComparison.OrdinalIgnoreCase)))
                {
                    string errorMessage = string.Format(
                                            CultureInfo.InvariantCulture,
                                            Resources.LROOperationFailedAdditionalInfo,
                                                asyncOperation.Status, asyncOperation.Error?.Message);

                    pollingState.Error = new CloudError()
                    {
                        Code = asyncOperation.Error.Code,
                        Message = asyncOperation.Error.Message
                    };

                    pollingState.CloudException = new CloudException(errorMessage)
                    {
                        Body = asyncOperation.Error,
                        Request = new HttpRequestMessageWrapper(pollingState.Request, null),
                        Response = new HttpResponseMessageWrapper(pollingState.Response, responseContent)
                    };
                }
            }
            else if (azureResponse != null)
            {
                statusCode = azureResponse.Response.StatusCode;
                var resource = azureResponse.Body;

                if (statusCode == HttpStatusCode.Accepted)
                {
                    pollingState.Status = AzureAsyncOperation.InProgressStatus;
                }
                else if (statusCode == HttpStatusCode.OK ||
                         (statusCode == HttpStatusCode.Created && method == HttpMethod.Put) ||
                         (statusCode == HttpStatusCode.NoContent && (method == HttpMethod.Delete || method == HttpMethod.Post)))
                {
                    // We check if we got provisionState and we get the status from provisioning state
                    // if not then we try to find if error was returned in the response
                    if (resource != null &&
                        resource["properties"] != null &&
                        resource["properties"]["provisioningState"] != null)
                    {
                        pollingState.Status = (string)resource["properties"]["provisioningState"];
                    }
                    else
                    {
                        pollingState.Status = AzureAsyncOperation.SuccessStatus;
                    }
                }
                else
                {
                    throw new CloudException("The response from long running operation does not have a valid status code.");
                }
            }
            else
            {
                throw new CloudException("The response from long running operation does not have a valid status code.");
            }

            return pollingState;
        }
    }
}