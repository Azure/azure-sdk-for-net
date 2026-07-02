// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ClientModel.Primitives;
using System;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.FrontDoor.Models
{
    internal static class FrontDoorSerializationHelpers
    {
        internal static bool TryReadResourceDataProperty(
            JsonProperty prop,
            ModelReaderWriterOptions options,
            ref ResourceIdentifier id,
            ref string name,
            ref ResourceType resourceType,
            ref SystemData systemData)
        {
            if (prop.NameEquals("id"u8))
            {
                if (prop.Value.ValueKind != JsonValueKind.Null)
                {
                    id = new ResourceIdentifier(prop.Value.GetString());
                }
                return true;
            }
            if (prop.NameEquals("name"u8))
            {
                name = prop.Value.GetString();
                return true;
            }
            if (prop.NameEquals("type"u8))
            {
                if (prop.Value.ValueKind != JsonValueKind.Null)
                {
                    resourceType = new ResourceType(prop.Value.GetString());
                }
                return true;
            }
            if (prop.NameEquals("systemData"u8))
            {
                if (prop.Value.ValueKind != JsonValueKind.Null)
                {
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerFrontDoorContext.Default);
                }
                return true;
            }

            return false;
        }

        internal static bool TryReadTrackedResourceDataProperty(
            JsonProperty prop,
            ModelReaderWriterOptions options,
            ref ResourceIdentifier id,
            ref string name,
            ref ResourceType resourceType,
            ref SystemData systemData,
            ref IDictionary<string, string> tags,
            ref AzureLocation location)
        {
            if (TryReadResourceDataProperty(prop, options, ref id, ref name, ref resourceType, ref systemData))
            {
                return true;
            }
            if (prop.NameEquals("tags"u8))
            {
                if (prop.Value.ValueKind != JsonValueKind.Null)
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        dictionary.Add(prop0.Name, prop0.Value.ValueKind == JsonValueKind.Null ? null : prop0.Value.GetString());
                    }
                    tags = dictionary;
                }
                return true;
            }
            if (prop.NameEquals("location"u8))
            {
                location = new AzureLocation(prop.Value.GetString());
                return true;
            }

            return false;
        }
    }
}
