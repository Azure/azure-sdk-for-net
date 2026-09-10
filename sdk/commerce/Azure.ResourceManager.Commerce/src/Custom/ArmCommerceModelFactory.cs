// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Commerce.Models
{
    // The generated factory overload exposes the base discriminator parameter as a string,
    // but currently discards it when constructing the unknown polymorphic fallback type.
    [CodeGenSuppress("OfferTermInfo", typeof(string), typeof(DateTimeOffset?))]
    public static partial class ArmCommerceModelFactory
    {
        /// <param name="name"> Name of the offer term. </param>
        /// <param name="effectiveOn"> Indicates the date from which the offer term is effective. </param>
        /// <returns> A new <see cref="Models.CommerceOfferTermInfo"/> instance for mocking. </returns>
        public static CommerceOfferTermInfo CommerceOfferTermInfo(string name = default, DateTimeOffset? effectiveOn = default)
        {
            return new UnknownCommerceOfferTermInfo(name is null ? default : new OfferTermInfoName(name), effectiveOn, default);
        }
    }
}
