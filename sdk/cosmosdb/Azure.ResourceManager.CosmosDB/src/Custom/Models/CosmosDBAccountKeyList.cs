// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // CosmosDBAccountKeyList extends CosmosDBAccountReadOnlyKeyList. Both classes
    // generate an `internal static FromResponse(Response)` helper with the same
    // signature, which triggers CS0108 (hides inherited member). The MPG generator
    // does not emit `new` on the derived helper. Suppress the generated helper and
    // re-emit it with the `new` modifier so the hide is explicit and the warning
    // is silenced without globally suppressing CS0108.
    [CodeGenSuppress("FromResponse", typeof(Response))]
    public partial class CosmosDBAccountKeyList
    {
        internal static new CosmosDBAccountKeyList FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeCosmosDBAccountKeyList(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
