﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing an Identity assigned by the system.
    /// </summary>
    public sealed partial class SystemAssignedIdentity : IEquatable<SystemAssignedIdentity>
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

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as SystemAssignedIdentity);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(TenantId, PrincipalId);
        }
    }
}
