// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Extension methods for RolePermissions.
    /// </summary>
    public static class PathAccessControlExtensions
    {
        /// <summary>
        /// Parses octal char to RolePermissions.
        /// </summary>
        public static RolePermissions ParseOctalRolePermissions(char c)
        {
            RolePermissions rolePermissions = RolePermissions.None;

            int value = (int)char.GetNumericValue(c);

            if (value < 0 || value > 7)
            {
                throw Errors.MustBeBetweenInclusive(nameof(c), 0, 7, value);
            }

            if ((value & 4) > 0)
            {
                rolePermissions |= RolePermissions.Read;
            }

            if ((value & 2) > 0)
            {
                rolePermissions |= RolePermissions.Write;
            }

            if ((value & 1) > 0)
            {
                rolePermissions |= RolePermissions.Execute;
            }

            return rolePermissions;
        }

        /// <summary>
        /// Parses symbolic permissions string to RolePermissions.
        /// </summary>
        /// <param name="s">String to parse.</param>
        /// <param name="allowStickyBit">If sticky bit is allowed.</param>
        /// <returns><see cref="RolePermissions"/>.</returns>
        public static RolePermissions ParseSymbolicRolePermissions(string s, bool allowStickyBit = false)
        {
            RolePermissions rolePermissions = RolePermissions.None;
            ArgumentException argumentException = DataLakeErrors.RolePermissionsSymbolicInvalidCharacter(s);

            if (s == null)
            {
                throw Errors.ArgumentNull(nameof(s));
            }

            if (s.Length != 3)
            {
                throw DataLakeErrors.RolePermissionsSymbolicInvalidLength(s);
            }

            if (s[0] == 'r')
            {
                rolePermissions |= RolePermissions.Read;
            }
            else if (s[0] != '-')
            {
                throw argumentException;
            }

            if (s[1] == 'w')
            {
                rolePermissions |= RolePermissions.Write;
            }
            else if (s[1] != '-')
            {
                throw argumentException;
            }

            if (s[2] == 'x')
            {
                rolePermissions |= RolePermissions.Execute;
            }
            else if (allowStickyBit && (s[2] == 'T'))
            {
                // This means both sticky bit and execute is enabled.
                rolePermissions |= RolePermissions.Execute;
            }
            else if ((s[2] != '-') && (s[2] != 't'))
            {
                throw argumentException;
            }

            return rolePermissions;
        }

        /// <summary>
        /// Returns the octal string representation of this RolePermissions.
        /// </summary>
        /// <returns>String.</returns>
        public static string ToOctalRolePermissions(this RolePermissions rolePermissions)
        {
            int result = 0;

            if (rolePermissions.HasFlag(RolePermissions.Read))
            {
                result |= 4;
            }

            if (rolePermissions.HasFlag(RolePermissions.Write))
            {
                result |= 2;
            }

            if (rolePermissions.HasFlag(RolePermissions.Execute))
            {
                result |= 1;
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the octal string respentation of this RolePermissions.
        /// </summary>
        /// <returns>String.</returns>
        public static string ToSymbolicRolePermissions(this RolePermissions rolePermissions)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(rolePermissions.HasFlag(RolePermissions.Read) ? "r" : "-");
            stringBuilder.Append(rolePermissions.HasFlag(RolePermissions.Write) ? "w" : "-");
            stringBuilder.Append(rolePermissions.HasFlag(RolePermissions.Execute) ? "x" : "-");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns the octal string respentation of this RolePermissions.
        /// </summary>
        /// <returns>String.</returns>
        public static string ToSymbolicRolePermissions(this RolePermissions rolePermissions, bool stickyBit)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(rolePermissions.HasFlag(RolePermissions.Read) ? "r" : "-");
            stringBuilder.Append(rolePermissions.HasFlag(RolePermissions.Write) ? "w" : "-");
            bool executeFlag = rolePermissions.HasFlag(RolePermissions.Execute);
            if (!stickyBit && executeFlag)
            {
                stringBuilder.Append('x');
            }
            else if (stickyBit && !executeFlag)
            {
                stringBuilder.Append('t');
            }
            else if (stickyBit && executeFlag)
            {
                stringBuilder.Append('T');
            }
            else
            {
                stringBuilder.Append('-');
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts the Access Control List to a <see cref="string"/>.
        /// </summary>
        /// <param name="accessControlList">The Access Control List to serialize</param>
        /// <returns>string.</returns>
        public static string ToAccessControlListString(IList<PathAccessControlItem> accessControlList)
        {
            if (accessControlList == null)
            {
                return null;
            }

            IList<string> serializedAcl = new List<string>();
            foreach (PathAccessControlItem ac in accessControlList)
            {
                serializedAcl.Add(ac.ToString());
            }
            return string.Join(",", serializedAcl);
        }

        /// <summary>
        /// Deseralizes an access control list string  into a list of PathAccessControlEntries.
        /// </summary>
        /// <param name="s">The string to parse.</param>
        /// <returns>A List of <see cref="PathAccessControlItem"/>.</returns>
        public static IList<PathAccessControlItem> ParseAccessControlList(string s)
        {
            if (s == null)
            {
                return null;
            }

            string[] strings = s.Split(',');
            List<PathAccessControlItem> accessControlList = new List<PathAccessControlItem>();
            foreach (string entry in strings)
            {
                accessControlList.Add(PathAccessControlItem.Parse(entry));
            }
            return accessControlList;
        }
    }
}
