// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.VoiceLive
{
#pragma warning disable AZC0015, AZC0107 // Client methods should return approved types
    public partial class VoiceLiveClient
    {
        internal VoiceLiveClientOptions Options { get; set; }

#pragma warning disable AZC0007 // A websocket based client cannot use the pipeline provided by the typical options class, and showing it will cause confusion.
        /// <summary> Initializes a new instance of VoiceLiveClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public VoiceLiveClient(Uri endpoint, AzureKeyCredential credential, VoiceLiveClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new VoiceLiveClientOptions();

            _endpoint = endpoint;
            _keyCredential = credential;
            Options = options;
            ClientDiagnostics = new ClientDiagnostics(options.InternalOptions, true);
        }

        /// <summary> Initializes a new instance of VoiceLiveClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public VoiceLiveClient(Uri endpoint, TokenCredential credential, VoiceLiveClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new VoiceLiveClientOptions();

            _endpoint = endpoint;
            _tokenCredential = credential;
            Options = options;
            ClientDiagnostics = new ClientDiagnostics(options.InternalOptions, true);
        }
#pragma warning restore AZC0007 // A websocket based client cannot use the pipeline provided by the typical options class, and showing it will cause confusion.
    }
}
