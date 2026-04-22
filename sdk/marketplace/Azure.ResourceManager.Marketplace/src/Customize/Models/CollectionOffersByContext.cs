// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Marketplace.Models
{
    // Backward-compat shim: old API exposed Value as IReadOnlyList<PrivateStoreOfferResult>,
    // but the generator produces IList<PrivateStoreOfferResult> from the flattened inner model.
    // Suppress generated property and expose as IReadOnlyList for backward compatibility.
    [CodeGenSuppress("Value")]
    public partial class CollectionOffersByContext
    {
        /// <summary> Gets the Value. </summary>
        public IReadOnlyList<PrivateStoreOfferResult> Value
        {
            get
            {
                return Offers is null ? default : (IReadOnlyList<PrivateStoreOfferResult>)Offers.Value;
            }
        }
    }
}
