// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
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

        /// <summary> Indicates the Service Fabric system services for the cluster will run on this node type. This setting cannot be changed once the node type is created. </summary>
        public bool? IsPrimary
        {
            get
            {
                return Properties is null ? default : Properties.IsPrimary;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new ServiceFabricManagedNodeTypeProperties();
                }
                Properties.IsPrimary = value.Value;
            }
        }

        /// <summary> The number of nodes in the node type. **Values:** -1 - Use when auto scale rules are configured or sku.capacity is defined 0 - Not supported &gt;0 - Use for manual scale. </summary>
        public int? VmInstanceCount
        {
            get
            {
                return Properties is null ? default : Properties.VmInstanceCount;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new ServiceFabricManagedNodeTypeProperties();
                }
                Properties.VmInstanceCount = value.Value;
            }
        }
    }
}
