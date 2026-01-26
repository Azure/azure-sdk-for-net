// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    public partial class ServiceFabricManagedUnsupportedVmSize : ResourceData
    {
        /// <summary> VM Size name. </summary>
        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMemberAttribute("ServiceFabricManagedVmSize")]
        public string VmSize
        {
            get
            {
                return Properties.Size;
            }
        }
    }
}
