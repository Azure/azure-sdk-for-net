// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Authorization;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   Represents the ambient environment in which the test suite is
    ///   being run, offering access to information such as environment
    ///   variables.
    /// </summary>
    ///
    public class ServiceBusTestEnvironment : TestEnvironment
    {
        /// <summary>The name of the shared access key to be used for accessing an Service Bus namespace.</summary>
        public const string ServiceBusDefaultSharedAccessKey = "RootManageSharedAccessKey";

        /// <summary>A shared instance of <see cref="ServiceBusTestEnvironment"/>. </summary>
        public static ServiceBusTestEnvironment Instance { get; } = new ServiceBusTestEnvironment();

        /// <summary>The active Service Bus namespace for this test run.</summary>
        private ServiceBusConnectionStringProperties ParsedConnectionString => ServiceBusConnectionStringProperties.Parse(ServiceBusConnectionString);

        /// <summary>
        ///   The connection string for the Service Bus namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The connection string will be determined by creating an ephemeral Service Bus namespace for the test execution.</value>
        ///
        public string ServiceBusConnectionString => GetRecordedVariable(
            "SERVICEBUS_CONNECTION_STRING",
            options => options.HasSecretConnectionStringParameter("SharedAccessKey", SanitizedValue.Base64));

        /// <summary>
        ///   The connection string for the premium Service Bus namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The connection string will be determined by creating an ephemeral Service Bus namespace for the test execution.</value>
        ///
        public string ServiceBusPremiumNamespaceConnectionString => GetRecordedVariable(
            "SERVICEBUS_PREMIUM_NAMESPACE_CONNECTION_STRING",
            options => options.HasSecretConnectionStringParameter("SharedAccessKey", SanitizedValue.Base64));

        /// <summary>
        ///   The connection string for the secondary Service Bus namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The connection string will be determined by creating an ephemeral Service Bus namespace for the test execution.</value>
        ///
        public string ServiceBusSecondaryNamespaceConnectionString => GetRecordedVariable(
            "SERVICEBUS_SECONDARY_NAMESPACE_CONNECTION_STRING",
            options => options.HasSecretConnectionStringParameter("SharedAccessKey", SanitizedValue.Base64));

        /// <summary>
        ///   The name of the Service Bus namespace to be used for Live tests.
        /// </summary>
        ///
        /// <value>The name will be determined by creating an ephemeral Service Bus namespace for the test execution.</value>
        ///
        public string ServiceBusNamespace => ParseServiceBusNamespace(FullyQualifiedNamespace).Name;

        /// <summary>
        ///   The name of the Service Bus namespace to be used for Live tests.
        /// </summary>
        ///
        /// <value>The name will be determined by creating an ephemeral Service Bus namespace for the test execution.</value>
        ///
        public string ServiceBusSecondaryNamespace => ParseServiceBusNamespace(SecondaryFullyQualifiedNamespace).Name;

        /// <summary>
        ///   The fully qualified namespace for the Service Bus namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The fully qualified namespace, as contained within the associated connection string.</value>
        ///
        public string FullyQualifiedNamespace => GetRecordedVariable("SERVICEBUS_FULLY_QUALIFIED_NAMESPACE");

        /// <summary>
        ///   The secondary fully qualified namespace for the Service Bus namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The secondary fully qualified namespace, as contained within the associated connection string.</value>
        ///
        public string SecondaryFullyQualifiedNamespace => GetRecordedVariable("SERVICEBUS_SECONDARY_FULLY_QUALIFIED_NAMESPACE");

        /// <summary>
        ///   The premium fully qualified namespace for the Service Bus namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The premium fully qualified namespace, as contained within the associated connection string.</value>
        ///
        public string PremiumFullyQualifiedNamespace => GetRecordedVariable("SERVICEBUS_PREMIUM_FULLY_QUALIFIED_NAMESPACE");

        /// <summary>
        ///   The shared access key name for the Service Bus namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The shared access key name, as contained within the associated connection string.</value>
        ///
        public string SharedAccessKeyName => ParsedConnectionString.SharedAccessKeyName;

        /// <summary>
        ///   The shared access key for the Service Bus namespace represented by this scope.
        /// </summary>
        ///
        /// <value>The shared access key, as contained within the associated connection string.</value>
        ///
        public string SharedAccessKey => ParsedConnectionString.SharedAccessKey;

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
        public new string ResourceManagerUrl => base.ResourceManagerUrl ?? "https://management.azure.com/";

        public string StorageClaimCheckAccountName => GetRecordedVariable("STORAGE_CLAIM_CHECK_ACCOUNT_NAME");

        /// <summary>
        ///   Builds a connection string for a specific Service Bus entity instance under the namespace used for
        ///   Live tests.
        /// </summary>
        ///
        /// <param name="entityName">The name of the entity for which the connection string is being built.</param>
        ///
        /// <returns>The connection string to the requested Service Bus namespace and entity.</returns>
        ///
        public string BuildConnectionStringForEntity(string entityName) => $"{ServiceBusConnectionString};EntityPath={entityName}";

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
            var signature = new SharedAccessSignature(signatureAudience, SharedAccessKeyName, SharedAccessKey,
                TimeSpan.FromMinutes(validDurationMinutes));
            return $"Endpoint={ParsedConnectionString.Endpoint};EntityPath={entityName};SharedAccessSignature={signature.Value}";
        }

        /// <returns>The active Service Bus namespace for this test run.</returns>
        ///
        private NamespaceProperties ParseServiceBusNamespace(string fullyQualifiedNamespace)
        {
            int ending = ".servicebus.windows.net".Length;
            string nameSpace = fullyQualifiedNamespace.Substring(0, fullyQualifiedNamespace.Length - ending);

            return new NamespaceProperties(nameSpace, fullyQualifiedNamespace, false);
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

            /// <summary>The fully qualified namespace.</summary>
            public readonly string FullyQualifiedNamespace;

            /// <summary>A flag indicating if the namespace was dynamically created by the test environment.</summary>
            public readonly bool ShouldRemoveAtCompletion;

            /// <summary>
            ///   Initializes a new instance of the <see cref="NamespaceProperties"/> struct.
            /// </summary>
            ///
            /// <param name="name">The name of the namespace.</param>
            /// <param name="fullyQualifiedNamespace">The fully qualified namespace.</param>
            /// <param name="shouldRemoveAtCompletion">A flag indicating if the namespace should be removed when the test run has completed.</param>
            ///
            public NamespaceProperties(string name,
                                       string fullyQualifiedNamespace,
                                       bool shouldRemoveAtCompletion)
            {
                Name = name;
                FullyQualifiedNamespace = fullyQualifiedNamespace;
                ShouldRemoveAtCompletion = shouldRemoveAtCompletion;
            }
        }
    }
}
