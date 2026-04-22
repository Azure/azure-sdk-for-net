// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Consumption.Models
{
    // Custom ETag deserialization: the generated code uses string for ETag,
    // but the old SDK exposed it as Azure.ETag?. This hook converts string to ETag
    // during deserialization to maintain backward compatibility.
    [CodeGenSerialization(nameof(ETag), DeserializationValueHook = nameof(DeserializeETag))]
    public partial class ConsumptionLotSummary
    {
        /// <summary> Initializes a new instance of <see cref="ConsumptionLotSummary"/>. </summary>
        public ConsumptionLotSummary()
        {
        }

        /// <summary> eTag of the resource. To handle concurrent update scenario, this field will be used to determine whether the user is updating the latest version or not. </summary>
        public ETag? ETag { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeETag(JsonProperty property, ref ETag? etag)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            etag = new ETag(property.Value.GetString());
        }
    }
}
