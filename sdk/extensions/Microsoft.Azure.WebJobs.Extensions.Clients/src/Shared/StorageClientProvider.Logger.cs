// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Clients.Shared
{
    internal abstract partial class StorageClientProvider<TClient, TClientOptions>
    {
        private static class Logger
        {
            // Event IDs in 300-399 range for shared storage client provider logging

            private static readonly Action<ILogger, string, string, string, string, string, Exception> _authenticationTypeDetected =
                LoggerMessage.Define<string, string, string, string, string>(
                    LogLevel.Debug,
                    new EventId(300, nameof(AuthenticationTypeDetected)),
                    "Storage authentication detected for connection '{connectionName}' ({connectionType}). Type: {authenticationType}, Account: {accountName}, Details: {details}");

            private static readonly Action<ILogger, string, string, Exception> _connectionStringDetected =
                LoggerMessage.Define<string, string>(
                    LogLevel.Debug,
                    new EventId(301, nameof(ConnectionStringDetected)),
                    "Connection string authentication detected for '{connectionName}'. Account: {accountName}");

            private static readonly Action<ILogger, string, string, string, Exception> _managedIdentityDetected =
                LoggerMessage.Define<string, string, string>(
                    LogLevel.Debug,
                    new EventId(302, nameof(ManagedIdentityDetected)),
                    "Managed Identity authentication detected for '{connectionName}'. Type: {identityType}, ClientId: {clientId}");

            private static readonly Action<ILogger, string, string, Exception> _servicePrincipalDetected =
                LoggerMessage.Define<string, string>(
                    LogLevel.Debug,
                    new EventId(303, nameof(ServicePrincipalDetected)),
                    "Service Principal authentication detected for '{connectionName}'. Credential type: {credentialType}");

            private static readonly Action<ILogger, string, Exception> _defaultAzureCredentialDetected =
                LoggerMessage.Define<string>(
                    LogLevel.Debug,
                    new EventId(306, nameof(DefaultAzureCredentialDetected)),
                    "DefaultAzureCredential or credential chain detected for '{connectionName}'");

            private static readonly Action<ILogger, string, string, Exception> _configurationStructureAnalyzed =
                LoggerMessage.Define<string, string>(
                    LogLevel.Debug,
                    new EventId(307, nameof(ConfigurationStructureAnalyzed)),
                    "Configuration structure for '{connectionName}': {structure}");

            public static void AuthenticationTypeDetected(ILogger logger, StorageAuthenticationInfo authInfo)
            {
                if (authInfo == null) return;

                _authenticationTypeDetected(
                    logger,
                    authInfo.ConnectionName,
                    authInfo.IsDefault ? "default" : "custom",
                    authInfo.AuthenticationType.ToString(),
                    authInfo.AccountName ?? "Unknown",
                    authInfo.Details ?? "None",
                    null);
            }

            public static void ConnectionStringDetected(ILogger logger, string connectionName, string accountName)
            {
                _connectionStringDetected(logger, connectionName, accountName, null);
            }

            public static void ManagedIdentityDetected(ILogger logger, string connectionName, string identityType, string clientId)
            {
                _managedIdentityDetected(logger, connectionName, identityType, clientId ?? "System-Assigned", null);
            }

            public static void ServicePrincipalDetected(ILogger logger, string connectionName, string credentialType)
            {
                _servicePrincipalDetected(logger, connectionName, credentialType, null);
            }
            public static void DefaultAzureCredentialDetected(ILogger logger, string connectionName)
            {
                _defaultAzureCredentialDetected(logger, connectionName, null);
            }

            public static void ConfigurationStructureAnalyzed(ILogger logger, string connectionName, string structure)
            {
                _configurationStructureAnalyzed(logger, connectionName, structure, null);
            }
        }
    }
}