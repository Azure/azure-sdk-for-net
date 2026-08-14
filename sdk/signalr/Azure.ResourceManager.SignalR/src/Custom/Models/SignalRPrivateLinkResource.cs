// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.SignalR.Models
{
    public partial class SignalRPrivateLinkResource : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="SignalRPrivateLinkResource"/>. </summary>
        public SignalRPrivateLinkResource()
        {
        }

        /// <summary> Group Id of the private link resource. </summary>
        [WirePath("properties.groupId")]
        public string GroupId
        {
            get
            {
                return Properties.GroupId;
            }
            set
            {
                if (Properties != null)
                {
                    Properties.GroupId = value;
                }
            }
        }
    }
}
