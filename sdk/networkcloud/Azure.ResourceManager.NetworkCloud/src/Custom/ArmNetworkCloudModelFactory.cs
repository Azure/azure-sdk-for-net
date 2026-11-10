// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // The generated factory retains the synthesized flattened name even when CodeGenMember renames the property.
    [CodeGenSuppress("NetworkCloudClusterManagerPatch", typeof(ManagedServiceIdentity), typeof(IDictionary<string, string>), typeof(int?))]
    public static partial class ArmNetworkCloudModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch"/>. </summary>
        /// <param name="identity"> The identity for the resource. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="rolloutRing"> The relative ordering group used to apply software updates to associated clusters. </param>
        /// <returns> A new <see cref="Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch"/> instance for mocking. </returns>
        public static NetworkCloudClusterManagerPatch NetworkCloudClusterManagerPatch(ManagedServiceIdentity identity = default, IDictionary<string, string> tags = default, int? rolloutRing = default)
        {
            return new NetworkCloudClusterManagerPatch(
                identity,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                rolloutRing is null ? default : new ClusterManagerPatchProperties(rolloutRing, default),
                default);
        }
    }
}
