// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.WebPubSub.Models
{
    public partial class WebPubSubPrivateLink : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="WebPubSubPrivateLink"/>. </summary>
        public WebPubSubPrivateLink()
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
            set     // This setter is intentionally added for backward compatibility.
            {
                if (Properties != null)
                {
                    Properties.GroupId = value;
                }
            }
        }
    }
}
