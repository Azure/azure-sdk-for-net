// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.Identity
{
    internal interface ISupportsTokenRequestCallback
    {
        /// <summary>
        /// Gets or sets an optional callback that is invoked before each token request is sent to the identity provider.
        /// This callback can be used to customize the token request.
        /// </summary>
#pragma warning disable AZID0003 // TokenRequestCallbackContext is experimental
        Action<TokenRequestCallbackContext> TokenRequestCallback { get; set; }
#pragma warning restore AZID0003
    }
}
