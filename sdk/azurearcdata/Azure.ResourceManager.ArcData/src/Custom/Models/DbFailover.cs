// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ArcData.Models
{
    /// <summary> Specifies whether the availability group supports failover for database health conditions. </summary>
    [CodeGenType("DBFailover")]
    public enum DbFailover
    {
        /// <summary> ON. </summary>
        On,
        /// <summary> OFF. </summary>
        Off
    }
}
