// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class NetworkCloudVirtualMachinePatch
    {
        /// <summary> The credentials used to login to the image repository that has access to the specified image. </summary>
        [CodeGenMember("VmImageRepositoryCredentials")]
        public ImageRepositoryCredentials VmImageRepositoryCredentials
        {
            get => Properties is null ? null : NetworkCloudPatchCompatibility.ToClassic(Properties.VmImageRepositoryCredentials);
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachinePatchProperties();
                }
                Properties.VmImageRepositoryCredentials = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }
    }
}
