// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Storage.Queues;
using Microsoft.WCF.Azure.Tokens;
using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;

namespace Microsoft.WCF.Azure.StorageQueues.Channels
{
    /// <summary>
    /// IChannelFactory implementation for AzureQueueStorage.
    /// </summary>
    internal class AzureQueueStorageChannelFactory : ChannelFactoryBase<IOutputChannel>
    {
        private const string SecurityTokenTypesNamespace = "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens";
        private const string X509CertificateTokenType = SecurityTokenTypesNamespace + "/X509Certificate";
        private const string RequirementNamespace = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement";
        private const string PreferSslCertificateAuthenticatorProperty = RequirementNamespace + "/PreferSslCertificateAuthenticator";

        private readonly AzureQueueStorageTransportBindingElement _azureQueueStorageTransportBindingElement;
        private SecurityCredentialsManager _channelCredentials;

        public AzureQueueStorageChannelFactory(AzureQueueStorageTransportBindingElement bindingElement, BindingContext context)
            : base(context.Binding)
        {
            _azureQueueStorageTransportBindingElement = bindingElement;
            var messageEncoderBindingElement = context.BindingParameters.Find<MessageEncodingBindingElement>();
            MessageEncoderFactory = messageEncoderBindingElement == null
                ? AzureQueueStorageConstants.DefaultMessageEncoderFactory
                : messageEncoderBindingElement.CreateMessageEncoderFactory();

            BufferManager = BufferManager.CreateBufferManager(bindingElement.MaxBufferPoolSize, int.MaxValue);

            _channelCredentials = context.BindingParameters.Find<SecurityCredentialsManager>();
        }

        private SecurityTokenAuthenticator SecurityTokenAuthenticator { get; }

        internal HttpClient HttpClient { get; }

        public BufferManager BufferManager { get; }

        internal string ConnectionString { get; }

        public MessageEncoderFactory MessageEncoderFactory { get; } = null;

        public SecurityTokenManager SecurityTokenManager { get; private set; }

        public override T GetProperty<T>()
        {
            T messageEncoderProperty = MessageEncoderFactory.Encoder.GetProperty<T>();
            if (messageEncoderProperty != null)
            {
                return messageEncoderProperty;
            }

            if (typeof(T) == typeof(MessageVersion))
            {
                return (T)(object)MessageEncoderFactory.Encoder.MessageVersion;
            }

            return base.GetProperty<T>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void InitializeSecurityTokenManager()
        {
            var channelCredentials = _channelCredentials as AzureClientCredentials;
            if (channelCredentials == null)
            {
                    // If using the Default credential type, no need to configure AzureClientCredentials on the ChannelFactory
                    // and we can use a default instance which just wraps the DefaultAzureCredential with no config needed. If
                    // a different client credential type is configured, then AzureClientCredentials will throw with a message
                    // indicating the need to configure the credential.
                    channelCredentials = new AzureClientCredentials();
            }

            SecurityTokenManager = channelCredentials.CreateSecurityTokenManager();
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            InitializeSecurityTokenManager();
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            InitializeSecurityTokenManager();
            return Task.CompletedTask.ToApm(callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            result.ToApmEnd();
        }

        /// <summary>
        /// Create a new Azure Queue Storage Channel. Supports IOutputChannel.
        /// </summary>
        /// <param name="remoteAddress">The address of the remote endpoint</param>
        /// <param name="via">The via address.</param>
        /// <returns></returns>
        protected override IOutputChannel OnCreateChannel(EndpointAddress remoteAddress, Uri via)
        {
            return new AzureQueueStorageOutputChannel(this, remoteAddress, via, MessageEncoderFactory.Encoder, _azureQueueStorageTransportBindingElement);
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            BufferManager.Clear();
        }

        internal async Task<SecurityTokenProviderContainer> CreateAndOpenTokenProviderAsync(TimeSpan timeout, EndpointAddress target, Uri via, ChannelParameterCollection channelParameters)
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
            var tokenProviderContainer = CreateTokenProvider(timeout, target, via, channelParameters);

            if (tokenProviderContainer != null)
            {
                await tokenProviderContainer.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            }

            return tokenProviderContainer;
        }

        internal SecurityTokenProviderContainer CreateAndOpenTokenProvider(TimeSpan timeout, EndpointAddress target, Uri via, ChannelParameterCollection channelParameters)
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
            var tokenProviderContainer = CreateTokenProvider(timeout, target, via, channelParameters);

            if (tokenProviderContainer != null)
            {
                tokenProviderContainer.Open(timeoutHelper.RemainingTime());
            }

            return tokenProviderContainer;
        }

