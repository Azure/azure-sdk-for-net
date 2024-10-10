// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Extension methods for <see cref="RolePermissions"/>.
    /// </summary>
    public static class RolePermissionExtensions
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
    }
}
