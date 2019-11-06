// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Represents an access control in a file access control list.
    /// </summary>
    public class PathAccessControlEntry
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
        /// Specifies the permissions granted to this entry.
        /// </summary>
        public RolePermissions Permissions { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public PathAccessControlEntry() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="accessControlType">Specifies which role this entry targets.</param>
        /// <param name="permissions">Specifies the permissions granted to this entry.</param>
        /// <param name="defaultScope">Indicates whether this is the default entry for the ACL.</param>
        /// <param name="entityId">Specifies the entity for which this entry applies.</param>
        public PathAccessControlEntry(
            AccessControlType accessControlType,
            RolePermissions permissions,
            bool defaultScope = false,
            string entityId = null)
        {
            DefaultScope = defaultScope;
            AccessControlType = accessControlType;
            EntityId = entityId;
            Permissions = permissions;
        }

        /// <summary>
        /// Override of ToString()
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
            stringBuilder.Append(":");
            stringBuilder.Append(EntityId ?? "");
            stringBuilder.Append(":");
            stringBuilder.Append(Permissions.ToSymbolicString());

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Parses the provided string into a <see cref="PathAccessControlEntry"/>
        /// </summary>
        /// <param name="str">The string representation of the ACL.</param>
        /// <returns>A <see cref="PathAccessControlEntry"/>.</returns>
        public static PathAccessControlEntry Parse(string str)
        {
            PathAccessControlEntry entry = new PathAccessControlEntry();
            string[] parts = str.Split(':');
            int indexOffset = 0;

            if (parts.Length == 4)
            {
                if (!parts[0].Equals("default", StringComparison.InvariantCultureIgnoreCase))
                {
                    throw Errors.InvalidArgument(nameof(str));
                }
                entry.DefaultScope = true;
                indexOffset = 1;
            }
            entry.AccessControlType = ParseAccesControlType(parts[indexOffset]);

            if (!string.IsNullOrEmpty(parts[1 + indexOffset]))
            {
                entry.EntityId = parts[1 + indexOffset];
            }

            entry.Permissions = RolePermissionsExtensions.ParseSymbolic(parts[2 + indexOffset], false);
            return entry;
        }

        /// <summary>
        /// Converts the Access Control List to a <see cref="string"/>.
        /// </summary>
        /// <param name="acl">The Access Control List to serialize</param>
        /// <returns>string</returns>
        public static string SerializeList(IList<PathAccessControlEntry> acl)
        {
            IList<string> serializedAcl = new List<string>();
            foreach (PathAccessControlEntry ac in acl)
            {
                serializedAcl.Add(ac.ToString());
            }
            return string.Join(",", serializedAcl);
        }

        /// <summary>
        /// Deseralizes an acl into a List of PathAccessControlEntries.
        /// </summary>
        /// <param name="str">The string to parse.</param>
        /// <returns>A List of <see cref="PathAccessControlEntry"/>.</returns>
        public static IList<PathAccessControlEntry> ParseList(string str)
        {
            string[] strings = str.Split(',');
            List<PathAccessControlEntry> accessControlList = new List<PathAccessControlEntry>();
            foreach (string entry in strings)
            {
                accessControlList.Add(Parse(entry));
            }
            return accessControlList;
        }

        /// <summary>
        /// Override Equals().
        /// </summary>
        /// <param name="other">Another <see cref="PathAccessControlEntry"/></param>
        /// <returns></returns>
        public bool Equals(PathAccessControlEntry other)
        {
            if (other != null
                && DefaultScope == other.DefaultScope
                && AccessControlType == other.AccessControlType
                && EntityId == other.EntityId
                && Permissions.Equals(other.Permissions))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Override Equals
        /// </summary>
        /// <param name="other">An <see cref="object"/></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            return other is PathAccessControlEntry && Equals((PathAccessControlEntry)other);
        }

        internal static AccessControlType ParseAccesControlType(string typeString)
        {
            if ("user".Equals(typeString, StringComparison.InvariantCultureIgnoreCase))
            {
                return AccessControlType.User;
            }
            else if ("group".Equals(typeString, StringComparison.InvariantCultureIgnoreCase))
            {
                return AccessControlType.Group;
            }
            else if ("mask".Equals(typeString, StringComparison.InvariantCultureIgnoreCase))
            {
                return AccessControlType.Mask;
            }
            else if ("other".Equals(typeString, StringComparison.InvariantCultureIgnoreCase))
            {
                return AccessControlType.Other;
            }
            else
            {
                throw Errors.InvalidArgument(nameof(typeString));
            }
        }

        /// <summary>
        /// Get a hash code for the PathAccessControlEntry.
        /// </summary>
        /// <returns>Hash code for the PathAccessControlEntry.</returns>
        public override int GetHashCode() =>
            DefaultScope.GetHashCode()
            ^ AccessControlType.GetHashCode()
            ^ EntityId.GetHashCode()
            ^ (int)Permissions;
    }
}
