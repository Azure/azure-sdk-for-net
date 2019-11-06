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
        public static RolePermissions ParseOctal(char octal)
        {
            RolePermissions rolePermissions = RolePermissions.All;

            int value = Convert.ToInt32(octal);

            if (value < 0 || value > 7)
            {
                Errors.InvalidArgument(nameof(octal));
            }

            if (value / 4 > 0)
            {
                rolePermissions |= RolePermissions.Read;
            }
            value %= 4;

            if (value / 2 > 0)
            {
                rolePermissions |= RolePermissions.Write;
            }
            value %= 2;

            if (value > 0)
            {
                rolePermissions |= RolePermissions.Execute;
            }

            return rolePermissions;
        }

        /// <summary>
        /// Parses symbolic permissions string to RolePermissions.
        /// </summary>
        /// <param name="str">String to parse.</param>
        /// <param name="allowStickyBit">If sticky bit is allowed.</param>
        /// <returns><see cref="RolePermissions"/>.</returns>
        public static RolePermissions ParseSymbolic(string str, bool allowStickyBit)
        {
            RolePermissions rolePermissions = RolePermissions.All;
            ArgumentException argumentException = Errors.InvalidArgument(nameof(str));

            if (str == null)
            {
                Errors.ArgumentNull(nameof(str));
            }

            if (str.Length < 3)
            {
                throw argumentException;
            }

            if (str.Length > 3)
            {
                throw argumentException;
            }

            if (str[0] == 'r')
            {
                rolePermissions |= RolePermissions.Read;
            }
            else if (str[0] != '-')
            {
                throw argumentException;
            }

            if (str[1] == 'w')
            {
                rolePermissions |= RolePermissions.Write;
            }
            else if (str[1] != '-')
            {
                throw argumentException;
            }

            if (str[2] == 'x')
            {
                rolePermissions |= RolePermissions.Execute;
            }
            else if (allowStickyBit)
            {
                if (str[2] == 't')
                {
                    rolePermissions |= RolePermissions.Execute;
                }
                else if (str[2] != 'T' && str[2] != '-')
                {
                    throw argumentException;
                }
            }
            else if (str[2] != '-')
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
                result |= (1 << 2);
            }

            if (rolePermissions.HasFlag(RolePermissions.Write))
            {
                result |= (1 << 1);
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
