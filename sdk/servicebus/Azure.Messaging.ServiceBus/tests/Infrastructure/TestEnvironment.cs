// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   Represents the ambient environment in which the test suite is
    ///   being run, offering access to information such as environment
    ///   variables.
    /// </summary>
    ///
    public static class TestEnvironment
    {
        /// <summary>The environment variable value for the Service Bus subscription name, lazily evaluated.</summary>
        private static readonly Lazy<string> ServiceBusAzureSubscriptionInstance =
            new Lazy<string>(() => ReadAndVerifyEnvironmentVariable("SERVICE_BUS_SUBSCRIPTION"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Service Bus resource group name, lazily evaluated.</summary>
        private static readonly Lazy<string> ServiceBusResourceGroupInstance =
            new Lazy<string>(() => ReadAndVerifyEnvironmentVariable("SERVICE_BUS_RESOURCEGROUP"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Azure Active Directory tenant that holds the service principal, lazily evaluated.</summary>
        private static readonly Lazy<string> ServiceBusTenantInstance =
            new Lazy<string>(() => ReadAndVerifyEnvironmentVariable("SERVICE_BUS_TENANT"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Azure Active Directory client identifier of the service principal, lazily evaluated.</summary>
        private static readonly Lazy<string> ServiceBusClientInstance =
            new Lazy<string>(() => ReadAndVerifyEnvironmentVariable("SERVICE_BUS_CLIENT"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Azure Active Directory client secret of the service principal, lazily evaluated.</summary>
        private static readonly Lazy<string> ServiceBusSecretInstance =
            new Lazy<string>(() => ReadAndVerifyEnvironmentVariable("SERVICE_BUS_SECRET"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the override connection string to indicate an existing namespace should be used, lazily evaluated.</summary>
        private static readonly Lazy<string> ServiceBusOverrideConnectionString =
            new Lazy<string>(() => ReadEnvironmentVariable("SERVICE_BUS_NAMESPACE_CONNECTION_STRING"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the override name of an existing queue should be used when a queue scope is requested, lazily evaluated.</summary>
        private static readonly Lazy<string> ServiceBusOverrideQueueName =
            new Lazy<string>(() => ReadEnvironmentVariable("SERVICE_BUS_OVERRIDE_QUEUE"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the override name of an existing queue should be used when a topic scope is requested, lazily evaluated.</summary>
        private static readonly Lazy<string> ServiceBusOverrideTopicName =
            new Lazy<string>(() => ReadEnvironmentVariable("SERVICE_BUS_OVERRIDE_TOPIC"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The active Service Bus namespace for this test run, lazily created.</summary>
        private static readonly Lazy<NamespaceProperties> ActiveServiceBusNamespace =
            new Lazy<NamespaceProperties>(EnsureServiceBusNamespace, LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>The active Service Bus namespace for this test run, lazily created.</summary>
        private static readonly Lazy<ConnectionStringProperties> ParsedConnectionString =
            new Lazy<ConnectionStringProperties>(() => ConnectionStringParser.Parse(ServiceBusConnectionString), LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>The name of the shared access key to be used for accessing an Service Bus namespace.</summary>
        public const string ServiceBusDefaultSharedAccessKey = "RootManageSharedAccessKey";

        /// <summary>
        ///   Indicates whether or not an ephemeral namespace was created for the current test execution.
        /// </summary>
        ///
        /// <value><c>true</c> if an Service Bus namespace was created for the current test run; otherwise, <c>false</c>.</value>
        ///
        public static bool ShouldRemoveNamespaceAfterTestRunCompletion => (ActiveServiceBusNamespace.IsValueCreated && ActiveServiceBusNamespace.Value.ShouldRemoveAtCompletion);

        /// <summary>
        ///   The connection string for the Service Bus namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The connection string will be determined by creating an ephemeral Service Bus namespace for the test execution.</value>
        ///
        public static string ServiceBusConnectionString => ActiveServiceBusNamespace.Value.ConnectionString;

        /// <summary>
        ///   The name of the Service Bus namespace to be used for Live tests.
        /// </summary>
        ///
        /// <value>The name will be determined by creating an ephemeral Service Bus namespace for the test execution.</value>
        ///
        public static string ServiceBusNamespace => ActiveServiceBusNamespace.Value.Name;

        /// <summary>
        ///   The name of the Azure subscription containing the Service Bus namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "SERVICE_BUS_SUBSCRIPTION" environment variable.</value>
        ///
        public static string ServiceBusAzureSubscription => ServiceBusAzureSubscriptionInstance.Value;

        /// <summary>
        ///   The name of the resource group containing the Service Bus namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "SERVICE_BUS_RESOURCEGROUP" environment variable.</value>
        ///
        public static string ServiceBusResourceGroup => ServiceBusResourceGroupInstance.Value;

        /// <summary>
        ///   The name of the Azure Active Directory tenant that holds the service principal to use for management
        ///   of the Service Bus namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "SERVICE_BUS_TENANT" environment variable.</value>
        ///
        public static string ServiceBusTenant => ServiceBusTenantInstance.Value;

        /// <summary>
        ///   The name of the Azure Active Directory client identifier of the service principal to use for management
        ///   of the Service Bus namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "SERVICE_BUS_CLIENT" environment variable.</value>
        ///
        public static string ServiceBusClient => ServiceBusClientInstance.Value;

        /// <summary>
        ///   The name of the Azure Active Directory client secret of the service principal to use for management
        ///   of the Service Bus namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "SERVICE_BUS_SECRET" environment variable.</value>
        ///
        public static string ServiceBusSecret => ServiceBusSecretInstance.Value;

        /// <summary>
        ///   The fully qualified namespace for the Service Bus namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The fully qualified namespace, as contained within the associated connection string.</value>
        ///
        public static string FullyQualifiedNamespace => ParsedConnectionString.Value.Endpoint.Host;

        /// <summary>
        ///   The shared access key name for the Service Bus namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The shared access key name, as contained within the associated connection string.</value>
        ///
        public static string SharedAccessKeyName => ParsedConnectionString.Value.SharedAccessKeyName;

        /// <summary>
        ///   The shared access key for the Service Bus namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The shared access key, as contained within the associated connection string.</value>
        ///
        public static string SharedAccessKey => ParsedConnectionString.Value.SharedAccessKey;

        /// <summary>
        ///   The name of an existing Service Bus queue to consider an override and use when
        ///   requesting a test scope, overriding the creation of a new dynamic queue specific to
        ///   the scope.
        /// </summary>
        ///
        public static string OverrideQueueName => ServiceBusOverrideQueueName.Value;

        /// <summary>
        ///   The name of an existing Service Bus topic to consider an override and use when
        ///   requesting a test scope, overriding the creation of a new dynamic topic specific to
        ///   the scope.
        /// </summary>
        ///
        public static string OverrideTopicName => ServiceBusOverrideTopicName.Value;

        /// <summary>
        ///   Builds a connection string for a specific Service Bus entity instance under the namespace used for
        ///   Live tests.
        /// </summary>
        ///
        /// <param name="entityName">The name of the entity for which the connection string is being built.</param>
        ///
        /// <returns>The connection string to the requested Service Bus namespace and entity.</returns>
        ///
        public static string BuildConnectionStringForEntity(string entityName) => $"{ ServiceBusConnectionString };EntityPath={ entityName }";

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
            var environmentValue = ReadEnvironmentVariable(variableName);

            if (string.IsNullOrWhiteSpace(environmentValue))
            {
                throw new InvalidOperationException($"The environment variable '{ variableName }' was not found or was not populated.");
            }

            return environmentValue;
        }

        /// <summary>
        ///   Ensures that a Service Bus namespace is available.  If the <see cref="ServiceBusOverrideConnectionString"/> override was set for the environment,
        ///   that namespace will be respected.  Otherwise, a new Service Bus namespace will be created on Azure for this test run.
        /// </summary>
        ///
        /// <returns>The active Service Bus namespace for this test run.</returns>
        ///
        private static NamespaceProperties EnsureServiceBusNamespace()
        {
            if (!string.IsNullOrEmpty(ServiceBusOverrideConnectionString.Value))
            {
                var parsed = ConnectionStringParser.Parse(ServiceBusOverrideConnectionString.Value);

                return new NamespaceProperties
                (
                    parsed.Endpoint.Host.Substring(0, parsed.Endpoint.Host.IndexOf('.')),
                    ServiceBusOverrideConnectionString.Value.Replace($";EntityPath={ parsed.EntityPath }", string.Empty),
                    false
                );
            }

            return Task
               .Run(async () => await ServiceBusScope.CreateNamespaceAsync().ConfigureAwait(false))
               .ConfigureAwait(false)
               .GetAwaiter()
               .GetResult();
        }

        /// <summary>
        ///   The key attributes for identifying and accessing a dynamically created Service Bus namespace,
        ///   intended to serve as an ephemeral container for the entity instances used during a test run.
        /// </summary>
        ///
        public struct NamespaceProperties
        {
            /// <summary>The name of the namespace.</summary>
            public readonly string Name;

            /// <summary>The connection string to use for accessing the dynamically created namespace.</summary>
            public readonly string ConnectionString;

            /// <summary>A flag indicating if the namespace was dynamically created by the test environment.</summary>
            public readonly bool ShouldRemoveAtCompletion;

            /// <summary>
            ///   Initializes a new instance of the <see cref="NamespaceProperties"/> struct.
            /// </summary>
            ///
            /// <param name="name">The name of the namespace.</param>
            /// <param name="connectionString">The connection string to use for accessing the namespace.</param>
            /// <param name="shouldRemoveAtCompletion">A flag indicating if the namespace should be removed when the test run has completed.</param>
            ///
            public NamespaceProperties(string name,
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
