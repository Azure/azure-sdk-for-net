// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Models
{
    // Justification: GA exposed AppliedScopes as a settable IList<string> on
    // ReservationPurchaseContent. The new generator emits a get-only flattened property; this
    // shim restores the GA setter by replacing the underlying collection contents.
    [CodeGenSuppress("AppliedScopes")]
    public partial class ReservationPurchaseContent
    {
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
