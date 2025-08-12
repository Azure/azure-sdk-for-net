// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.BotService.Models
{
    public partial class BotServicePrivateLinkResourceData
    {
        /// <summary> Initializes a new instance of <see cref="BotServicePrivateLinkResourceData"/>. </summary>
        public BotServicePrivateLinkResourceData()
        {
            RequiredMembers = new ChangeTrackingList<string>();
            RequiredZoneNames = new ChangeTrackingList<string>();
        }
    }
}
