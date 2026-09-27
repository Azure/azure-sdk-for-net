// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class NetworkCloudVirtualMachinePatch
    {
        /// <summary> The credentials used to login to the image repository that has access to the specified image. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageRepositoryCredentials VmImageRepositoryCredentials
        {
            get => NetworkCloudPatchCompatibility.ToClassic(VmImageRepositoryCredentialsPatch);
            set
            {
                VmImageRepositoryCredentialsPatch = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }
    }
}
