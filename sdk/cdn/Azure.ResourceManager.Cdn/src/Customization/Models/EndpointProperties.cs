// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: The generator does not produce a property for DeepCreatedCustomDomains on this inner model.
    // It is added here so that the flattened property on CdnEndpointData can delegate to it correctly.
    internal partial class EndpointProperties : EndpointPropertiesUpdateParameters
    {
        /// <summary> The custom domains under the endpoint. </summary>
        [WirePath("customDomains")]
        public IReadOnlyList<DeepCreatedCustomDomain> DeepCreatedCustomDomains { get; }
    }
}
