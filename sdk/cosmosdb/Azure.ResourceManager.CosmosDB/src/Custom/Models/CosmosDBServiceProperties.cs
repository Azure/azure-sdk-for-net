// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    public partial class CosmosDBServiceProperties
    {
        // Restore the historical parameterless public constructor that the AutoRest-generated
        // SDK exposed. The MPG generator now only emits a discriminator-taking public ctor.
        // Chain to it with `default(CosmosDBServiceType)` so the generated ctor body handles
        // initializing the `_additionalBinaryDataProperties` backing field — that way this
        // customization does NOT touch the generated field directly (which would be fragile if
        // the generator ever renames or relocates it).
        /// <summary> Initializes a new instance of <see cref="CosmosDBServiceProperties"/>. </summary>
        public CosmosDBServiceProperties() : this(default(CosmosDBServiceType))
        {
        }
    }
}
