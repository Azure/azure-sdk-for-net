// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ManagedServiceIdentities
{
    public partial class FederatedIdentityCredentialData : ResourceData
    {
        /// <summary> The URL of the issuer to be trusted. </summary>
        public string Issuer { get; set; }
    }
}
