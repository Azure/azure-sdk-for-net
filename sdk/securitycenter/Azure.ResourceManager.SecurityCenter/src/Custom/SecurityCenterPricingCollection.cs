// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    // Previous GA packages were generated from an older pricing API version whose list operation did
    // not have a $filter query parameter. The current TypeSpec input is based on a newer operation
    // that adds optional $filter. Keep the generated GetAll(string filter = null, ...) overload for
    // spec alignment, and preserve the GA token-only no-filter call pattern below. The token is
    // intentionally required; if it had a default value, collection.GetAll() would be ambiguous
    // between the generated filter overload and this custom overload.
    public partial class SecurityCenterPricingCollection
    {
        /// <summary> Lists Microsoft Defender for Cloud pricing configurations of the scope. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityCenterPricingResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityCenterPricingResource> GetAllAsync(CancellationToken cancellationToken)
        {
            // Keep the GA token-only no-filter call working. The token is required here to avoid
            // ambiguity with the generated filter overload's optional parameters.
            return GetAllAsync(filter: null, cancellationToken: cancellationToken);
        }

        /// <summary> Lists Microsoft Defender for Cloud pricing configurations of the scope. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityCenterPricingResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityCenterPricingResource> GetAll(CancellationToken cancellationToken)
        {
            // Keep the GA token-only no-filter call working. The token is required here to avoid
            // ambiguity with the generated filter overload's optional parameters.
            return GetAll(filter: null, cancellationToken: cancellationToken);
        }
    }
}
