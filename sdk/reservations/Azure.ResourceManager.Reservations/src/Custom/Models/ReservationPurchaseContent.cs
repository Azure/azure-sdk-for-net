// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Reservations.Models
{
    public partial class ReservationPurchaseContent
    {
        // The generator only produces a get-only collection by default; customization preserves the GA setter behavior.
        /// <summary> List of the subscriptions that the benefit will be applied. Do not specify if AppliedScopeType is Shared. This property will be deprecated and replaced by appliedScopeProperties instead for Single AppliedScopeType. </summary>
        public IList<string> AppliedScopes
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new PurchaseRequestProperties();
                }
                return Properties.AppliedScopes;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new PurchaseRequestProperties();
                }
                Properties.AppliedScopes.Clear();
                if (value != null)
                {
                    foreach (string item in value)
                    {
                        Properties.AppliedScopes.Add(item);
                    }
                }
            }
        }
    }
}
