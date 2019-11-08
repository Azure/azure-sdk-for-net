// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// Extension methods for RolePermissions.
    /// </summary>
    public static class RolePermissionsExtensions
    {
        /// <summary>
        /// Parses octal char to RolePermissions.
        /// </summary>
        public static RolePermissions ParseOctal(char octalRolePermission)
        {
            RolePermissions rolePermissions = RolePermissions.None;

            int value = (int)char.GetNumericValue(octalRolePermission);

            if (value < 0 || value > 7)
            {
                throw Errors.MustBeBetweenInclusive(nameof(octalRolePermission), 0, 7);
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
        /// <param name="symbolicRolePermissions">String to parse.</param>
        /// <param name="allowStickyBit">If sticky bit is allowed.</param>
        /// <returns><see cref="RolePermissions"/>.</returns>
        public static RolePermissions ParseSymbolic(string symbolicRolePermissions, bool allowStickyBit)
        {
            RolePermissions rolePermissions = RolePermissions.None;
            ArgumentException argumentException = new ArgumentException("Role permission contains an invalid character");

            if (symbolicRolePermissions == null)
            {
                throw Errors.ArgumentNull(nameof(symbolicRolePermissions));
            }

            if (symbolicRolePermissions.Length != 3)
            {
                throw new ArgumentException("Role permission must be 3 characters");
            }

            if (symbolicRolePermissions[0] == 'r')
            {
                rolePermissions |= RolePermissions.Read;
            }
            else if (symbolicRolePermissions[0] != '-')
            {
                throw argumentException;
            }

            if (symbolicRolePermissions[1] == 'w')
            {
                rolePermissions |= RolePermissions.Write;
            }
            else if (symbolicRolePermissions[1] != '-')
            {
                throw argumentException;
            }

            if (symbolicRolePermissions[2] == 'x')
            {
                rolePermissions |= RolePermissions.Execute;
            }
            else if (allowStickyBit)
            {
                if (symbolicRolePermissions[2] == 't')
                {
                    rolePermissions |= RolePermissions.Execute;
                }
                else if (symbolicRolePermissions[2] != 'T' && symbolicRolePermissions[2] != '-')
                {
                    throw argumentException;
                }
            }
            else if (symbolicRolePermissions[2] != '-')
            {
                throw argumentException;
            }

            return rolePermissions;
        }

        /// <summary>
        /// Returns the octal string representation of this RolePermissions.
        /// </summary>
        /// <returns>String.</returns>
        public static string ToOctalString(this RolePermissions rolePermissions)
        {
            return rolePermissions.ToOctal().ToString(CultureInfo.InvariantCulture);
        }

        private static int ToOctal(this RolePermissions rolePermissions)
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

            return result;
        }

        /// <summary>
        /// Returns the octal string respentation of this RolePermissions.
        /// </summary>
        /// <returns>String</returns>
        public static string ToSymbolicString(this RolePermissions rolePermissions)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(rolePermissions.HasFlag(RolePermissions.Read) ? "r" : "-");
            stringBuilder.Append(rolePermissions.HasFlag(RolePermissions.Write) ? "w" : "-");
            stringBuilder.Append(rolePermissions.HasFlag(RolePermissions.Execute) ? "x" : "-");

            return stringBuilder.ToString();
        }
    }
}
