// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Reservations.Models
{
    [CodeGenSuppress("AppliedScopes")]
    public partial class ReservationPurchaseContent
    {
        /// <summary> Initializes a new instance of <see cref="ReservationPurchaseContent"/>. </summary>
        public ReservationPurchaseContent()
        {
            AppliedScopes = new ChangeTrackingList<string>();
        }
        /// <summary> List of the subscriptions that the benefit will be applied. Do not specify if AppliedScopeType is Shared. This property will be deprecated and replaced by appliedScopeProperties instead for Single AppliedScopeType. </summary>
        public IList<string> AppliedScopes { get; set; }
    }
}
