// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// The <see cref="SignalRMessage.Arguments"/> shouldn't be required, but it's a breaking change to remove the <see cref="JsonRequiredAttribute"/> of the member. As a workaround, we have to use a converter to override the behaviour.
    /// </summary>
    internal class SignalRMessageConverter : JsonConverter<SignalRMessage>
    {
        public override SignalRMessage ReadJson(JsonReader reader, Type objectType, SignalRMessage existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var internalMessageObj = serializer.Deserialize<InternalSignalRMessage>(reader);
            return new()
            {
                ConnectionId = internalMessageObj.connectionId,
                UserId = internalMessageObj.userId,
                GroupName = internalMessageObj.groupName,
                Target = internalMessageObj.target,
                Arguments = internalMessageObj.arguments,
                Endpoints = internalMessageObj.endpoints,
            };
        }

        public override void WriteJson(JsonWriter writer, SignalRMessage value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
