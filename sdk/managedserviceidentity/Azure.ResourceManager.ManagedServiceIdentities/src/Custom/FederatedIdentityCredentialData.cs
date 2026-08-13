// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat shim: pre-migration SDK had string Issuer property.
// IssuerUri was added in the TypeSpec migration; Issuer delegates to it.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedServiceIdentities
{
    public partial class FederatedIdentityCredentialData
    {
        /// <summary> The URL of the issuer to be trusted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Issuer
        {
            get => IssuerUri?.AbsoluteUri;
            set => IssuerUri = value != null ? new Uri(value) : null;
        }
    }
}
