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
    [CodeGenSuppress("VirtualMachineData", typeof(AzureLocation))]
    [CodeGenSuppress("VirtualMachineData", typeof(string), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(VirtualMachineProperties), typeof(IDictionary<string, BinaryData>))]
    public partial class VirtualMachineData
    {
        /// <summary> Initializes a new instance of <see cref="VirtualMachineData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public VirtualMachineData(AzureLocation location) : base(location)
        {
            Properties = new VirtualMachineProperties();
        }

        internal VirtualMachineData(string id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, VirtualMachineProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id is null ? null : new ResourceIdentifier(id), name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
