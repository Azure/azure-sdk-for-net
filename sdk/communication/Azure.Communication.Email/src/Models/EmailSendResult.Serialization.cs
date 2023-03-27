// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.Email
{
    public partial class EmailSendResult
    {
        internal static EmailSendResult DeserializeEmailSendResult(JsonElement element)
        {
            string id = default;
            EmailSendStatus status = default;
            Optional<ErrorDetail> error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new EmailSendStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    error = ErrorDetail.DeserializeErrorDetail(property.Value);
                    continue;
                }
            }
            return new EmailSendResult(id, status, error.Value);
        }
    }
}
