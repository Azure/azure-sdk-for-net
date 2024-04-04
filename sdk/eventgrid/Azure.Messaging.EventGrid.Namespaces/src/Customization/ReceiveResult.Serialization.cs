// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class ReceiveResult
    {
        internal static ReceiveResult DeserializeReceiveResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<ReceiveDetails> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<ReceiveDetails> array = new List<ReceiveDetails>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ReceiveDetails.DeserializeReceiveDetails(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new ReceiveResult(value);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ReceiveResult FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeReceiveResult(document.RootElement);
        }
    }
}