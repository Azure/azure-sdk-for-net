// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Only applicable to NFS files and directories.
    /// The mode permissions of the file or directory.
    /// </summary>
    public class NfsFileMode
    {
        /// <summary>
        /// Permissions the owner has over the file or directory.
        /// </summary>
        public RolePermissions Owner { get; set; }

        /// <summary>
        /// Permissions the group has over the file or directory.
        /// </summary>
        public RolePermissions Group { get; set; }

        /// <summary>
        /// Permissions other have over the file or directory.
        /// </summary>
        public RolePermissions Other { get; set; }

        /// <summary>
        /// Set effective user ID (setuid) on the file or directory.
        /// </summary>
        public bool EffectiveUserIdentity { get; set; }

        /// <summary>
        /// Set effective group ID (setgid) on the file or directory.
        /// </summary>
        public bool EffectiveGroupIdentity { get; set; }

        /// <summary>
        /// The sticky bit may be set on directories.  The files in that
        /// directory may only be renamed or deleted by the file's owner, the directory's owner, or the root user.
        /// </summary>
        public bool StickyBit { get; set; }

        /// <summary>
        /// Returns the octal represenation of this <see cref="NfsFileMode"/> as a string.
        /// </summary>
        public string ToOctalFileMode()
        {
            StringBuilder stringBuilder = new StringBuilder();

            int higherOrderDigit = 0;

            if (EffectiveUserIdentity)
            {
                higherOrderDigit |= 4;
            }

            if (EffectiveGroupIdentity)
            {
                higherOrderDigit |= 2;
            }

            if (StickyBit)
            {
                higherOrderDigit |= 1;
            }

            stringBuilder.Append(higherOrderDigit.ToString(CultureInfo.InvariantCulture));
            stringBuilder.Append(Owner.ToOctalRolePermissions());
            stringBuilder.Append(Group.ToOctalRolePermissions());
            stringBuilder.Append(Other.ToOctalRolePermissions());
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns a <see cref="NfsFileMode"/> from the octal string representation.
        /// </summary>
        public static NfsFileMode ParseOctalFileMode(string modeString)
        {
            if (modeString == null)
            {
                return null;
            }

            NfsFileMode nfsFileMode = new NfsFileMode
            {
                Owner = RolePermissionExtensions.ParseOctalRolePermissions(modeString[1]),
                Group = RolePermissionExtensions.ParseOctalRolePermissions(modeString[2]),
                Other = RolePermissionExtensions.ParseOctalRolePermissions(modeString[3])
            };

            int value = (int)char.GetNumericValue(modeString[0]);

            if ((value & 4) > 0)
            {
                nfsFileMode.EffectiveUserIdentity = true;
            }

            if ((value & 2) > 0)
            {
                nfsFileMode.EffectiveGroupIdentity = true;
            }

            if ((value & 1) > 0)
            {
                nfsFileMode.StickyBit = true;
            }

            return nfsFileMode;
        }
    }
}
