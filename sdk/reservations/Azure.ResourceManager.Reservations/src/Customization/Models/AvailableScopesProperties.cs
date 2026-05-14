// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed AvailableScopesProperties.Scopes as IReadOnlyList<ScopeProperties>.
// The new generator emits IList<T> for the flattened inner SubscriptionScopeProperties; this
// shim restores the read-only collection surface.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Models
{
    [CodeGenSuppress("Scopes")]
    public partial class AvailableScopesProperties
    {
        public IReadOnlyList<ScopeProperties> Scopes
        {
            get
            {
                return Properties is null ? default : (IReadOnlyList<ScopeProperties>)Properties.Scopes;
            }
        }
    }
}
