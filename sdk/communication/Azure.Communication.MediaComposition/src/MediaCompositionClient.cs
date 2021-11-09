// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Communication.Pipeline;
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
        internal readonly string _resourceEndpoint;

        internal MediaCompositionRestClient RestClient { get; }

        #region public constructors

        /// <summary> Initializes a new instance of <see cref="MediaCompositionRestClient"/>.</summary>
        public MediaCompositionClient(string connectionString)
            : this(
                  ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                  new MediaCompositionClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="MediaCompositionRestClient"/>.</summary>
        public MediaCompositionClient(string connectionString, MediaCompositionClientOptions options)
            : this(
                  ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                  options ?? new MediaCompositionClientOptions())
        { }

        #endregion

        #region private constructors

        private MediaCompositionClient(ConnectionString connectionString, MediaCompositionClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private MediaCompositionClient(string endpoint, HttpPipeline httpPipeline, MediaCompositionClientOptions options)
        {
            _pipeline = httpPipeline;
            _resourceEndpoint = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new MediaCompositionRestClient(_clientDiagnostics, httpPipeline, new Uri(endpoint));
        }

        #endregion

        #region protected constructors
        /// <summary> Initializes a new instance of Media Composition Client for mocking. </summary>
        protected MediaCompositionClient()
        {
        }
        #endregion protected constructors
    }
}
