// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Microsoft.WCF.Azure.Tokens;
using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;

namespace Microsoft.WCF.Azure.StorageQueues.Channels
{
    internal class SecurityUtils
    {
        public static SecurityTokenProvider GetDefaultTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via,
            string transportScheme, ChannelParameterCollection channelParameters)
        {
            if (tokenManager != null)
            {
                var tokenRequirement = CreateTokenRequirement(target, via, transportScheme, channelParameters, AzureSecurityTokenTypes.DefaultTokenType);
                return tokenManager.CreateSecurityTokenProvider(tokenRequirement);
            }

            return null;
        }

        public static SecurityTokenProvider GetSasTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via,
            string transportScheme, ChannelParameterCollection channelParameters)
        {
            if (tokenManager != null)
            {
                var tokenRequirement = CreateTokenRequirement(target, via, transportScheme, channelParameters, AzureSecurityTokenTypes.SasTokenType);
                return tokenManager.CreateSecurityTokenProvider(tokenRequirement);
            }

            return null;
        }

        public static SecurityTokenProvider GetStorageSharedKeyTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via,
            string transportScheme, ChannelParameterCollection channelParameters)
        {
            if (tokenManager != null)
            {
                var tokenRequirement = CreateTokenRequirement(target, via, transportScheme, channelParameters, AzureSecurityTokenTypes.StorageSharedKeyTokenType);
                return tokenManager.CreateSecurityTokenProvider(tokenRequirement);
            }

            return null;
        }

        public static SecurityTokenProvider GetTokenTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via,
            string transportScheme, ChannelParameterCollection channelParameters)
        {
            if (tokenManager != null)
            {
                var tokenRequirement = CreateTokenRequirement(target, via, transportScheme, channelParameters, AzureSecurityTokenTypes.TokenTokenType);
                return tokenManager.CreateSecurityTokenProvider(tokenRequirement);
            }

            return null;
        }

        public static SecurityTokenProvider GetConnectionStringTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via,
            string transportScheme, ChannelParameterCollection channelParameters)
        {
            if (tokenManager != null)
            {
                var tokenRequirement = CreateTokenRequirement(target, via, transportScheme, channelParameters, AzureSecurityTokenTypes.ConnectionStringTokenType);
                return tokenManager.CreateSecurityTokenProvider(tokenRequirement);
            }

            return null;
        }

        private static SecurityTokenRequirement CreateTokenRequirement(EndpointAddress target, Uri via, string transportScheme, ChannelParameterCollection channelParameters, string tokenType)
        {
            InitiatorServiceModelSecurityTokenRequirement azureTokenRequirement = new InitiatorServiceModelSecurityTokenRequirement();
            azureTokenRequirement.TokenType = tokenType;
            azureTokenRequirement.RequireCryptographicToken = false;
            azureTokenRequirement.TransportScheme = transportScheme;
            azureTokenRequirement.TargetAddress = target;
            azureTokenRequirement.Via = via;
            if (channelParameters != null)
            {
                azureTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.ChannelParametersCollectionProperty] = channelParameters;
            }

            return azureTokenRequirement;
        }

        internal static void OpenTokenProviderIfRequired(SecurityTokenProvider tokenProvider, TimeSpan timeout)
        {
            if (tokenProvider is ICommunicationObject communicationObject && communicationObject != null)
            {
                communicationObject.Open(timeout);
            }
        }

        internal static void CloseTokenProviderIfRequired(SecurityTokenProvider tokenProvider, TimeSpan timeout)
        {
            CloseCommunicationObject(tokenProvider, false, timeout);
        }

        internal static Task OpenTokenProviderIfRequiredAsync(SecurityTokenProvider tokenProvider, TimeSpan timeout)
        {
            if (tokenProvider is ICommunicationObject communicationObject && communicationObject != null)
            {
                return Task.Factory.FromAsync(communicationObject.BeginOpen, communicationObject.EndOpen, timeout, null, TaskCreationOptions.None);
            }

            return Task.CompletedTask;
        }

        internal static Task CloseTokenProviderIfRequiredAsync(SecurityTokenProvider tokenProvider, TimeSpan timeout)
        {
            if (tokenProvider is ICommunicationObject communicationObject && communicationObject != null)
            {
                return Task.Factory.FromAsync(communicationObject.BeginClose, communicationObject.EndClose, timeout, null, TaskCreationOptions.None);
            }

            return Task.CompletedTask;
        }

        internal static void AbortTokenProviderIfRequired(SecurityTokenProvider tokenProvider)
        {
            CloseCommunicationObject(tokenProvider, true, TimeSpan.Zero);
        }

        private static void CloseCommunicationObject(Object obj, bool aborted, TimeSpan timeout)
        {
            if (obj != null)
            {
                ICommunicationObject co = obj as ICommunicationObject;
                if (co != null)
                {
                    if (aborted)
                    {
                        try
                        {
                            co.Abort();
                        }
                        catch (CommunicationException)
                        {
                        }
                    }
                    else
                    {
                        co.Close(timeout);
                    }
                }
                else if (obj is IDisposable)
                {
                    ((IDisposable)obj).Dispose();
                }
            }
        }

        private static async Task<T> GetTokenAsync<T>(SecurityTokenProvider tokenProvider, TimeSpan timeout) where T : SecurityToken
        {
            SecurityToken result = await tokenProvider.GetTokenAsync(timeout).ConfigureAwait(false);
            if ((result != null) && !(result is T))
            {
                throw new InvalidOperationException(String.Format(SR.InvalidTokenProvided, tokenProvider.GetType(), typeof(T)));
            }
            return result as T;
        }

        internal static async Task<QueueClient> CreateQueueClientWithTokenCredentialAsync(SecurityTokenProviderContainer tokenProvider, Uri via, QueueClientOptions queueClientOptions, TimeSpan timeout)
        {
            var provider = tokenProvider.TokenProvider;
            var endpointUri = new UriBuilder(via) { Scheme = "https" }.Uri;
            TokenCredentialSecurityToken result = await GetTokenAsync<TokenCredentialSecurityToken>(provider, timeout).ConfigureAwait(false);
            var queueClient = new QueueClient(endpointUri, result.TokenCredential, queueClientOptions);
            return queueClient;
        }

        internal static async Task<QueueClient> CreateQueueClientWithSasCredentialAsync(SecurityTokenProviderContainer tokenProvider, Uri via, QueueClientOptions queueClientOptions, TimeSpan timeout)
        {
            var provider = tokenProvider.TokenProvider;
            var endpointUri = new UriBuilder(via) { Scheme = "https" }.Uri;
            SasSecurityToken result = await GetTokenAsync<SasSecurityToken>(provider, timeout).ConfigureAwait(false);
            var queueClient = new QueueClient(endpointUri, result.SasCredential, queueClientOptions);
            return queueClient;
        }

        internal static async Task<QueueClient> CreateQueueClientWithStorageSharedKeyCredentialAsync(SecurityTokenProviderContainer tokenProvider, Uri via, QueueClientOptions queueClientOptions, TimeSpan timeout)
        {
            var provider = tokenProvider.TokenProvider;
            var endpointUri = new UriBuilder(via) { Scheme = "https" }.Uri;
            StorageSharedKeySecurityToken result = await GetTokenAsync<StorageSharedKeySecurityToken>(provider, timeout).ConfigureAwait(false);
            var queueClient = new QueueClient(endpointUri, result.StorageSharedKeyCredential, queueClientOptions);
            return queueClient;
        }

        internal static async Task<QueueClient> CreateQueueClientWithConnectionStringAsync(SecurityTokenProviderContainer tokenProvider, Uri via, QueueClientOptions queueClientOptions, TimeSpan timeout)
        {
            var provider = tokenProvider.TokenProvider;
            ConnectionStringSecurityToken result = await GetTokenAsync<ConnectionStringSecurityToken>(provider, timeout).ConfigureAwait(false);
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
    }
}
