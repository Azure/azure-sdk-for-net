// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: GA exposed this resource-id overload without the generated Resource suffix.
    public static partial class SecurityCenterExtensions
    {
        /// <summary> Gets an object representing a <see cref="AdvancedThreatProtectionSettingResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="AdvancedThreatProtectionSettingResource"/> object. </returns>
        public static AdvancedThreatProtectionSettingResource GetAdvancedThreatProtectionSetting(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableSecurityCenterArmClient(client).GetAdvancedThreatProtectionSettingResource(id);
        }
    }
}