        private SecurityTokenProviderContainer CreateTokenProvider(TimeSpan timeout, EndpointAddress target, Uri via, ChannelParameterCollection channelParameters)
        {
            SecurityTokenProvider tokenProvider = null;
            switch (_azureQueueStorageTransportBindingElement.ClientCredentialType)
            {
                case AzureClientCredentialType.Default:
                    tokenProvider = SecurityUtils.GetDefaultTokenProvider(SecurityTokenManager, target, via, AzureQueueStorageConstants.Scheme, channelParameters);
                    break;
                case AzureClientCredentialType.Sas:
                    tokenProvider = SecurityUtils.GetSasTokenProvider(SecurityTokenManager, target, via, AzureQueueStorageConstants.Scheme, channelParameters);
                    break;
                case AzureClientCredentialType.StorageSharedKey:
                    tokenProvider = SecurityUtils.GetStorageSharedKeyTokenProvider(SecurityTokenManager, target, via, AzureQueueStorageConstants.Scheme, channelParameters);
                    break;
                case AzureClientCredentialType.Token:
                    tokenProvider = SecurityUtils.GetTokenTokenProvider(SecurityTokenManager, target, via, AzureQueueStorageConstants.Scheme, channelParameters);
                    break;
                case AzureClientCredentialType.ConnectionString:
                    tokenProvider = SecurityUtils.GetConnectionStringTokenProvider(SecurityTokenManager, target, via, AzureQueueStorageConstants.Scheme, channelParameters);
                    break;
                default:
                    // The setter for this property should prevent this.
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                    throw new ArgumentOutOfRangeException(nameof(_azureQueueStorageTransportBindingElement.ClientCredentialType), _azureQueueStorageTransportBindingElement.ClientCredentialType, null);
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }

            return tokenProvider == null ? null : new SecurityTokenProviderContainer(tokenProvider);
        }

        internal Task<QueueClient> GetQueueClientAsync(Uri via, SecurityTokenProviderContainer tokenProvider, TimeSpan timeout)
        {
            return GetQueueClientAsyncCore(via, tokenProvider, timeout);
        }

        internal QueueClient GetQueueClient(Uri via, SecurityTokenProviderContainer tokenProvider, TimeSpan timeout)
        {
#pragma warning disable AZC0106 // Non-public asynchronous method needs 'async' parameter.
            return GetQueueClientAsyncCore(via, tokenProvider, timeout).EnsureCompleted();
#pragma warning restore AZC0106 // Non-public asynchronous method needs 'async' parameter.
        }

        internal Task<QueueClient> GetQueueClientAsyncCore(Uri via, SecurityTokenProviderContainer tokenProvider, TimeSpan timeout)
        {
            QueueClientOptions queueClientOptions = BuildQueueClientOptions();
            switch (_azureQueueStorageTransportBindingElement.ClientCredentialType)
            {
                case AzureClientCredentialType.Default:
                case AzureClientCredentialType.Token:
                    return SecurityUtils.CreateQueueClientWithTokenCredentialAsync(tokenProvider, via, queueClientOptions, timeout);
                case AzureClientCredentialType.Sas:
                    return SecurityUtils.CreateQueueClientWithSasCredentialAsync(tokenProvider, via, queueClientOptions, timeout);
                case AzureClientCredentialType.StorageSharedKey:
                    return SecurityUtils.CreateQueueClientWithStorageSharedKeyCredentialAsync(tokenProvider, via, queueClientOptions, timeout);
                case AzureClientCredentialType.ConnectionString:
                    return SecurityUtils.CreateQueueClientWithConnectionStringAsync(tokenProvider, via, queueClientOptions, timeout);
                default:
                    return Task.FromResult<QueueClient>(null);
            }
        }

        private QueueClientOptions BuildQueueClientOptions()
        {
            QueueClientOptions options = new();
            var azureClientCredentials = _channelCredentials as AzureClientCredentials;
            if (azureClientCredentials != null)
            {
                options.Audience = azureClientCredentials.Audience;
                options.EnableTenantDiscovery = azureClientCredentials.EnableTenantDiscovery;
            }

            options.MessageEncoding = _azureQueueStorageTransportBindingElement.QueueMessageEncoding;

            var certificateValidationCallback = GetServiceCertificateValidationCallback();
            if (certificateValidationCallback != null)
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = certificateValidationCallback;
                HttpClient httpClient = new(httpClientHandler);
                HttpClientTransport httpClientTransport = new HttpClientTransport(httpClient);
                options.Transport = httpClientTransport;
            }

            return options;
        }

        private Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> GetServiceCertificateValidationCallback()
        {
            var securityTokenManager = _channelCredentials.CreateSecurityTokenManager();
            InitiatorServiceModelSecurityTokenRequirement serverCertRequirement = new()
            {
                TokenType = X509CertificateTokenType,
                RequireCryptographicToken = true,
                KeyUsage = SecurityKeyUsage.Exchange,
                TransportScheme = _azureQueueStorageTransportBindingElement.Scheme
            };
            serverCertRequirement.Properties[PreferSslCertificateAuthenticatorProperty] = true;

            var securityTokenAuthenticator = securityTokenManager.CreateSecurityTokenAuthenticator(serverCertRequirement, out SecurityTokenResolver dummy) as X509SecurityTokenAuthenticator;
            if (securityTokenAuthenticator == null)
            {
                return null;
            }

            bool RemoteCertificateValidationCallback(HttpRequestMessage sender, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                try
                {
                    SecurityToken token = new X509SecurityToken(certificate);
                    ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies = securityTokenAuthenticator.ValidateToken(token);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return RemoteCertificateValidationCallback;
        }
    }
}
