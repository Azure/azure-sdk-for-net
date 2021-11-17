// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.MediaComposition.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.MediaComposition
{
    /// <summary>
    /// The Azure Communication Services Media Composition client.
    /// </summary>
    public class MediaCompositionClient
    {
        internal readonly ClientDiagnostics _clientDiagnostics;
        internal readonly HttpPipeline _pipeline;

        internal MediaCompositionRestClient RestClient { get; }

        #region public constructors

        /// <summary> Initializes a new instance of <see cref="MediaCompositionRestClient"/>.</summary>
        public MediaCompositionClient(Uri endpoint)
            : this(
                  Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                  new MediaCompositionClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="MediaCompositionRestClient"/>.</summary>
        public MediaCompositionClient(Uri endpoint, MediaCompositionClientOptions options)
            : this(
                  Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                  options ?? new MediaCompositionClientOptions())
        { }

        #endregion

        #region private constructors

        private MediaCompositionClient(string endpoint, MediaCompositionClientOptions options)
        {
            _pipeline = HttpPipelineBuilder.Build(options);
            _clientDiagnostics = new ClientDiagnostics(options);

            RestClient = new MediaCompositionRestClient(_clientDiagnostics, _pipeline, new Uri(endpoint));
        }

        #endregion

        #region protected constructors

        /// <summary> Initializes a new instance of Media Composition Client for mocking. </summary>
        protected MediaCompositionClient()
        {
        }

        #endregion protected constructors

        #region sync methods

        /// <summary> Create a new Media Composition resource. </summary>
        public virtual Response<MediaCompositionBody> CreateMediaComposition(
            string mediaCompositionId,
            MediaLayout layout,
            IDictionary<string, MediaInput> mediaInputs,
            IDictionary<string, MediaOutput> mediaOutputs,
            IDictionary<string, MediaSource> sources,
            CancellationToken cancellationToken = default)
        {
            var newMediaComposition = new MediaCompositionBody(
                mediaCompositionId,
                layout,
                mediaInputs,
                mediaOutputs,
                sources,
                CompositionStreamState.NotStarted);

            return RestClient.Create(mediaCompositionId, newMediaComposition, cancellationToken);
        }

        /// <summary> Retrieves a Media Composition resource. </summary>
        public virtual Response<MediaCompositionBody> GetMediaComposition(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            return RestClient.Get(mediaCompositionId, cancellationToken);
        }

        /// <summary> Starts a Media Composition resource. </summary>
        public virtual Response<CompositionStreamState> StartMediaComposition(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            return RestClient.Start(mediaCompositionId, cancellationToken);
        }

        /// <summary> Stops a Media Composition resource. </summary>
        public virtual Response<CompositionStreamState> StopMediaComposition(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            return RestClient.Stop(mediaCompositionId, cancellationToken);
        }

        /// <summary> Deletes a Media Composition resource. </summary>
        public virtual Response DeleteMediaComposition(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            return RestClient.Delete(mediaCompositionId, cancellationToken);
        }

        /// <summary> Updates a Media Composition resource. </summary>
        public virtual Response<MediaCompositionBody> UpdateMediaComposition(
            string mediaCompositionId,
            MediaCompositionBody mediaCompositionBody,
            CancellationToken cancellationToken = default)
        {
            return RestClient.Update(mediaCompositionId, mediaCompositionBody, cancellationToken);
        }

        #endregion

        #region async methods

        /// <summary> Create a new Media Composition resource. </summary>
        public virtual async Task<Response<MediaCompositionBody>> CreateMediaCompositionAsync(
            string mediaCompositionId,
            MediaLayout layout,
            IDictionary<string, MediaInput> mediaInputs,
            IDictionary<string, MediaOutput> mediaOutputs,
            IDictionary<string, MediaSource> sources,
            CancellationToken cancellationToken = default)
        {
            var newMediaComposition = new MediaCompositionBody(
                mediaCompositionId,
                layout,
                mediaInputs,
                mediaOutputs,
                sources,
                CompositionStreamState.NotStarted);

            return await RestClient.CreateAsync(mediaCompositionId, newMediaComposition, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Retrieves a Media Composition resource. </summary>
        public virtual async Task<Response<MediaCompositionBody>> GetMediaCompositionAsync(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            return await RestClient.GetAsync(mediaCompositionId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Starts a Media Composition resource. </summary>
        public virtual async Task<Response<CompositionStreamState>> StartMediaCompositionAsync(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            return await RestClient.StartAsync(mediaCompositionId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Stops a Media Composition resource. </summary>
        public virtual async Task<Response<CompositionStreamState>> StopMediaCompositionAsync(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            return await RestClient.StopAsync(mediaCompositionId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Deletes a Media Composition resource. </summary>
        public virtual async Task<Response> DeleteMediaCompositionAsync(string mediaCompositionId, CancellationToken cancellationToken = default)
        {
            return await RestClient.DeleteAsync(mediaCompositionId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Updates a Media Composition resource. </summary>
        public virtual async Task<Response<MediaCompositionBody>> UpdateMediaCompositionAsyn(
            string mediaCompositionId,
            MediaCompositionBody mediaCompositionBody,
            CancellationToken cancellationToken = default)
        {
            return await RestClient.UpdateAsync(mediaCompositionId, mediaCompositionBody, cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}
