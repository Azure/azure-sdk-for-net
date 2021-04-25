// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubOperationJsonConverter : JsonConverter<WebPubSubOperation>
    {
        public override WebPubSubOperation ReadJson(JsonReader reader, Type objectType, WebPubSubOperation existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            try
            {
                if (reader == null)
                {
                    throw new ArgumentNullException(nameof(reader));
                }
                if (objectType == null)
                {
                    throw new ArgumentNullException(nameof(objectType));
                }
                if (serializer == null)
                {
                    throw new ArgumentNullException(nameof(serializer));
                }

                if (reader.TokenType == JsonToken.Null)
                {
                    return null;
                }

                JObject jObject = JObject.Load(reader);
                var kind = jObject.Properties().SingleOrDefault(p =>
                    p.Name.Equals("operationKind", StringComparison.OrdinalIgnoreCase)).Value.ToString().ToLowerInvariant();

                existingValue = kind switch
                {
                    "sendtoall" => jObject.ToObject<SendToAll>(),
                    "sendtogroup" => jObject.ToObject<SendToGroup>(),
                    "sendtoconnection" => jObject.ToObject<SendToConnection>(),
                    "sendtouser" => jObject.ToObject<SendToUser>(),
                    "addusertogroup" => jObject.ToObject<AddUserToGroup>(),
                    "removeuserfromgroup" => jObject.ToObject<RemoveUserFromGroup>(),
                    "addconnectiontogroup" => jObject.ToObject<AddConnectionToGroup>(),
                    "removeconnectionfromgroup" => jObject.ToObject<RemoveConnectionFromGroup>(),
                    "removeuserfromallgroups" => jObject.ToObject<RemoveUserFromAllGroups>(),
                    "closeclientconnection" => jObject.ToObject<CloseClientConnection>(),
                    "grantgrouppermission" => jObject.ToObject<GrantGroupPermission>(),
                    "revokegrouppermission" => jObject.ToObject<RevokeGroupPermission>(),
                    _ => jObject.ToObject<WebPubSubOperation>()
                };
                hasExistingValue = true;
                return existingValue;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, WebPubSubOperation value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
}
