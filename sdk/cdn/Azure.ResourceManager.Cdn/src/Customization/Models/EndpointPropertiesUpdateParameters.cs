// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Cdn.Models
{
    internal partial class EndpointPropertiesUpdateParameters
    {
        /// <summary> List of keys used to validate the signed URL hashes. </summary>
        [WirePath("urlSigningKeys")]
        public IReadOnlyList<UriSigningKey> UriSigningKeys { get; }
    }
}
