// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.AgentServer.Core.Storage
{
    public partial class DeletedStateStoreItem
    {
        /// <summary>Gets the server-assigned identifier when the item existed.</summary>
        [CodeGenMember("Id")]
        public string? Id { get; }

        /// <param name="result">The <see cref="ClientResult"/> to deserialize.</param>
        public static explicit operator DeletedStateStoreItem(ClientResult result)
        {
            PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeDeletedStateStoreItem(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
