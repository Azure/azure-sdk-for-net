// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.DataBox.Models
{
    /// <summary> Managed identity properties. </summary>
    [CodeGenSuppress("UserAssignedResourceId")]
    public partial class DataBoxManagedIdentity
    {
        /// <summary> Arm resource id for user assigned identity to be used to fetch MSI token. </summary>
        public ResourceIdentifier UserAssignedIdentityId
        {
            get => UserAssigned is null ? default : UserAssigned.ResourceId;
            set
            {
                if (UserAssigned is null)
                    UserAssigned = new DataBoxUserAssignedIdentity();
                UserAssigned.ResourceId = value;
            }
        }
    }
}
