// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning
{
    // Fix the responsed error type "environments" to "Microsoft.MachineLearningServices/registries/environments"
    // Issue:https://github.com/Azure/azure-sdk-for-net/issues/45884
    [CodeGenSerialization(nameof(ResourceType), DeserializationValueHook = nameof(DeserializeTypeValue))]
    public partial class MachineLearningEnvironmentContainerData
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
