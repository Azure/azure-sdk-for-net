// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.MultiService.Combined.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MultiService.Combined
{
    // The cross-language Spector contract requires an empty properties object, but the generated
    // constructor leaves Properties null and omits it from the request payload.
    [CodeGenSuppress("DiskData", typeof(AzureLocation))]
    // TODO: Remove the string-ID workaround after the fix in Azure/typespec-azure#5517 is released
    // and adopted. ARM common types v3 projects the ID as string, while TrackedResourceData requires
    // ResourceIdentifier.
    [CodeGenSuppress("DiskData", typeof(string), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(DiskProperties), typeof(IDictionary<string, BinaryData>))]
    public partial class DiskData
    {
        /// <summary> Initializes a new instance of <see cref="DiskData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public DiskData(AzureLocation location) : base(location)
        {
            Properties = new DiskProperties();
        }

        internal DiskData(string id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, DiskProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id is null ? null : new ResourceIdentifier(id), name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
