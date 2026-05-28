// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // CosmosDBAccountKeyList extends CosmosDBAccountReadOnlyKeyList; both emit
    // `internal static FromResponse(Response)`, causing CS0108 because MPG does not emit `new`
    // on the derived helper. Suppress and re-emit with `new` to make the hide explicit.
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
