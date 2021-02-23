// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    using System;
    using System.Text.Json;
    using Azure.Core;

    /// <summary>
    /// A class representing an Identity assigned by the user.
    /// </summary>
    public sealed class UserAssignedIdentity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAssignedIdentity"/> class.
        /// </summary>
        /// <param name="clientId"> ClientId . </param>
        /// <param name="principalId"> PrincipalId. </param>
        public UserAssignedIdentity(Guid clientId, Guid principalId)
        {
            ClientId = clientId;
            PrincipalId = principalId;
        }

        /// <summary>
        /// Gets or sets the Client ID.
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Principal ID.
        /// </summary>
        public Guid PrincipalId { get; set; }

        /// <summary>
        /// Converts a <see cref="JsonElement"/> into an <see cref="UserAssignedIdentity"/> object.
        /// </summary>
        /// <param name="element"> A <see cref="JsonElement"/> containing an identity. </param>
        /// <returns> New <see cref="UserAssignedIdentity"/> object with JSON values. </returns>
        internal static UserAssignedIdentity Deserialize(JsonElement element)
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

        /// <summary>
        /// Converts an <see cref="UserAssignedIdentity"/> object into a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="writer"> Utf8JsonWriter object to which the output is going to be written. </param>
        /// <param name="userAssignedIdentity"> <see cref="UserAssignedIdentity"/> object to be converted. </param>
        internal static void Serialize(Utf8JsonWriter writer, UserAssignedIdentity userAssignedIdentity)
        {
            if (userAssignedIdentity == null)
                throw new ArgumentNullException(nameof(userAssignedIdentity));

            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            writer.WriteStartObject();

            writer.WritePropertyName("clientId");
            writer.WriteStringValue(userAssignedIdentity.ClientId.ToString());

            writer.WritePropertyName("principalId");
            writer.WriteStringValue(userAssignedIdentity.PrincipalId.ToString());

            writer.WriteEndObject();
            writer.Flush();
        }

        /// <summary>
        /// Compares two <see cref="UserAssignedIdentity"/> objects to determine if they are equal.
        /// </summary>
        /// <param name="original"> First <see cref="UserAssignedIdentity"/> object to compare. </param>
        /// <param name="other"> Second <see cref="UserAssignedIdentity"/> object to compare. </param>
        /// <returns> True if they are equal, otherwise False. </returns>
        public static bool Equals(UserAssignedIdentity original, UserAssignedIdentity other)
        {
            if (original == null)
                return other == null;

            return original.Equals(other);
        }

        /// <summary>
        /// Compares this <see cref="UserAssignedIdentity"/> with another instance.
        /// </summary>
        /// <param name="other"> <see cref="UserAssignedIdentity"/> object to compare. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(UserAssignedIdentity other)
        {
            if (other == null)
                return 1;

            int compareResult = 0;
            if ((compareResult = ClientId.CompareTo(other.ClientId)) == 0 &&
                (compareResult = PrincipalId.CompareTo(other.PrincipalId)) == 0)
            {
                return 0;
            }

            return compareResult;
        }

        /// <summary>
        /// Compares this <see cref="UserAssignedIdentity"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="other"> <see cref="UserAssignedIdentity"/> object to compare. </param>
        /// <returns> True if they are equal, otherwise false. </returns>
        public bool Equals(UserAssignedIdentity other)
        {
            if (other == null)
                return false;

            return ClientId.Equals(other.ClientId) && PrincipalId.Equals(other.PrincipalId);
        }
    }
}
