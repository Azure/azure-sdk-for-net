// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Microsoft.Identity.Client.Extensibility;

namespace Azure.Identity
{
    /// <summary>
    /// Provides access to customize the token request before it is sent.
    /// </summary>
    [Experimental("AZID0003")]
    public class TokenRequestCallbackContext
    {
        private readonly OnBeforeTokenRequestData _data;

        internal TokenRequestCallbackContext(OnBeforeTokenRequestData data)
        {
            _data = data;
        }

        /// <summary>
        /// Gets the body parameters of the token request. Adding or modifying entries in this
        /// dictionary will cause them to be included in the token request body sent to the identity provider.
        /// </summary>
        public IDictionary<string, string> BodyParameters => _data.BodyParameters;

        /// <summary>
        /// Gets the headers of the token request.
        /// </summary>
        internal IDictionary<string, string> Headers => _data.Headers;

        /// <summary>
        /// Gets the URI of the token request.
        /// </summary>
        internal Uri RequestUri => _data.RequestUri;

        /// <summary>
        /// Gets the cancellation token for the token request.
        /// </summary>
        internal CancellationToken CancellationToken => _data.CancellationToken;
    }
}
