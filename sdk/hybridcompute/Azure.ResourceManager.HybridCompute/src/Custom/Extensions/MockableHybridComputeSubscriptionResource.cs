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
        // Backward-compat justification: the GA mockable subscription APIs exposed the GetValidationDetailsPrivateLinkScope legacy name.
        /// <summary>
        /// Returns a Azure Arc PrivateLinkScope's validation details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PrivateLinkScopeValidationDetails>> GetValidationDetailsPrivateLinkScopeAsync(AzureLocation location, string privateLinkScopeId, CancellationToken cancellationToken = default)
            => GetValidationDetailsAsync(location, privateLinkScopeId, cancellationToken);

        /// <summary>
        /// Returns a Azure Arc PrivateLinkScope's validation details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PrivateLinkScopeValidationDetails> GetValidationDetailsPrivateLinkScope(AzureLocation location, string privateLinkScopeId, CancellationToken cancellationToken = default)
            => GetValidationDetails(location, privateLinkScopeId, cancellationToken);

        // Backward-compat justification: the GA mockable subscription APIs exposed the ValidateLicenseLicense legacy name.
        /// <summary>
        /// The operation to validate a license.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<HybridComputeLicenseResource>> ValidateLicenseLicenseAsync(WaitUntil waitUntil, HybridComputeLicenseData data, CancellationToken cancellationToken = default)
            => ValidateLicenseAsync(waitUntil, data, cancellationToken);

        /// <summary>
        /// The operation to validate a license.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<HybridComputeLicenseResource> ValidateLicenseLicense(WaitUntil waitUntil, HybridComputeLicenseData data, CancellationToken cancellationToken = default)
            => ValidateLicense(waitUntil, data, cancellationToken);
    }
}
