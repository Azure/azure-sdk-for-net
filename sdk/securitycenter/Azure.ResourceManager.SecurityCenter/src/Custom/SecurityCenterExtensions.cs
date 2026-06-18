// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shims do not need public docs.

using System;
using System.ComponentModel;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;

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

            return GetMockableSecurityCenterArmClient(client).GetAdvancedThreatProtectionSetting(id);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SecureScoreControlDetails> GetSecureScoreControlsAsync(this SubscriptionResource subscriptionResource, SecurityScoreODataExpand? expand = default, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityConnectorGovernanceRuleResource GetSecurityConnectorGovernanceRuleResource(this ArmClient client, ResourceIdentifier id)
            => throw new NotSupportedException("This API is no longer supported by the service.");
    }
}
