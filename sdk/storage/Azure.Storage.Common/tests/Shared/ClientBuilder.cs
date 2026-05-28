// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
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

        private readonly ServiceEndpoint _serviceEndpoint;
        public TenantConfigurationBuilder Tenants { get; }

        public RecordedTestBase AzureCoreRecordedTestBase => Tenants.AzureCoreRecordedTestBase;

        /// <summary>
        /// Recording reference. Unsafe to access until [Setup] step.
        /// </summary>
        public TestRecording Recording => AzureCoreRecordedTestBase.Recording;

        /// <summary>
        /// Test mode reference. Safe to access even when <see cref="Recording"/> is not.
        /// </summary>
        public RecordedTestMode Mode => AzureCoreRecordedTestBase.Mode;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tenantConfigurationBuilder">Source of tenants for appropriate service clients.</param>
        /// <param name="getServiceClient">Constructs a service client from the given arguments.</param>
        /// <param name="getServiceClientStorageSharedKeyCredential">Constructs a service client from the given arguments.</param>
        /// <param name="getServiceClientTokenCredential">Constructs a service client from the given arguments.</param>
        /// <param name="getServiceClientAzureSasCredential">Constructs a service client from the given arguments.</param
        /// <param name="getServiceClientOptions">Constructs service-specific client options.</param>
        public ClientBuilder(
            ServiceEndpoint serviceEndpoint,
            TenantConfigurationBuilder tenantConfigurationBuilder,
            GetServiceClient getServiceClient,
            GetServiceClientStorageSharedKeyCredential getServiceClientStorageSharedKeyCredential,
            GetServiceClientTokenCredential getServiceClientTokenCredential,
            GetServiceClientAzureSasCredential getServiceClientAzureSasCredential,
            GetServiceClientOptions getServiceClientOptions)
        {
            _serviceEndpoint = serviceEndpoint;
            Tenants = tenantConfigurationBuilder;
            _getServiceClient = getServiceClient;
            _getServiceClientStorageSharedKeyCredential = getServiceClientStorageSharedKeyCredential;
            _getServiceClientTokenCredential = getServiceClientTokenCredential;
            _getServiceClientAzureSasCredential = getServiceClientAzureSasCredential;
            _getServiceClientOptions = getServiceClientOptions;
        }

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

        private string GetEndpoint(TenantConfiguration config)
            => _serviceEndpoint switch
            {
                ServiceEndpoint.Blob => config.BlobServiceEndpoint,
                ServiceEndpoint.File => config.FileServiceEndpoint,
                ServiceEndpoint.Queue => config.QueueServiceEndpoint,
                _ => throw new ArgumentException($"{nameof(_serviceEndpoint)} not properly initialized.")
            };

        public TServiceClient GetServiceClientFromSharedKeyConfig(TenantConfiguration config, TServiceClientOptions options = default)
            => AzureCoreRecordedTestBase.InstrumentClient(
                _getServiceClientStorageSharedKeyCredential(
                    new Uri(GetEndpoint(config)),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    options ?? GetOptions()));

        public TServiceClient GetServiceClientFromOauthConfig(
            TenantConfiguration config,
            TokenCredential tokenCredential,
            TServiceClientOptions options = default)
            => AzureCoreRecordedTestBase.InstrumentClient(
                _getServiceClientTokenCredential(
                    new Uri(GetEndpoint(config)),
                    tokenCredential,
                    options ?? GetOptions()));

        public TServiceClientOptions GetOptions(bool parallelRange = false)
        {
            var options = _getServiceClientOptions();
            options.Diagnostics.IsLoggingEnabled = true;
            options.Retry.Mode = RetryMode.Exponential;
            options.Retry.MaxRetries = Constants.MaxReliabilityRetries;
            options.Retry.Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1);
            options.Retry.MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60);
            options.Retry.NetworkTimeout = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 100 : 400);

            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording, parallelRange), HttpPipelinePosition.PerCall);
            }

            return AzureCoreRecordedTestBase.InstrumentClientOptions(options);
        }
    }
}
