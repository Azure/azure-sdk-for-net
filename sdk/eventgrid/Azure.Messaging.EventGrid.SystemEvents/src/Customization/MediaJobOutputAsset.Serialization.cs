// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class MediaJobOutputAsset
    {
        internal static MediaJobOutputAsset DeserializeMediaJobOutputAsset(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string assetName = default;
            string odataType = default;
            MediaJobError error = default;
            string label = default;
            long progress = default;
            MediaJobState state = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("assetName"u8))
                {
                    assetName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    error = MediaJobError.DeserializeMediaJobError(property.Value);
                    continue;
                }
                if (property.NameEquals("label"u8))
                {
                    label = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("progress"u8))
                {
                    progress = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("state"u8))
                {
                    state = property.Value.GetString().ToMediaJobState();
                    continue;
                }
            }
            return new MediaJobOutputAsset(
                odataType,
                error,
                label,
                progress,
                state,
                assetName);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new MediaJobOutputAsset FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaJobOutputAsset(document.RootElement);
        }
    }
}
