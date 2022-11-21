// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class VolumeResolution
    {
        internal static VolumeResolution DeserializeVolumeResolution(JsonElement element)
        {
            VolumeUnit unit = default;
            double value = default;
            ResolutionKind resolutionKind = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("unit"))
                {
                    unit = new VolumeUnit(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    value = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("resolutionKind"))
                {
                    resolutionKind = new ResolutionKind(property.Value.GetString());
                    continue;
                }
            }
            return new VolumeResolution(resolutionKind, unit, value);
        }
    }
}
