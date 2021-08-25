// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// A class representing an Identity assigned by the user.
    /// </summary>
    [PropertyReferenceType]
    public sealed partial class UserAssignedIdentity : IEquatable<UserAssignedIdentity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAssignedIdentity"/> class.
        /// </summary>
        [InitializationConstructor]
        public UserAssignedIdentity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAssignedIdentity"/> class.
        /// </summary>
        /// <param name="clientId"> ClientId . </param>
        /// <param name="principalId"> PrincipalId. </param>
        [SerializationConstructor]
        internal UserAssignedIdentity(Guid clientId, Guid principalId)
        {
            ClientId = clientId;
            PrincipalId = principalId;
        }

        /// <summary>
        /// Gets or sets the Client ID.
        /// </summary>
        public Guid ClientId { get; }

        /// <summary>
        /// Gets or sets the Principal ID.
        /// </summary>
        public Guid PrincipalId { get; }

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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as UserAssignedIdentity);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(ClientId, PrincipalId);
        }
    }
}
