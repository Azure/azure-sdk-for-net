// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Security.Models
{
    // Generated private-link forwarding helpers pass this modeled parameter to protocol methods expecting the raw name.
    public partial class PrivateLinkParameters
    {
        public static implicit operator string(PrivateLinkParameters value) => value?.PrivateLinkName;
    }
}
