// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.Reservations.Models
{
    public partial class ReservationPurchaseContent
    {
        // AppliedScopes is a property in PurchaseRequestProperties which is also a flattened property in ReservationPurchaseContent.
        // We flattened the AppliedScopes property to ReservationPurchaseContent for better usability.
        // And the wrapped property PurchaseRequestProperties.AppliedScopes changed from bare Get Set to only Get within an internal partial class.
        // So we can provide a public setter in ReservationPurchaseContent while keeping the internal class encapsulation.
        /// <summary> List of the subscriptions that the benefit will be applied. Do not specify if AppliedScopeType is Shared. This property will be deprecated and replaced by appliedScopeProperties instead for Single AppliedScopeType. </summary>
        [Obsolete("This property will be deprecated and replaced by appliedScopeProperties instead for Single AppliedScopeType.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
