// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// Represents a managed identity
    /// </summary>
    [PropertyReferenceType(new Type[] { typeof(ResourceIdentityType) })]
    public partial class ResourceIdentity : IEquatable<ResourceIdentity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentity"/> class.
        /// </summary>
        [InitializationConstructor]
        public ResourceIdentity()
            : this(null, false)
        {
        } // not system or user

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentity"/> class.
        /// </summary>
        /// <param name="user"> Dictionary with a <see cref="ResourceIdentifier"/> key and a <see cref="UserAssignedIdentity"/> object value. </param>
        /// <param name="useSystemAssigned"> Flag for using <see cref="SystemAssignedIdentity"/> or not. </param>
        public ResourceIdentity(Dictionary<ResourceIdentifier, UserAssignedIdentity> user, bool useSystemAssigned)
        {
            // check for combination of user and system on the impact to type value
            SystemAssignedIdentity = useSystemAssigned ? new SystemAssignedIdentity() : null;
            UserAssignedIdentities = new Dictionary<ResourceIdentifier, UserAssignedIdentity>();
            if (user != null)
            {
                foreach (KeyValuePair<ResourceIdentifier, UserAssignedIdentity> id in user)
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
        [SerializationConstructor]
        internal ResourceIdentity(SystemAssignedIdentity systemAssigned, IDictionary<ResourceIdentifier, UserAssignedIdentity> user)
        {
            // TODO: remove this constructor later
            SystemAssignedIdentity = systemAssigned;
            if (user == null)
            {
                UserAssignedIdentities = new Dictionary<ResourceIdentifier, UserAssignedIdentity>();
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
        public IDictionary<ResourceIdentifier, UserAssignedIdentity> UserAssignedIdentities { get; private set; }

        /// <summary>
        /// Detects if this Identity is equals to another Identity instance.
        /// </summary>
        /// <param name="other"> Identity object to compare. </param>
        /// <returns> True if they are equal, otherwise False. </returns>
        public bool Equals(ResourceIdentity other)
        {
            if (ReferenceEquals(other, null))
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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as ResourceIdentity);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(SystemAssignedIdentity, UserAssignedIdentities);
        }
    }
}
