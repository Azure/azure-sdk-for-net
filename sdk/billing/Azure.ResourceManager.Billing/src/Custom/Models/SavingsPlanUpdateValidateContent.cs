// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat POCO restored from GA 1.2.2. The new MPG generator renamed this
    // payload to SavingsPlanUpdateValidateRequest; this aggregate is preserved so
    // existing GA call sites continue to compile. The Resource overload accepting
    // this type forwards to the new generated overload.
    public partial class SavingsPlanUpdateValidateContent
    {
        public SavingsPlanUpdateValidateContent() { }

        public IList<SavingsPlanUpdateRequestProperties> Benefits { get; } = new List<SavingsPlanUpdateRequestProperties>();
    }
}
