// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file customizes the UriSigningKeys property of CdnEndpointPatch for backward API compatibility with the previous SDK.
    // Reason: The generator's FlattenPropertyVisitor does not generate a setter for flattened collection properties,
    // but the old SDK's deserialization requires the setter to be present. A getter/setter implementation is manually added here,
    // bridging through Properties.UriSigningKeys. The setter is marked as EditorBrowsable.Never to remain hidden but maintain deserialization compatibility.
    public partial class CdnEndpointPatch
    {
        /// <summary> List of keys used to validate the signed URL hashes. </summary>
        [WirePath("properties.urlSigningKeys")]
        public IList<UriSigningKey> UriSigningKeys
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new EndpointPropertiesUpdateParameters();
                }
                return Properties.UriSigningKeys;
            }
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                if (Properties is null)
                {
                    Properties = new EndpointPropertiesUpdateParameters();
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
