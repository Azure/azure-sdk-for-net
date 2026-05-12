// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.HybridCompute.Models;

namespace Azure.ResourceManager.HybridCompute.Mocking
{
    public partial class MockableHybridComputeSubscriptionResource
    {
        /// <summary>
        /// Gets a collection of HybridComputeExtensionValues.
        /// This overload accepts <see cref="AzureLocation"/> for backward compatibility.
        /// Use <see cref="GetHybridComputeExtensionValues(string, string, string)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual HybridComputeExtensionValueCollection GetHybridComputeExtensionValues(AzureLocation location, string publisher, string extensionType)
            => GetHybridComputeExtensionValues(location.ToString(), publisher, extensionType);

        /// <summary>
        /// Gets an Extension Metadata based on location, publisher, extensionType and version.
        /// This overload accepts <see cref="AzureLocation"/> for backward compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<HybridComputeExtensionValueResource>> GetHybridComputeExtensionValueAsync(AzureLocation location, string publisher, string extensionType, string version, CancellationToken cancellationToken = default)
            => GetHybridComputeExtensionValueAsync(location.ToString(), publisher, extensionType, version, cancellationToken);

        /// <summary>
        /// Gets an Extension Metadata based on location, publisher, extensionType and version.
        /// This overload accepts <see cref="AzureLocation"/> for backward compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<HybridComputeExtensionValueResource> GetHybridComputeExtensionValue(AzureLocation location, string publisher, string extensionType, string version, CancellationToken cancellationToken = default)
            => GetHybridComputeExtensionValue(location.ToString(), publisher, extensionType, version, cancellationToken);

        /// <summary>
        /// Returns a Azure Arc PrivateLinkScope's validation details.
        /// This method was renamed to <see cref="GetValidationDetailsAsync(AzureLocation, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PrivateLinkScopeValidationDetails>> GetValidationDetailsPrivateLinkScopeAsync(AzureLocation location, string privateLinkScopeId, CancellationToken cancellationToken = default)
            => GetValidationDetailsAsync(location, privateLinkScopeId, cancellationToken);

        /// <summary>
        /// Returns a Azure Arc PrivateLinkScope's validation details.
        /// This method was renamed to <see cref="GetValidationDetails(AzureLocation, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PrivateLinkScopeValidationDetails> GetValidationDetailsPrivateLinkScope(AzureLocation location, string privateLinkScopeId, CancellationToken cancellationToken = default)
            => GetValidationDetails(location, privateLinkScopeId, cancellationToken);

        /// <summary>
        /// Validates a license.
        /// This method was renamed to <see cref="ValidateLicenseAsync(WaitUntil, HybridComputeLicenseData, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<HybridComputeLicenseResource>> ValidateLicenseLicenseAsync(WaitUntil waitUntil, HybridComputeLicenseData data, CancellationToken cancellationToken = default)
            => ValidateLicenseAsync(waitUntil, data, cancellationToken);

        /// <summary>
        /// Validates a license.
        /// This method was renamed to <see cref="ValidateLicense(WaitUntil, HybridComputeLicenseData, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<HybridComputeLicenseResource> ValidateLicenseLicense(WaitUntil waitUntil, HybridComputeLicenseData data, CancellationToken cancellationToken = default)
            => ValidateLicense(waitUntil, data, cancellationToken);
    }
}
