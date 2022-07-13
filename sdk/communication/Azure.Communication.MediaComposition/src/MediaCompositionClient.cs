// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.Pipeline;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Azure.Communication.MediaComposition.Models;

namespace Azure.Communication.MediaComposition
{
    /// <summary>
    /// The Azure Communication Services Media Composition client.
    /// </summary>
    public class MediaCompositionClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal MediaCompositionRestClient RestClient { get; }

        #region public constructors - all arguments need null check

        /// <summary> Initializes a new instance of <see cref="MediaCompositionClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public MediaCompositionClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new MediaCompositionClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="MediaCompositionClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public MediaCompositionClient(string connectionString, MediaCompositionClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new MediaCompositionClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="MediaCompositionClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public MediaCompositionClient(Uri endpoint, AzureKeyCredential keyCredential, MediaCompositionClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new MediaCompositionClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="MediaCompositionClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public MediaCompositionClient(Uri endpoint, TokenCredential tokenCredential, MediaCompositionClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new MediaCompositionClientOptions())
        { }

        #endregion

        #region private constructors
        private MediaCompositionClient(ConnectionString connectionString, MediaCompositionClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private MediaCompositionClient(string endpoint, TokenCredential tokenCredential, MediaCompositionClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private MediaCompositionClient(string endpoint, AzureKeyCredential keyCredential, MediaCompositionClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private MediaCompositionClient(string endpoint, HttpPipeline httpPipeline, MediaCompositionClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new MediaCompositionRestClient(_clientDiagnostics, httpPipeline, new Uri(endpoint), options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="MediaCompositionClient"/> for mocking.</summary>
        protected MediaCompositionClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
        }

        /// <param name="mediaCompositionId"> The media composition id to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MediaCompositionBody>> GetAsync(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Get");
            scope.Start();
            try
            {
                return await RestClient.GetAsync(mediaCompositionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="mediaCompositionId"> The media composition id to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MediaCompositionBody> Get(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Get");
            scope.Start();
            try
            {
                return RestClient.Get(mediaCompositionId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="mediaCompositionId"> The media composition id. </param>
        /// <param name="layout"> The layout to compose the media. </param>
        /// <param name="inputs"> The media inputs. </param>
        /// <param name="outputs"> The media outputs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MediaCompositionBody>> CreateAsync(string mediaCompositionId, MediaCompositionLayout layout, IDictionary<string, MediaInput> inputs, IDictionary<string, MediaOutput> outputs, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Create");
            scope.Start();
            try
            {
                return await RestClient.CreateAsync(mediaCompositionId, mediaCompositionId, layout, inputs, outputs, CompositionStreamState.NotStarted, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="mediaCompositionId"> The media composition id. </param>
        /// <param name="layout"> The layout to compose the media. </param>
        /// <param name="inputs"> The media inputs. </param>
        /// <param name="outputs"> The media outputs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MediaCompositionBody> Create(string mediaCompositionId, MediaCompositionLayout layout, IDictionary<string, MediaInput> inputs, IDictionary<string, MediaOutput> outputs, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Create");
            scope.Start();
            try
            {
                return RestClient.Create(mediaCompositionId, mediaCompositionId, layout, inputs, outputs, CompositionStreamState.NotStarted, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="mediaCompositionId"> The media composition id of the composition to update. </param>
        /// <param name="layout"> The updated layout to compose media. </param>
        /// <param name="inputs"> The updated media inputs. </param>
        /// <param name="outputs"> The updated media outputs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MediaCompositionBody>> UpdateAsync(string mediaCompositionId, MediaCompositionLayout layout = null, IDictionary<string, MediaInput> inputs = null, IDictionary<string, MediaOutput> outputs = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Update");
            scope.Start();
            try
            {
                return await RestClient.UpdateAsync(mediaCompositionId, mediaCompositionId, layout, inputs, outputs, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="mediaCompositionId"> The media composition id of the composition to update. </param>
        /// <param name="layout"> The updated layout to compose media. </param>
        /// <param name="inputs"> The updated media inputs. </param>
        /// <param name="outputs"> The updated media outputs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MediaCompositionBody> Update(string mediaCompositionId, MediaCompositionLayout layout = null, IDictionary<string, MediaInput> inputs = null, IDictionary<string, MediaOutput> outputs = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Update");
            scope.Start();
            try
            {
                return RestClient.Update(mediaCompositionId, mediaCompositionId, layout, inputs, outputs, null, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="mediaCompositionId"> The media composition id of the composition to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteAsync(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Delete");
            scope.Start();
            try
            {
                return await RestClient.DeleteAsync(mediaCompositionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="mediaCompositionId"> The media composition id of the composition to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Delete");
            scope.Start();
            try
            {
                return RestClient.Delete(mediaCompositionId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="mediaCompositionId"> The media composition id of the composition to start. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CompositionStreamState>> StartAsync(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Start");
            scope.Start();
            try
            {
                return await RestClient.StartAsync(mediaCompositionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="mediaCompositionId"> The media composition id of the composition to start. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CompositionStreamState> Start(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Start");
            scope.Start();
            try
            {
                return RestClient.Start(mediaCompositionId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="mediaCompositionId"> The media composition id of the composition to stop. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CompositionStreamState>> StopAsync(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Stop");
            scope.Start();
            try
            {
                return await RestClient.StopAsync(mediaCompositionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="mediaCompositionId"> The media composition id of the composition to stop. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CompositionStreamState> Stop(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MediaCompositionClient.Stop");
            scope.Start();
            try
            {
                return RestClient.Stop(mediaCompositionId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
