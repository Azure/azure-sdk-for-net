// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.MachineLearning.Models;
using Azure.ResourceManager.Models;

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
            type = propVal == "environments" ? new ResourceType("Microsoft.MachineLearningServices/registries/environments") : new ResourceType(propVal);
        }
    }
}
