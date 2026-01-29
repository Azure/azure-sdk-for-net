// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class RegistryAcrDetails
    {
        // Add these properties back because they are not included in the api version 2025-10-01-preview for compatibility reason.
        /// <summary> Details of user created ACR account to be used for the Registry. </summary>
        internal UserCreatedAcrAccount UserCreatedAcrAccount { get; set; }
        /// <summary>
        /// Arm ResourceId is in the format "/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Storage/storageAccounts/{StorageAccountName}"
        /// or "/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{AcrName}"
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("userCreatedAcrAccount.armResourceId.resourceId")]
        public ResourceIdentifier ArmResourceId
        {
            get => UserCreatedAcrAccount is null ? default : UserCreatedAcrAccount.ArmResourceId;
            set
            {
                if (UserCreatedAcrAccount is null)
                    UserCreatedAcrAccount = new UserCreatedAcrAccount();
                UserCreatedAcrAccount.ArmResourceId = value;
            }
        }
    }
}
