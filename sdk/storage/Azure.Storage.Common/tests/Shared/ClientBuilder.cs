// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Sas;

namespace Azure.Storage.Test.Shared
{
    public class ClientBuilder<TServiceClient, TServiceClientOptions>
        where TServiceClient : class
        where TServiceClientOptions : ClientOptions
    {
        #region Delegate Definitions
        /// <summary>
        /// Delegate for accessing a shared key credential constructor for a service client.
        /// </summary>
        public delegate TServiceClient GetServiceClientStorageSharedKeyCredential(Uri endpoint, StorageSharedKeyCredential credential, TServiceClientOptions clientOptions);

        /// <summary>
        /// Delegate for accessing a SAS credential constructor for a service client.
        /// </summary>
        public delegate TServiceClient GetServiceClientAzureSasCredential(Uri endpoint, AzureSasCredential credential, TServiceClientOptions clientOptions);

        /// <summary>
        /// Delegate for accessing a token credential constructor for a service client.
        /// </summary>
        public delegate TServiceClient GetServiceClientTokenCredential(Uri endpoint, TokenCredential credential, TServiceClientOptions clientOptions);

        /// <summary>
        /// Delegate for accessing a credential-less constructor for a service client.
        /// </summary>
        public delegate TServiceClient GetServiceClient(Uri endpoint, TServiceClientOptions clientOptions);

        /// <summary>
        /// Delegate for accessing constructor for service client options.
        /// </summary>
        /// <param name="serviceVersion"></param>
        /// <returns></returns>
        public delegate TServiceClientOptions GetServiceClientOptions();

        /// <summary>
        /// Delegate for applying Azure Core client instrumentation to a service client.
        /// </summary>
        public delegate TClient InstrumentServiceClient<TClient>(TClient client);

        /// <summary>
        /// Delegate for applying Azure Core client options instrumentation to client options.
        /// </summary>
        public delegate TServiceClientOptions InstrumentClientOptions(TServiceClientOptions client);
        #endregion

        private readonly GetServiceClientStorageSharedKeyCredential _getServiceClientStorageSharedKeyCredential;
        private readonly GetServiceClientAzureSasCredential _getServiceClientAzureSasCredential;
        private readonly GetServiceClientTokenCredential _getServiceClientTokenCredential;
        private readonly GetServiceClient _getServiceClient;
        private readonly GetServiceClientOptions _getServiceClientOptions;

        private TenantConfigurationBuilder Tenants { get; }

        public RecordedTestBase AzureCoreRecordedTestBase => Tenants.AzureCoreRecordedTestBase;

        public TestRecording Recording => AzureCoreRecordedTestBase.Recording;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tenantConfigurationBuilder">Source of tenants for appropriate service clients.</param>
        /// <param name="getServiceClient">Constructs a service client from the given arguments.</param>
        /// <param name="getServiceClientStorageSharedKeyCredential">Constructs a service client from the given arguments.</param>
        /// <param name="getServiceClientTokenCredential">Constructs a service client from the given arguments.</param>
        /// <param name="getServiceClientAzureSasCredential">Constructs a service client from the given arguments.</param>
        /// <param name="instrumentClient">Delegate to the test environment's InstrumentClient functionality.</param>
        public ClientBuilder(
            TenantConfigurationBuilder tenantConfigurationBuilder,
            GetServiceClient getServiceClient,
            GetServiceClientStorageSharedKeyCredential getServiceClientStorageSharedKeyCredential,
            GetServiceClientTokenCredential getServiceClientTokenCredential,
            GetServiceClientAzureSasCredential getServiceClientAzureSasCredential,
            GetServiceClientOptions getServiceClientOptions)
        {
            Tenants = tenantConfigurationBuilder;
            _getServiceClient = getServiceClient;
            _getServiceClientStorageSharedKeyCredential = getServiceClientStorageSharedKeyCredential;
            _getServiceClientTokenCredential = getServiceClientTokenCredential;
            _getServiceClientAzureSasCredential = getServiceClientAzureSasCredential;
            _getServiceClientOptions = getServiceClientOptions;
        }

        public TServiceClient GetServiceClient_SharedKey(TServiceClientOptions options = default)
            => GetServiceClientFromSharedKeyConfig(Tenants.TestConfigDefault, options);

        public TServiceClient GetServiceClient_SecondaryAccount_SharedKey()
            => GetServiceClientFromSharedKeyConfig(Tenants.TestConfigSecondary);

        public TServiceClient GetServiceClient_PreviewAccount_SharedKey()
            => GetServiceClientFromSharedKeyConfig(Tenants.TestConfigPreviewBlob);

        public TServiceClient GetServiceClient_PremiumBlobAccount_SharedKey()
            => GetServiceClientFromSharedKeyConfig(Tenants.TestConfigPremiumBlob);
        public TServiceClient GetServiceClient_OAuth() =>
            GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth);

