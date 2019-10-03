// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
using Microsoft.Azure.Management.Storage;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Polly;

using StorageManagement = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.EventHubs.Tests
{
    internal sealed class EventHubScope : IAsyncDisposable
    {
        private const int RetryMaximumAttempts = 15;
        private const double RetryExponentialBackoffSeconds = 3.0;
        private const double RetryBaseJitterSeconds = 20.0;

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

        internal static Task<EventHubScope> CreateAsync(int partitionCount,
                                                       [CallerMemberName] string caller = "") => CreateAsync(partitionCount, Enumerable.Empty<string>(), caller);

        internal static Task<EventHubScope> CreateAsync(int partitionCount,
                                                        string consumerGroup,
                                                        [CallerMemberName] string caller = "") => CreateAsync(partitionCount, new[] { consumerGroup }, caller);
        internal static async Task<EventHubScope> CreateAsync(int partitionCount,
                                                              IEnumerable<string> consumerGroups,
                                                              [CallerMemberName] string caller = "")
        {
            caller = (caller.Length < 16) ? caller : caller.Substring(0, 15);

            var groups = (consumerGroups ?? Enumerable.Empty<string>()).ToList();
            var resourceGroup = TestUtility.EventHubsResourceGroup;
            var eventHubNamespace = TestUtility.EventHubsNamespace;
            var token = await AquireManagementTokenAsync();

            string CreateName() => $"{ Guid.NewGuid().ToString("D").Substring(0, 13) }-{ caller }";

            using (var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = TestUtility.EventHubsSubscription })
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

        public static async Task<AzureResourceProperties> CreateNamespaceAsync()
        {
            var subscription = TestUtility.EventHubsSubscription;
            var resourceGroup = TestUtility.EventHubsResourceGroup;
            var token = await AquireManagementTokenAsync();

            string CreateName() => $"net-eventhubs-track-one-{ Guid.NewGuid().ToString("D").Substring(0, 8) }";

            using (var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                var location = await QueryResourceGroupLocationAsync(token, resourceGroup, subscription);

                var eventHubsNamespace = new EHNamespace(sku: new Sku("Standard", "Standard", 12), tags: GetResourceTags(), isAutoInflateEnabled: true, maximumThroughputUnits: 20, location: location);
                eventHubsNamespace = await CreateRetryPolicy<EHNamespace>().ExecuteAsync(() => client.Namespaces.CreateOrUpdateAsync(resourceGroup, CreateName(), eventHubsNamespace));

                var accessKey = await CreateRetryPolicy<AccessKeys>().ExecuteAsync(() => client.Namespaces.ListKeysAsync(resourceGroup, eventHubsNamespace.Name, "RootManageSharedAccessKey"));
                return new AzureResourceProperties(eventHubsNamespace.Name, accessKey.PrimaryConnectionString);
            }
        }

        public static async Task DeleteNamespaceAsync(string namespaceName)
        {
            var subscription = TestUtility.EventHubsSubscription;
            var resourceGroup = TestUtility.EventHubsResourceGroup;
            var token = await AquireManagementTokenAsync();

            using (var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                await CreateRetryPolicy().ExecuteAsync(() => client.Namespaces.DeleteAsync(resourceGroup, namespaceName));
                ;
            }
        }

        public static async Task<AzureResourceProperties> CreateStorageAsync()
        {
            var subscription = TestUtility.EventHubsSubscription;
            var resourceGroup = TestUtility.EventHubsResourceGroup;
            var token = await AquireManagementTokenAsync();

            string CreateName() => $"neteventhubstrackone{ Guid.NewGuid().ToString("D").Substring(0, 4) }";

            using (var client = new StorageManagementClient(new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                var location = await QueryResourceGroupLocationAsync(token, resourceGroup, subscription);

                var sku = new StorageManagement.Sku(StorageManagement.SkuName.StandardLRS, StorageManagement.SkuTier.Standard);
                var parameters = new StorageManagement.StorageAccountCreateParameters(sku, StorageManagement.Kind.BlobStorage, location: location, tags: GetResourceTags(), accessTier: StorageManagement.AccessTier.Hot);
                var storageAccount = await CreateRetryPolicy<StorageManagement.StorageAccount>().ExecuteAsync(() => client.StorageAccounts.CreateAsync(resourceGroup, CreateName(), parameters));

                var storageKeys = await CreateRetryPolicy<StorageManagement.StorageAccountListKeysResult>().ExecuteAsync(() => client.StorageAccounts.ListKeysAsync(resourceGroup, storageAccount.Name));
                return new AzureResourceProperties(storageAccount.Name, $"DefaultEndpointsProtocol=https;AccountName={ storageAccount.Name };AccountKey={ storageKeys.Keys[0].Value };EndpointSuffix=core.windows.net");
            }
        }

        public static async Task DeleteStorageAsync(string accountName)
        {
            var subscription = TestUtility.EventHubsSubscription;
            var resourceGroup = TestUtility.EventHubsResourceGroup;
            var token = await AquireManagementTokenAsync();

            using (var client = new StorageManagementClient(new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                await CreateRetryPolicy().ExecuteAsync(() => client.StorageAccounts.DeleteAsync(resourceGroup, accountName));
            }
        }

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

        private static Dictionary<string, string> GetResourceTags() =>
             new Dictionary<string, string>
                {
                    { "source", typeof(EventHubScope).Assembly.GetName().Name },
                    { "platform", System.Runtime.InteropServices.RuntimeInformation.OSDescription },
                    { "framework", System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription },
                    { "created", $"{ DateTimeOffset.UtcNow.ToString("s") }Z" },
                    { "cleanup-after", $"{ DateTimeOffset.UtcNow.AddDays(1).ToString("s") }Z" }
                };

        private static IAsyncPolicy<T> CreateRetryPolicy<T>(int maxRetryAttempts = RetryMaximumAttempts, double exponentialBackoffSeconds = RetryExponentialBackoffSeconds, double baseJitterSeconds = RetryBaseJitterSeconds) =>
           Policy<T>
               .Handle<ErrorResponseException>(ex => IsRetriableStatus(ex.Response.StatusCode))
               .Or<CloudException>(ex => IsRetriableStatus(ex.Response.StatusCode))
               .WaitAndRetryAsync(maxRetryAttempts, attempt => CalculateRetryDelay(attempt, exponentialBackoffSeconds, baseJitterSeconds));

        private static IAsyncPolicy CreateRetryPolicy(int maxRetryAttempts = RetryMaximumAttempts, double exponentialBackoffSeconds = RetryExponentialBackoffSeconds, double baseJitterSeconds = RetryBaseJitterSeconds) =>
            Policy
                .Handle<ErrorResponseException>(ex => IsRetriableStatus(ex.Response.StatusCode))
                .Or<CloudException>(ex => IsRetriableStatus(ex.Response.StatusCode))
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
                    throw new AuthenticationException("Unable to acquire an Active Directory token for the Event Hubs management client.");
                }

                token = new ManagementToken(result.AccessToken, result.ExpiresOn);
                Interlocked.Exchange(ref s_managementToken, token);
            }

            return token.Token;
        }

        public struct AzureResourceProperties
        {
            public readonly string Name;
            public readonly string ConnectionString;

            internal AzureResourceProperties(string name,
                                             string connectionString)
            {
                Name = name;
                ConnectionString = connectionString;
            }
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
