// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Cdn.Models
{
    internal partial class EndpointProperties : EndpointPropertiesUpdateParameters
    {
        /// <summary> The custom domains under the endpoint. </summary>
        [WirePath("customDomains")]
        public IReadOnlyList<DeepCreatedCustomDomain> DeepCreatedCustomDomains { get; }
    }
}
