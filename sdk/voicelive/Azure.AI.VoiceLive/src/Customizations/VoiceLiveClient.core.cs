// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.VoiceLive
{
    /// <summary> The VoiceLiveClient. </summary>
    public partial class VoiceLiveClient
    {
        private readonly Uri _endpoint;
        /// <summary> A credential used to authenticate to the service. </summary>
        private readonly AzureKeyCredential _keyCredential;
        private const string AuthorizationHeader = "api-key";
        /// <summary> A credential used to authenticate to the service. </summary>
        private readonly TokenCredential _tokenCredential;
        private static readonly string[] AuthorizationScopes = new string[] { "https://ai.azure.com/.default" };

        /// <summary> Initializes a new instance of VoiceLiveClient for mocking. </summary>
        protected VoiceLiveClient()
        {
        }

#pragma warning disable AZC0007 // A websocket based client cannot use the pipeline provided by the typical options class, and showing it will cause confusion.

        /// <summary> Initializes a new instance of VoiceLiveClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public VoiceLiveClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new VoiceLiveClientOptions())
        {
        }

        /// <summary> Initializes a new instance of VoiceLiveClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public VoiceLiveClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new VoiceLiveClientOptions())
        {
        }
#pragma warning restore AZC0007 // A websocket based client cannot use the pipeline provided by the typical options class, and showing it will cause confusion.

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        internal Uri Endpoint { get => _endpoint; }
    }
}
