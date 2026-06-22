// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: bridge the GA MachineLearningWorkspacePatch model to the latest TypeSpec-generated
    // WorkspacePatch model used by the generated update operation.
    public partial class MachineLearningWorkspacePatch
    {
        /// <summary> Converts a legacy workspace patch to the generated update type. </summary>
        public static explicit operator WorkspacePatch(MachineLearningWorkspacePatch patch)
        {
            if (patch is null)
            {
                return null;
            }

            var result = new WorkspacePatch
            {
                Sku = patch.Sku,
                Identity = patch.Identity,
                Description = patch.Description,
                FriendlyName = patch.FriendlyName,
                ImageBuildCompute = patch.ImageBuildCompute,
                PrimaryUserAssignedIdentity = patch.PrimaryUserAssignedIdentity,
                ServerlessComputeSettings = patch.ServerlessComputeSettings,
                PublicNetworkAccessType = patch.PublicNetworkAccessType,
                ApplicationInsights = patch.ApplicationInsights,
                ContainerRegistry = patch.ContainerRegistry,
                FeatureStoreSettings = patch.FeatureStoreSettings,
                ManagedNetwork = patch.ManagedNetwork,
                EnableDataIsolation = patch.EnableDataIsolation
            };
            foreach (var tag in patch.Tags)
            {
                result.Tags[tag.Key] = tag.Value;
            }
            return result;
        }
    }
}
