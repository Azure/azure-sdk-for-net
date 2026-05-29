// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overload for GA 1.2.2 callers that pass SavingsPlanUpdateValidateContent.
    // The new MPG generator renamed the payload to SavingsPlanUpdateValidateRequest; this shim
    // translates the GA aggregate to the generated request type and forwards.
    public partial class BillingSavingsPlanModelResource
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="SavingsPlanUpdateValidateContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SavingsPlanValidateResult>> ValidateUpdateByBillingAccountAsync(SavingsPlanUpdateValidateContent content, CancellationToken cancellationToken = default)
        {
            var request = new SavingsPlanUpdateValidateRequest();
            if (content != null)
            {
                foreach (var b in content.Benefits)
                {
                    request.Benefits.Add(b);
                }
            }
            return await ValidateUpdateByBillingAccountAsync(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="SavingsPlanUpdateValidateContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SavingsPlanValidateResult> ValidateUpdateByBillingAccount(SavingsPlanUpdateValidateContent content, CancellationToken cancellationToken = default)
        {
            var request = new SavingsPlanUpdateValidateRequest();
            if (content != null)
            {
                foreach (var b in content.Benefits)
                {
                    request.Benefits.Add(b);
                }
            }
            return ValidateUpdateByBillingAccount(request, cancellationToken);
        }
    }
}
