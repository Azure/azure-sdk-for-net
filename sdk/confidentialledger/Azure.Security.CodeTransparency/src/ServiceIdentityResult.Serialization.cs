// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.CodeTransparency
{
    public partial class ServiceIdentityResult
    {
        internal static ServiceIdentityResult DeserializeServiceIdentityResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string ledgerTlsCertificate = default;
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("ledgerTlsCertificate"u8))
                {
                    ledgerTlsCertificate = property.Value.GetString();
                    continue;
                }
            }
            return new ServiceIdentityResult(ledgerTlsCertificate);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ServiceIdentityResult FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeServiceIdentityResult(document.RootElement);
        }
    }
}
