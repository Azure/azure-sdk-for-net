// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Polly;


namespace Microsoft.Azure.EventHubs.Tests
{
    
    internal sealed class EventHubScope : IAsyncDisposable
    {
      
        private const int RetryMaximumAttemps = 8;

        private const double RetryExponentialBackoffSeconds = 0.5;

        private const double RetryBaseJitterSeconds = 3.0;

        private static readonly TimeSpan CredentialRefreshBuffer = TimeSpan.FromMinutes(5);

        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        private static int s_randomSeed = Environment.TickCount;

        private static ManagementToken s_managementToken;

        private bool _disposed = false;

        internal string EventHubName { get; }

        internal IReadOnlyList<string> ConsumerGroups { get; }

        private EventHubScope(string eventHubHame,
                              IReadOnlyList<string> consumerGroups)
        {
            EventHubName = eventHubHame;
            ConsumerGroups = consumerGroups;
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                return;
            }

            var resourceGroup = TestUtility.EventHubsResourceGroup;
            var eventHubNamespace = TestUtility.EventHubsNamespace;
            var token = await AquireManagementTokenAsync();
            var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = TestUtility.EventHubsSubscription };

            try
            {
                await CreateRetryPolicy().ExecuteAsync(() => client.EventHubs.DeleteAsync(resourceGroup, eventHubNamespace, EventHubName));
            }
            finally
            {
                client?.Dispose();
            }

            _disposed = true;
        }

        internal static Task<EventHubScope> CreateAsync(int partitionCount,
                                                      [CallerMemberName] string caller = "") => CreateAsync(partitionCount, Enumerable.Empty<string>(), caller);

        internal static Task<EventHubScope> CreateAsync(int partitionCount,
                                                      string consumerGroup,
                                                      [CallerMemberName] string caller = "") => CreateAsync(partitionCount, new[] { consumerGroup }, caller);
        internal static async Task<EventHubScope> CreateAsync(int partitionCount,
                                                            IEnumerable<string> consumerGroups,
                                                            [CallerMemberName] string caller = "")
        {
            var eventHubName = $"{ caller }-{ Guid.NewGuid().ToString("D").Substring(0, 8) }";
            var groups = (consumerGroups ?? Enumerable.Empty<string>()).ToList();
            var resourceGroup = TestUtility.EventHubsResourceGroup;
            var eventHubNamespace = TestUtility.EventHubsNamespace;
            var token = await AquireManagementTokenAsync();
            var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = TestUtility.EventHubsSubscription };

            try
            {
                var eventHub = new Eventhub(name: eventHubName, partitionCount: partitionCount);
                await CreateRetryPolicy<Eventhub>().ExecuteAsync(() => client.EventHubs.CreateOrUpdateAsync(resourceGroup, eventHubNamespace, eventHubName, eventHub));

                var consumerPolicy = CreateRetryPolicy<ConsumerGroup>();

                await Task.WhenAll
                (
                    consumerGroups.Select(groupName =>
                    {
                        var group = new ConsumerGroup(name: groupName);
                        return consumerPolicy.ExecuteAsync(() => client.ConsumerGroups.CreateOrUpdateAsync(resourceGroup, eventHubNamespace, eventHubName, groupName, group));
                    })
                );
            }
            finally
            {
                client?.Dispose();
            }

            return new EventHubScope(eventHubName, groups);
        }

        private static IAsyncPolicy<T> CreateRetryPolicy<T>(int maxRetryAttempts = RetryMaximumAttemps, double exponentialBackoffSeconds = RetryExponentialBackoffSeconds, double baseJitterSeconds = RetryBaseJitterSeconds) =>
           Policy<T>
               .Handle<ErrorResponseException>(ex => IsRetriableStatus(ex.Response.StatusCode))
               .WaitAndRetryAsync(maxRetryAttempts, attempt => CalculateRetryDelay(attempt, exponentialBackoffSeconds, baseJitterSeconds));

        private static IAsyncPolicy CreateRetryPolicy(int maxRetryAttempts = RetryMaximumAttemps, double exponentialBackoffSeconds = RetryExponentialBackoffSeconds, double baseJitterSeconds = RetryBaseJitterSeconds) =>
            Policy
                .Handle<ErrorResponseException>(ex => IsRetriableStatus(ex.Response.StatusCode))
                .WaitAndRetryAsync(maxRetryAttempts, attempt => CalculateRetryDelay(attempt, exponentialBackoffSeconds, baseJitterSeconds));

        private static bool IsRetriableStatus(HttpStatusCode statusCode) =>
            ((statusCode == HttpStatusCode.Unauthorized)
                || (statusCode == HttpStatusCode.InternalServerError)
                || (statusCode == HttpStatusCode.ServiceUnavailable)
                || (statusCode == HttpStatusCode.Conflict)
                || (statusCode == HttpStatusCode.GatewayTimeout));

        private static TimeSpan CalculateRetryDelay(int attempt, double exponentialBackoffSeconds, double baseJitterSeconds) =>
            TimeSpan.FromSeconds((Math.Pow(2, attempt) * exponentialBackoffSeconds) + (RandomNumberGenerator.Value.NextDouble() * baseJitterSeconds));

        private static async Task<string> AquireManagementTokenAsync()
        {
            var token = s_managementToken;

            if ((token == null) || (token.ExpiresOn <= DateTimeOffset.UtcNow.Add(CredentialRefreshBuffer)))
            {
                var credential = new ClientCredential(TestUtility.EventHubsClient, TestUtility.EventHubsSecret);
                var context = new AuthenticationContext($"https://login.windows.net/{ TestUtility.EventHubsTenant }");
                var result = await context.AcquireTokenAsync("https://management.core.windows.net/", credential);

                if ((String.IsNullOrEmpty(result?.AccessToken)))
                {
                    throw new AuthenticationException("Unable to aquire an Active Directory token for the Event Hubs management client.");
                }

                token = new ManagementToken(result.AccessToken, result.ExpiresOn);
                Interlocked.Exchange(ref s_managementToken, token);
            }

            return token.Token;
        }

        private class ManagementToken
        {
          
            public readonly string Token;

            public readonly DateTimeOffset ExpiresOn;

            public ManagementToken(string token, DateTimeOffset expiresOn)
            {
                Token = token;
                ExpiresOn = expiresOn;
            }
        }
    }
}
