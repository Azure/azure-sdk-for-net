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
        // Backward-compat justification: preserve the GA subscription extension methods for validating a Private Link Scope.
        /// <summary>
        /// Returns a Azure Arc PrivateLinkScope's validation details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<PrivateLinkScopeValidationDetails>> GetValidationDetailsPrivateLinkScopeAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string privateLinkScopeId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableHybridComputeSubscriptionResource(subscriptionResource).GetValidationDetailsPrivateLinkScopeAsync(location, privateLinkScopeId, cancellationToken);
        }

        /// <summary>
        /// Returns a Azure Arc PrivateLinkScope's validation details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<PrivateLinkScopeValidationDetails> GetValidationDetailsPrivateLinkScope(this SubscriptionResource subscriptionResource, AzureLocation location, string privateLinkScopeId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableHybridComputeSubscriptionResource(subscriptionResource).GetValidationDetailsPrivateLinkScope(location, privateLinkScopeId, cancellationToken);
        }

        // Backward-compat justification: preserve the GA subscription extension methods for validating a license.
        /// <summary>
        /// The operation to validate a license.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<ArmOperation<HybridComputeLicenseResource>> ValidateLicenseLicenseAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, HybridComputeLicenseData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableHybridComputeSubscriptionResource(subscriptionResource).ValidateLicenseLicenseAsync(waitUntil, data, cancellationToken);
        }

        /// <summary>
        /// The operation to validate a license.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<HybridComputeLicenseResource> ValidateLicenseLicense(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, HybridComputeLicenseData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableHybridComputeSubscriptionResource(subscriptionResource).ValidateLicenseLicense(waitUntil, data, cancellationToken);
        }

        // ----- ResourceGroupResource overloads -----
        // Backward-compat justification: preserve the GA resource group extension methods that update settings using ArcSettings.
        /// <summary>
        /// Updates the base Settings of the target resource.
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
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<ArcSettings> UpdateSetting(this ResourceGroupResource resourceGroupResource, string baseProvider, string baseResourceType, string baseResourceName, string settingsResourceName, ArcSettings arcSettings, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableHybridComputeResourceGroupResource(resourceGroupResource).UpdateSetting(baseProvider, baseResourceType, baseResourceName, settingsResourceName, arcSettings, cancellationToken);
        }

        // Backward-compat justification: preserve the GA resource group extension methods that get a machine with a string expand parameter.
        /// <summary>
        /// Retrieves information about the model view or the instance view of a hybrid machine.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<HybridComputeMachineResource>> GetHybridComputeMachineAsync(this ResourceGroupResource resourceGroupResource, string machineName, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableHybridComputeResourceGroupResource(resourceGroupResource).GetHybridComputeMachineAsync(machineName, expand, cancellationToken);
        }

        /// <summary>
        /// Retrieves information about the model view or the instance view of a hybrid machine.
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
