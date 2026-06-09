// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    [CodeGenSerialization(nameof(ResourceType), DeserializationValueHook = nameof(DeserializeTypeValue))]
    public partial class EnvironmentContainerData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeTypeValue(JsonProperty property, ref ResourceType type)
        {
            var propVal = property.Value.GetString();
            try
            {
                type = new ResourceType(propVal);
            }
            catch (Exception)
            {
                type = new ResourceType("Microsoft.MachineLearningServices/registries/environments");
            }
        }
    }
}
