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
        /// Gets a collection of HybridComputeExtensionValues.
        /// This overload accepts <see cref="AzureLocation"/> for backward compatibility.
        /// Use <see cref="GetHybridComputeExtensionValues(SubscriptionResource, string, string, string)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static HybridComputeExtensionValueCollection GetHybridComputeExtensionValues(this SubscriptionResource subscriptionResource, AzureLocation location, string publisher, string extensionType)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableHybridComputeSubscriptionResource(subscriptionResource).GetHybridComputeExtensionValues(location, publisher, extensionType);
        }

        /// <summary>
        /// Gets an Extension Metadata based on location, publisher, extensionType and version.
        /// This overload accepts <see cref="AzureLocation"/> for backward compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<HybridComputeExtensionValueResource>> GetHybridComputeExtensionValueAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string publisher, string extensionType, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableHybridComputeSubscriptionResource(subscriptionResource).GetHybridComputeExtensionValueAsync(location, publisher, extensionType, version, cancellationToken);
        }

        /// <summary>
        /// Gets an Extension Metadata based on location, publisher, extensionType and version.
        /// This overload accepts <see cref="AzureLocation"/> for backward compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<HybridComputeExtensionValueResource> GetHybridComputeExtensionValue(this SubscriptionResource subscriptionResource, AzureLocation location, string publisher, string extensionType, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableHybridComputeSubscriptionResource(subscriptionResource).GetHybridComputeExtensionValue(location, publisher, extensionType, version, cancellationToken);
        }

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

        /// <summary>
        /// Gets a hybrid machine.
        /// This overload includes a string <paramref name="expand"/> parameter for backward compatibility.
        /// Use <see cref="GetHybridComputeMachineAsync(ResourceGroupResource, string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<HybridComputeMachineResource>> GetHybridComputeMachineAsync(this ResourceGroupResource resourceGroupResource, string machineName, string expand, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableHybridComputeResourceGroupResource(resourceGroupResource).GetHybridComputeMachineAsync(machineName, expand, cancellationToken);
        }

        /// <summary>
        /// Gets a hybrid machine.
        /// This overload includes a string <paramref name="expand"/> parameter for backward compatibility.
        /// Use <see cref="GetHybridComputeMachine(ResourceGroupResource, string, InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<HybridComputeMachineResource> GetHybridComputeMachine(this ResourceGroupResource resourceGroupResource, string machineName, string expand, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableHybridComputeResourceGroupResource(resourceGroupResource).GetHybridComputeMachine(machineName, expand, cancellationToken);
        }
    }
}
