// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        /// <summary> Create a new Media Composition resource. </summary>
        public MediaCompositionBody CreateMediaComposition(
            string mediaCompositionId,
            MediaLayout layout,
            IDictionary<string, MediaInput> mediaInputs,
            IDictionary<string, MediaOutput> mediaOutputs,
            IDictionary<string, MediaSource> sources)
        {
            var newMediaComposition = new MediaCompositionBody(
                mediaCompositionId,
                layout,
                mediaInputs,
                mediaOutputs,
                sources,
                CompositionStreamState.NotStarted);

            return RestClient.Create(mediaCompositionId, newMediaComposition).Value;
        }

        /// <summary> Starts a Media Composition resource. </summary>
        public CompositionStreamState StartMediaComposition(string mediaCompositionId)
        {
            return RestClient.Start(mediaCompositionId).Value;
        }
    }
}
