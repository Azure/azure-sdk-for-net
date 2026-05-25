// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: GA exposed the create operation on the singleton resource; the current generator emits it as Update.
    public partial class AdvancedThreatProtectionSettingResource
    {
        /// <summary> Creates or updates the Advanced Threat Protection settings on a specified resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Advanced Threat Protection Settings. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation<AdvancedThreatProtectionSettingResource>> CreateOrUpdateAsync(WaitUntil waitUntil, AdvancedThreatProtectionSettingData data, CancellationToken cancellationToken = default)
        {
            return UpdateAsync(waitUntil, data, cancellationToken);
        }

        /// <summary> Creates or updates the Advanced Threat Protection settings on a specified resource. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Advanced Threat Protection Settings. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<AdvancedThreatProtectionSettingResource> CreateOrUpdate(WaitUntil waitUntil, AdvancedThreatProtectionSettingData data, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, data, cancellationToken);
        }
    }
}
