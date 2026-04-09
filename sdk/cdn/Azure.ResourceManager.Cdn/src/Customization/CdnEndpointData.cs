// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Cdn.Models;

namespace Azure.ResourceManager.Cdn
{
    // Customization:
    // 1. CustomDomains (IReadOnlyList<CdnCustomDomainData>): The previous SDK exposed this property with type
    //    CdnCustomDomainData, but the new generator produces DeepCreatedCustomDomains with type DeepCreatedCustomDomain.
    //    This hidden property is kept for backward compatibility.
    // 2. UriSigningKeys setter: The generator's FlattenPropertyVisitor does not generate a setter for collection-type
    //    flattened properties (see BuildSetterForPropertyFlatten in PropertyHelpers.cs). A hidden setter is added
    //    here for deserialization backward compatibility with the previous SDK.
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
