// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class NetworkCloudClusterManagerPatch
    {
        // The flattened name is synthesized after TypeSpec naming customizations; match the create/read model's RolloutRing property.
        /// <summary> The relative ordering group used to apply software updates to associated clusters. The minimum accepted value is 1; the service enforces the upper bound currently in effect, which may change over time. </summary>
        [CodeGenMember("ClusterManagerPatchRolloutRing")]
        public int? RolloutRing
        {
            get => Properties is null ? default : Properties.RolloutRing;
            set
            {
                if (Properties is null)
                {
                    Properties = new ClusterManagerPatchProperties();
                }
                Properties.RolloutRing = value;
            }
        }
    }
}
