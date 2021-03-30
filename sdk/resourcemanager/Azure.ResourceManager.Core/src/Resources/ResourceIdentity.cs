// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Represents a managed identity
    /// </summary>
    public class ResourceIdentity : IEquatable<ResourceIdentity>
    {
        private const string SystemAssigned = "SystemAssigned";
        private const string UserAssigned = "UserAssigned";
        private const string SystemAndUserAssigned = "SystemAssigned, UserAssigned";

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentity"/> class.
        /// </summary>
        public ResourceIdentity()
            : this(null, false)
        {
        } // not system or user

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentity"/> class.
        /// </summary>
        /// <param name="user"> Dictionary with a <see cref="ResourceIdentifier"/> key and a <see cref="UserAssignedIdentity"/> object value. </param>
        /// <param name="useSystemAssigned"> Flag for using <see cref="SystemAssignedIdentity"/> or not. </param>
        public ResourceIdentity(Dictionary<ResourceGroupResourceIdentifier, UserAssignedIdentity> user, bool useSystemAssigned)
        {
            // check for combination of user and system on the impact to type value
            SystemAssignedIdentity = useSystemAssigned ? new SystemAssignedIdentity() : null;
            UserAssignedIdentities = new Dictionary<ResourceGroupResourceIdentifier, UserAssignedIdentity>();
            if (user != null)
            {
                foreach (KeyValuePair<ResourceGroupResourceIdentifier, UserAssignedIdentity> id in user)
                {
                    UserAssignedIdentities.Add(id.Key, id.Value);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentity"/> class.
        /// </summary>
        /// <param name="systemAssigned"> The <see cref="SystemAssignedIdentity"/> to use. </param>
        /// <param name="user"> Dictionary with a <see cref="ResourceIdentifier"/> key and a <see cref="UserAssignedIdentity"/> object value. </param>
        public ResourceIdentity(SystemAssignedIdentity systemAssigned, IDictionary<ResourceGroupResourceIdentifier, UserAssignedIdentity> user)
        {
            // TODO: remove this constructor later
            SystemAssignedIdentity = systemAssigned;
            if (user == null)
            {
                UserAssignedIdentities = new Dictionary<ResourceGroupResourceIdentifier, UserAssignedIdentity>();
            }
            else
            {
                UserAssignedIdentities = user;
            }
        }

        /// <summary>
        /// Gets the SystemAssignedIdentity.
        /// </summary>
        public SystemAssignedIdentity SystemAssignedIdentity { get; private set; }

        /// <summary>
        /// Gets a dictionary of the User Assigned Identities.
        /// </summary>
        public IDictionary<ResourceGroupResourceIdentifier, UserAssignedIdentity> UserAssignedIdentities { get; private set; }

        /// <summary>
        /// Converts a <see cref="JsonElement"/> into an <see cref="ResourceIdentity"/> object.
        /// </summary>
        /// <param name="element"> A <see cref="JsonElement"/> containing an <see cref="ResourceIdentity"/>. </param>
        /// <returns> New Identity object with JSON values. </returns>
        internal static ResourceIdentity Deserialize(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Undefined)
            {
                throw new ArgumentException("JsonElement cannot be undefined ", nameof(element));
            }

            Optional<SystemAssignedIdentity> systemAssignedIdentity = default;
            IDictionary<ResourceGroupResourceIdentifier, UserAssignedIdentity> userAssignedIdentities = new Dictionary<ResourceGroupResourceIdentifier, UserAssignedIdentity>();
            string type = string.Empty;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("userAssignedIdentities"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        userAssignedIdentities = null;
                        continue;
                    }

                    string resourceId = string.Empty;
                    foreach (var keyValuePair in property.Value.EnumerateObject())
                    {
                        resourceId = keyValuePair.Name;
                        var userAssignedIdentity = UserAssignedIdentity.Deserialize(keyValuePair.Value);
                        userAssignedIdentities.Add(new ResourceGroupResourceIdentifier(resourceId), userAssignedIdentity);
                    }

                    continue;
                }

                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        throw new InvalidOperationException("The type property had a JsonValueKind equal to Null");
                    }

                    type = property.Value.GetString();
                }

                if (type.Equals(SystemAssigned))
                {
                    systemAssignedIdentity = SystemAssignedIdentity.Deserialize(element);
                    continue;
                }

                if (type.Equals(SystemAndUserAssigned))
                {
                    systemAssignedIdentity = SystemAssignedIdentity.Deserialize(element);
                    continue;
                }
            }

            return new ResourceIdentity(systemAssignedIdentity, userAssignedIdentities);
        }

        /// <summary>
        /// Converts an <see cref="ResourceIdentity"/> object into a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="writer"> Utf8JsonWriter object to which the output is going to be written. </param>
        /// <param name="identity"> Identity object to be converted. </param>
        internal static void Serialize(Utf8JsonWriter writer, ResourceIdentity identity)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (identity == null)
                throw new ArgumentNullException(nameof(identity));

            writer.WriteStartObject();
            writer.WritePropertyName("identity");

            if (identity.SystemAssignedIdentity == null && identity.UserAssignedIdentities.Count == 0)
            {
                writer.WriteStringValue("null");
                writer.WriteEndObject();
                writer.Flush();
                return;
            }

            writer.WriteStartObject();
            if (identity.SystemAssignedIdentity != null && identity.UserAssignedIdentities.Count != 0)
            {
                SystemAssignedIdentity.Serialize(writer, identity.SystemAssignedIdentity);
                writer.WritePropertyName("kind");
                writer.WriteStringValue(SystemAndUserAssigned);
                writer.WritePropertyName("userAssignedIdentities");
                writer.WriteStartObject();
                foreach (var keyValuePair in identity.UserAssignedIdentities)
                {
                    writer.WritePropertyName(keyValuePair.Key);
                    UserAssignedIdentity.Serialize(writer, keyValuePair.Value);
                }

                writer.WriteEndObject();
            }
            else if (identity.SystemAssignedIdentity != null)
            {
                SystemAssignedIdentity.Serialize(writer, identity.SystemAssignedIdentity);
                writer.WritePropertyName("kind");
                writer.WriteStringValue(SystemAssigned);
            }
            else if (identity.UserAssignedIdentities.Count != 0)
            {
                writer.WritePropertyName("kind");
                writer.WriteStringValue(UserAssigned);
                writer.WritePropertyName("userAssignedIdentities");
                writer.WriteStartObject();
                foreach (var keyValuePair in identity.UserAssignedIdentities)
                {
                    writer.WritePropertyName(keyValuePair.Key);
                    UserAssignedIdentity.Serialize(writer, keyValuePair.Value);
                }

                writer.WriteEndObject();
            }

            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.Flush();
        }

        /// <summary>
        /// Detects if this Identity is equals to another Identity instance.
        /// </summary>
        /// <param name="other"> Identity object to compare. </param>
        /// <returns> True if they are equal, otherwise False. </returns>
        public bool Equals(ResourceIdentity other)
        {
            if (other == null)
                return false;

            if (UserAssignedIdentities.Count == other.UserAssignedIdentities.Count)
            {
                foreach (var identity in UserAssignedIdentities)
                {
                    UserAssignedIdentity value;
                    if (other.UserAssignedIdentities.TryGetValue(identity.Key, out value))
                    {
                        if (!UserAssignedIdentity.Equals(identity.Value, value))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return SystemAssignedIdentity.Equals(SystemAssignedIdentity, other.SystemAssignedIdentity);
        }
    }
}
