// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

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

        /// <summary>The environment variable value for the namespace connection string, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsNamespaceConnectionString =
            new Lazy<string>(() => ReadConnectionStringFromEnvironment("EVENT_HUBS_OVERRIDE_NAMESPACE_CONNECTION_STRING"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the event hub name, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsEventHubName =
            new Lazy<string>(() => ReadEnvironmentVariable("EVENT_HUBS_OVERRIDE_EVENT_HUB_NAME"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The active Event Hubs namespace for this test run, lazily created.</summary>
        private static readonly Lazy<EventHubScope.NamespaceProperties> ActiveEventHubsNamespace =
            new Lazy<EventHubScope.NamespaceProperties>(CreateNamespaceIfMissing, LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>The fully qualified namespace contained within the active connection string, lazily created.</summary>
        private static readonly Lazy<string> FullyQualifiedNamespaceInstance =
            new Lazy<string>(() => ParseFullyQualifiedNamespace(EventHubsConnectionString), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The shared access key name contained within the active connection string, lazily created.</summary>
        private static readonly Lazy<string> SharedAccessKeyNameInstance =
            new Lazy<string>(() => ParseSharedAccessKeyName(EventHubsConnectionString), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The shared access key contained within the active connection string, lazily created.</summary>
        private static readonly Lazy<string> SharedAccessKeyInstance =
            new Lazy<string>(() => ParseSharedAccessKey(EventHubsConnectionString), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The name of the shared access key to be used for accessing an Event Hubs namespace.</summary>
        public const string EventHubsDefaultSharedAccessKey = "RootManageSharedAccessKey";

        /// <summary>
        ///   Indicates whether or not an ephemeral namespace was created for the current test execution.
        /// </summary>
        ///
        /// <value><c>true</c> if an Event Hubs namespace was created for the current test run; otherwise, <c>false</c>.</value>
        ///
        public static bool WasEventHubsNamespaceCreated => ActiveEventHubsNamespace.IsValueCreated && ActiveEventHubsNamespace.Value.WasNamespaceCreated;

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
        ///   The fully qualified namespace for the Event Hubs namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The fully qualified namespace, as contained within the associated connection string.</value>
        ///
        public static string FullyQualifiedNamespace => FullyQualifiedNamespaceInstance.Value;

        /// <summary>
        ///   The name of the Event Hub to use during Live tests.
        /// </summary>
        ///
        /// <value>The name of the event hub is read from the "EVENT_HUBS_EVENT_HUB_NAME" environment variable.</value>
        ///
        public static string EventHubName => EventHubsEventHubName.Value;

        /// <summary>
        ///   The shared access key name for the Event Hubs namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The shared access key name, as contained within the associated connection string.</value>
        ///
        public static string SharedAccessKeyName => SharedAccessKeyNameInstance.Value;

        /// <summary>
        ///   The shared access key for the Event Hubs namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The shared access key, as contained within the associated connection string.</value>
        ///
        public static string SharedAccessKey => SharedAccessKeyInstance.Value;

        /// <summary>
        ///   Builds a connection string for a specific Event Hub instance under the Event Hubs namespace used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The namespace connection string is based on the dynamic Event Hubs scope.</value>
        ///
        public static string BuildConnectionStringForEventHub(string eventHubName) => $"{ EventHubsConnectionString };EntityPath={ eventHubName }";

        /// <summary>
        ///   Reads an environment variable.
        /// </summary>
        ///
        /// <param name="variableName">The name of the environment variable to read.</param>
        ///
        /// <returns>The value of the environment variable, if present and populated; null otherwise</returns>
        ///
        private static string ReadEnvironmentVariable(string variableName) =>
            Environment.GetEnvironmentVariable(variableName);

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

            if (string.IsNullOrWhiteSpace(environmentValue))
            {
                throw new InvalidOperationException($"The environment variable '{ variableName }' was not found or was not populated.");
            }

            return environmentValue;
        }

        /// <summary>
        ///   It tries to read the <see cref="EventHubsNamespaceConnectionString"/> environment variable.
        ///   If not found, it creates a new namespace on Azure.
        /// </summary>
        ///
        /// <returns>The active Event Hubs namespace for this test run.</returns>
        ///
        private static EventHubScope.NamespaceProperties CreateNamespaceIfMissing()
        {
            if (!string.IsNullOrEmpty(EventHubsNamespaceConnectionString.Value))
            {
                return EventHubScope.PopulateNamespacePropertiesFromConnectionString(EventHubsNamespaceConnectionString.Value);
            }

            return CreateNamespace();
        }

        /// <summary>
        ///   Parses a well-formed connection string to extract the fully qualified namespace.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to parse.</param>
        ///
        /// <returns>The fully qualified namespace contained in the connection string if the connection string is well-formed; otherwise, a <see cref="InvalidOperationException" /> is thrown.</returns>
        ///
        private static string ParseFullyQualifiedNamespace(string connectionString) =>
            new Uri(ConnectionStringTokenParser.ParseTokenAndReturnValue(connectionString, "Endpoint")).Host;

        /// <summary>
        ///   Parses a well-formed connection string to extract the shared access key name.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to parse.</param>
        ///
        /// <returns>The fully qualified namespace contained in the connection string if the connection string is well-formed; otherwise, a <see cref="InvalidOperationException" /> is thrown.</returns>
        ///
        private static string ParseSharedAccessKeyName(string connectionString) =>
            ConnectionStringTokenParser.ParseTokenAndReturnValue(connectionString, "SharedAccessKeyName");

        /// <summary>
        ///   Parses a well-formed connection string to extract the shared access key.
        /// </summary>
        /// <param name="connectionString"></param>
        ///
        /// <returns>The fully qualified namespace contained in the connection string if the connection string is well-formed; otherwise, a <see cref="InvalidOperationException" /> is thrown.</returns>
        ///
        private static string ParseSharedAccessKey(string connectionString) =>
            ConnectionStringTokenParser.ParseTokenAndReturnValue(connectionString, "SharedAccessKey");

        /// <summary>
        ///   Reads a connection string from environment.
        ///   If any is found it removes the entity path from it.
        /// </summary>
        ///
        /// <param name="environmentVariable">The name of the environment variable containing the connection string.</param>
        ///
        /// <returns>The connection string without the entity path.</returns>
        ///
        private static string ReadConnectionStringFromEnvironment(string environmentVariable)
        {
            string connectionString = ReadEnvironmentVariable(environmentVariable);

            if (!string.IsNullOrEmpty(connectionString))
            {
                return ParseNamespaceConnectionString(connectionString);
            }

            return null;
        }

        /// <summary>
        ///   It removes the entity path from a event hub connection string if found.
        ///   It returns the same connection string.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to parse.</param>
        ///
        /// <returns>A namespace scoped connection string.</returns>
        ///
        private static string ParseNamespaceConnectionString(string connectionString)
        {
            string entityPath = ConnectionStringTokenParser.ParseToken(connectionString, "EntityPath");

            if (!string.IsNullOrEmpty(entityPath))
            {
                return connectionString.Replace(entityPath, string.Empty);
            }

            return connectionString;
        }

        /// <summary>
        ///   Requests creation of an Event Hubs namespace to use for a specific test run,
        ///   transforming the asynchronous request into a synchronous one that can be used with
        ///   lazy instantiation.
        /// </summary>
        ///
        /// <returns>The active Event Hubs namespace for this test run.</returns>
        ///
        private static EventHubScope.NamespaceProperties CreateNamespace() =>
            Task
                .Run(async () => await EventHubScope.CreateNamespaceAsync().ConfigureAwait(false))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
    }
}
