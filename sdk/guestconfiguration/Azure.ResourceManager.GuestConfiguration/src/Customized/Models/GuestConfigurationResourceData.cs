// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.GuestConfiguration.Models
{
    public partial class GuestConfigurationResourceData
    {
        /// <summary> Initializes a new instance of <see cref="GuestConfigurationResourceData"/>. </summary>
        public GuestConfigurationResourceData()
        {
        }

        /// <summary> Azure Resource Manager metadata containing createdBy and modifiedBy information. </summary>
        [WirePath("systemData")]
        public SystemData SystemData { get; }
    }
}
