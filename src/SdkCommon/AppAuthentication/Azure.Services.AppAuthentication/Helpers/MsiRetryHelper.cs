// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    internal static class MsiRetryHelper
    {
        internal const int MaxRetries = 5;
        internal const int DeltaBackOffInSecs = 2;

        // for unit test purposes
        internal static bool WaitBeforeRetry = true;

        internal static bool IsRetryableStatusCode(this HttpResponseMessage response)
        {
            // 404 NotFound, 429 TooManyRequests, and 5XX server error status codes are retryable
            return Regex.IsMatch(((int)response.StatusCode).ToString(), @"404|429|5\d{2}");
        }

        /// <summary>
        /// Implements recommended retry guidance here: https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token#retry-guidance
        /// </summary>
        internal static async Task<HttpResponseMessage> SendAsyncWithRetry(this HttpClient httpClient, Func<HttpRequestMessage> getRequest, CancellationToken cancellationToken)
        {
            var attempts = 0;
            var backoffTimeInSecs = 0;
            HttpResponseMessage response;

            while (true)
            {
                attempts++;

                try
                {
                    response = await httpClient.SendAsync(getRequest(), cancellationToken);

                    if (response.IsSuccessStatusCode || !response.IsRetryableStatusCode() || attempts == MaxRetries)
                    {
                        break;
                    }
                }
                catch (HttpRequestException)
                {
                    if (attempts == MaxRetries) throw;
                }

                if (WaitBeforeRetry)
                {
                    // use recommended exponential backoff strategy, and use cancellation token wait handle so caller is still able to cancel
                    backoffTimeInSecs = backoffTimeInSecs + (int)Math.Pow(DeltaBackOffInSecs, attempts);
                    cancellationToken.WaitHandle.WaitOne(TimeSpan.FromSeconds(backoffTimeInSecs));
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }

            return response;
        }
    }
}
