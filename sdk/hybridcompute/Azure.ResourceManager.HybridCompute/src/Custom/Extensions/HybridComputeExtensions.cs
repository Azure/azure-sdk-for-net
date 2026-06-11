// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.HybridCompute.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.HybridCompute
{
    public static partial class HybridComputeExtensions
    {
        // ----- SubscriptionResource overloads -----
        /// <summary>
        /// Returns a Azure Arc PrivateLinkScope's validation details.
        /// This method was renamed to <see cref="GetValidationDetailsAsync(SubscriptionResource, AzureLocation, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<PrivateLinkScopeValidationDetails>> GetValidationDetailsPrivateLinkScopeAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string privateLinkScopeId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableHybridComputeSubscriptionResource(subscriptionResource).GetValidationDetailsPrivateLinkScopeAsync(location, privateLinkScopeId, cancellationToken);
        }

        /// <summary>
        /// Returns a Azure Arc PrivateLinkScope's validation details.
        /// This method was renamed to <see cref="GetValidationDetails(SubscriptionResource, AzureLocation, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<PrivateLinkScopeValidationDetails> GetValidationDetailsPrivateLinkScope(this SubscriptionResource subscriptionResource, AzureLocation location, string privateLinkScopeId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableHybridComputeSubscriptionResource(subscriptionResource).GetValidationDetailsPrivateLinkScope(location, privateLinkScopeId, cancellationToken);
        }

        /// <summary>
        /// Validates a license.
        /// This method was renamed to <see cref="ValidateLicenseAsync(SubscriptionResource, WaitUntil, HybridComputeLicenseData, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<ArmOperation<HybridComputeLicenseResource>> ValidateLicenseLicenseAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, HybridComputeLicenseData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableHybridComputeSubscriptionResource(subscriptionResource).ValidateLicenseLicenseAsync(waitUntil, data, cancellationToken);
        }

        /// <summary>
        /// Validates a license.
        /// This method was renamed to <see cref="ValidateLicense(SubscriptionResource, WaitUntil, HybridComputeLicenseData, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<HybridComputeLicenseResource> ValidateLicenseLicense(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, HybridComputeLicenseData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableHybridComputeSubscriptionResource(subscriptionResource).ValidateLicenseLicense(waitUntil, data, cancellationToken);
        }

        // ----- ResourceGroupResource overloads -----
        // Backward-compat justification: the GA resource group extension methods exposed ArcSettings-based settings APIs and expand overloads.

        /// <summary>
        /// Updates the base Settings of the target resource.
        /// This method preserves the AutoRest-generated ResourceGroupResource convenience API for backward compatibility.
        /// Use <see cref="HybridComputeSettingsResource.UpdateAsync(ArcSettingsData, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<ArcSettings>> UpdateSettingAsync(this ResourceGroupResource resourceGroupResource, string baseProvider, string baseResourceType, string baseResourceName, string settingsResourceName, ArcSettings arcSettings, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableHybridComputeResourceGroupResource(resourceGroupResource).UpdateSettingAsync(baseProvider, baseResourceType, baseResourceName, settingsResourceName, arcSettings, cancellationToken);
        }

        /// <summary>
        /// Updates the base Settings of the target resource.
        /// This method preserves the AutoRest-generated ResourceGroupResource convenience API for backward compatibility.
        /// Use <see cref="HybridComputeSettingsResource.Update(ArcSettingsData, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<ArcSettings> UpdateSetting(this ResourceGroupResource resourceGroupResource, string baseProvider, string baseResourceType, string baseResourceName, string settingsResourceName, ArcSettings arcSettings, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableHybridComputeResourceGroupResource(resourceGroupResource).UpdateSetting(baseProvider, baseResourceType, baseResourceName, settingsResourceName, arcSettings, cancellationToken);
        }

        /// <summary>
        /// Gets a hybrid machine.
        /// This overload includes a string <paramref name="expand"/> parameter for backward compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<HybridComputeMachineResource>> GetHybridComputeMachineAsync(this ResourceGroupResource resourceGroupResource, string machineName, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableHybridComputeResourceGroupResource(resourceGroupResource).GetHybridComputeMachineAsync(machineName, expand, cancellationToken);
        }

        /// <summary>
        /// Gets a hybrid machine.
        /// This overload includes a string <paramref name="expand"/> parameter for backward compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<HybridComputeMachineResource> GetHybridComputeMachine(this ResourceGroupResource resourceGroupResource, string machineName, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableHybridComputeResourceGroupResource(resourceGroupResource).GetHybridComputeMachine(machineName, expand, cancellationToken);
        }
    }
}
