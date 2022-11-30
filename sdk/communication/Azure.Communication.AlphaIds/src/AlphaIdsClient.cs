// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.AlphaIds.Models;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.AlphaIds
{
    /// <summary> The Alpha ID service client. </summary>
    public partial class AlphaIdsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        internal AlphaIdsRestClient RestClient { get; }

        /// <summary> Initializes a new instance of AlphaIdsClient for mocking. </summary>
        protected AlphaIdsClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AlphaIdsClient"/>
        /// </summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public AlphaIdsClient(string connectionString)
            : this(ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                 new AlphaIdsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="AlphaIdsClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public AlphaIdsClient(string connectionString, AlphaIdsClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new AlphaIdsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="AlphaIdsClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public AlphaIdsClient(Uri endpoint, AzureKeyCredential keyCredential, AlphaIdsClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new AlphaIdsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="AlphaIdsClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public AlphaIdsClient(Uri endpoint, TokenCredential tokenCredential, AlphaIdsClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new AlphaIdsClientOptions())
        { }

        private AlphaIdsClient(ConnectionString connectionString, AlphaIdsClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        {
        }

        private AlphaIdsClient(string endpoint, HttpPipeline httpPipeline, AlphaIdsClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new AlphaIdsRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        private AlphaIdsClient(string endpoint, AzureKeyCredential keyCredential, AlphaIdsClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        {
        }

        private AlphaIdsClient(string endpoint, TokenCredential tokenCredential, AlphaIdsClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        /// <summary> Get the Alpha IDs configuration that&apos;s applied for the current resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AlphaIdConfiguration>> GetConfigurationAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("AlphaIdsClient.GetConfiguration");
            scope.Start();
            try
            {
                return await RestClient.GetConfigurationAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the Alpha IDs configuration that&apos;s applied for the current resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AlphaIdConfiguration> GetConfiguration(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("AlphaIdsClient.GetConfiguration");
            scope.Start();
            try
            {
                return RestClient.GetConfiguration(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates Alpha ID Configuration for the current resource. </summary>
        /// <param name="enabled"> Indicates whether the use of Alpha IDs is supported for a specific resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AlphaIdConfiguration>> UpsertConfigurationAsync(bool enabled, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("AlphaIdsClient.UpsertConfiguration");
            scope.Start();
            try
            {
                return await RestClient.UpsertConfigurationAsync(enabled, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates Alpha ID Configuration for the current resource. </summary>
        /// <param name="enabled"> Indicates whether the use of Alpha IDs is supported for a specific resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AlphaIdConfiguration> UpsertConfiguration(bool enabled, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("AlphaIdsClient.UpsertConfiguration");
            scope.Start();
            try
            {
                return RestClient.UpsertConfiguration(enabled, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
