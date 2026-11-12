// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    [CodeGenSerialization(nameof(UserAssignedIdentityClientId), "userAssignedIdentityClientId")]
    public partial class ContainerInstanceAzureFileVolume
    {
        // Preserves the GA property and wire field independently from UserManagedIdentityClientId.
        /// <summary> The client id of the user-assigned managed identity that has access to the Azure File share. </summary>
        public string UserAssignedIdentityClientId { get; set; }
    }
}
