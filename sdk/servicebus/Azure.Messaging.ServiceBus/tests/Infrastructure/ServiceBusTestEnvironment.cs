// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   Represents the ambient environment in which the test suite is
    ///   being run, offering access to information such as environment
    ///   variables.
    /// </summary>
    ///
    public class ServiceBusTestEnvironment: TestEnvironment
    {
        /// <summary>The name of the environment variable used to specify the Service Bus namespace to use for the test run.</summary>
        public const string ServiceBusConnectionStringEnvironmentVariable  = "SERVICEBUS_CONNECTION_STRING";

        /// <summary>The name of the shared access key to be used for accessing an Service Bus namespace.</summary>
        public const string ServiceBusDefaultSharedAccessKey = "RootManageSharedAccessKey";

        /// <summary>A shared instance of <see cref="ServiceBusTestEnvironment"/>. </summary>
        public static ServiceBusTestEnvironment Instance { get; } = new ServiceBusTestEnvironment();

        /// <summary>The active Service Bus namespace for this test run, lazily created.</summary>
        private readonly Lazy<NamespaceProperties> ActiveServiceBusNamespace;

        /// <summary>The active Service Bus namespace for this test run, lazily created.</summary>
        private readonly Lazy<ServiceBusConnectionStringProperties> ParsedConnectionString;

        /// <summary>
        ///   Indicates whether or not an ephemeral namespace was created for the current test execution.
        /// </summary>
        ///
        /// <value><c>true</c> if an Service Bus namespace was created for the current test run; otherwise, <c>false</c>.</value>
        ///
        public bool ShouldRemoveNamespaceAfterTestRunCompletion => (ActiveServiceBusNamespace.IsValueCreated && ActiveServiceBusNamespace.Value.ShouldRemoveAtCompletion);

        /// <summary>
        ///   The connection string for the Service Bus namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The connection string will be determined by creating an ephemeral Service Bus namespace for the test execution.</value>
        ///
        public string ServiceBusConnectionString => ActiveServiceBusNamespace.Value.ConnectionString;

        /// <summary>
        ///   The name of the Service Bus namespace to be used for Live tests.
        /// </summary>
        ///
        /// <value>The name will be determined by creating an ephemeral Service Bus namespace for the test execution.</value>
        ///
        public string ServiceBusNamespace => ActiveServiceBusNamespace.Value.Name;

        /// <summary>
        ///   The fully qualified namespace for the Service Bus namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The fully qualified namespace, as contained within the associated connection string.</value>
        ///
        public string FullyQualifiedNamespace => ParsedConnectionString.Value.Endpoint.Host;

        /// <summary>
        ///   The shared access key name for the Service Bus namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The shared access key name, as contained within the associated connection string.</value>
        ///
        public string SharedAccessKeyName => ParsedConnectionString.Value.SharedAccessKeyName;

        /// <summary>
        ///   The shared access key for the Service Bus namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The shared access key, as contained within the associated connection string.</value>
        ///
        public string SharedAccessKey => ParsedConnectionString.Value.SharedAccessKey;

        /// <summary>
        ///   The Azure Authority host to be used for authentication with the active cloud environment.
        /// </summary>
        ///
        public new string AuthorityHostUrl => base.AuthorityHostUrl ?? "https://login.microsoftonline.com/";

        /// <summary>
        ///   The Azure Service Management endpoint to be used for management plane authentication with the active cloud environment.
        /// </summary>
        ///
        public new string ServiceManagementUrl => base.ServiceManagementUrl ?? "https://management.core.windows.net/";

        /// <summary>
        ///   The location of the resource manager for the active cloud environment.
        /// </summary>
        ///
        public new string ResourceManagerUrl  => base.ResourceManagerUrl ?? "https://management.azure.com/";

        /// <summary>
        ///   The environment variable value for the override connection string to indicate an existing namespace should be used.
        /// </summary>
        ///
        public string OverrideServiceBusConnectionString => GetRecordedOptionalVariable(ServiceBusConnectionStringEnvironmentVariable, options => options.HasSecretConnectionStringParameter("SharedAccessKey", SanitizedValue.Base64));

        /// <summary>
        ///   The name of an existing Service Bus queue to consider an override and use when
        ///   requesting a test scope, overriding the creation of a new dynamic queue specific to
        ///   the scope.
        /// </summary>
        ///
        public string OverrideQueueName => GetOptionalVariable("SERVICEBUS_OVERRIDE_QUEUE");

        /// <summary>
        ///   The name of an existing Service Bus topic to consider an override and use when
        ///   requesting a test scope, overriding the creation of a new dynamic topic specific to
        ///   the scope.
        /// </summary>
        ///
        public string OverrideTopicName => GetOptionalVariable("SERVICEBUS_OVERRIDE_TOPIC");

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusTestEnvironment"/> class.
        /// </summary>
        ///
        public ServiceBusTestEnvironment()
        {
            ActiveServiceBusNamespace = new Lazy<NamespaceProperties>(EnsureServiceBusNamespace, LazyThreadSafetyMode.ExecutionAndPublication);
            ParsedConnectionString = new Lazy<ServiceBusConnectionStringProperties>(() => ServiceBusConnectionStringProperties.Parse(ServiceBusConnectionString), LazyThreadSafetyMode.ExecutionAndPublication);
        }

        /// <summary>
        ///   Builds a connection string for a specific Service Bus entity instance under the namespace used for
        ///   Live tests.
        /// </summary>
        ///
        /// <param name="entityName">The name of the entity for which the connection string is being built.</param>
        ///
        /// <returns>The connection string to the requested Service Bus namespace and entity.</returns>
        ///
        public string BuildConnectionStringForEntity(string entityName) => $"{ ServiceBusConnectionString };EntityPath={ entityName }";

        /// <summary>
        ///   Builds a connection string for the Service Bus namespace used for Live tests, creating a shared access signature
        ///   in place of the shared key.
        /// </summary>
        ///
        /// <param name="entityName">The name of the entity for which the connection string is being built.</param>
        /// <param name="signatureAudience">The audience to use for the shared access signature.</param>
        /// <param name="validDurationMinutes">The duration, in minutes, that the signature should be considered valid for.</param>
        ///
        /// <returns>The namespace connection string with a shared access signature based on the shared key of the current scope.</value>
        ///
        public string BuildConnectionStringWithSharedAccessSignature(string entityName,
                                                                     string signatureAudience,
                                                                     int validDurationMinutes = 30)
        {
            var signature = new SharedAccessSignature(signatureAudience, SharedAccessKeyName, SharedAccessKey, TimeSpan.FromMinutes(validDurationMinutes));
            return $"Endpoint={ ParsedConnectionString.Value.Endpoint };EntityPath={ entityName };SharedAccessSignature={ signature.Value }";
        }

        /// <summary>
        ///   Ensures that a Service Bus namespace is available.  If the <see cref="OverrideServiceBusConnectionString"/> override was set for the environment,
        ///   that namespace will be respected.  Otherwise, a new Service Bus namespace will be created on Azure for this test run.
        /// </summary>
        ///
        /// <returns>The active Service Bus namespace for this test run.</returns>
        ///
        private NamespaceProperties EnsureServiceBusNamespace()
        {
            if (!string.IsNullOrEmpty(OverrideServiceBusConnectionString))
            {
                var parsed = ServiceBusConnectionStringProperties.Parse(OverrideServiceBusConnectionString);

                return new NamespaceProperties
                (
                    parsed.Endpoint.Host.Substring(0, parsed.Endpoint.Host.IndexOf('.')),
                    OverrideServiceBusConnectionString.Replace($";EntityPath={ parsed.EntityPath }", string.Empty),
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
