// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public bool DefaultScope { get; }

        /// <summary>
        /// Specifies which role this entry targets.
        /// </summary>
        public AccessControlType AccessControlType { get; }

        /// <summary>
        /// Specifies the entity for which this entry applies.
        /// Must be omitted for types mask or other.  It must also be omitted when the user or group is the owner.
        /// </summary>
        public string EntityId { get; }

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
            if ((accessControlType == AccessControlType.Mask || accessControlType == AccessControlType.Other)
                && !string.IsNullOrEmpty(entityId))
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
                stringBuilder.Append(':');
                stringBuilder.Append(EntityId);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Parses the provided string into a <see cref="RemovePathAccessControlItem"/>
        /// </summary>
        /// <param name="serializedAccessControl">The string representation of the access control list.</param>
        /// <returns>A <see cref="RemovePathAccessControlItem"/>.</returns>
        public static RemovePathAccessControlItem Parse(string serializedAccessControl)
        {
            if (string.IsNullOrWhiteSpace(serializedAccessControl))
            {
                throw DataLakeErrors.RemovePathAccessControlItemInvalidString(serializedAccessControl);
            }

            string[] parts = serializedAccessControl.Split(':');
            int indexOffset = 0;

            if (parts.Length < 1 || parts.Length > 3)
            {
                throw DataLakeErrors.RemovePathAccessControlItemInvalidString(serializedAccessControl);
            }

            if (parts.Length == 3 && !parts[0].Equals("default", StringComparison.OrdinalIgnoreCase))
            {
                throw DataLakeErrors.RemovePathAccessControlItemStringInvalidPrefix(serializedAccessControl);
            }

            bool defaultScope = false;
            if (parts[0].Equals("default", StringComparison.OrdinalIgnoreCase))
            {
                defaultScope = true;
                indexOffset = 1;
            }

            AccessControlType accessControlType = (AccessControlType)Enum.Parse(typeof(AccessControlType), parts[indexOffset], true);

            string entityId = null;
            if ((1 + indexOffset) < parts.Length && !string.IsNullOrEmpty(parts[1 + indexOffset]))
            {
                entityId = parts[1 + indexOffset];
            }

            return new RemovePathAccessControlItem(accessControlType, defaultScope, entityId);
        }

        /// <summary>
        /// Converts the Access Control List for removal to a <see cref="string"/>.
        /// </summary>
        /// <param name="accessControlList">The Access Control List for removal to serialize</param>
        /// <returns>string.</returns>
        public static string ToAccessControlListString(IList<RemovePathAccessControlItem> accessControlList)
        {
            if (accessControlList == null)
            {
                return null;
            }

            IList<string> serializedAcl = new List<string>();
            foreach (RemovePathAccessControlItem ac in accessControlList)
            {
                serializedAcl.Add(ac.ToString());
            }
            return string.Join(",", serializedAcl);
        }

        /// <summary>
        /// Deseralizes an access control list string for removal into a list of RemovePathAccessControlItem.
        /// </summary>
        /// <param name="s">The string to parse.</param>
        /// <returns>A List of <see cref="RemovePathAccessControlItem"/>.</returns>
        public static IList<RemovePathAccessControlItem> ParseAccessControlList(string s)
        {
            if (s == null)
            {
                return null;
            }

            string[] strings = s.Split(',');
            List<RemovePathAccessControlItem> accessControlList = new List<RemovePathAccessControlItem>();
            foreach (string entry in strings)
            {
                accessControlList.Add(RemovePathAccessControlItem.Parse(entry));
            }
            return accessControlList;
        }
    }
}
