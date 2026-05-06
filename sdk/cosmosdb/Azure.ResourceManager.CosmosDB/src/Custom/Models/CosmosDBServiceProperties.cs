// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The new generator emits CosmosDBServiceProperties with a public constructor
    // that takes the CosmosDBServiceType discriminator argument. The historical
    // public surface only exposed a parameterless constructor — the discriminator
    // was set internally by each subclass. Suppress the discriminator-injected
    // ctor and re-introduce the parameterless one so subclasses (and downstream
    // consumers) can mock/instantiate without supplying a discriminator value.
    [CodeGenSuppress("CosmosDBServiceProperties", typeof(CosmosDBServiceType))]
    public partial class CosmosDBServiceProperties
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBServiceProperties"/>. </summary>
        public CosmosDBServiceProperties()
        {
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }
    }
}
