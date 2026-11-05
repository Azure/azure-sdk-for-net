// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.MultiServiceSharedModels.Combined.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MultiServiceSharedModels.Combined
{
    // TODO: Remove the string-ID workaround after the fix in Azure/typespec-azure#5517 is released
    // and adopted. ARM common types v3 projects the ID as string, while TrackedResourceData requires
    // ResourceIdentifier.
    [CodeGenSuppress("StorageAccountData", typeof(string), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(StorageAccountProperties), typeof(IDictionary<string, BinaryData>))]
    public partial class StorageAccountData
    {
        internal StorageAccountData(string id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, StorageAccountProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id is null ? null : new ResourceIdentifier(id), name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
