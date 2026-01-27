// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Core;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Clients.Shared
{
    /// <summary>
    /// Abstraction to provide storage clients from the connection names.
    /// This gets the storage account name via the binding attribute's <see cref="IConnectionProvider.Connection"/>
    /// property.
    /// If the connection is not specified on the attribute, it uses a default account.
    /// </summary>
    internal abstract partial class StorageClientProvider<TClient, TClientOptions> where TClientOptions : ClientOptions
    {
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _componentFactory;
        private readonly AzureEventSourceLogForwarder _logForwarder;
        private readonly ILogger _logger;

        public const string DefaultStorageEndpointSuffix = "core.windows.net";
        private const string RedactedLog = "<REDACTED>";

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageClientProvider{TClient, TClientOptions}"/> class that uses the registered Azure services.
        /// </summary>
        /// <param name="configuration">The configuration to use when creating Client-specific objects. <see cref="IConfiguration"/></param>
        /// <param name="componentFactory">The Azure factory responsible for creating clients. <see cref="AzureComponentFactory"/></param>
        /// <param name="logForwarder">Log forwarder that forwards events to ILogger. <see cref="AzureEventSourceLogForwarder"/></param>
        /// <param name="logger">Logger used when there is an error creating a client</param>
        public StorageClientProvider(IConfiguration configuration, AzureComponentFactory componentFactory, AzureEventSourceLogForwarder logForwarder, ILogger<TClient> logger)
        {
            _configuration = configuration;
            _componentFactory = componentFactory;
            _logForwarder = logForwarder;
            _logger = logger;

            _logForwarder?.Start();
        }

        /// <summary>
        /// Gets the subdomain for the resource (i.e. blob, queue, file, table)
        /// </summary>
#pragma warning disable CA1056 // URI-like properties should not be strings
        protected abstract string ServiceUriSubDomain { get; }
#pragma warning restore CA1056 // URI-like properties should not be strings

        /// <summary>
        /// Gets the storage client specified by <paramref name="name"/>
        /// </summary>
        /// <param name="name">Name of the connection to use</param>
        /// <param name="resolver">A resolver to interpret the provided connection <paramref name="name"/>.</param>
        /// <returns>Client that was created.</returns>
        public virtual TClient Get(string name, INameResolver resolver)
        {
            var resolvedName = resolver.ResolveWholeString(name);
            return this.Get(resolvedName);
        }

        /// <summary>
        /// Gets the storage client specified by <paramref name="name"/>
        /// </summary>
        /// <param name="name">Name of the connection to use</param>
        /// <returns>Client that was created.</returns>
        public virtual TClient Get(string name)
        {
            IConfigurationSection connectionSection = GetWebJobsConnectionStringSection(name);
            var credential = _componentFactory.CreateTokenCredential(connectionSection);
            var options = CreateClientOptions(connectionSection);
            return CreateClient(connectionSection, credential, options);
        }

        public IConfigurationSection GetWebJobsConnectionStringSection(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = ConnectionStringNames.Storage; // default
            }

            // $$$ Where does validation happen?
            IConfigurationSection connectionSection = _configuration.GetWebJobsConnectionStringSection(name);
            if (!connectionSection.Exists())
            {
                // Not found
                throw new InvalidOperationException($"Storage account connection string '{IConfigurationExtensions.GetPrefixedConnectionStringName(name)}' does not exist. Make sure that it is a defined App Setting.");
            }

            // Detect and log authentication type
            var authInfo = DetectAuthenticationTypeFromConfiguration(connectionSection, name);
            Logger.AuthenticationTypeDetected(_logger, authInfo);

            return connectionSection;
        }

        /// <summary>
        /// Creates a storage client
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> to use when creating Client-specific objects.</param>
        /// <param name="tokenCredential">The <see cref="TokenCredential"/> to authenticate for requests.</param>
        /// <param name="options">Generic options to use for the client</param>
        /// <returns>Storage client</returns>
        protected virtual TClient CreateClient(IConfiguration configuration, TokenCredential tokenCredential, TClientOptions options)
        {
            // If connection string is present, it will be honored first
            if (!IsConnectionStringPresent(configuration) && TryGetServiceUri(configuration, out Uri serviceUri))
            {
                var constructor = typeof(TClient).GetConstructor(new Type[] { typeof(Uri), typeof(TokenCredential), typeof(TClientOptions) });
                return (TClient)constructor.Invoke(new object[] { serviceUri, tokenCredential, options });
            }

            return (TClient)_componentFactory.CreateClient(typeof(TClient), configuration, tokenCredential, options);
        }

        /// <summary>
        /// The host account is for internal storage mechanisms like load balancer queuing.
        /// </summary>
        /// <returns>Storage client</returns>
        public virtual TClient GetHost()
        {
            return this.Get(null);
        }

        /// <summary>
        /// Creates client options from the given configuration
        /// </summary>
        /// <param name="configuration">Registered <see cref="IConfiguration"/></param>
        /// <returns>Client options</returns>
        protected virtual TClientOptions CreateClientOptions(IConfiguration configuration)
        {
            var clientOptions = (TClientOptions)_componentFactory.CreateClientOptions(typeof(TClientOptions), null, configuration);
            return clientOptions;
        }

        /// <summary>
        /// Either constructs the serviceUri from the provided accountName
        /// or retrieves the serviceUri for the specific resource (i.e. blobServiceUri or queueServiceUri)
        /// </summary>
        /// <param name="configuration">Registered <see cref="IConfiguration"/></param>
        /// <param name="serviceUri">instantiates the serviceUri</param>
        /// <returns>retrieval success</returns>
        protected virtual bool TryGetServiceUri(IConfiguration configuration, out Uri serviceUri)
        {
            try
            {
                var serviceUriConfig = string.Format(CultureInfo.InvariantCulture, "{0}ServiceUri", ServiceUriSubDomain);

                string accountName;
                string uriStr;
                if ((accountName = configuration.GetValue<string>("accountName")) != null)
                {
                    serviceUri = FormatServiceUri(accountName);
                    return true;
                }
                else if ((uriStr = configuration.GetValue<string>(serviceUriConfig)) != null)
                {
                    serviceUri = new Uri(uriStr);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not parse serviceUri from the configuration.");
            }

            serviceUri = default(Uri);
            return false;
        }

        /// <summary>
        /// Generates the serviceUri for a particular storage resource
        /// </summary>
        /// <param name="accountName">accountName for the storage account</param>
        /// <param name="defaultProtocol">protocol to use for REST requests</param>
        /// <param name="endpointSuffix">endpoint suffix for the storage account</param>
        /// <returns>Uri for the storage resource</returns>
        protected virtual Uri FormatServiceUri(string accountName, string defaultProtocol = "https", string endpointSuffix = DefaultStorageEndpointSuffix)
        {
            // Todo: Eventually move this into storage sdk
            var uri = string.Format(CultureInfo.InvariantCulture, "{0}://{1}.{2}.{3}", defaultProtocol, accountName, ServiceUriSubDomain, endpointSuffix);
            return new Uri(uri);
        }

        /// <summary>
        /// Checks if the specified <see cref="IConfiguration"/> object represents a connection string.
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> to check</param>
        /// <returns>true if this <see cref="IConfiguration"/> object is a connection string; false otherwise.</returns>
        protected static bool IsConnectionStringPresent(IConfiguration configuration)
        {
            return configuration is IConfigurationSection section && section.Value != null;
        }

        /// <summary>
        /// Detects authentication type from configuration BEFORE client creation.
        /// This is the earliest point where authentication type can be determined.
        /// </summary>
        /// <param name="config">Configuration section for the connection</param>
        /// <param name="connectionName">Name of the connection</param>
        /// <returns>Information about the detected authentication type</returns>
        protected virtual StorageAuthenticationInfo DetectAuthenticationTypeFromConfiguration(
            IConfigurationSection config,
            string connectionName)
        {
            var authInfo = new StorageAuthenticationInfo
            {
                ConnectionName = connectionName,
                IsDefault = string.IsNullOrWhiteSpace(connectionName) ||
                           connectionName == ConnectionStringNames.Storage
            };

            // DETECTION 1: Connection String (highest priority)
            if (IsConnectionStringPresent(config))
            {
                string connectionString = config.Value;
                authInfo.AuthenticationType = StorageAuthenticationType.ConnectionString;
                authInfo.AccountName = ExtractAccountNameFromConnectionString(connectionString);
                authInfo.Details = "Using connection string";

                Logger.ConfigurationStructureAnalyzed(_logger, connectionName, "ConnectionString");
                Logger.ConnectionStringDetected(_logger, connectionName, authInfo.AccountName ?? "Unknown");

                return authInfo;
            }

            // DETECTION 2: Structured Configuration (token-based auth)
            string accountName = config.GetValue<string>("accountName");
            string blobServiceUri = config.GetValue<string>("blobServiceUri");
            string queueServiceUri = config.GetValue<string>("queueServiceUri");
            string serviceUri = config.GetValue<string>("serviceUri");
            string clientId = config.GetValue<string>("clientId");
            string clientSecret = config.GetValue<string>("clientSecret");
            string tenantId = config.GetValue<string>("tenantId");
            string certificatePath = config.GetValue<string>("clientCertificatePath");
            string credential = config.GetValue<string>("credential");

            // Extract account name from URI if available
            if (string.IsNullOrEmpty(accountName))
            {
                accountName = ExtractAccountNameFromUri(blobServiceUri ?? queueServiceUri ?? serviceUri);
            }

            authInfo.AccountName = accountName;
            authInfo.ServiceUri = blobServiceUri ?? queueServiceUri ?? serviceUri;
            authInfo.ClientId = clientId;

            // DETECTION 3: Determine credential type
            if (!string.IsNullOrEmpty(clientSecret))
            {
                authInfo.AuthenticationType = StorageAuthenticationType.ServicePrincipalSecret;
                authInfo.Details = $"ClientId: {MaskSensitiveValue(clientId)}, TenantId: {MaskSensitiveValue(tenantId)}";
                Logger.ServicePrincipalDetected(_logger, connectionName, "ClientSecret");
            }
            else if (!string.IsNullOrEmpty(certificatePath))
            {
                authInfo.AuthenticationType = StorageAuthenticationType.ServicePrincipalCertificate;
                authInfo.Details = $"ClientId: {MaskSensitiveValue(clientId)}";
                Logger.ServicePrincipalDetected(_logger, connectionName, "Certificate");
            }
            else if (!string.IsNullOrEmpty(clientId))
            {
                authInfo.AuthenticationType = StorageAuthenticationType.ManagedIdentityUser;
                authInfo.Details = $"User-Assigned, ClientId: {MaskSensitiveValue(clientId)}";
                Logger.ManagedIdentityDetected(_logger, connectionName, "User-Assigned", clientId);
            }
            else if (!string.IsNullOrEmpty(accountName) || !string.IsNullOrEmpty(serviceUri))
            {
                // Has URI/accountName but no explicit credentials = System MI or DefaultAzureCredential
                if (string.Equals(credential, "managedidentity", StringComparison.OrdinalIgnoreCase))
                {
                    authInfo.AuthenticationType = StorageAuthenticationType.ManagedIdentitySystem;
                    authInfo.Details = "System-Assigned Managed Identity";
                    Logger.ManagedIdentityDetected(_logger, connectionName, "System-Assigned", null);
                }
                else
                {
                    authInfo.AuthenticationType = StorageAuthenticationType.DefaultAzureCredential;
                    authInfo.Details = "DefaultAzureCredential or credential chain";
                    Logger.DefaultAzureCredentialDetected(_logger, connectionName);
                }
            }
            else
            {
                authInfo.AuthenticationType = StorageAuthenticationType.Unknown;
                authInfo.Details = "Unable to determine authentication type from configuration";
            }

            string structure = $"AccountName={!string.IsNullOrEmpty(accountName)}, " +
                              $"ServiceUri={!string.IsNullOrEmpty(serviceUri)}, " +
                              $"ClientId={!string.IsNullOrEmpty(clientId)}, ";

            Logger.ConfigurationStructureAnalyzed(_logger, connectionName, structure);

            return authInfo;
        }

        private static string ExtractAccountNameFromConnectionString(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                return null;
            }

            var parts = connectionString.Split(';');
            foreach (var part in parts)
            {
                var keyValue = part.Split(new[] { '=' }, count: 2);
                if (keyValue.Length == 2 &&
                    keyValue[0].Trim().Equals("AccountName", StringComparison.OrdinalIgnoreCase))
                {
                    return keyValue[1].Trim();
                }
            }

            return null;
        }

        /// <summary>
        /// Extracts account name from a storage service URI.
        /// </summary>
        private static string ExtractAccountNameFromUri(string uriString)
        {
            if (string.IsNullOrEmpty(uriString))
            {
                return null;
            }

            try
            {
                var uri = new Uri(uriString);
                string host = uri.Host;

                if (string.IsNullOrWhiteSpace(host))
                {
                    return null;
                }

                // Format: accountname.blob.core.windows.net
                int dotIndex = host.IndexOf('.');
                if (dotIndex >= 0)
                {
                    return host.Substring(0, dotIndex);
                }
                return host;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Masks sensitive values for logging.
        /// </summary>
        private static string MaskSensitiveValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return RedactedLog;
            }

            if (value.Length <= 8)
            {
                return RedactedLog;
            }

            return $"{value.Substring(0, 4)}...{value.Substring(value.Length - 4)}";
        }
    }

    /// <summary>
    /// Information about detected storage authentication configuration. Currently only used for StorageClientProvider.
    /// </summary>
#pragma warning disable SA1402 // File may only contain a single type
    internal class StorageAuthenticationInfo
#pragma warning restore SA1402 // File may only contain a single type
    {
        public string ConnectionName { get; set; }
        public bool IsDefault { get; set; }
        public StorageAuthenticationType AuthenticationType { get; set; }
        public string AccountName { get; set; }
        public string ServiceUri { get; set; }
        public string ClientId { get; set; }
        public string Details { get; set; }
    }

    /// <summary>
    /// Types of authentication that can be detected from configuration. Currently only used for StorageClientProvider.
    /// </summary>
#pragma warning disable SA1402 // File may only contain a single type
    internal enum StorageAuthenticationType
#pragma warning restore SA1402 // File may only contain a single type
    {
        Unknown,
        ConnectionString,
        ManagedIdentitySystem,
        ManagedIdentityUser,
        ServicePrincipalSecret,
        ServicePrincipalCertificate,
        DefaultAzureCredential
    }
}
