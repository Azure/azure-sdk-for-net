// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Messaging.EventHubs.Tests.Infrastructure;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Represents the ambient environment in which the test suite is
    ///   being run, offering access to information such as environment
    ///   variables.
    /// </summary>
    ///
    public static class TestEnvironment
    {
        /// <summary>The environment variable value for the Event Hubs subscription name, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsSubscriptionInstance =
            new Lazy<string>(() => ReadAndVerifyEnvironmentVariable("EVENT_HUBS_SUBSCRIPTION"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Event Hubs resource group name, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsResourceGroupInstance =
            new Lazy<string>(() => ReadAndVerifyEnvironmentVariable("EVENT_HUBS_RESOURCEGROUP"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Azure Active Directory tenant that holds the service principal, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsTenantInstance =
            new Lazy<string>(() => ReadAndVerifyEnvironmentVariable("EVENT_HUBS_TENANT"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Azure Active Directory client identifier of the service principal, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsClientInstance =
            new Lazy<string>(() => ReadAndVerifyEnvironmentVariable("EVENT_HUBS_CLIENT"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Azure Active Directory client secret of the service principal, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsSecretInstance =
            new Lazy<string>(() => ReadAndVerifyEnvironmentVariable("EVENT_HUBS_SECRET"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The active Event Hubs namespace for this test run, lazily created.</summary>
        private static readonly Lazy<EventHubScope.NamespaceProperties> ActiveEventHubsNamespace =
            new Lazy<EventHubScope.NamespaceProperties>(() => EventHubScope.CreateNamespaceAsync().GetAwaiter().GetResult(), LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>The name of the shared access key to be used for accessing an Event Hubs namespace.</summary>
        public const string EventHubsDefaultSharedAccessKey = "RootManageSharedAccessKey";

        /// <summary>
        ///   Indicates whether or not an ephemeral namespace was created for the current test execution.
        /// </summary>
        ///
        /// <value><c>true</c> if an Event Hubs namespace was created; otherwise, <c>false</c>.</value>
        ///
        public static bool WasEventHubsNamespaceCreated => ActiveEventHubsNamespace.IsValueCreated;

        /// <summary>
        ///   The connection string for the Event Hubs namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The connection string will be determined by creating an ephemeral Event Hubs namespace for the test execution.</value>
        ///
        public static string EventHubsConnectionString => ActiveEventHubsNamespace.Value.ConnectionString;

        /// <summary>
        ///   The name of the Event Hubs namespace to be used for Live tests.
        /// </summary>
        ///
        /// <value>The name will be determined by creating an ephemeral Event Hubs namespace for the test execution.</value>
        ///
        public static string EventHubsNamespace => ActiveEventHubsNamespace.Value.Name;

        /// <summary>
        ///   The name of the Azure subscription containing the Event Hubs namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_SUBSCRIPTION" environment variable.</value>
        ///
        public static string EventHubsSubscription => EventHubsSubscriptionInstance.Value;

        /// <summary>
        ///   The name of the resource group containing the Event Hubs namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_RESOURCEGROUP" environment variable.</value>
        ///
        public static string EventHubsResourceGroup => EventHubsResourceGroupInstance.Value;

        /// <summary>
        ///   The name of the Azure Active Directory tenant that holds the service principal to use for management
        ///   of the Event Hubs namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_TENANT" environment variable.</value>
        ///
        public static string EventHubsTenant => EventHubsTenantInstance.Value;

        /// <summary>
        ///   The name of the Azure Active Directory client identifier of the service principal to use for management
        ///   of the Event Hubs namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_CLIENT" environment variable.</value>
        ///
        public static string EventHubsClient => EventHubsClientInstance.Value;

        /// <summary>
        ///   The name of the Azure Active Directory client secret of the service principal to use for management
        ///   of the Event Hubs namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_SECRET" environment variable.</value>
        ///
        public static string EventHubsSecret => EventHubsSecretInstance.Value;

        /// <summary>
        ///   Builds a connection string for a specific Event Hub instance under the Event Hubs namespace used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The namepsace connection string is read from the "EVENT_HUBS_CONNECTION_STRING" environment variable.</value>
        ///
        public static string BuildConnectionStringForEventHub(string eventHubName) => $"{ EventHubsConnectionString };EntityPath={eventHubName}";

        /// <summary>
        ///   Reads an environment variable, ensuring that it is populated.
        /// </summary>
        ///
        /// <param name="variableName">The name of the environment variable to read.</param>
        ///
        /// <returns>The value of the environment variable, if present and populated; otherwise, a <see cref="InvalidOperationException" /> is thrown.</returns>
        ///
        private static string ReadAndVerifyEnvironmentVariable(string variableName)
        {
            var environmentValue = Environment.GetEnvironmentVariable(variableName);

            if (String.IsNullOrWhiteSpace(environmentValue))
            {
                throw new InvalidOperationException($"The environment variable '{ variableName }' was not found or was not populated.");
            }

            return environmentValue;
        }
    }
}
