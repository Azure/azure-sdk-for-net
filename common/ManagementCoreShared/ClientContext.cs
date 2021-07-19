// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// helper class
    /// </summary>
    internal class ClientContext
    {
        /// <summary>
        /// client options
        /// </summary>
        public ArmClientOptions ClientOptions { get; set; }

        /// <summary>
        /// credential
        /// </summary>
        public TokenCredential Credential { get; set; }

        /// <summary>
        /// baseuri
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// pipeline
        /// </summary>
        public HttpPipeline Pipeline { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientContext"/> class.
        /// </summary>
        /// <param name="clientOptions"></param>
        /// <param name="credential"></param>
        /// <param name="uri"></param>
        /// <param name="pipeline"></param>
        internal ClientContext(ArmClientOptions clientOptions, TokenCredential credential, Uri uri, HttpPipeline pipeline)
        {
            ClientOptions = clientOptions;
            Credential = credential;
            BaseUri = uri;
            Pipeline = pipeline;
        }
    }
}
