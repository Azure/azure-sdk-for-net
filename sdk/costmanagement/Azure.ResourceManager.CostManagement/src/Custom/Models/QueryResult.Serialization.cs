// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CostManagement.Models
{
    [CodeGenSerialization(nameof(Id), DeserializationValueHook = nameof(ReadId))]
    public partial class QueryResult : IUtf8JsonSerializable, IJsonModel<QueryResult>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadId(JsonProperty property, ref ResourceIdentifier id)
        {
            var idString = property.Value.GetString();
            // Service may return resource id without '/'.
            id = idString.StartsWith("/") ? new ResourceIdentifier(idString) : new ResourceIdentifier($"/{idString}");
        }
    }
}
