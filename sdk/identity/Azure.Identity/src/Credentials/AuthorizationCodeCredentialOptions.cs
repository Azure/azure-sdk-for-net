// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="AuthorizationCodeCredential"/>.
    /// </summary>
    public class AuthorizationCodeCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// The redirect Uri that will be sent with the GetToken request.
        /// </summary>
        public Uri RedirectUri { get; set; }
    }
}
