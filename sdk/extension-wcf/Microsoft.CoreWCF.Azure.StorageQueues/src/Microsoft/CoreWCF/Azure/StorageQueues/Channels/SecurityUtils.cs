// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using CoreWCF;
using CoreWCF.IdentityModel.Selectors;
using CoreWCF.IdentityModel.Tokens;
using Microsoft.CoreWCF.Azure.Tokens;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Channels
{
    internal class SecurityUtils
    {
        public static SecurityTokenProvider GetDefaultTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via,
            string transportScheme)
        {
            if (tokenManager != null)
            {
                var tokenRequirement = CreateTokenRequirement(target, via, transportScheme, AzureSecurityTokenTypes.DefaultTokenType);
                return tokenManager.CreateSecurityTokenProvider(tokenRequirement);
            }

            return null;
        }

        public static SecurityTokenProvider GetSasTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via,
            string transportScheme)
        {
            if (tokenManager != null)
            {
                var tokenRequirement = CreateTokenRequirement(target, via, transportScheme, AzureSecurityTokenTypes.SasTokenType);
                return tokenManager.CreateSecurityTokenProvider(tokenRequirement);
            }

            return null;
        }

        public static SecurityTokenProvider GetStorageSharedKeyTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via,
            string transportScheme)
        {
            if (tokenManager != null)
            {
                var tokenRequirement = CreateTokenRequirement(target, via, transportScheme, AzureSecurityTokenTypes.StorageSharedKeyTokenType);
                return tokenManager.CreateSecurityTokenProvider(tokenRequirement);
            }

            return null;
        }

        public static SecurityTokenProvider GetTokenTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via,
            string transportScheme)
        {
            if (tokenManager != null)
            {
                var tokenRequirement = CreateTokenRequirement(target, via, transportScheme, AzureSecurityTokenTypes.TokenTokenType);
                return tokenManager.CreateSecurityTokenProvider(tokenRequirement);
            }

            return null;
        }

        public static SecurityTokenProvider GetConnectionStringTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via,
            string transportScheme)
        {
            if (tokenManager != null)
            {
                var tokenRequirement = CreateTokenRequirement(target, via, transportScheme, AzureSecurityTokenTypes.ConnectionStringTokenType);
                return tokenManager.CreateSecurityTokenProvider(tokenRequirement);
            }

            return null;
        }

        private static SecurityTokenRequirement CreateTokenRequirement(EndpointAddress target, Uri via, string transportScheme, string tokenType)
        {
            InitiatorServiceModelSecurityTokenRequirement azureTokenRequirement = new InitiatorServiceModelSecurityTokenRequirement();
            azureTokenRequirement.TokenType = tokenType;
            azureTokenRequirement.RequireCryptographicToken = false;
            azureTokenRequirement.TransportScheme = transportScheme;
            azureTokenRequirement.TargetAddress = target;
            azureTokenRequirement.Via = via;
            return azureTokenRequirement;
        }

        internal static Task OpenTokenProviderIfRequiredAsync(SecurityTokenProvider tokenProvider, CancellationToken token)
        {
            if (tokenProvider is ICommunicationObject communicationObject && communicationObject != null)
            {
                return communicationObject.OpenAsync();
            }

            return Task.CompletedTask;
        }

        internal static Task CloseTokenProviderIfRequiredAsync(SecurityTokenProvider tokenProvider, CancellationToken token)
        {
            if (tokenProvider is ICommunicationObject communicationObject && communicationObject != null)
            {
                return communicationObject.CloseAsync();
            }

            return Task.CompletedTask;
        }

        internal static void AbortTokenProviderIfRequired(SecurityTokenProvider tokenProvider)
        {
            if (tokenProvider is ICommunicationObject communicationObject && communicationObject != null)
            {
                try
                {
                    communicationObject.Abort();
                }
                catch (CommunicationException)
                {
                }
            }
        }

        private static async Task<T> GetTokenAsync<T>(SecurityTokenProvider tokenProvider, CancellationToken token) where T : SecurityToken
        {
            SecurityToken result = await tokenProvider.GetTokenAsync(token).ConfigureAwait(false);
            if ((result != null) && result is not T)
            {
                throw new InvalidOperationException(String.Format(SR.InvalidTokenProvided, tokenProvider.GetType(), typeof(T)));
            }
            return result as T;
        }

        internal static async Task<QueueClient> CreateQueueClientWithTokenCredentialAsync(SecurityTokenProviderContainer tokenProvider, Uri via, QueueClientOptions queueClientOptions, CancellationToken token)
        {
            var provider = tokenProvider.TokenProvider;
            var endpointUri = new UriBuilder(via) { Scheme = "https" }.Uri;
            TokenCredentialSecurityToken result = await GetTokenAsync<TokenCredentialSecurityToken>(provider, token).ConfigureAwait(false);
            var queueClient = new QueueClient(endpointUri, result.TokenCredential, queueClientOptions);
            return queueClient;
        }

        internal static async Task<QueueClient> CreateQueueClientWithSasCredentialAsync(SecurityTokenProviderContainer tokenProvider, Uri via, QueueClientOptions queueClientOptions, CancellationToken token)
        {
            var provider = tokenProvider.TokenProvider;
            var endpointUri = new UriBuilder(via) { Scheme = "https" }.Uri;
            SasSecurityToken result = await GetTokenAsync<SasSecurityToken>(provider, token).ConfigureAwait(false);
            var queueClient = new QueueClient(endpointUri, result.SasCredential, queueClientOptions);
            return queueClient;
        }

        internal static async Task<QueueClient> CreateQueueClientWithStorageSharedKeyCredentialAsync(SecurityTokenProviderContainer tokenProvider, Uri via, QueueClientOptions queueClientOptions, CancellationToken token)
        {
            var provider = tokenProvider.TokenProvider;
            var endpointUri = new UriBuilder(via) { Scheme = "https" }.Uri;
            StorageSharedKeySecurityToken result = await GetTokenAsync<StorageSharedKeySecurityToken>(provider, token).ConfigureAwait(false);
            var queueClient = new QueueClient(endpointUri, result.StorageSharedKeyCredential, queueClientOptions);
            return queueClient;
        }

        internal static async Task<QueueClient> CreateQueueClientWithConnectionStringAsync(SecurityTokenProviderContainer tokenProvider, Uri via, QueueClientOptions queueClientOptions, CancellationToken token)
        {
            var provider = tokenProvider.TokenProvider;
            ConnectionStringSecurityToken result = await GetTokenAsync<ConnectionStringSecurityToken>(provider, token).ConfigureAwait(false);
            var connectionStringUri = AzureQueueStorageChannelHelpers.ExtractQueueUriFromConnectionString(result.ConnectionString);
            AzureQueueStorageChannelHelpers.ExtractAccountAndQueueNameFromUri(connectionStringUri, queueNameRequired: false, out string connectionStringAccountName, out string connectionStringQueueName);
            AzureQueueStorageChannelHelpers.ExtractAccountAndQueueNameFromUri(via, queueNameRequired: true, out string viaAccountName, out string viaQueueName);
            string queueName;
            if (!string.IsNullOrEmpty(connectionStringQueueName) && !string.IsNullOrEmpty(viaQueueName) &&
                !connectionStringQueueName.Equals(viaQueueName, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format(SR.ConnectionStringAndViaQueueNameMismatch, connectionStringQueueName, viaQueueName));
            }
            queueName = string.IsNullOrEmpty(connectionStringQueueName) ? viaQueueName : connectionStringQueueName;
            if (string.IsNullOrEmpty(queueName))
            {
                throw new ArgumentException(SR.MissingQueueName);
            }
            if (!string.IsNullOrEmpty(connectionStringAccountName) && !string.IsNullOrEmpty(viaAccountName) &&
                !connectionStringAccountName.Equals(viaAccountName, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format(SR.ConnectionStringAndViaAccountNameMismatch, connectionStringAccountName, viaAccountName));
            }

            var queueClient = new QueueClient(result.ConnectionString, queueName, queueClientOptions);
            return queueClient;
        }

        internal static async Task<QueueClient> CreateDeadLetterQueueClientWithConnectionStringAsync(SecurityTokenProviderContainer tokenProvider, Uri via, QueueClientOptions queueClientOptions, CancellationToken token)
        {
            // Any necessary validation has already been done when creating the main QueueClient instance.
            var provider = tokenProvider.TokenProvider;
            ConnectionStringSecurityToken result = await GetTokenAsync<ConnectionStringSecurityToken>(provider, token).ConfigureAwait(false);
            var deadLetterQueueConnectionString = AzureQueueStorageChannelHelpers.ReplaceQueueUriInConnectionString(result.ConnectionString, via);
            AzureQueueStorageChannelHelpers.ExtractAccountAndQueueNameFromUri(via, queueNameRequired: false, out string connectionStringAccountName, out string connectionStringQueueName);
            string queueName = connectionStringQueueName;
            var queueClient = new QueueClient(deadLetterQueueConnectionString, connectionStringQueueName, queueClientOptions);
            return queueClient;
        }
    }
}
