// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HorizonDB.Models
{
    public abstract partial class HorizonDBComputeModelCapability
    {
        /// <summary> Gets the compute model represented by these capabilities, including unrecognized service values. </summary>
        [CodeGenMember("Type")]
        public PoolComputeModelType Type { get; internal set; }
    }
}