        public TServiceClient GetServiceClient_OAuthAccount_SharedKey() =>
            GetServiceClientFromSharedKeyConfig(Tenants.TestConfigOAuth);

        public TServiceClient GetServiceClient_ManagedDisk() =>
            GetServiceClientFromSharedKeyConfig(Tenants.TestConfigManagedDisk);

        public TServiceClient GetServiceClient_PremiumBlob() =>
            GetServiceClientFromSharedKeyConfig(Tenants.TestConfigPremiumBlob);

        public TServiceClient GetServiceClient_PremiumFile() =>
            GetServiceClientFromSharedKeyConfig(Tenants.TestConfigPremiumFile);

        public TServiceClient GetServiceClient_Hns() =>
            GetServiceClientFromSharedKeyConfig(Tenants.TestConfigHierarchicalNamespace);

        public TServiceClient GetServiceClient_SoftDelete() =>
            GetServiceClientFromSharedKeyConfig(Tenants.TestConfigSoftDelete);

        public SasQueryParameters GetNewAccountSas(
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All,
            AccountSasPermissions permissions = AccountSasPermissions.All,
            StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new AccountSasBuilder
            {
                Protocol = SasProtocol.None,
                Services = AccountSasServices.Blobs,
                ResourceTypes = resourceTypes,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None),
                Version = Constants.DefaultSasVersion
            };
            builder.SetPermissions(permissions);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials());
        }

        private TServiceClient GetServiceClientFromSharedKeyConfig(TenantConfiguration config, TServiceClientOptions options = default)
            => AzureCoreRecordedTestBase.InstrumentClient(
                _getServiceClientStorageSharedKeyCredential(
                    new Uri(config.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    options ?? _getServiceClientOptions()));

        private TServiceClient GetServiceClientFromOauthConfig(
            TenantConfiguration config,
            TServiceClientOptions options = default)
            => AzureCoreRecordedTestBase.InstrumentClient(
                _getServiceClientTokenCredential(
                    new Uri(config.BlobServiceEndpoint),
                    Tenants.GetOAuthCredential(config),
                    options ?? _getServiceClientOptions()));

        public TServiceClientOptions GetOptions(bool parallelRange = false)
        {
            var options = _getServiceClientOptions();
            options.Diagnostics.IsLoggingEnabled = true;
            options.Retry.Mode = RetryMode.Exponential;
            options.Retry.MaxRetries = Constants.MaxReliabilityRetries;
            options.Retry.Delay = TimeSpan.FromSeconds(Recording.Mode == RecordedTestMode.Playback ? 0.01 : 1);
            options.Retry.MaxDelay = TimeSpan.FromSeconds(Recording.Mode == RecordedTestMode.Playback ? 0.1 : 60);
            options.Retry.NetworkTimeout = TimeSpan.FromSeconds(Recording.Mode == RecordedTestMode.Playback ? 100 : 400);

            if (Recording.Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording, parallelRange), HttpPipelinePosition.PerCall);
            }

            return AzureCoreRecordedTestBase.InstrumentClientOptions(options);
        }
    }
}
