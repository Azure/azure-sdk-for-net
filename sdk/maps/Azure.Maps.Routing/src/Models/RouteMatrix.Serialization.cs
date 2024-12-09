// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.Maps.Routing.Models
{
    public partial class RouteMatrix
    {
        internal static RouteMatrix DeserializeRouteMatrix(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? statusCode = default;
            RouteMatrixResultResponse response = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("statusCode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    statusCode = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("response"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    if (statusCode == 200) {
                        response = RouteMatrixResultResponse.DeserializeRouteMatrixResultResponse(property.Value);
                    } else {
                        response = new RouteMatrixResultResponse(null);
                    }
                    continue;
                }
            }
            return new RouteMatrix(statusCode, response);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static RouteMatrix FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRouteMatrix(document.RootElement);
        }
    }
}
