// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Represents the ambient environment in which the test suite is
    ///   being run, offering access to information such as environment
    ///   variables.
    /// </summary>
    ///
    public sealed class EventHubsTestEnvironment: TestEnvironment
    {
        /// <summary>The name of the shared access key to be used for accessing an Event Hubs namespace.</summary>
        public const string EventHubsDefaultSharedAccessKey = "RootManageSharedAccessKey";

        /// <summary>The name of the environment variable used to specify The maximum duration, in minutes, that a test is permitted to run normally.</summary>
        private const string EventHubsPerTestExecutionLimitEnvironmentVariable = "EVENTHUB_PER_TEST_LIMIT_MINUTES";

        /// <summary>The name of the environment variable used to specify the Event Hubs namespace to use for the test run.</summary>
        private const string EventHubsNamespaceConnectionStringEnvironmentVariable = "EVENTHUB_NAMESPACE_CONNECTION_STRING";

        /// <summary>The name of the environment variable used to specify an override for the Event Hub instance to use for all tests.</summary>
        private const string EventHubNameOverrideEnvironmentVariable = "EVENTHUB_OVERRIDE_EVENT_HUB_NAME";

        /// <summary>The default value for the maximum duration, in minutes, that a single test is permitted to run before it is considered at-risk for being hung.</summary>
        private const int DefaultPerTestExecutionLimitMinutes = 5;

        /// <summary>The singleton instance of the <see cref="EventHubsTestEnvironment" />, lazily created.</summary>
        private static readonly Lazy<EventHubsTestEnvironment> Singleton = new Lazy<EventHubsTestEnvironment>(() => new EventHubsTestEnvironment(), LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>The active Event Hubs namespace for this test run, lazily created.</summary>
        private readonly Lazy<NamespaceProperties> ActiveEventHubsNamespace;

        /// <summary> The environment variable value, or default, for the maximum duration, in minutes, that a single test is permitted to run before it is considered at-risk for being hung, lazily evaluated.</summary>
        private readonly Lazy<TimeSpan> ActivePerTestExecutionLimit;

        /// <summary>The connection string for the active Event Hubs namespace for this test run, lazily created.</summary>
        private readonly Lazy<EventHubsConnectionStringProperties> ParsedConnectionString;

        /// <summary>
        ///   The shared instance of the <see cref="EventHubsTestEnvironment"/> to be used during test runs.
        /// </summary>
        ///
        public static EventHubsTestEnvironment Instance => Singleton.Value;

        /// <summary>
        ///   Indicates whether or not an ephemeral namespace was created for the current test execution.
        /// </summary>
        ///
        /// <value><c>true</c> if an Event Hubs namespace should be removed after the current test run; otherwise, <c>false</c>.</value>
        ///
        public bool ShouldRemoveNamespaceAfterTestRunCompletion => (ActiveEventHubsNamespace.IsValueCreated && ActiveEventHubsNamespace.Value.ShouldRemoveAtCompletion);

        /// <summary>
        ///   The environment variable value, or default, for the maximum duration, in minutes,
        ///   that a single test is permitted to run before it is considered at-risk for being hung.
        /// </summary>
        ///
        public TimeSpan TestExecutionTimeLimit => ActivePerTestExecutionLimit.Value;

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
        ///   The fully qualified namespace for the Event Hubs namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The fully qualified namespace, as contained within the associated connection string.</value>
        ///
        public string FullyQualifiedNamespace => ParsedConnectionString.Value.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the Event Hub to use during Live tests.
        /// </summary>
        ///
        /// <value>The name of the event hub is read from the "EVENTHUB_OVERRIDE_EVENT_HUB_NAME" environment variable.</value>
        ///
        public string EventHubNameOverride => GetOptionalVariable(EventHubNameOverrideEnvironmentVariable);

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
        ///   Initializes a new instance of <see cref="EventHubsTestEnvironment"/>.
        /// </summary>
        ///
        public EventHubsTestEnvironment()
        {
            ParsedConnectionString = new Lazy<EventHubsConnectionStringProperties>(() => EventHubsConnectionStringProperties.Parse(EventHubsConnectionString), LazyThreadSafetyMode.ExecutionAndPublication);
            ActiveEventHubsNamespace = new Lazy<NamespaceProperties>(EnsureEventHubsNamespace, LazyThreadSafetyMode.ExecutionAndPublication);

            ActivePerTestExecutionLimit = new Lazy<TimeSpan>(() =>
            {
                var interval = DefaultPerTestExecutionLimitMinutes;

                if (int.TryParse(GetOptionalVariable(EventHubsPerTestExecutionLimitEnvironmentVariable), out var environmentVariable))
                {
                    interval = environmentVariable;
                }

                return TimeSpan.FromMinutes(interval);
            }, LazyThreadSafetyMode.PublicationOnly);
        }

        /// <summary>
        ///   Builds a connection string for a specific Event Hub instance under the Event Hubs namespace used for
        ///   Live tests.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub to base the connection string on.</param>
        ///
        /// <return>The Event Hub-level connection string.</return>
        ///
        public string BuildConnectionStringForEventHub(string eventHubName) => $"{ EventHubsConnectionString };EntityPath={ eventHubName }";

        /// <summary>
        ///   Ensures that an Event Hubs namespace is available for the test run, using one if provided by the
        ///   <see cref="EventHubsNamespaceConnectionStringEnvironmentVariable" /> or creating a new Azure resource specific
        ///   to the current run.
        /// </summary>
        ///
        /// <returns>The active Event Hubs namespace for this test run.</returns>
        ///
        private NamespaceProperties EnsureEventHubsNamespace()
        {
            var environmentConnectionString = GetOptionalVariable(EventHubsNamespaceConnectionStringEnvironmentVariable);

            if (!string.IsNullOrEmpty(environmentConnectionString))
            {
                var parsed = EventHubsConnectionStringProperties.Parse(environmentConnectionString);

                return new NamespaceProperties
                (
                    parsed.FullyQualifiedNamespace.Substring(0, parsed.FullyQualifiedNamespace.IndexOf('.')),
                    environmentConnectionString.Replace($";EntityPath={ parsed.EventHubName }", string.Empty),
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
