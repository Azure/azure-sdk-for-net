// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Messaging.EventGrid.Models;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class MediaJobOutput
    {
        internal static MediaJobOutput DeserializeMediaJobOutput(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Media.JobOutputAsset": return MediaJobOutputAsset.DeserializeMediaJobOutputAsset(element);
                }
            }
            return UnknownMediaJobOutput.DeserializeUnknownMediaJobOutput(element);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaJobOutput FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaJobOutput(document.RootElement);
        }
    }
}
