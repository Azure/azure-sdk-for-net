// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
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
                return (IList<UriSigningKey>)Properties.UriSigningKeys;
            }
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                if (Properties is null)
                {
                    Properties = new EndpointPropertiesUpdateParameters();
                }
                var list = (IList<UriSigningKey>)Properties.UriSigningKeys;
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
