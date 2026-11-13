// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.WebPubSub.Models
{
    /// <summary> Describes the properties of a resource type that has been onboarded to private link service. </summary>
    public partial class ShareablePrivateLinkProperties
    {
        /// <summary> The resource provider type for the resource that has been onboarded to private link service. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ShareablePrivateLinkPropertiesType { get => Type; set => Type = value; }
    }
}
