// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Extension methods for <see cref="RolePermissions"/>.
    /// </summary>
    internal static class RolePermissionExtensions
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
        /// Returns the octal string representation of this RolePermissions.
        /// </summary>
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
        /// Returns the symbolic string representation of this RolePermissions.
        /// </summary>
        public static string ToSymbolicRolePermissions(this RolePermissions rolePermissions)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (rolePermissions.HasFlag(RolePermissions.Read))
            {
                stringBuilder.Append("r");
            }
            else
            {
                stringBuilder.Append("-");
            }

            if (rolePermissions.HasFlag(RolePermissions.Write))
            {
                stringBuilder.Append("w");
            }
            else
            {
                stringBuilder.Append("-");
            }

            if (rolePermissions.HasFlag(RolePermissions.Execute))
            {
                stringBuilder.Append("x");
            }
            else
            {
                stringBuilder.Append("-");
            }

            return stringBuilder.ToString();
        }

        public static RolePermissions ParseSymbolicRolePermissions(string s, out bool setSticky)
        {
            RolePermissions rolePermissions = new RolePermissions();
            setSticky = false;
            if (s[0] == 'r')
            {
                rolePermissions |= RolePermissions.Read;
            }
            if (s[1] == 'w')
            {
                rolePermissions |= RolePermissions.Write;
            }
            if (s[2] == 'x' || s[2] == 's' || s[2] == 't')
            {
                rolePermissions |= RolePermissions.Execute;
                if (s[2] == 's' || s[2] == 't')
                {
                    setSticky = true;
                }
            }
            if (s[2] == 'S' || s[2] == 'T')
            {
                setSticky = true;
            }

           return rolePermissions;
        }
    }
}
