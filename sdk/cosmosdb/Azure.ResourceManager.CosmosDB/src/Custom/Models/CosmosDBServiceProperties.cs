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
        // 1.4.0 GA exposed a public parameterless ctor; MPG now emits only the discriminator-taking
        // public ctor. Re-add the parameterless ctor and chain to the generated one (so the generated
        // body initializes _additionalBinaryDataProperties without this customization touching the field).
        /// <summary> Initializes a new instance of <see cref="CosmosDBServiceProperties"/>. </summary>
        public CosmosDBServiceProperties() : this(default(CosmosDBServiceType))
        {
        }
    }
}
