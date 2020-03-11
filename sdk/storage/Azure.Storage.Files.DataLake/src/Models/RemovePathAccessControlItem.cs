// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Represents an access control in a file access control list for removal.
    /// </summary>
    public class RemovePathAccessControlItem
    {
        /// <summary>
        /// Indicates whether this is the default entry for the ACL.
        /// </summary>
        public bool DefaultScope { get; set; }

        /// <summary>
        /// Specifies which role this entry targets.
        /// </summary>
        public AccessControlType AccessControlType { get; set; }

        /// <summary>
        /// Specifies the entity for which this entry applies.
        /// Must be omitted for types mask or other.  It must also be omitted when the user or group is the owner.
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public RemovePathAccessControlItem() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="accessControlType">Specifies which role this entry targets.</param>
        /// <param name="defaultScope">Indicates whether this is the default entry for the ACL.</param>
        /// <param name="entityId">Optional entity ID to which this entry applies.</param>
        public RemovePathAccessControlItem(
            AccessControlType accessControlType,
            bool defaultScope = false,
            string entityId = default)
        {
            if (entityId != null
                && !(accessControlType == AccessControlType.User || accessControlType == AccessControlType.Group))
            {
                throw DataLakeErrors.EntityIdAndInvalidAccessControlType(accessControlType.ToString());
            }

            DefaultScope = defaultScope;
            AccessControlType = accessControlType;
            EntityId = entityId;
        }

        /// <summary>
        /// Override of ToString().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (DefaultScope)
            {
                stringBuilder.Append("default:");
            }
            stringBuilder.Append(AccessControlType.ToString().ToLowerInvariant());
            if (!string.IsNullOrWhiteSpace(EntityId))
            {
                stringBuilder.Append(":");
                stringBuilder.Append(EntityId);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Parses the provided string into a <see cref="RemovePathAccessControlItem"/>
        /// </summary>
        /// <param name="s">The string representation of the access control list.</param>
        /// <returns>A <see cref="RemovePathAccessControlItem"/>.</returns>
        public static RemovePathAccessControlItem Parse(string s)
        {
            if (s == null)
            {
                return null;
            }

            RemovePathAccessControlItem entry = new RemovePathAccessControlItem();
            string[] parts = s.Split(':');
            int indexOffset = 0;

            if (parts.Length < 1 || parts.Length > 3)
            {
                throw DataLakeErrors.RemovePathAccessControlItemStringInvalidLength(s);
            }

            if (parts.Length == 3 && !parts[0].Equals("default", StringComparison.OrdinalIgnoreCase))
            {
                throw DataLakeErrors.RemovePathAccessControlItemStringInvalidPrefix(s);
            }

            if (parts[0].Equals("default", StringComparison.OrdinalIgnoreCase))
            {
                entry.DefaultScope = true;
                indexOffset = 1;
            }

            entry.AccessControlType = ParseAccesControlType(parts[indexOffset]);

            if ((1 + indexOffset) < parts.Length && !string.IsNullOrEmpty(parts[1 + indexOffset]))
            {
                entry.EntityId = parts[1 + indexOffset];
            }

            return entry;
        }

        internal static AccessControlType ParseAccesControlType(string s)
        {
            if ("user".Equals(s, StringComparison.OrdinalIgnoreCase))
            {
                return AccessControlType.User;
            }
            else if ("group".Equals(s, StringComparison.OrdinalIgnoreCase))
            {
                return AccessControlType.Group;
            }
            else if ("mask".Equals(s, StringComparison.OrdinalIgnoreCase))
            {
                return AccessControlType.Mask;
            }
            else if ("other".Equals(s, StringComparison.OrdinalIgnoreCase))
            {
                return AccessControlType.Other;
            }
            else
            {
                throw Errors.InvalidArgument(nameof(s));
            }
        }
    }
}
