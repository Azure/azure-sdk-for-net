// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.Calling.Server
{
    public partial class InviteParticipantsResultEvent
    {
        /// <summary>
        /// Deserialize <see cref="InviteParticipantsResultEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns></returns>
        public static InviteParticipantsResultEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            Optional<ResultInfoInternal> resultInfo = default;
            Optional<string> operationContext = default;
            Optional<OperationStatusModel> status = default;
            Optional<string> callLegId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resultInfo") || property.NameEquals("ResultInfo"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    resultInfo = ResultInfoInternal.DeserializeResultInfoInternal(property.Value);
                    continue;
                }
                if (property.NameEquals("operationContext") || property.NameEquals("OperationContext"))
                {
                    operationContext = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status") || property.NameEquals("Status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    status = new OperationStatusModel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("callLegId") || property.NameEquals("CallLegId"))
                {
                    callLegId = property.Value.GetString();
                    continue;
                }
            }
            return new InviteParticipantsResultEvent(resultInfo.Value, operationContext.Value, status, callLegId.Value);
        }
    }
}
