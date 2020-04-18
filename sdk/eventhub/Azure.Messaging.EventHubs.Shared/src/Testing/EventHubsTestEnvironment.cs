// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Represents the ambient environment in which the test suite is
    ///   being run, offering access to information such as environment
    ///   variables.
    /// </summary>
    ///
    public class EventHubsTestEnvironment: TestEnvironment
    {
        public EventHubsTestEnvironment() : base("eventhub")
        {
            ParsedConnectionString = new Lazy<ConnectionStringProperties>(() => ConnectionStringParser.Parse(EventHubsConnectionString), LazyThreadSafetyMode.ExecutionAndPublication);
            ActiveEventHubsNamespace = new Lazy<NamespaceProperties>(EnsureEventHubsNamespace, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public static EventHubsTestEnvironment Instance { get; } = new EventHubsTestEnvironment();

        /// <summary>The environment variable value for the Event Hubs subscription name, lazily evaluated.</summary>
        private string EventHubsSubscriptionInstance => GetVariable("EVENT_HUBS_SUBSCRIPTION");

        /// <summary>The environment variable value for the Event Hubs resource group name, lazily evaluated.</summary>
        private string EventHubsResourceGroupInstance => ResourceGroup;

        /// <summary>The environment variable value for the Azure Active Directory tenant that holds the service principal, lazily evaluated.</summary>
        private string EventHubsTenantInstance => TenantId;

        /// <summary>The environment variable value for the Azure Active Directory client identifier of the service principal, lazily evaluated.</summary>
        private string EventHubsClientInstance => ClientId;

        /// <summary>The environment variable value for the Azure Active Directory client secret of the service principal, lazily evaluated.</summary>
        private string EventHubsSecretInstance => ClientSecret;

        /// <summary>The environment variable value for the namespace connection string, lazily evaluated.</summary>
        private string EventHubsNamespaceConnectionString => GetVariable("EVENT_HUBS_NAMESPACE_CONNECTION_STRING");

        /// <summary>The environment variable value for the event hub name, lazily evaluated.</summary>
        private string EventHubsEventHubName => GetVariable("EVENT_HUBS_OVERRIDE_EVENT_HUB_NAME");

        /// <summary>The active Event Hubs namespace for this test run, lazily created.</summary>
        private readonly Lazy<NamespaceProperties> ActiveEventHubsNamespace;

        /// <summary>The connection string for the active Event Hubs namespace for this test run, lazily created.</summary>
        private readonly Lazy<ConnectionStringProperties> ParsedConnectionString;

        /// <summary>The name of the shared access key to be used for accessing an Event Hubs namespace.</summary>
        public const string EventHubsDefaultSharedAccessKey = "RootManageSharedAccessKey";

        /// <summary>
        ///   Indicates whether or not an ephemeral namespace was created for the current test execution.
        /// </summary>
        ///
        /// <value><c>true</c> if an Event Hubs namespace should be removed after the current test run; otherwise, <c>false</c>.</value>
        ///
        public bool ShouldRemoveNamespaceAfterTestRunCompletion => (ActiveEventHubsNamespace.IsValueCreated && ActiveEventHubsNamespace.Value.ShouldRemoveAtCompletion);

        /// <summary>
        ///   The connection string for the Event Hubs namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The connection string will be determined by creating an ephemeral Event Hubs namespace for the test execution.</value>
        ///
        public string EventHubsConnectionString => ActiveEventHubsNamespace.Value.ConnectionString;

        /// <summary>
        ///   The name of the Event Hubs namespace to be used for Live tests.
        /// </summary>
        ///
        /// <value>The name will be determined by creating an ephemeral Event Hubs namespace for the test execution.</value>
        ///
        public string EventHubsNamespace => ActiveEventHubsNamespace.Value.Name;

        /// <summary>
        ///   The name of the Azure subscription containing the Event Hubs namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_SUBSCRIPTION" environment variable.</value>
        ///
        public string EventHubsSubscription => SubscriptionId;

        /// <summary>
        ///   The name of the resource group containing the Event Hubs namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_RESOURCEGROUP" environment variable.</value>
        ///
        public string EventHubsResourceGroup => ResourceGroup;

        /// <summary>
        ///   The name of the Azure Active Directory tenant that holds the service principal to use for management
        ///   of the Event Hubs namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_TENANT" environment variable.</value>
        ///
        public string EventHubsTenant => TenantId;

        /// <summary>
        ///   The name of the Azure Active Directory client identifier of the service principal to use for management
        ///   of the Event Hubs namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_CLIENT" environment variable.</value>
        ///
        public string EventHubsClient => ClientId;

        /// <summary>
        ///   The name of the Azure Active Directory client secret of the service principal to use for management
        ///   of the Event Hubs namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_SECRET" environment variable.</value>
        ///
        public string EventHubsSecret => ClientSecret;

        /// <summary>
        ///   The fully qualified namespace for the Event Hubs namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The fully qualified namespace, as contained within the associated connection string.</value>
        ///
        public string FullyQualifiedNamespace => ParsedConnectionString.Value.Endpoint.Host;

        /// <summary>
        ///   The name of the Event Hub to use during Live tests.
        /// </summary>
        ///
        /// <value>The name of the event hub is read from the "EVENT_HUBS_EVENT_HUB_NAME" environment variable.</value>
        ///
        public string EventHubName => EventHubsEventHubName;

        /// <summary>
        ///   The shared access key name for the Event Hubs namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The shared access key name, as contained within the associated connection string.</value>
        ///
        public string SharedAccessKeyName => ParsedConnectionString.Value.SharedAccessKeyName;

        /// <summary>
        ///   The shared access key for the Event Hubs namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The shared access key, as contained within the associated connection string.</value>
        ///
        public string SharedAccessKey => ParsedConnectionString.Value.SharedAccessKey;

        /// <summary>
        ///   Builds a connection string for a specific Event Hub instance under the Event Hubs namespace used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The namespace connection string is based on the dynamic Event Hubs scope.</value>
        ///
        public string BuildConnectionStringForEventHub(string eventHubName) => $"{ EventHubsConnectionString };EntityPath={ eventHubName }";

        /// <summary>
        ///   It tries to read the <see cref="EventHubsNamespaceConnectionString"/> environment variable.
        ///   If not found, it creates a new namespace on Azure.
        /// </summary>
        ///
        /// <returns>The active Event Hubs namespace for this test run.</returns>
        ///
        private NamespaceProperties EnsureEventHubsNamespace()
        {
            if (!string.IsNullOrEmpty(EventHubsNamespaceConnectionString))
            {
                var parsed = ConnectionStringParser.Parse(EventHubsNamespaceConnectionString);

                return new NamespaceProperties
                (
                    parsed.Endpoint.Host.Substring(0, parsed.Endpoint.Host.IndexOf('.')),
                    EventHubsNamespaceConnectionString.Replace($";EntityPath={ parsed.EventHubName }", string.Empty),
                    shouldRemoveAtCompletion: false
                );
            }

            return Task
                .Run(async () => await EventHubScope.CreateNamespaceAsync().ConfigureAwait(false))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
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

            /// <summary>A flag indicating if the namespace was created or referenced from environment variables.</summary>
            public readonly bool ShouldRemoveAtCompletion;

            /// <summary>
            ///   Initializes a new instance of the <see cref="NamespaceProperties"/> struct.
            /// </summary>
            ///
            /// <param name="name">The name of the namespace.</param>
            /// <param name="connectionString">The connection string to use for accessing the namespace.</param>
            /// <param name="shouldRemoveAtCompletion">A flag indicating if the namespace should be removed when the test run has completed.</param>
            ///
            internal NamespaceProperties(string name,
                                         string connectionString,
                                         bool shouldRemoveAtCompletion)
            {
                Name = name;
                ConnectionString = connectionString;
                ShouldRemoveAtCompletion = shouldRemoveAtCompletion;
            }
        }
    }
}
