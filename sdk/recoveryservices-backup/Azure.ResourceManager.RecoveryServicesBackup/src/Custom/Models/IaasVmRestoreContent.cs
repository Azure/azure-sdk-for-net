// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    public partial class IaasVmRestoreContent
    {
        /// <summary> Gets or sets the disk encryption set ID for the secured VM OS disk. </summary>
        public ResourceIdentifier SecuredVmOSDiskEncryptionSetId
        {
            get => SecuredVmDetails?.SecuredVmOSDiskEncryptionSetId;
            set
            {
                SecuredVmDetails ??= new SecuredVmDetails();
                SecuredVmDetails.SecuredVmOSDiskEncryptionSetId = value;
            }
        }
    }
}
