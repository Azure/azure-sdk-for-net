// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.CognitiveServices;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices.Models
{
    public partial class CognitiveServicesPrivateLinkResourceProperties
    {
        /// <summary> Initializes a new instance of <see cref="CognitiveServicesPrivateLinkResourceProperties"/>. </summary>
        public CognitiveServicesPrivateLinkResourceProperties()
        {
            RequiredMembers = new ChangeTrackingList<string>();
            RequiredZoneNames = new ChangeTrackingList<string>();
        }
    }
}
