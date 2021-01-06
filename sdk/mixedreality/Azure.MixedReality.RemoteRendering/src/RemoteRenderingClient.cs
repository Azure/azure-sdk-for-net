// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.MixedReality.Authentication;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// The client to use for interacting with the Azure Remote Rendering.
    /// </summary>
    public class RemoteRenderingClient
    {
        private readonly string _accountId;

        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly HttpPipeline _pipeline;

        private readonly MixedRealityRemoteRenderingRestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClient"/> class.
        /// </summary>
        public RemoteRenderingClient(string accountId)
            : this(accountId, new RemoteRenderingClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClient"/> class.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="options">The options.</param>
        public RemoteRenderingClient(string accountId, RemoteRenderingClientOptions options)
        {
            _accountId = accountId;
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = new HttpPipeline();
            _restClient = new MixedRealityRemoteRenderingRestClient(_clientDiagnostics, _pipeline);
        }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary> Initializes a new instance of RemoteRenderingClient for mocking. </summary>
        protected RemoteRenderingClient()
        {
        }

#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

    }
}
