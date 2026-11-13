// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.SignalR.Models
{
    internal partial class SignalRPrivateLinkResourceProperties
    {
        /// <summary> Group Id of the private link resource. </summary>
        [WirePath("groupId")]
        public string GroupId { get; set; }
    }
}
