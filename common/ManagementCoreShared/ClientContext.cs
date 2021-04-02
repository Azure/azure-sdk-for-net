// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

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
        /// Initializes a new instance of the <see cref="ClientContext"/> class.
        /// </summary>
        /// <param name="clientOptions"></param>
        /// <param name="credential"></param>
        /// <param name="uri"></param>
        internal ClientContext(ArmClientOptions clientOptions, TokenCredential credential, Uri uri)
        {
            ClientOptions = clientOptions;
            Credential = credential;
            BaseUri = uri;
        }
    }
}
