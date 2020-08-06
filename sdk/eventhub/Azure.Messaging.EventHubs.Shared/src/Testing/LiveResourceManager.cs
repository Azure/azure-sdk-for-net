// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Polly;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///  Provides common operations for managing resources used for Live tests.
    /// </summary>
    ///
    public sealed class LiveResourceManager
    {
        /// <summary>The maximum number of attempts to retry a management operation.</summary>
        private const int RetryMaximumAttempts = 20;

        /// <summary>The number of seconds to use as the basis for backing off on retry attempts.</summary>
        private const double RetryExponentialBackoffSeconds = 3.0;

        /// <summary>The number of seconds to use as the basis for applying jitter to retry back-off calculations.</summary>
        private const double RetryBaseJitterSeconds = 60.0;

        /// <summary>The buffer to apply when considering refreshing; credentials that expire less than this duration will be refreshed.</summary>
        private static readonly TimeSpan CredentialRefreshBuffer = TimeSpan.FromMinutes(5);

        /// <summary>The random number generator to use for each requesting thread.</summary>
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        /// <summary>The seed to use for random number generation.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>The token credential to be used with the Event Hubs management client.</summary>
        private static ManagementToken s_managementToken;

        /// <summary>
        ///   Queries the location for the requested Azure Resource Group.
        /// </summary>
        ///
        /// <param name="accessToken">The access token to use for the query request.</param>
        /// <param name="resourceGroupName">The name of the resource group to query the location of.</param>
        /// <param name="subscriptionId">The identifier of the Azure subscription in which the resource group resides.</param>
        ///
        /// <returns>The location code for the requested <paramref name="resourceGroupName"/>.</returns>
        ///
        public async Task<string> QueryResourceGroupLocationAsync(string accessToken,
                                                                  string resourceGroupName,
                                                                  string subscriptionId)
        {
            using (var client = new ResourceManagementClient(new Uri(EventHubsTestEnvironment.Instance.ResourceManagerUrl), new TokenCredentials(accessToken)) { SubscriptionId = subscriptionId })
            {
                ResourceGroup resourceGroup = await CreateRetryPolicy<ResourceGroup>().ExecuteAsync(() => client.ResourceGroups.GetAsync(resourceGroupName)).ConfigureAwait(false);
                return resourceGroup.Location;
            }
        }

        /// <summary>
        ///   Acquires a JWT token for use with the Event Hubs management client.
        /// </summary>
        ///
        /// <returns>The token to use for management operations against the Event Hubs Live test namespace.</returns>
        ///
        public async Task<string> AquireManagementTokenAsync()
        {
            ManagementToken token = s_managementToken;

            // If there was no current token, or it is within the buffer for expiration, request a new token.
            // There is a benign race condition here, where there may be multiple requests in-flight for a new token.  Since
            // this is test infrastructure, just allow the acquired token to replace the current one without attempting to
            // coordinate or ensure that the most recent is kept.

            if ((token == null) || (token.ExpiresOn <= DateTimeOffset.UtcNow.Add(CredentialRefreshBuffer)))
            {
                var credential = new ClientCredential(EventHubsTestEnvironment.Instance.ClientId, EventHubsTestEnvironment.Instance.ClientSecret);
                var context = new AuthenticationContext($"{ EventHubsTestEnvironment.Instance.AuthorityHostUrl }{ EventHubsTestEnvironment.Instance.TenantId }");
                var result = await context.AcquireTokenAsync(EventHubsTestEnvironment.Instance.ServiceManagementUrl, credential).ConfigureAwait(false);

                if ((string.IsNullOrEmpty(result?.AccessToken)))
                {
                    throw new AuthenticationException("Unable to acquire an Active Directory token for the Event Hubs management client.");
                }

                token = new ManagementToken(result.AccessToken, result.ExpiresOn);
                Interlocked.Exchange(ref s_managementToken, token);
            }

            return token.Token;
        }

        /// <summary>
        ///   Generates the set of common metadata tags to apply to an ephemeral cloud resource
        ///   used for test purposes.
        /// </summary>
        ///
        /// <returns>The set of metadata tags to apply.</returns>
        ///
        public Dictionary<string, string> GenerateTags() =>
            new Dictionary<string, string>
            {
                { "source", typeof(LiveResourceManager).Assembly.GetName().Name },
                { "platform", System.Runtime.InteropServices.RuntimeInformation.OSDescription },
                { "framework", System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription },
                { "created", $"{ DateTimeOffset.UtcNow.ToString("s") }Z" },
                { "cleanup-after", $"{ DateTimeOffset.UtcNow.AddDays(1).ToString("s") }Z" }
            };

        /// <summary>
        ///   Creates the retry policy to apply to a management operation.
        /// </summary>
        ///
        /// <typeparam name="T">The expected type of response from the management operation.</typeparam>
        ///
        /// <param name="maxRetryAttempts">The maximum retry attempts to allow.</param>
        /// <param name="exponentialBackoffSeconds">The number of seconds to use as the basis for backing off on retry attempts.</param>
        /// <param name="baseJitterSeconds">TThe number of seconds to use as the basis for applying jitter to retry back-off calculations.</param>
        ///
        /// <returns>The retry policy in which to execute the management operation.</returns>
        ///
        public IAsyncPolicy<T> CreateRetryPolicy<T>(int maxRetryAttempts = RetryMaximumAttempts,
                                                    double exponentialBackoffSeconds = RetryExponentialBackoffSeconds,
                                                    double baseJitterSeconds = RetryBaseJitterSeconds) =>
           Policy<T>
               .Handle<Exception>(ex => ShouldRetry(ex))
               .WaitAndRetryAsync(maxRetryAttempts, attempt => CalculateRetryDelay(attempt, exponentialBackoffSeconds, baseJitterSeconds));

        /// <summary>
        ///   Creates the retry policy to apply to a management operation.
        /// </summary>
        ///
        /// <param name="maxRetryAttempts">The maximum retry attempts to allow.</param>
        /// <param name="exponentialBackoffSeconds">The number of seconds to use as the basis for backing off on retry attempts.</param>
        /// <param name="baseJitterSeconds">TThe number of seconds to use as the basis for applying jitter to retry back-off calculations.</param>
        ///
        /// <returns>The retry policy in which to execute the management operation.</returns>
        ///
        public IAsyncPolicy CreateRetryPolicy(int maxRetryAttempts = RetryMaximumAttempts,
                                              double exponentialBackoffSeconds = RetryExponentialBackoffSeconds,
                                              double baseJitterSeconds = RetryBaseJitterSeconds) =>
            Policy
                .Handle<Exception>(ex => ShouldRetry(ex))
                .WaitAndRetryAsync(maxRetryAttempts, attempt => CalculateRetryDelay(attempt, exponentialBackoffSeconds, baseJitterSeconds));

        /// <summary>
        ///   Determines whether the specified HTTP status code is considered eligible to retry
        ///   the associated operation.
        /// </summary>
        ///
        /// <param name="statusCode">The status code to consider.</param>
        ///
        /// <returns><c>true</c> if the status code is eligible for retries; otherwise, <c>false</c>.</returns>
        ///
        private static bool IsRetriableStatus(HttpStatusCode statusCode) =>
            ((statusCode == HttpStatusCode.Unauthorized)
                || (statusCode == ((HttpStatusCode)408))
                || (statusCode == HttpStatusCode.Conflict)
                || (statusCode == ((HttpStatusCode)429))
                || (statusCode == HttpStatusCode.InternalServerError)
                || (statusCode == HttpStatusCode.ServiceUnavailable)
                || (statusCode == HttpStatusCode.GatewayTimeout));

        /// <summary>
        ///   Determines whether the specified exception is considered eligible to retry the associated
        ///   operation.
        /// </summary>
        ///
        /// <param name="ex">The exception to consider.</param>
        ///
        /// <returns><c>true</c> if the exception is eligible for retries; otherwise, <c>false</c>.</returns>
        ///
        private static bool ShouldRetry(Exception ex) =>
            ((IsRetriableException(ex)) || (IsRetriableException(ex?.InnerException)));

        /// <summary>
        ///   Determines whether the type of the specified exception is considered eligible to retry
        ///   the associated operation.
        /// </summary>
        ///
        /// <param name="ex">The exception to consider.</param>
        ///
        /// <returns><c>true</c> if the exception type is eligible for retries; otherwise, <c>false</c>.</returns>
        ///
        private static bool IsRetriableException(Exception ex)
        {
            if (ex == null)
            {
                return false;
            }

            switch (ex)
            {
                case ErrorResponseException erEx:
                    return IsRetriableStatus(erEx.Response.StatusCode);

                case CloudException clEx:
                    return IsRetriableStatus(clEx.Response.StatusCode);

                case TimeoutException _:
                case TaskCanceledException _:
                case OperationCanceledException _:
                case HttpRequestException _:
                case WebException _:
                case SocketException _:
                case IOException _:
                    return true;

                default:
                    return false;
            };
        }

        /// <summary>
        ///   Calculates the retry delay to use for management-related operations.
        /// </summary>
        ///
        /// <param name="attempt">The current attempt number.</param>
        /// <param name="exponentialBackoffSeconds">The exponential back-off amount,, in seconds.</param>
        /// <param name="baseJitterSeconds">The amount of base jitter to include, in seconds.</param>
        ///
        /// <returns>The interval to wait before retrying the attempted operation.</returns>
        ///
        private static TimeSpan CalculateRetryDelay(int attempt,
                                                    double exponentialBackoffSeconds,
                                                    double baseJitterSeconds) =>
            TimeSpan.FromSeconds((Math.Pow(2, attempt) * exponentialBackoffSeconds) + (RandomNumberGenerator.Value.NextDouble() * baseJitterSeconds));

        /// <summary>
        ///   An internal type for tracking the management access token and
        ///   its associated expiration.
        /// </summary>
        ///
        private class ManagementToken
        {
            /// <summary>The value bearer token to use for authorization.</summary>
            public readonly string Token;

            /// <summary>The date and time, in UTC, that the token expires.</summary>
            public readonly DateTimeOffset ExpiresOn;

            /// <summary>
            ///   Initializes a new instance of the <see cref="ManagementToken"/> class.
            /// </summary>
            ///
            /// <param name="token">The value of the bearer token.</param>
            /// <param name="expiresOn">The date and time, in UTC, that the token expires on.</param>
            ///
            public ManagementToken(string token,
                                   DateTimeOffset expiresOn)
            {
                Token = token;
                ExpiresOn = expiresOn;
            }
        }
    }
}
