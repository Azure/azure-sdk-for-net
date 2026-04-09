// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: The generator's FlattenPropertyVisitor does not generate a setter for collection-type
    // flattened properties (see BuildSetterForPropertyFlatten in PropertyHelpers.cs). A hidden setter for
    // UriSigningKeys is added here for deserialization backward compatibility with the previous SDK.
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
