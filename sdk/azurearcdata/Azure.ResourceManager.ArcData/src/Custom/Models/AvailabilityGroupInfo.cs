// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ArcData.Models
{
    public partial class AvailabilityGroupInfo
    {
        /// <summary> Specifies whether the availability group supports failover for database health conditions. </summary>
        [CodeGenMember("DBFailover")]
        public bool? DbFailover { get; set; }
    }
}
