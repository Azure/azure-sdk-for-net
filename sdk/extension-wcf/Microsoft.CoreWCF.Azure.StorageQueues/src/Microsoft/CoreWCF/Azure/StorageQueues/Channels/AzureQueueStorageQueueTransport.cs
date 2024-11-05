// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.IdentityModel.Policy;
using CoreWCF.IdentityModel.Selectors;
using CoreWCF.IdentityModel.Tokens;
using CoreWCF.Queue.Common;
using CoreWCF.Security;
using Microsoft.CoreWCF.Azure.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Buffers;
using System.Collections.ObjectModel;
using System.IO.Pipelines;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Channels
{
    internal class AzureQueueStorageQueueTransport : IQueueTransport
    {
        private const string SecurityTokenTypesNamespace = "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens";
        private const string X509CertificateTokenType = SecurityTokenTypesNamespace + "/X509Certificate";
        private const string RequirementNamespace = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement";
        private const string PreferSslCertificateAuthenticatorProperty = RequirementNamespace + "/PreferSslCertificateAuthenticator";

        private MessageQueue _messageQueue;
        private readonly ILogger<AzureQueueStorageQueueTransport> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private TimeSpan _receiveMessageVisibilityTimeout;
        private AzureQueueStorageTransportBindingElement _azureQueueStorageTransportBindingElement;
        private readonly ILogger<AzureQueueReceiveContext> _azureQueueReceiveContextLogger;
        private SecurityCredentialsManager _serviceCredentials;

        public AzureQueueStorageQueueTransport(BindingContext context, AzureQueueStorageTransportBindingElement azureQueueStorageTransportBindingElement)
        {
            _azureQueueStorageTransportBindingElement = azureQueueStorageTransportBindingElement;
            _receiveMessageVisibilityTimeout = _azureQueueStorageTransportBindingElement.MaxReceiveTimeout;
            var serviceDispatcher = context.BindingParameters.Find<IServiceDispatcher>();
            _serviceCredentials = serviceDispatcher.Host.Credentials;
            BaseAddress = serviceDispatcher.BaseAddress;
            var serviceProvider = context.BindingParameters.Find<IServiceProvider>();
            _loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            _logger = _loggerFactory.CreateLogger<AzureQueueStorageQueueTransport>();
            _azureQueueReceiveContextLogger = _loggerFactory.CreateLogger<AzureQueueReceiveContext>();
            QueueClientConfigureDelegate = context.BindingParameters.Find<Func<QueueClient, QueueClient>>();
            ValidateConfiguration();
        }

        private void ValidateConfiguration()
        {
            var azureServiceCredentials = _serviceCredentials as AzureServiceCredentials;
            if (azureServiceCredentials is null)
            {
                // It could be a custom credentials implementation and that needs to be used on an async code path
                // as the token manager might implement OpenAsync. We can only do a best effort check if it's AzureServiceCredentials
                return;
            }

            switch (_azureQueueStorageTransportBindingElement.ClientCredentialType)
            {
                case AzureClientCredentialType.Default: // We don't need an AzureServiceCredentials in this case
                    return;
                case AzureClientCredentialType.ConnectionString:
                    if (azureServiceCredentials.ConnectionString is null)
                    {
                        throw new InvalidOperationException(SR.ConnectionStringNotProvidedOnAzureServiceCredentials);
                    }

                    string queueName;
                    var connectionStringUri = AzureQueueStorageChannelHelpers.ExtractQueueUriFromConnectionString(azureServiceCredentials.ConnectionString);
                    AzureQueueStorageChannelHelpers.ExtractAccountAndQueueNameFromUri(connectionStringUri, queueNameRequired: false, out string connectionStringAccountName, out string connectionStringQueueName);
                    if (!BaseAddress.AbsoluteUri.Equals(AzureQueueStorageTransportBindingElement.DummyNetAqsAddress))
                    {
                        AzureQueueStorageChannelHelpers.ExtractAccountAndQueueNameFromUri(BaseAddress, queueNameRequired: true, out string viaAccountName, out string viaQueueName);
                        if (!string.IsNullOrEmpty(connectionStringQueueName) && !string.IsNullOrEmpty(viaQueueName) &&
                            !connectionStringQueueName.Equals(viaQueueName, StringComparison.OrdinalIgnoreCase))
                        {
                            throw new ArgumentException(string.Format(SR.ConnectionStringAndViaQueueNameMismatch, connectionStringQueueName, viaQueueName));
                        }
                        queueName = string.IsNullOrEmpty(connectionStringQueueName) ? viaQueueName : connectionStringQueueName;

                        if (!string.IsNullOrEmpty(connectionStringAccountName) && !string.IsNullOrEmpty(viaAccountName) &&
                            !connectionStringAccountName.Equals(viaAccountName, StringComparison.OrdinalIgnoreCase))
                        {
                            throw new ArgumentException(string.Format(SR.ConnectionStringAndViaAccountNameMismatch, connectionStringAccountName, viaAccountName));
                        }
                    }
                    else
                    {
                        // Using ConnectionString and address wasn't passed to AddServiceEndpoint so we only have the QueueEndpoint from the ConnectionString
                        queueName = connectionStringQueueName;
                    }

                    if (string.IsNullOrEmpty(queueName))
                    {
                        throw new ArgumentException(SR.MissingQueueName);
                    }

                    return;
                case AzureClientCredentialType.Token:
                    if (azureServiceCredentials.Token == null)
                    {
                        throw new InvalidOperationException(SR.TokenCredentialNotProvidedOnAzureServiceCredentials);
                    }
                    return;
                case AzureClientCredentialType.Sas:
                    if (azureServiceCredentials.Sas == null)
                    {
                        throw new InvalidOperationException(SR.SasCredentialNotProvidedOnAzureServiceCredentials);
                    }
                    return;
                case AzureClientCredentialType.StorageSharedKey:
                    if (azureServiceCredentials.StorageSharedKey == null)
                    {
                        throw new InvalidOperationException(SR.StorageSharedKeyCredentialNotProvidedOnAzureServiceCredentials);
                    }
                    return;
                default:
                    return;
            }
        }

        internal QueueMessageEncoding QueueMessageEncoding => _azureQueueStorageTransportBindingElement.QueueMessageEncoding;

        public int ConcurrencyLevel => 1;

        internal Uri BaseAddress { get; }

        internal Func<QueueClient, QueueClient> QueueClientConfigureDelegate { get; }

        internal async Task<SecurityTokenProviderContainer> CreateAndOpenTokenProviderAsync(CancellationToken token)
        {
            var tokenProviderContainer = CreateTokenProvider(token);

            if (tokenProviderContainer != null)
            {
                await tokenProviderContainer.OpenAsync(token).ConfigureAwait(false);
            }

            return tokenProviderContainer;
        }

        private SecurityTokenProviderContainer CreateTokenProvider(CancellationToken token)
        {
            var target = new EndpointAddress(BaseAddress);
            var via = BaseAddress;
            var securityTokenManager = _serviceCredentials.CreateSecurityTokenManager();
            string scheme = _azureQueueStorageTransportBindingElement.Scheme;
            SecurityTokenProvider tokenProvider = null;
            switch (_azureQueueStorageTransportBindingElement.ClientCredentialType)
            {
                case AzureClientCredentialType.Default:
                    tokenProvider = SecurityUtils.GetDefaultTokenProvider(securityTokenManager, target, via, scheme);
                    break;
                case AzureClientCredentialType.Sas:
                    tokenProvider = SecurityUtils.GetSasTokenProvider(securityTokenManager, target, via, scheme);
                    break;
                case AzureClientCredentialType.StorageSharedKey:
                    tokenProvider = SecurityUtils.GetStorageSharedKeyTokenProvider(securityTokenManager, target, via, scheme);
                    break;
                case AzureClientCredentialType.Token:
                    tokenProvider = SecurityUtils.GetTokenTokenProvider(securityTokenManager, target, via, scheme);
                    break;
                case AzureClientCredentialType.ConnectionString:
                    tokenProvider = SecurityUtils.GetConnectionStringTokenProvider(securityTokenManager, target, via, scheme);
                    break;
                default:
                    // The setter for this property should prevent this.
                    throw new ArgumentOutOfRangeException(nameof(_azureQueueStorageTransportBindingElement.ClientCredentialType), _azureQueueStorageTransportBindingElement.ClientCredentialType, null);
            }

            return tokenProvider == null ? null : new SecurityTokenProviderContainer(tokenProvider);
        }

        public async ValueTask<QueueMessageContext> ReceiveQueueMessageContextAsync(CancellationToken cancellationToken)
        {
            if (_messageQueue is null)
            {
                await EnsureMessageQueueAsync(cancellationToken).ConfigureAwait(false);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _logger.LogDebug("ReceiveQueueMessageContextAsync: ReceiveQueueMessageContextAsync called");

            QueueMessage queueMessage;
            try
            {
                queueMessage = await _messageQueue.ReceiveMessageAsync(_receiveMessageVisibilityTimeout, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                _logger.LogDebug("ReceiveQueueMessageContextAsync: Request cancelled");
                throw;
            }

            if (queueMessage == null)
            {
                _logger.LogDebug("ReceiveQueueMessageContextAsync: ReceiveMessageAsync returned null");
                return null;
            }

            _logger.LogDebug("ReceiveQueueMessageContextAsync: ReceiveMessageAsync returned message with id: " + queueMessage.MessageId);
            var reader = PipeReader.Create(new ReadOnlySequence<byte>(queueMessage.Body.ToMemory()));
            return GetContext(reader, new EndpointAddress(BaseAddress), queueMessage);
        }

        private async Task EnsureMessageQueueAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (_messageQueue is null)
            {
                var messageQueue = new MessageQueue(
                    this,
                    _azureQueueStorageTransportBindingElement.PollingInterval,
                    _loggerFactory.CreateLogger<MessageQueue>(),
                    _azureQueueStorageTransportBindingElement.DeadLetterQueueName,
                    _loggerFactory.CreateLogger<DeadLetterQueue>());
                await messageQueue.InitAsync(cancellationToken).ConfigureAwait(false);
                Interlocked.CompareExchange(ref _messageQueue, messageQueue, null);
            }
        }

        internal async Task<QueueClient> GetQueueClientAsync(Uri via, SecurityTokenProviderContainer tokenProvider, bool forceEncodingNone, CancellationToken cancellationToken)
        {
            QueueClientOptions queueClientOptions = BuildQueueClientOptions(forceEncodingNone);
            switch (_azureQueueStorageTransportBindingElement.ClientCredentialType)
            {
                case AzureClientCredentialType.Default:
                case AzureClientCredentialType.Token:
                    return await SecurityUtils.CreateQueueClientWithTokenCredentialAsync(tokenProvider, via, queueClientOptions, cancellationToken).ConfigureAwait(false);
                case AzureClientCredentialType.Sas:
                    return await SecurityUtils.CreateQueueClientWithSasCredentialAsync(tokenProvider, via, queueClientOptions, cancellationToken).ConfigureAwait(false);
                case AzureClientCredentialType.StorageSharedKey:
                    return await SecurityUtils.CreateQueueClientWithStorageSharedKeyCredentialAsync(tokenProvider, via, queueClientOptions, cancellationToken).ConfigureAwait(false);
                case AzureClientCredentialType.ConnectionString:
                    via = await UseConnectionStringQueueUrifNeededAsync(tokenProvider, via, cancellationToken).ConfigureAwait(false);
                    return await SecurityUtils.CreateQueueClientWithConnectionStringAsync(tokenProvider, via, queueClientOptions, cancellationToken).ConfigureAwait(false);
                default:
                    return null;
            }
        }

        private async Task<Uri> UseConnectionStringQueueUrifNeededAsync(SecurityTokenProviderContainer tokenProvider, Uri via, CancellationToken cancellationToken)
        {
            if (via.AbsoluteUri.Equals(AzureQueueStorageTransportBindingElement.DummyNetAqsAddress))
            {
                var result = await tokenProvider.TokenProvider.GetTokenAsync(cancellationToken).ConfigureAwait(false) as ConnectionStringSecurityToken;
                return AzureQueueStorageChannelHelpers.ExtractQueueUriFromConnectionString(result.ConnectionString);
            }

            return via;
        }

        internal Task<QueueClient> GetDeadLetterQueueClientAsync(Uri via, SecurityTokenProviderContainer tokenProvider, bool forceEncodingNone, CancellationToken cancellationToken)
        {
            switch (_azureQueueStorageTransportBindingElement.ClientCredentialType)
            {
                case AzureClientCredentialType.ConnectionString:
                    QueueClientOptions queueClientOptions = BuildQueueClientOptions(forceEncodingNone);
                    return SecurityUtils.CreateDeadLetterQueueClientWithConnectionStringAsync(tokenProvider, via, queueClientOptions, cancellationToken);
                default:
                    return GetQueueClientAsync(via, tokenProvider, forceEncodingNone, cancellationToken);
            }
        }

        private QueueClientOptions BuildQueueClientOptions(bool forceEncodingNone)
        {
            QueueClientOptions options = new();
            var azureClientCredentials = _serviceCredentials as AzureServiceCredentials;
            if (azureClientCredentials != null)
            {
                options.Audience = azureClientCredentials.Audience;
                options.EnableTenantDiscovery = azureClientCredentials.EnableTenantDiscovery;
            }

            options.MessageEncoding = forceEncodingNone ? QueueMessageEncoding.None : QueueMessageEncoding;

            var certificateValidationCallback = GetServiceCertificateValidationCallback();
            if (certificateValidationCallback != null)
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = certificateValidationCallback;
                HttpClient httpClient = new(httpClientHandler);
                HttpClientTransport httpClientTransport = new HttpClientTransport(httpClient);
                options.Transport = httpClientTransport;
            }

            options.MessageDecodingFailed += Options_MessageDecodingFailed;

            return options;
        }

        private async Task Options_MessageDecodingFailed(QueueMessageDecodingFailedEventArgs args)
        {
            if (args.ReceivedMessage != null)
            {
                bool deadLettered = false;
                try
                {
                    await _messageQueue.SendRawToDeadLetterQueueAsync(args.ReceivedMessage.MessageId, args.ReceivedMessage.Body, default).ConfigureAwait(false);
                    _logger.LogDebug("MessageDecodingFailed: Dead lettered message with id: " + args.ReceivedMessage.MessageId);
                    deadLettered = true;
                }
                catch (Exception e)
                {
                    _logger.LogWarning("MessageDecodingFailed: Exception: " + e.Message);
                }
                if (deadLettered)
                {
                    try
                    {
                        await _messageQueue.DeleteMessageAsync(args.ReceivedMessage.MessageId, args.ReceivedMessage.PopReceipt).ConfigureAwait(false);
                        _logger.LogDebug("MessageDecodingFailed: Deleted message with id: " + args.ReceivedMessage.MessageId);
                    }
                    catch (Exception e)
                    {
                        _logger.LogWarning("MessageDecodingFailed: Exception while deleting message with id " + args.ReceivedMessage.MessageId + " : " + e.Message);
                    }
                }
            }
        }

        private Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> GetServiceCertificateValidationCallback()
        {
            var securityTokenManager = _serviceCredentials.CreateSecurityTokenManager();
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

        private QueueMessageContext GetContext(PipeReader reader, EndpointAddress endpointAddress, QueueMessage queueMessage)
        {
            var context = new QueueMessageContext
            {
                QueueMessageReader = reader,
                LocalAddress = endpointAddress
            };

            var receiveContext = new AzureQueueReceiveContext(
                _messageQueue,
                queueMessage,
                _azureQueueStorageTransportBindingElement.PollingInterval,
                _azureQueueReceiveContextLogger);
            context.ReceiveContext = receiveContext;

            return context;
        }
    }
}
