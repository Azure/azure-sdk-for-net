// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Represents POSIX-style permissions on a given resource. Each resource specifies permissions for the owner, the owning
    /// group, and everyone else. Permissions for users or groups not included here can be set using an Access Control List.
    /// Manipulating resource permissions is only supported when ADLS interop is enabled.
    /// </summary>
    public class PathPermissions
    {
        /// <summary>
        /// The <see cref="RolePermissions"/> for the owner of the resource.
        /// </summary>
        public RolePermissions Owner { get; set; }

        /// <summary>
        /// The <see cref="RolePermissions"/> for the owning group of the resource.
        /// </summary>
        public RolePermissions Group { get; set; }

        /// <summary>
        /// The <see cref="RolePermissions"/> for the other users.
        /// </summary>
        public RolePermissions Other { get; set; }

        /// <summary>
        /// If the sticky bit has been set. The sticky bit may be set on directories, the files in that
        /// directory may only be renamed or deleted by the file's owner, the directory's owner, or the root user.
        /// </summary>
        public bool StickyBit { get; set; }

        /// <summary>
        /// Whether or not there is more permissions information in the ACLs. The permissions string only returns
        /// information on the owner, owning group, and other, but the ACLs may contain more permissions for specific users
        /// or groups.
        /// </summary>
        public bool ExtendedAcls { get; set; }

        /// <summary>
        /// Internal empty constructor.
        /// </summary>
        public PathPermissions() { }

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="owner">The path owner's permissions.</param>
        /// <param name="group">The path group's permissions.</param>
        /// <param name="other">Permissions for other users.</param>
        /// <param name="stickyBit">If sticky bit is enabled</param>
        /// <param name="extendedInfoInAcl">If there is extended info in the ACL</param>
        public PathPermissions(
            RolePermissions owner,
            RolePermissions group,
            RolePermissions other,
            bool stickyBit = false,
            bool extendedInfoInAcl = false)
        {
            Owner = owner;
            Group = group;
            Other = other;
            StickyBit = stickyBit;
            ExtendedAcls = extendedInfoInAcl;
        }

        /// <summary>
        /// Parses a string in octal format to PathPermissions.
        /// </summary>
        /// <param name="s">Octal string to parse.</param>
        /// <returns><see cref="PathPermissions"/>.</returns>
        public static PathPermissions ParseOctalPermissions(string s)
        {
            if (s == null)
            {
                return null;
            }

            if (s.Length != 4)
            {
                throw DataLakeErrors.PathPermissionsOctalInvalidLength(s);
            }

            var pathPermissions = new PathPermissions();

            if (s[0] == '0')
            {
                pathPermissions.StickyBit = false;
            }
            else if (s[0] == '1')
            {
                pathPermissions.StickyBit = true;
            }
            else
            {
                throw DataLakeErrors.PathPermissionsOctalInvalidFirstDigit(s);
            }

            pathPermissions.Owner = PathAccessControlExtensions.ParseOctalRolePermissions(s[1]);
            pathPermissions.Group = PathAccessControlExtensions.ParseOctalRolePermissions(s[2]);
            pathPermissions.Other = PathAccessControlExtensions.ParseOctalRolePermissions(s[3]);

            return pathPermissions;
        }

        /// <summary>
        /// Parses a symbolic string to PathPermissions.
        /// </summary>
        /// <param name="s">String to parse.</param>
        /// <returns><see cref="PathPermissions"/>.</returns>
        public static PathPermissions ParseSymbolicPermissions(string s)
        {
            if (s == null)
            {
                return null;
            }

            if (s.Length != 9 && s.Length != 10)
            {
                throw DataLakeErrors.PathPermissionsSymbolicInvalidLength(s);
            }

            var pathPermissions = new PathPermissions();

            // Set sticky bit
            if (char.ToLower(s[8], CultureInfo.InvariantCulture) == 't')
            {
                pathPermissions.StickyBit = true;
            }
            else
            {
                pathPermissions.StickyBit = false;
            }

            // Set extended info in ACL
            if (s.Length == 10)
            {
                if (s[9] == '+')
                {
                    pathPermissions.ExtendedAcls = true;
                }
                else
                {
                    throw Errors.InvalidFormat(nameof(s));
                }
            }
            else
            {
                pathPermissions.ExtendedAcls = false;
            }

            pathPermissions.Owner = PathAccessControlExtensions.ParseSymbolicRolePermissions(s.Substring(0, 3), allowStickyBit: false);
            pathPermissions.Group = PathAccessControlExtensions.ParseSymbolicRolePermissions(s.Substring(3, 3), allowStickyBit: false);
            pathPermissions.Other = PathAccessControlExtensions.ParseSymbolicRolePermissions(s.Substring(6, 3), allowStickyBit: true);

            return pathPermissions;
        }

        /// <summary>
        /// Returns the octal representation of this PathPermissions as a string.
        /// </summary>
        /// <returns>string</returns>
        public string ToOctalPermissions()
        {
            var sb = new StringBuilder();

            if (StickyBit)
            {
                sb.Append(1);
            }
            else
            {
                sb.Append(0);
            }

            sb.Append(Owner.ToOctalRolePermissions());
            sb.Append(Group.ToOctalRolePermissions());
            sb.Append(Other.ToOctalRolePermissions());

            return sb.ToString();
        }

        /// <summary>
        /// Returns the symbolic represenation of this PathPermissions as a string.
        /// </summary>
        /// <returns>string.</returns>
        public string ToSymbolicPermissions()
        {
            var sb = new StringBuilder();
            sb.Append(Owner.ToSymbolicRolePermissions());
            sb.Append(Group.ToSymbolicRolePermissions());
            sb.Append(Other.ToSymbolicRolePermissions());

            if (StickyBit)
            {
                sb.Remove(8, 1);
                sb.Append('t');
            }

            if (ExtendedAcls)
            {
                sb.Append('+');
            }

            return sb.ToString();
        }
    }
}
