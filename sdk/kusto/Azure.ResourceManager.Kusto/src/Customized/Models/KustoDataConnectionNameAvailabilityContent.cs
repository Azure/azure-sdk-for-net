// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class KustoDataConnectionNameAvailabilityContent
    {
        // The check-name request `type` field is a constant discriminator in TypeSpec; exposing the GA
        // resource-type enum makes the generated constructor require it. This restores the GA
        // single-argument `(string name)` constructor shipped by the previous AutoRest SDK.

        /// <summary> Initializes a new instance of <see cref="KustoDataConnectionNameAvailabilityContent"/>. </summary>
        /// <param name="name"> Data connection name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public KustoDataConnectionNameAvailabilityContent(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
