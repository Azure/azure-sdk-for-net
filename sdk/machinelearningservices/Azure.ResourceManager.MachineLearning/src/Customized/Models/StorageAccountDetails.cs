// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class StorageAccountDetails
    {
        // Add these properties back because they are not included in the api version 2025-10-01-preview for compatibility reason.
        /// <summary> Details of user created storage account to be used for the registry. </summary>
        internal UserCreatedStorageAccount UserCreatedStorageAccount { get; set; }
        /// <summary>
        /// Arm ResourceId is in the format "/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Storage/storageAccounts/{StorageAccountName}"
        /// or "/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{AcrName}"
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("userCreatedStorageAccount.armResourceId.resourceId")]
        public ResourceIdentifier ArmResourceId
        {
            get => UserCreatedStorageAccount is null ? default : UserCreatedStorageAccount.ArmResourceId;
            set
            {
                if (UserCreatedStorageAccount is null)
                    UserCreatedStorageAccount = new UserCreatedStorageAccount();
                UserCreatedStorageAccount.ArmResourceId = value;
            }
        }
    }
}
