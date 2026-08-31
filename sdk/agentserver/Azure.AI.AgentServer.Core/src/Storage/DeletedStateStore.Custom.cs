// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.AgentServer.Core.Storage
{
    public partial class DeletedStateStore
    {
        /// <summary>Gets the server-assigned identifier when the state store existed.</summary>
        [CodeGenMember("Id")]
        public string? Id { get; }

        /// <param name="result">The <see cref="ClientResult"/> to deserialize.</param>
        public static explicit operator DeletedStateStore(ClientResult result)
        {
            PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeDeletedStateStore(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
