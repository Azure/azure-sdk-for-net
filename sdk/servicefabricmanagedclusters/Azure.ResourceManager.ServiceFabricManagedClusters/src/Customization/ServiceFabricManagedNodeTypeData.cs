// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    public partial class ServiceFabricManagedNodeTypeData : ResourceData
    {
        /// <summary> The list of user identities associated with the virtual machine scale set under the node type. Each entry will be an ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'. </summary>
        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("VmManagedIdentityUserAssignedIdentities")]
        public IList<ResourceIdentifier> UserAssignedIdentities
        {
            get
            {
                return Properties is null ? default : Properties.VmManagedIdentityUserAssignedIdentities;
            }
        }
    }
}
