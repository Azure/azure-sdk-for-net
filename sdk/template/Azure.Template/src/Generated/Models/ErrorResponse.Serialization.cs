// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Template.Models
{
    public partial class ErrorResponse : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("error");
            writer.WriteObjectValue(Error);
            writer.WriteEndObject();
        }
        internal static ErrorResponse DeserializeErrorResponse(JsonElement element)
        {
            ErrorResponse result = new ErrorResponse();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("error"))
                {
                    result.Error = ErrorInformation.DeserializeErrorInformation(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
