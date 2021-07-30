// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class SystemAssignedIdentity : IUtf8JsonSerializable
    {
        /// <summary>
        /// Converts an <see cref="UserAssignedIdentity"/> object into a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="writer"> Utf8JsonWriter object to which the output is going to be written. </param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            writer.WritePropertyName("principalId");
            if (!Optional.IsDefined(PrincipalId))
            {
                writer.WriteStringValue("null");
            }
            else
            {
                writer.WriteStringValue(PrincipalId.ToString());
            }

            writer.WritePropertyName("tenantId");
            if (!Optional.IsDefined(TenantId))
            {
                writer.WriteStringValue("null");
            }
            else
            {
                writer.WriteStringValue(TenantId.ToString());
            }

            writer.Flush();
        }

        /// <summary>
        /// Converts a <see cref="JsonElement"/> into an <see cref="SystemAssignedIdentity"/> object.
        /// </summary>
        /// <param name="element"> A <see cref="JsonElement"/> containing an identity. </param>
        /// <returns> New <see cref="SystemAssignedIdentity"/> object with JSON values. </returns>
        internal static SystemAssignedIdentity DeserializeSystemAssignedIdentity(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Undefined)
            {
                throw new ArgumentException("JsonElement cannot be undefined ", nameof(element));
            }

            Guid principalId = default;
            Guid tenantId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("principalId"))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                        principalId = Guid.Parse(property.Value.GetString());
                }

                if (property.NameEquals("tenantId"))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                        tenantId = Guid.Parse(property.Value.GetString());
                }
            }

            if (principalId == default(Guid) && tenantId == default(Guid))
                return null;

            if (principalId == default(Guid) || tenantId == default(Guid))
                throw new InvalidOperationException("Either TenantId or PrincipalId were null");

            return new SystemAssignedIdentity(tenantId, principalId);
        }
    }
}
