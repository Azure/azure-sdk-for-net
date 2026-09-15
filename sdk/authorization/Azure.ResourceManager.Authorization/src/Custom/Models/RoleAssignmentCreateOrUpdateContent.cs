// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Authorization.Models
{
    public partial class RoleAssignmentCreateOrUpdateContent
    {
        // The generator emits getter-only flattened properties even though the generated inner properties are settable.
        // These forwarding setters restore the shipped mutable surface without changing inner storage or serialization: https://github.com/Azure/azure-sdk-for-net/issues/61114.

        /// <summary> The principal type of the assigned principal ID. </summary>
        [WirePath("properties.principalType")]
        public RoleManagementPrincipalType? PrincipalType
        {
            get => Properties.PrincipalType;
            set => Properties.PrincipalType = value;
        }

        /// <summary> Description of role assignment. </summary>
        [WirePath("properties.description")]
        public string Description
        {
            get => Properties.Description;
            set => Properties.Description = value;
        }

        /// <summary> The conditions on the role assignment. This limits the resources it can be assigned to. e.g.: @Resource[Microsoft.Storage/storageAccounts/blobServices/containers:ContainerName] StringEqualsIgnoreCase 'foo_storage_container'. </summary>
        [WirePath("properties.condition")]
        public string Condition
        {
            get => Properties.Condition;
            set => Properties.Condition = value;
        }

        /// <summary> Version of the condition. Currently the only accepted value is '2.0'. </summary>
        [WirePath("properties.conditionVersion")]
        public string ConditionVersion
        {
            get => Properties.ConditionVersion;
            set => Properties.ConditionVersion = value;
        }

        /// <summary> Id of the delegated managed identity resource. </summary>
        [WirePath("properties.delegatedManagedIdentityResourceId")]
        public ResourceIdentifier DelegatedManagedIdentityResourceId
        {
            get => Properties.DelegatedManagedIdentityResourceId;
            set => Properties.DelegatedManagedIdentityResourceId = value;
        }
    }
}
