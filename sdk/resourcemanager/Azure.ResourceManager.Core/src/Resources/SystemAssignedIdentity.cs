// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    using System;
    using System.Text.Json;
    using Azure.Core;

    /// <summary>
    /// A class representing an Identity assigned by the system.
    /// </summary>
    public sealed class SystemAssignedIdentity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemAssignedIdentity"/> class with Null properties.
        /// </summary>
        public SystemAssignedIdentity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemAssignedIdentity"/> class.
        /// </summary>
        /// <param name="tenantId"> Application TenantId . </param>
        /// <param name="principalId"> PrincipalId. </param>
        public SystemAssignedIdentity(Guid tenantId, Guid principalId)
        {
            TenantId = tenantId;
            PrincipalId = principalId;
        }

        /// <summary>
        /// Gets the Tenant ID.
        /// </summary>
        public Guid? TenantId { get; private set; }

        /// <summary>
        /// Gets the Principal ID.
        /// </summary>
        public Guid? PrincipalId { get; private set; }

        /// <summary>
        /// Converts a <see cref="JsonElement"/> into an <see cref="SystemAssignedIdentity"/> object.
        /// </summary>
        /// <param name="element"> A <see cref="JsonElement"/> containing an identity. </param>
        /// <returns> New <see cref="SystemAssignedIdentity"/> object with JSON values. </returns>
        internal static SystemAssignedIdentity Deserialize(JsonElement element)
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

        /// <summary>
        /// Converts an <see cref="SystemAssignedIdentity"/> object into a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="writer"> Utf8JsonWriter object to which the output is going to be written. </param>
        /// <param name="systemAssignedIdentity"> <see cref="SystemAssignedIdentity"/> object to be converted. </param>
        internal static void Serialize(Utf8JsonWriter writer, SystemAssignedIdentity systemAssignedIdentity)
        {
            if (systemAssignedIdentity == null)
                throw new ArgumentNullException(nameof(systemAssignedIdentity));

            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            writer.WritePropertyName("principalId");
            if (!Optional.IsDefined(systemAssignedIdentity.PrincipalId))
            {
                writer.WriteStringValue("null");
            }
            else
            {
                writer.WriteStringValue(systemAssignedIdentity.PrincipalId.ToString());
            }

            writer.WritePropertyName("tenantId");
            if (!Optional.IsDefined(systemAssignedIdentity.TenantId))
            {
                writer.WriteStringValue("null");
            }
            else
            {
                writer.WriteStringValue(systemAssignedIdentity.TenantId.ToString());
            }

            writer.Flush();
        }

        /// <summary>
        /// Compares two <see cref="SystemAssignedIdentity"/> objects to determine if they are equal.
        /// </summary>
        /// <param name="original"> First <see cref="SystemAssignedIdentity"/> object to compare. </param>
        /// <param name="other"> Second <see cref="SystemAssignedIdentity"/> object to compare. </param>
        /// <returns> True if they are equal, otherwise False. </returns>
        public static bool Equals(SystemAssignedIdentity original, SystemAssignedIdentity other)
        {
            if (original == null)
                return other == null;

            return original.Equals(other);
        }

        /// <summary>
        /// Compares this <see cref="SystemAssignedIdentity"/> with another instance.
        /// </summary>
        /// <param name="other"> <see cref="SystemAssignedIdentity"/> object to compare. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(SystemAssignedIdentity other)
        {
            if (other == null)
                return 1;

            int compareResult = 0;
            if ((compareResult = TenantId.GetValueOrDefault().CompareTo(other.TenantId.GetValueOrDefault())) == 0 &&
                (compareResult = PrincipalId.GetValueOrDefault().CompareTo(other.PrincipalId.GetValueOrDefault())) == 0)
                return 0;

            return compareResult;
        }

        /// <summary>
        /// Compares this <see cref="SystemAssignedIdentity"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="other"> <see cref="SystemAssignedIdentity"/> object to compare. </param>
        /// <returns> True if they are equal, otherwise false. </returns>
        public bool Equals(SystemAssignedIdentity other)
        {
            if (other == null)
                return false;

            return TenantId.Equals(other.TenantId) && PrincipalId.Equals(other.PrincipalId);
        }
    }
}
