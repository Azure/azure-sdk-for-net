// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary>
    /// Provides a compatibility shim for the SecuritySettingResource class.
    /// </summary>
    public partial class SecuritySettingResource
    {
        /// <summary>
        /// Provides a compatibility shim for the CreateResourceIdentifier operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionId">The value preserved for API compatibility.</param>
        /// <param name="settingName">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName settingName)
            => CreateResourceIdentifier(subscriptionId, new Azure.ResourceManager.SecurityCenter.Models.SettingName(settingName.ToString()));
    }
}
