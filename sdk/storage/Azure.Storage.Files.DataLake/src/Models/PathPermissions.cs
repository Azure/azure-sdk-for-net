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
        public bool ExtendedInfoInAcl { get; set; }

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
            ExtendedInfoInAcl = extendedInfoInAcl;
        }

        /// <summary>
        /// Parses a string in octal format to PathPermissions.
        /// </summary>
        /// <param name="octalString">Octal string to parse.</param>
        /// <returns><see cref="PathPermissions"/>.</returns>
        public static PathPermissions ParseOctal(string octalString)
        {
            if (octalString == null)
            {
                return null;
            }

            if (octalString.Length != 4)
            {
                throw new ArgumentException("octalString must be 4 characters");
            }

            var pathPermissions = new PathPermissions();

            if (octalString[0] == '0')
            {
                pathPermissions.StickyBit = false;
            }
            else if (octalString[0] == '1')
            {
                pathPermissions.StickyBit = true;
            }
            else
            {
                throw new ArgumentException("First digit of octalString must be 0 or 1");
            }

            pathPermissions.Owner = RolePermissionsExtensions.ParseOctal(octalString[1]);
            pathPermissions.Group = RolePermissionsExtensions.ParseOctal(octalString[2]);
            pathPermissions.Other = RolePermissionsExtensions.ParseOctal(octalString[3]);

            return pathPermissions;
        }

        /// <summary>
        /// Parses a symbolic string to PathPermissions.
        /// </summary>
        /// <param name="symbolicString">String to parse</param>
        /// <returns><see cref="PathPermissions"/></returns>
        public static PathPermissions ParseSymbolic(string symbolicString)
        {
            if (symbolicString == null)
            {
                return null;
            }

            if (symbolicString.Length != 9 && symbolicString.Length != 10)
            {
                throw new ArgumentException("symbolicString must be 9 or 10 characters");
            }

            var pathPermissions = new PathPermissions();

            // Set sticky bit
            if (symbolicString.ToLower(CultureInfo.InvariantCulture)[8] == 't')
            {
                pathPermissions.StickyBit = true;
            }
            else
            {
                pathPermissions.StickyBit = false;
            }

            // Set extended info in ACL
            if (symbolicString.Length == 10)
            {
                if (symbolicString[9] == '+')
                {
                    pathPermissions.ExtendedInfoInAcl = true;
                }
                else
                {
                    throw Errors.InvalidFormat(nameof(symbolicString));
                }
            }
            else
            {
                pathPermissions.ExtendedInfoInAcl = false;
            }

            pathPermissions.Owner = RolePermissionsExtensions.ParseSymbolic(symbolicString.Substring(0, 3), allowStickyBit: false);
            pathPermissions.Group = RolePermissionsExtensions.ParseSymbolic(symbolicString.Substring(3, 3), allowStickyBit: false);
            pathPermissions.Other = RolePermissionsExtensions.ParseSymbolic(symbolicString.Substring(6, 3), allowStickyBit: true);

            return pathPermissions;
        }

        /// <summary>
        /// Returns the octal representation of this PathPermissions as a string.
        /// </summary>
        /// <returns>string</returns>
        public string ToOctalString()
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

            sb.Append(Owner.ToOctalString());
            sb.Append(Group.ToOctalString());
            sb.Append(Other.ToOctalString());

            return sb.ToString();
        }

        /// <summary>
        /// Returns the symbolic represenation of this PathPermissions as a string.
        /// </summary>
        /// <returns>string</returns>
        public string ToSymbolicString()
        {
            var sb = new StringBuilder();
            sb.Append(Owner.ToSymbolicString());
            sb.Append(Group.ToSymbolicString());
            sb.Append(Other.ToSymbolicString());

            if (StickyBit)
            {
                sb.Remove(8, 1);
                sb.Append("t");
            }

            if (ExtendedInfoInAcl)
            {
                sb.Append("+");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Equals.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(PathPermissions other)
        {
            if (other != null
                && Owner.Equals(other.Owner)
                && Group.Equals(other.Group)
                && Other.Equals(other.Other)
                && StickyBit == other.StickyBit
                && ExtendedInfoInAcl == other.ExtendedInfoInAcl)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Equals.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            return other is PathPermissions && Equals((PathPermissions)other);
        }

        /// <summary>
        /// Get a hash code for the PathPermissions.
        /// </summary>
        /// <returns>Hash code for the PathPermissions.</returns>
        public override int GetHashCode() =>
            int.Parse(ToOctalString(), CultureInfo.InvariantCulture);
    }
}
