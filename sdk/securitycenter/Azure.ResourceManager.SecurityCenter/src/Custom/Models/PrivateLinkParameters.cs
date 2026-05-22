// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated private-link forwarding helpers pass this modeled parameter to protocol methods expecting the raw name.
    public partial class PrivateLinkParameters
    {
        /// <summary> Converts the parameter model to the private link name. </summary>
        /// <param name="value"> The private link parameters. </param>
        public static implicit operator string(PrivateLinkParameters value) => value?.PrivateLinkName;
    }
}
