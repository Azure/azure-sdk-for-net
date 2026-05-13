// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Identity.Client.Extensibility;

namespace Azure.Identity
{
    /// <summary>
    /// Provides access to customize the token request before it is sent.
    /// </summary>
#pragma warning disable AZC0034 // Type in Azure.Identity namespace defined in Azure.Core assembly
    [Experimental("AZID0002")]
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
    }
#pragma warning restore AZC0034
}
