// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ElasticSan.Models
{
    // API versions before 2026-05-01-preview represent managedBy as a single object with a resourceId
    // property, while newer versions use an array. Accept both shapes so that responses from an older
    // api-version and models persisted by earlier library versions still deserialize.
    [CodeGenSerialization(nameof(ManagedBy), DeserializationValueHook = nameof(DeserializeManagedBy))]
    internal partial class VolumeProperties
    {
        private static void DeserializeManagedBy(JsonProperty property, ref IList<ElasticSanManagedByInfo> managedBy)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<ElasticSanManagedByInfo> list = new List<ElasticSanManagedByInfo>();
            if (property.Value.ValueKind == JsonValueKind.Object)
            {
                if (property.Value.TryGetProperty("resourceId", out JsonElement resourceId) && resourceId.ValueKind == JsonValueKind.String)
                {
                    ElasticSanManagedByInfo legacy = new ElasticSanManagedByInfo();
                    legacy.ResourceIds.Add(new Azure.Core.ResourceIdentifier(resourceId.GetString()));
                    list.Add(legacy);
                }
            }
            else
            {
                foreach (JsonElement item in property.Value.EnumerateArray())
                {
                    list.Add(ElasticSanManagedByInfo.DeserializeElasticSanManagedByInfo(item, ModelReaderWriterOptions.Json));
                }
            }
            managedBy = list;
        }
    }
}