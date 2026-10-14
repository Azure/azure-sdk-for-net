// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ArcData.Models
{
    public partial class AvailabilityGroupCreateUpdateConfiguration
    {
        /// <summary> Specifies whether the availability group supports failover for database health conditions. </summary>
        [CodeGenMember("DBFailover")]
        public DbFailover? DbFailover { get; set; }
    }
}
