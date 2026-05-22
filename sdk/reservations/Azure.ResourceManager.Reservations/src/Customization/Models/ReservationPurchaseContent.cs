// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Models
{
    [CodeGenSuppress("AppliedScopes")]
    public partial class ReservationPurchaseContent
    {
        // The generator can project appliedScopes?: string[] as IList<string>, but it emits a
        // get-only collection by default; customization preserves the GA setter behavior.
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
