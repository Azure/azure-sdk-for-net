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
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Polly;

namespace Azure.Messaging.EventHubs.Tests.Infrastructure
{
    /// <summary>
    ///  Provides a dynamically created Event Hub instance which exists only in the context
    ///  of the scope; disposal removes the instance.
    /// </summary>
    ///
    /// <seealso cref="System.IAsyncDisposable" />
    ///
    public sealed class EventHubScope : IAsyncDisposable
    {
        /// <summary>The maximum number of attempts to retry a management operation.</summary>
        private const int RetryMaximumAttemps = 15;

        /// <summary>The number of seconds to use as the basis for backing off on retry attempts.</summary>
        private const double RetryExponentialBackoffSeconds = 2.0;

        /// <summary>The number of seconds to use as the basis for applying jitter to retry back-off calculations.</summary>
        private const double RetryBaseJitterSeconds = 8.0;

        /// <summary>The buffer to apply when considering refreshing; credentials that expire less than this duration will be refreshed.</summary>
        private static readonly TimeSpan CredentialRefreshBuffer = TimeSpan.FromMinutes(5);

        /// <summary>The random number generator to use for each requesting thread.</summary>
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        /// <summary>The seed to use for random number generation.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>The token credential to be used with the Event Hubs management client.</summary>
        private static ManagementToken s_managementToken;

        /// <summary>Serves as a sentinel flag to denote when the instance has been disposed.</summary>
        private bool _disposed = false;

        /// <summary>
        ///  The name of the Event Hub that was created.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The consumer groups created and associated with the Event Hub, not including
        ///   the default consumer group which is created implicitly.
        /// </summary>
        ///
        public IReadOnlyList<string> ConsumerGroups { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubScope"/> class.
        /// </summary>
        ///
        /// <param name="eventHubHame">The name of the Event Hub that was created.</param>
        /// <param name="consumerGroups">The set of consumer groups associated with the Event Hub; the default consumer group is not included, as it is implicitly created.</param>
        ///
        private EventHubScope(string eventHubHame,
                              IReadOnlyList<string> consumerGroups)
        {
            EventHubName = eventHubHame;
            ConsumerGroups = consumerGroups;
        }

        /// <summary>
        ///   Performs the tasks needed to remove the dynamically created
        ///   Event Hub.
        /// </summary>
        ///
        public async ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                return;
            }

            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var eventHubNamespace = TestEnvironment.EventHubsNamespace;
            var token = await AquireManagementTokenAsync();
            var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = TestEnvironment.EventHubsSubscription };

            try
            {
                await CreateRetryPolicy().ExecuteAsync(() => client.EventHubs.DeleteAsync(resourceGroup, eventHubNamespace, EventHubName));
            }
            catch
            {
                // This should not be considered a critical failure that results in a test failure.  Due
                // to ARM being temperamental, some management operations may be rejected.  Throwing here
                // does not help to ensure resource cleanup only flags the test itself as a failure.
                //
                // If an Event Hub fails to be deleted, removing of the associated namespace at the end of the
                // test run will also remove the orphan.
            }
            finally
            {
                client?.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        ///   Performs the tasks needed to create a new Event Hub instance with the requested
        ///   partition count and a dynamically assigned unique name.
        /// </summary>
        ///
        /// <param name="partitionCount">The number of partitions that the Event Hub should be configured with.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        public static Task<EventHubScope> CreateAsync(int partitionCount,
                                                      [CallerMemberName] string caller = "") => CreateAsync(partitionCount, Enumerable.Empty<string>(), caller);

