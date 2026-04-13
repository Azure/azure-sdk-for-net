// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Cdn.Models;

namespace Azure.ResourceManager.Cdn
{
    // Customization: This file customizes the CdnEndpointData resource data class to maintain backward API compatibility with the previous SDK.
    // Reason 1: CustomDomains property — The old SDK exposed this property as IReadOnlyList<CdnCustomDomainData>,
    // but the TypeSpec generator changed it to DeepCreatedCustomDomains (type DeepCreatedCustomDomain).
    // A hidden property (EditorBrowsable.Never) with the old type is preserved to avoid a breaking change.
    // Reason 2: UriSigningKeys setter — The generator's FlattenPropertyVisitor does not generate a setter for
    // flattened collection properties, but the old SDK's deserialization relies on the setter. A hidden setter is added for deserialization compatibility.
    public partial class CdnEndpointData
    {
        /// <summary> The custom domains under the endpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<CdnCustomDomainData> CustomDomains { get; }

        /// <summary> List of keys used to validate the signed URL hashes. </summary>
        [WirePath("properties.urlSigningKeys")]
        public IList<UriSigningKey> UriSigningKeys
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new EndpointProperties();
                }
                return Properties.UriSigningKeys;
            }
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                if (Properties is null)
                {
                    Properties = new EndpointProperties();
                }
                var list = Properties.UriSigningKeys;
                list.Clear();
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        list.Add(item);
                    }
                }
            }
        }
    }
}
