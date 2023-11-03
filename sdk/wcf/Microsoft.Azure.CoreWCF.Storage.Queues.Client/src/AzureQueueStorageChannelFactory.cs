// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;

namespace Azure.Storage.WCF.Channels
{
    /// <summary>
    /// IChannelFactory implementation for AzureQueueStorage.
    /// </summary>
    internal class AzureQueueStorageChannelFactory : ChannelFactoryBase<IOutputChannel>
    {
        private readonly AzureQueueStorageTransportBindingElement _azureQueueStorageTransportBindingElement;
        private const string SecurityTokenTypesNamespace = "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens";
        private const string X509CertificateTokenType = SecurityTokenTypesNamespace + "/X509Certificate";
        private const string RequirementNamespace = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement";
        private const string PreferSslCertificateAuthenticatorProperty = RequirementNamespace + "/PreferSslCertificateAuthenticator";

        public AzureQueueStorageChannelFactory(
            AzureQueueStorageTransportBindingElement bindingElement,
            BindingContext context)
            : base(context.Binding)
        {
            _azureQueueStorageTransportBindingElement = bindingElement;
            var messageEncoderBindingElement = context.BindingParameters.Find<MessageEncodingBindingElement>();
            MessageEncoderFactory = messageEncoderBindingElement == null
                ? AzureQueueStorageConstants.DefaultMessageEncoderFactory
                : messageEncoderBindingElement.CreateMessageEncoderFactory();

            BufferManager = BufferManager.CreateBufferManager(bindingElement.MaxBufferPoolSize, int.MaxValue);
            ConnectionString = bindingElement.ConnectionString;

            var securityCredentialsManager = context.BindingParameters.Find<SecurityCredentialsManager>() ?? new ClientCredentials();

            var securityTokenManager = securityCredentialsManager.CreateSecurityTokenManager();
            InitiatorServiceModelSecurityTokenRequirement serverCertRequirement = new()
            {
                TokenType = X509CertificateTokenType,
                RequireCryptographicToken = true,
                KeyUsage = SecurityKeyUsage.Exchange,
                TransportScheme = "net.aqs"
            };
            serverCertRequirement.Properties[PreferSslCertificateAuthenticatorProperty] = true;

            SecurityTokenAuthenticator = securityTokenManager.CreateSecurityTokenAuthenticator(serverCertRequirement, out SecurityTokenResolver dummy);

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = RemoteCertificateValidationCallback;
            HttpClient = new HttpClient(httpClientHandler);
        }

        private SecurityTokenAuthenticator SecurityTokenAuthenticator { get;}

        internal HttpClient HttpClient { get; }

        public BufferManager BufferManager { get; }

        internal string ConnectionString { get; }

        internal string QueueName { get; set; }

        public MessageEncoderFactory MessageEncoderFactory { get; } = null;

        public override T GetProperty<T>()
        {
            T messageEncoderProperty = this.MessageEncoderFactory.Encoder.GetProperty<T>();
            if (messageEncoderProperty != null)
            {
                return messageEncoderProperty;
            }

            if (typeof(T) == typeof(MessageVersion))
            {
                return (T)(object)this.MessageEncoderFactory.Encoder.MessageVersion;
            }

            return base.GetProperty<T>();
        }

        protected override void OnOpen(TimeSpan timeout)
        {
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return Task.CompletedTask.ToApm(callback,state);
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

        private bool RemoteCertificateValidationCallback(
            HttpRequestMessage sender,
            X509Certificate2 certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            Debug.Assert(SecurityTokenAuthenticator != null, "SecurityTokenAuthenticator is null");

            try
            {
                SecurityToken token = new X509SecurityToken(certificate);
                ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies = SecurityTokenAuthenticator.ValidateToken(token);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
