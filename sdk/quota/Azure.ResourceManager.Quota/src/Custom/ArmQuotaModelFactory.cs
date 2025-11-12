// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Quota.Models
{
    public partial class ArmQuotaModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties" />. </summary>
        /// <param name="displayName"> Display name of the GroupQuota entity. </param>
        /// <param name="provisioningState"> Provisioning state of the operation. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GroupQuotasEntityProperties GroupQuotasEntityProperties(string displayName, QuotaRequestStatus? provisioningState)
        {
            return GroupQuotasEntityProperties(displayName: displayName, groupType: default, provisioningState: provisioningState);
        }
    }
}
