// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    // Backward-compatibility shim for the pre-migration WritableSubResource constructor.
    public partial class DnsResolverData
    {
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsResolverData(AzureLocation location, WritableSubResource virtualNetwork) : this(location, virtualNetwork?.Id)
        {
        }
    }
}
