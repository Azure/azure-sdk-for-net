// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    public partial class FeatureProperties
    {
        internal static FeatureProperties DeserializeFeatureProperties(JsonElement element)
        {
            Optional<string> state = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("state"))
                {
                    state = property.Value.GetString();
                    continue;
                }
            }
            return new FeatureProperties(state.Value);
        }
    }
}
