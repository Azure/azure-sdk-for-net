// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing an Identity assigned by the user.
    /// </summary>
    public partial class UserAssignedIdentity : IUtf8JsonSerializable
    {
        /// <summary>
        /// Converts an <see cref="UserAssignedIdentity"/> object into a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="writer"> Utf8JsonWriter object to which the output is going to be written. </param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            writer.WriteStartObject();

            writer.WritePropertyName("clientId");
            writer.WriteStringValue(ClientId.ToString());

            writer.WritePropertyName("principalId");
            writer.WriteStringValue(PrincipalId.ToString());

            writer.WriteEndObject();
            writer.Flush();
        }

        /// <summary>
        /// Converts a <see cref="JsonElement"/> into an <see cref="UserAssignedIdentity"/> object.
        /// </summary>
        /// <param name="element"> A <see cref="JsonElement"/> containing an identity. </param>
        /// <returns> New <see cref="UserAssignedIdentity"/> object with JSON values. </returns>
        internal static UserAssignedIdentity DeserializeUserAssignedIdentity(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Undefined)
            {
                throw new ArgumentException("JsonElement is undefined " + nameof(element));
            }

            Guid principalId = default;
            Guid clientId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("principalId"))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                        principalId = Guid.Parse(property.Value.GetString());
                }

                if (property.NameEquals("clientId"))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                        clientId = Guid.Parse(property.Value.GetString());
                }
            }

            if (principalId == default(Guid) && clientId == default(Guid))
                return null;

            if (principalId == default(Guid) || clientId == default(Guid))
                throw new InvalidOperationException("Either ClientId or PrincipalId were null");

            return new UserAssignedIdentity(clientId, principalId);
        }
    }
}
