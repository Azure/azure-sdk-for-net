// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ManagedServiceIdentities
{
    public partial class FederatedIdentityCredentialData
    {
        /// <summary> The URL of the issuer to be trusted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Issuer
        {
            get
            {
                return IssuerUri?.AbsoluteUri;
            }
            set
            {
                IssuerUri = new Uri(value);
            }
        }
    }
}
