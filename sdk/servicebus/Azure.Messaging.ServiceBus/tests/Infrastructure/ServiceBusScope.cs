// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ServiceBus;
using Microsoft.Azure.Management.ServiceBus.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Polly;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///  Provides access to dynamically created instances of Service Bus resources which exists only in the context
    ///  of their scope.
    /// </summary>
    ///
    public static class ServiceBusScope
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

        ///<summary>The URI for the location of the resource manager for the active cloud environment.</summary>
        private static readonly Uri ResourceManagerUri = new Uri(ServiceBusTestEnvironment.Instance.ResourceManagerUrl);

        /// <summary>The seed to use for random number generation.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>The token credential to be used with the  Service Bus management client.</summary>
        private static ManagementToken s_managementToken;

        /// <summary>
        ///   Performs the tasks needed to create a new  Service Bus namespace within a resource group, intended to be used as
        ///   an ephemeral container for the queue and topic instances used in a given test run.
        /// </summary>
        ///
        /// <returns>The key attributes for identifying and accessing a dynamically created  Service Bus namespace.</returns>
        ///
        public static async Task<ServiceBusTestEnvironment.NamespaceProperties> CreateNamespaceAsync()
        {
            var azureSubscription = ServiceBusTestEnvironment.Instance.SubscriptionId;
            var resourceGroup = ServiceBusTestEnvironment.Instance.ResourceGroup;
            var token = await AquireManagementTokenAsync().ConfigureAwait(false);

            string CreateName() => $"net-servicebus-{ Guid.NewGuid().ToString("D").Substring(0, 30) }";

            using (var client = new ServiceBusManagementClient(ResourceManagerUri, new TokenCredentials(token)) { SubscriptionId = azureSubscription })
            {
                var location = await QueryResourceGroupLocationAsync(token, resourceGroup, azureSubscription).ConfigureAwait(false);

                var serviceBusNamspace = new SBNamespace(sku: new SBSku(SkuName.Standard, SkuTier.Standard), tags: GenerateTags(), location: location);
                serviceBusNamspace = await CreateRetryPolicy<SBNamespace>().ExecuteAsync(() => client.Namespaces.CreateOrUpdateAsync(resourceGroup, CreateName(), serviceBusNamspace)).ConfigureAwait(false);

                var accessKey = await CreateRetryPolicy<AccessKeys>().ExecuteAsync(() => client.Namespaces.ListKeysAsync(resourceGroup, serviceBusNamspace.Name, ServiceBusTestEnvironment.ServiceBusDefaultSharedAccessKey)).ConfigureAwait(false);
                return new ServiceBusTestEnvironment.NamespaceProperties(serviceBusNamspace.Name, accessKey.PrimaryConnectionString, shouldRemoveAtCompletion: true);
            }
        }

        /// <summary>
        ///   Performs the tasks needed to remove an ephemeral Service Bus namespace used as a container for queue and topic instances
        ///   for a specific test run.
        /// </summary>
        ///
        /// <param name="namespaceName">The name of the namespace to delete.</param>
        ///
        public static async Task DeleteNamespaceAsync(string namespaceName)
        {
            var azureSubscription = ServiceBusTestEnvironment.Instance.SubscriptionId;
            var resourceGroup = ServiceBusTestEnvironment.Instance.ResourceGroup;
            var token = await AquireManagementTokenAsync().ConfigureAwait(false);

            using (var client = new ServiceBusManagementClient(ResourceManagerUri, new TokenCredentials(token)) { SubscriptionId = azureSubscription })
            {
                await CreateRetryPolicy().ExecuteAsync(() => client.Namespaces.DeleteAsync(resourceGroup, namespaceName)).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///   Creates a Service Bus scope associated with a queue instance, intended to be used in the context
        ///   of a single test and disposed when the test has completed.
        /// </summary>
        ///
        /// <param name="enablePartitioning">When <c>true</c>, partitioning will be enabled on the queue that is created.</param>
        /// <param name="enableSession">When <c>true</c>, a session will be enabled on the queue that is created.</param>
        /// <param name="forceQueueCreation">When <c>true</c>, forces creation of a new queue even if an environmental override was specified to use an existing one.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The requested Service Bus <see cref="QueueScope" />.</returns>
        ///
        /// <remarks>
        ///   If an environmental override was set to use an existing Service Bus queue resource and the <paramref name="forceQueueCreation" /> flag
        ///   was not set, the existing queue will be assumed with no validation.  In this case the <paramref name="enablePartitioning" /> and
        ///   <paramref name="enableSession" /> parameters are also ignored.
        /// </remarks>
        ///
        public static async Task<QueueScope> CreateWithQueue(bool enablePartitioning,
                                                             bool enableSession,
                                                             bool forceQueueCreation = false,
                                                             TimeSpan? lockDuration = default,
                                                             [CallerMemberName] string caller = "")
        {
            // If there was an override and the force flag is not set for creation, then build a scope
            // for the specified queue.

            if ((!string.IsNullOrEmpty(ServiceBusTestEnvironment.Instance.OverrideQueueName)) && (!forceQueueCreation))
            {
                return new QueueScope(ServiceBusTestEnvironment.Instance.ServiceBusNamespace, ServiceBusTestEnvironment.Instance.OverrideQueueName, false);
            }

            // Create a new queue specific to the scope being created.

            caller = (caller.Length < 16) ? caller : caller.Substring(0, 15);

            var azureSubscription = ServiceBusTestEnvironment.Instance.SubscriptionId;
            var resourceGroup = ServiceBusTestEnvironment.Instance.ResourceGroup;
            var serviceBusNamespace = ServiceBusTestEnvironment.Instance.ServiceBusNamespace;
            var token = await AquireManagementTokenAsync().ConfigureAwait(false);

            string CreateName() => $"{ Guid.NewGuid().ToString("D").Substring(0, 13) }-{ caller }";

            using (var client = new ServiceBusManagementClient(ResourceManagerUri, new TokenCredentials(token)) { SubscriptionId = azureSubscription })
            {
                var queueParameters = new SBQueue(enablePartitioning: enablePartitioning, requiresSession: enableSession, maxSizeInMegabytes: 1024, lockDuration: lockDuration);
                var queue = await CreateRetryPolicy<SBQueue>().ExecuteAsync(() => client.Queues.CreateOrUpdateAsync(resourceGroup, serviceBusNamespace, CreateName(), queueParameters)).ConfigureAwait(false);

                return new QueueScope(serviceBusNamespace, queue.Name, true);
            }
        }

        /// <summary>
        ///   Creates a Service Bus scope associated with a topic instance, intended to be used in the context
        ///   of a single test and disposed when the test has completed.
        /// </summary>
        ///
        /// <param name="enablePartitioning">When <c>true</c>, partitioning will be enabled on the topic that is created.</param>
        /// <param name="enableSession">When <c>true</c>, a session will be enabled on the topic that is created.</param>
        /// <param name="topicSubscriptions">The set of subscriptions to create for the topic.  If <c>null</c>, a default subscription will be assumed.</param>
        /// <param name="forceTopicCreation">When <c>true</c>, forces creation of a new topic even if an environmental override was specified to use an existing one.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The requested Service Bus <see cref="TopicScope" />.</returns>
        ///
        /// <remarks>
        ///   If an environmental override was set to use an existing Service Bus queue resource and the <paramref name="forceTopicCreation" /> flag
        ///   was not set, the existing queue will be assumed with no validation.  In this case the <paramref name="enablePartitioning" />,
        ///   <paramref name="enableSession" />, and <paramref name="topicSubscriptions" /> parameters are also ignored.
        /// </remarks>
        ///
        public static async Task<TopicScope> CreateWithTopic(bool enablePartitioning,
                                                             bool enableSession,
                                                             IEnumerable<string> topicSubscriptions = null,
                                                             bool forceTopicCreation = false,
                                                             [CallerMemberName] string caller = "")
        {
            caller = (caller.Length < 16) ? caller : caller.Substring(0, 15);
            topicSubscriptions ??= new[] { "default-subscription" };

            var azureSubscription = ServiceBusTestEnvironment.Instance.SubscriptionId;
            var resourceGroup = ServiceBusTestEnvironment.Instance.ResourceGroup;
            var serviceBusNamespace = ServiceBusTestEnvironment.Instance.ServiceBusNamespace;
            var token = await AquireManagementTokenAsync().ConfigureAwait(false);

            using (var client = new ServiceBusManagementClient(ResourceManagerUri, new TokenCredentials(token)) { SubscriptionId = azureSubscription })
            {
                // If there was an override and the force flag is not set for creation, then build a scope for the
                // specified topic.  Query the topic resource to build the list of its subscriptions for the scope.

                if ((!string.IsNullOrEmpty(ServiceBusTestEnvironment.Instance.OverrideTopicName)) && (!forceTopicCreation))
                {
                    var subscriptionPage = await CreateRetryPolicy<IPage<SBSubscription>>().ExecuteAsync(() => client.Subscriptions.ListByTopicAsync(resourceGroup, serviceBusNamespace, ServiceBusTestEnvironment.Instance.OverrideTopicName)).ConfigureAwait(false);
                    var existingSubscriptions = new List<string>(subscriptionPage.Select(item => item.Name));

                    while (!string.IsNullOrEmpty(subscriptionPage.NextPageLink))
                    {
                        subscriptionPage = await CreateRetryPolicy<IPage<SBSubscription>>().ExecuteAsync(() => client.Subscriptions.ListByTopicAsync(resourceGroup, serviceBusNamespace, ServiceBusTestEnvironment.Instance.OverrideTopicName)).ConfigureAwait(false);
                        existingSubscriptions.AddRange(subscriptionPage.Select(item => item.Name));
                    }

                    return new TopicScope(ServiceBusTestEnvironment.Instance.ServiceBusNamespace, ServiceBusTestEnvironment.Instance.OverrideTopicName, existingSubscriptions, false);
                }

                // Create a new topic specific for the scope being created.

                string CreateName() => $"{ Guid.NewGuid().ToString("D").Substring(0, 13) }-{ caller }";

                var duplicateDetection = TimeSpan.FromMinutes(10);
                var topicParameters = new SBTopic(enablePartitioning: enablePartitioning, duplicateDetectionHistoryTimeWindow: duplicateDetection, maxSizeInMegabytes: 1024);
                var topic = await CreateRetryPolicy<SBTopic>().ExecuteAsync(() => client.Topics.CreateOrUpdateAsync(resourceGroup, serviceBusNamespace, CreateName(), topicParameters)).ConfigureAwait(false);

                var subscriptionParams = new SBSubscription(requiresSession: enableSession, duplicateDetectionHistoryTimeWindow: duplicateDetection, maxDeliveryCount: 10);

                var activeSubscriptions = await Task.WhenAll
                (
                    topicSubscriptions.Select(subscriptionName =>
                        CreateRetryPolicy<SBSubscription>().ExecuteAsync(() => client.Subscriptions.CreateOrUpdateAsync(resourceGroup, serviceBusNamespace, topic.Name, subscriptionName, subscriptionParams)))

                ).ConfigureAwait(false);

                return new TopicScope(serviceBusNamespace, topic.Name, activeSubscriptions.Select(item => item.Name).ToList(), true);
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
            using var client = new ResourceManagementClient(ResourceManagerUri, new TokenCredentials(accessToken)) { SubscriptionId = subscriptionId };
            {
                ResourceGroup resourceGroup = await CreateRetryPolicy<ResourceGroup>().ExecuteAsync(() => client.ResourceGroups.GetAsync(resourceGroupName));
                return resourceGroup.Location;
            }
        }

        /// <summary>
        ///   Acquires a JWT token for use with the  Service Bus management client.
        /// </summary>
        ///
        /// <returns>The token to use for management operations against the  Service Bus Live test namespace.</returns>
        ///
        private static async Task<string> AquireManagementTokenAsync()
        {
            ManagementToken token = s_managementToken;

            // If there was no current token, or it is within the buffer for expiration, request a new token.
            // There is a benign race condition here, where there may be multiple requests in-flight for a new token.  Since
            // this is test infrastructure, just allow the acquired token to replace the current one without attempting to
            // coordinate or ensure that the most recent is kept.

            if ((token == null) || (token.ExpiresOn <= DateTimeOffset.UtcNow.Add(CredentialRefreshBuffer)))
            {
                var credential = new ClientCredential(ServiceBusTestEnvironment.Instance.ClientId, ServiceBusTestEnvironment.Instance.ClientSecret);
                var context = new AuthenticationContext($"{ ServiceBusTestEnvironment.Instance.AuthorityHostUrl }{ ServiceBusTestEnvironment.Instance.TenantId }");
                var result = await context.AcquireTokenAsync(ServiceBusTestEnvironment.Instance.ServiceManagementUrl, credential);

                if ((string.IsNullOrEmpty(result?.AccessToken)))
                {
                    throw new AuthenticationException("Unable to acquire an Active Directory token for the  Service Bus management client.");
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
        private static Dictionary<string, string> GenerateTags() =>
            new Dictionary<string, string>
            {
                { "source", typeof(ServiceBusScope).Assembly.GetName().Name },
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
        private static IAsyncPolicy<T> CreateRetryPolicy<T>(int maxRetryAttempts = RetryMaximumAttempts,
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
        private static IAsyncPolicy CreateRetryPolicy(int maxRetryAttempts = RetryMaximumAttempts,
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
        ///   Provides access to dynamically created Service Bus Queue instance which exists only in the context
        ///   of the scope; disposal removes the resource from Azure.
        /// </summary>
        ///
        /// <seealso cref="IAsyncDisposable" />
        ///
        public sealed class QueueScope : IAsyncDisposable
        {
            /// <summary>Serves as a sentinel flag to denote when the instance has been disposed.</summary>
            private bool _disposed = false;

            /// <summary>
            ///   The name of the Service Bus namespace associated with the queue.
            /// </summary>
            ///
            public string NamespaceName { get; }

            /// <summary>
            ///  The name of the queue.
            /// </summary>
            ///
            public string QueueName { get; }

            /// <summary>
            ///   A flag indicating if the queue should be removed when the scope is complete.
            /// </summary>
            ///
            /// <value><c>true</c> if the queue was should be removed at scope completion; otherwise, <c>false</c>.</value>
            ///
            private bool ShouldRemoveAtScopeCompletion { get; }

            /// <summary>
            ///   Initializes a new instance of the <see cref="QueueScope"/> class.
            /// </summary>
            ///
            /// <param name="serviceBusNamespaceName">The name of the Service Bus namespace to which the queue is associated.</param>
            /// <param name="queueName">The name of the queue.</param>
            /// <param name="shouldRemoveAtScopeCompletion">A flag indicating whether the queue should be removed when the scope is complete.</param>
            ///
            public QueueScope(string serviceBusNamespaceName,
                              string queueName,
                              bool shouldRemoveAtScopeCompletion)
            {
                NamespaceName = serviceBusNamespaceName;
                QueueName = queueName;
                ShouldRemoveAtScopeCompletion = shouldRemoveAtScopeCompletion;
            }

            /// <summary>
            ///   Performs the tasks needed to remove the dynamically created Service Bus Queue.
            /// </summary>
            ///
            public async ValueTask DisposeAsync()
            {
                if (!ShouldRemoveAtScopeCompletion)
                {
                    _disposed = true;
                }

                if (_disposed)
                {
                    return;
                }

                try
                {
                    var azureSubscription = ServiceBusTestEnvironment.Instance.SubscriptionId;
                    var resourceGroup = ServiceBusTestEnvironment.Instance.ResourceGroup;
                    var token = await AquireManagementTokenAsync().ConfigureAwait(false);

                    using var client = new ServiceBusManagementClient(ResourceManagerUri, new TokenCredentials(token)) { SubscriptionId = azureSubscription };
                    await CreateRetryPolicy().ExecuteAsync(() => client.Queues.DeleteAsync(resourceGroup, NamespaceName, QueueName)).ConfigureAwait(false);
                }
                catch
                {
                    // This should not be considered a critical failure that results in a test failure.  Due
                    // to ARM being temperamental, some management operations may be rejected.  Throwing here
                    // does not help to ensure resource cleanup only flags the test itself as a failure.
                    //
                    // If a queue fails to be deleted, removing of the associated namespace at the end of the
                    // test run will also remove the orphan.
                }

                _disposed = true;
            }
        }

        /// <summary>
        ///   Provides access to dynamically created Service Bus Topic instance which exists only in the context
        ///   of the scope; disposal removes the resource from Azure.
        /// </summary>
        ///
        /// <seealso cref="IAsyncDisposable" />
        ///
        public sealed class TopicScope : IAsyncDisposable
        {
            /// <summary>Serves as a sentinel flag to denote when the instance has been disposed.</summary>
            private bool _disposed = false;

            /// <summary>
            ///   The name of the Service Bus namespace associated with the queue.
            /// </summary>
            ///
            public string NamespaceName { get; }

            /// <summary>
            ///  The name of the topic.
            /// </summary>
            ///
            public string TopicName { get; }

            /// <summary>
            ///   The set of names for the subscriptions associated with the topic.
            /// </summary>
            ///
            public IReadOnlyList<string> SubscriptionNames { get; }

            /// <summary>
            ///   A flag indicating if the topic should be removed when the scope is complete.
            /// </summary>
            ///
            /// <value><c>true</c> if the queue was should be removed at scope completion; otherwise, <c>false</c>.</value>
            ///
            private bool ShouldRemoveAtScopeCompletion { get; }

            /// <summary>
            ///   Initializes a new instance of the <see cref="TopicScope"/> class.
            /// </summary>
            ///
            /// <param name="serviceBusNamespaceName">The name of the Service Bus namespace to which the queue is associated.</param>
            /// <param name="topicName">The name of the topic.</param>
            /// <param name="subscriptionNames">The set of names for the subscriptions </param>
            /// <param name="shouldRemoveAtScopeCompletion">A flag indicating whether the topic should be removed when the scope is complete.</param>
            ///
            public TopicScope(string serviceBusNamespaceName,
                              string topicName,
                              IReadOnlyList<string> subscriptionNames,
                              bool shouldRemoveAtScopeCompletion)
            {
                NamespaceName = serviceBusNamespaceName;
                TopicName = topicName;
                SubscriptionNames = subscriptionNames;
                ShouldRemoveAtScopeCompletion = shouldRemoveAtScopeCompletion;
            }

            /// <summary>
            ///   Performs the tasks needed to remove the dynamically created Service Bus Topic.
            /// </summary>
            ///
            public async ValueTask DisposeAsync()
            {
                if (!ShouldRemoveAtScopeCompletion)
                {
                    _disposed = true;
                }

                if (_disposed)
                {
                    return;
                }

                try
                {
                    var azureSubscription = ServiceBusTestEnvironment.Instance.SubscriptionId;
                    var resourceGroup = ServiceBusTestEnvironment.Instance.ResourceGroup;
                    var token = await AquireManagementTokenAsync().ConfigureAwait(false);

                    using var client = new ServiceBusManagementClient(ResourceManagerUri, new TokenCredentials(token)) { SubscriptionId = azureSubscription };
                    await CreateRetryPolicy().ExecuteAsync(() => client.Topics.DeleteAsync(resourceGroup, NamespaceName, TopicName)).ConfigureAwait(false);
                }
                catch
                {
                    // This should not be considered a critical failure that results in a test failure.  Due
                    // to ARM being temperamental, some management operations may be rejected.  Throwing here
                    // does not help to ensure resource cleanup only flags the test itself as a failure.
                    //
                    // If a queue fails to be deleted, removing of the associated namespace at the end of the
                    // test run will also remove the orphan.
                }

                _disposed = true;
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
            public ManagementToken(string token,
                                   DateTimeOffset expiresOn)
            {
                Token = token;
                ExpiresOn = expiresOn;
            }
        }
    }
}
