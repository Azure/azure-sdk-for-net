// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Process Thread Information. </summary>
    [CodeGenSerialization(nameof(Id), DeserializationValueHook = nameof(DeserializeIdValue))]
    public partial class ProcessThreadInfo : ResourceData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeIdValue(JsonProperty property, ref ResourceIdentifier id) // the type here is string since name is required
        {
            try
            {
                id = new ResourceIdentifier(property.Value.GetString());
            }
            catch (Exception)
            {
                // Service doesn't always return a valid resource identifier, https://github.com/Azure/azure-sdk-for-net/issues/39126, so we need to handle the exception
                id = default;
            }
        }
    }
}
