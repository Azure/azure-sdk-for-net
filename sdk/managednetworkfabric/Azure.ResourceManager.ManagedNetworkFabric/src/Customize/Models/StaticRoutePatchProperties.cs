// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // TypeSpec does not mark prefix as read-only, but generation emits a get-only property
    // because it is a required constructor parameter. Restore the shipped setter for compatibility.
    public partial class StaticRoutePatchProperties
    {
        /// <summary> Prefix of the route. </summary>
        public string Prefix { get; set; }
    }
}
