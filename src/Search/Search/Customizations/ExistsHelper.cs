// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;

    internal static class ExistsHelper
    {
        public static async Task<AzureOperationResponse<bool>> ExistsFromGetResponse<T>(
            Func<Task<AzureOperationResponse<T>>> invokeGet)
        {
            var response = new AzureOperationResponse<bool>();

            try
            {
                // Get validates indexName.
                AzureOperationResponse<T> getResponse = await invokeGet().ConfigureAwait(false);
                response.Body = true;
                response.Request = getResponse.Request;
                response.RequestId = getResponse.RequestId;
                response.Response = getResponse.Response;
                return response;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    response.Body = false;
                    response.Request = e.Request;
                    response.Response = e.Response;

                    if (e.Response.Headers.Contains("request-id"))
                    {
                        response.RequestId = e.Response.Headers.GetValues("request-id").FirstOrDefault();
                    }

                    return response;
                }

                throw;
            }
        }
    }
}
