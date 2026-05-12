// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Security.Models
{
    public partial class PrivateLinkParameters
    {
        public static implicit operator string(PrivateLinkParameters value) => value?.PrivateLinkName;
    }
}
