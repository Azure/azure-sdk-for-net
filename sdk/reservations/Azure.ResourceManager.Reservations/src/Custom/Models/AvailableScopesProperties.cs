// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Reservations.Models
{
    // Justification: GA exposed AvailableScopesProperties.Scopes as IReadOnlyList<ScopeProperties>.
    // The new generator emits IList<T> for the flattened inner SubscriptionScopeProperties; this
    // shim restores the read-only collection surface.
    public partial class AvailableScopesProperties
    {
        /// <summary> Gets the scopes. </summary>
        public IReadOnlyList<ScopeProperties> Scopes
        {
            get
            {
                return Properties?.Scopes as IReadOnlyList<ScopeProperties>;
            }
        }
    }
}