        /// <summary>
        ///   Performs the tasks needed to create a new Event Hub instance with the requested
        ///   partition count and a dynamically assigned unique name.
        /// </summary>
        ///
        /// <param name="partitionCount">The number of partitions that the Event Hub should be configured with.</param>
        /// <param name="consumerGroup">The name of a consumer group to create and associate with the Event Hub; the default consumer group should not be specified, as it is implicitly created.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        public static Task<EventHubScope> CreateAsync(int partitionCount,
                                                      string consumerGroup,
                                                      [CallerMemberName] string caller = "") => CreateAsync(partitionCount, new[] { consumerGroup }, caller);

        /// <summary>
        ///   Performs the tasks needed to create a new Event Hub instance with the requested
        ///   partition count and a dynamically assigned unique name.
        /// </summary>
        ///
        /// <param name="partitionCount">The number of partitions that the Event Hub should be configured with.</param>
        /// <param name="consumerGroups">The set of consumer groups to create and associate with the Event Hub; the default consumer group should not be included, as it is implicitly created.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The <see cref="EventHubScope" /> in which the test should be executed.</returns>
        ///
        public static async Task<EventHubScope> CreateAsync(int partitionCount,
                                                            IEnumerable<string> consumerGroups,
                                                            [CallerMemberName] string caller = "")
        {
            caller = (caller.Length < 16) ? caller : caller.Substring(0, 15);

            var groups = (consumerGroups ?? Enumerable.Empty<string>()).ToList();
            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var eventHubNamespace = TestEnvironment.EventHubsNamespace;
            var token = await AquireManagementTokenAsync();

            string CreateName() => $"{ Guid.NewGuid().ToString("D").Substring(0, 13) }-{ caller }";

            using (var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = TestEnvironment.EventHubsSubscription })
            {
                var eventHub = new Eventhub(partitionCount: partitionCount);
                eventHub = await CreateRetryPolicy<Eventhub>().ExecuteAsync(() => client.EventHubs.CreateOrUpdateAsync(resourceGroup, eventHubNamespace, CreateName(), eventHub));

                var consumerPolicy = CreateRetryPolicy<ConsumerGroup>();

                await Task.WhenAll
                (
                    consumerGroups.Select(groupName =>
                    {
                        var group = new ConsumerGroup(name: groupName);
                        return consumerPolicy.ExecuteAsync(() => client.ConsumerGroups.CreateOrUpdateAsync(resourceGroup, eventHubNamespace, eventHub.Name, groupName, group));
                    })
                );

                return new EventHubScope(eventHub.Name, groups);
            }
        }

        /// <summary>
        ///   Performs the tasks needed to create a new Event Hubs namespace within a resource group, intended to be used as
        ///   an ephemeral container for the Event Hub instances used in a given test run.
        /// </summary>
        ///
        /// <returns>The key attributes for identifying and accessing a dynamically created Event Hubs namespace.</returns>
        ///
        public static async Task<NamespaceProperties> CreateNamespaceAsync()
        {
            var subscription = TestEnvironment.EventHubsSubscription;
            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var token = await AquireManagementTokenAsync();

            string CreateName() => $"net-eventhubs-{ Guid.NewGuid().ToString("D") }";

            using (var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                var location = await QueryResourceGroupLocationAsync(token, resourceGroup, subscription);

                var tags = new Dictionary<string, string>
                {
                    { "source", typeof(EventHubScope).Assembly.GetName().Name },
                    { "platform", System.Runtime.InteropServices.RuntimeInformation.OSDescription },
                    { "framework", System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription },
                    { "created", $"{ DateTimeOffset.UtcNow.ToString("s") }Z" },
                    { "cleanup-after", $"{ DateTimeOffset.UtcNow.AddDays(1).ToString("s") }Z" }
                };

                var eventHubsNamespace = new EHNamespace(sku: new Sku("Standard", "Standard", 12), tags: tags, isAutoInflateEnabled: true, maximumThroughputUnits: 20, location: location);
                eventHubsNamespace = await CreateRetryPolicy<EHNamespace>().ExecuteAsync(() => client.Namespaces.CreateOrUpdateAsync(resourceGroup, CreateName(), eventHubsNamespace));

                var accessKey = await CreateRetryPolicy<AccessKeys>().ExecuteAsync(() => client.Namespaces.ListKeysAsync(resourceGroup, eventHubsNamespace.Name, TestEnvironment.EventHubsDefaultSharedAccessKey));
                return new NamespaceProperties(eventHubsNamespace.Name, accessKey.PrimaryConnectionString);
            }
        }

        /// <summary>
        ///   Performs the tasks needed to remove an ephemeral Event Hubs namespace used as a container for a Event Hub instances
        ///   for a specific test run.
        /// </summary>
        ///
        /// <param name="namespaceName">The name of the namespace to delete.</param>
        ///
        public static async Task DeleteNamespaceAsync(string namespaceName)
        {
            var subscription = TestEnvironment.EventHubsSubscription;
            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var token = await AquireManagementTokenAsync();

            using (var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                await CreateRetryPolicy().ExecuteAsync(() => client.Namespaces.DeleteAsync(resourceGroup, namespaceName));
            }
        }

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
        private static async Task<string> QueryResourceGroupLocationAsync(string accessToken,
                                                                          string resourceGroupName,
                                                                          string subscriptionId)
        {
            using (var client = new ResourceManagementClient(new TokenCredentials(accessToken)) { SubscriptionId = subscriptionId })
            {
                var resourceGroup = await CreateRetryPolicy<Microsoft.Azure.Management.ResourceManager.Models.ResourceGroup>().ExecuteAsync(() => client.ResourceGroups.GetAsync(resourceGroupName));
                return resourceGroup.Location;
            }
        }

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
        private static IAsyncPolicy<T> CreateRetryPolicy<T>(int maxRetryAttempts = RetryMaximumAttemps, double exponentialBackoffSeconds = RetryExponentialBackoffSeconds, double baseJitterSeconds = RetryBaseJitterSeconds) =>
           Policy<T>
               .Handle<ErrorResponseException>(ex => IsRetriableStatus(ex.Response.StatusCode))
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
        private static IAsyncPolicy CreateRetryPolicy(int maxRetryAttempts = RetryMaximumAttemps, double exponentialBackoffSeconds = RetryExponentialBackoffSeconds, double baseJitterSeconds = RetryBaseJitterSeconds) =>
            Policy
                .Handle<ErrorResponseException>(ex => IsRetriableStatus(ex.Response.StatusCode))
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
                || (statusCode == HttpStatusCode.InternalServerError)
                || (statusCode == HttpStatusCode.ServiceUnavailable)
                || (statusCode == HttpStatusCode.Conflict)
                || (statusCode == HttpStatusCode.GatewayTimeout));

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
        private static TimeSpan CalculateRetryDelay(int attempt, double exponentialBackoffSeconds, double baseJitterSeconds) =>
            TimeSpan.FromSeconds((Math.Pow(2, attempt) * exponentialBackoffSeconds) + (RandomNumberGenerator.Value.NextDouble() * baseJitterSeconds));

        /// <summary>
        ///   Acquires a JWT token for use with the Event Hubs management client.
        /// </summary>
        ///
        /// <returns>The token to use for management operations against the Event Hubs Live test namespace.</returns>
        ///
        private static async Task<string> AquireManagementTokenAsync()
        {
            var token = s_managementToken;

            // If there was no current token, or it is within the buffer for expiration, request a new token.
            // There is a benign race condition here, where there may be multiple requests in-flight for a new token.  Since
            // this is test infrastructure, just allow the acquired token to replace the current one without attempting to
            // coordinate or ensure that the most recent is kept.

            if ((token == null) || (token.ExpiresOn <= DateTimeOffset.UtcNow.Add(CredentialRefreshBuffer)))
            {
                var credential = new ClientCredential(TestEnvironment.EventHubsClient, TestEnvironment.EventHubsSecret);
                var context = new AuthenticationContext($"https://login.windows.net/{ TestEnvironment.EventHubsTenant }");
                var result = await context.AcquireTokenAsync("https://management.core.windows.net/", credential);

                if ((String.IsNullOrEmpty(result?.AccessToken)))
                {
                    throw new AuthenticationException("Unable to acquire an Active Directory token for the Event Hubs management client.");
                }

                token = new ManagementToken(result.AccessToken, result.ExpiresOn);
                Interlocked.Exchange(ref s_managementToken, token);
            }

            return token.Token;
        }

        /// <summary>
        ///   The key attributes for identifying and accessing a dynamically created Event Hubs namespace,
        ///   intended to serve as an ephemeral container for the Event Hub instances used during a test run.
        /// </summary>
        ///
        public struct NamespaceProperties
        {
            /// <summary>The name of the Event Hubs namespace that was dynamically created.</summary>
            public readonly string Name;

            /// <summary>The connection string to use for accessing the dynamically created namespace.</summary>
            public readonly string ConnectionString;

            /// <summary>
            ///   Initializes a new instance of the <see cref="TestRunNamespace"/> struct.
            /// </summary>
            ///
            /// <param name="name">The name of the namespace.</param>
            /// <param name="connectionString">The connection string to use for accessing the namespace.</param>
            ///
            internal NamespaceProperties(string name,
                                         string connectionString)
            {
                Name = name;
                ConnectionString = connectionString;
            }
        }

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
            public ManagementToken(string token, DateTimeOffset expiresOn)
            {
                Token = token;
                ExpiresOn = expiresOn;
            }
        }
    }
}
