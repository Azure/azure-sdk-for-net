// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Marketplace.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Marketplace
{
    // Fix generator bug: generated constructor uses string id but base ResourceData expects ResourceIdentifier
    [CodeGenSuppress("PrivateStoreOfferData", typeof(string), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, BinaryData>), typeof(PrivateStoreOfferResult))]
    public partial class PrivateStoreOfferData
    {
        internal PrivateStoreOfferData(string id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, PrivateStoreOfferResult properties)
            : base(string.IsNullOrEmpty(id) ? null : new ResourceIdentifier(id), name, resourceType, systemData)
        {
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
            Properties = properties;
        }
    }
}
