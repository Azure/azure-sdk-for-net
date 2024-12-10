// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// The mode permissions of the file or directory.
    /// </summary>
    public class NfsFileMode
    {
        /// <summary>
        /// Permissions the owner has over the file or directory.
        /// </summary>
        public PosixRolePermissions Owner { get; set; }

        /// <summary>
        /// Permissions the group has over the file or directory.
        /// </summary>
        public PosixRolePermissions Group { get; set; }

        /// <summary>
        /// Permissions other have over the file or directory.
        /// </summary>
        public PosixRolePermissions Other { get; set; }

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
            // https://en.wikipedia.org/wiki/File-system_permissions#Numeric_notation
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
        /// <param name="modeString">
        /// A 4-digit octal string representation of a File Mode.
        /// </param>
        public static NfsFileMode ParseOctalFileMode(string modeString)
        {
            // https://en.wikipedia.org/wiki/File-system_permissions#Numeric_notation
            if (modeString == null)
            {
                return null;
            }

            if (modeString.Length != 4)
            {
                throw Errors.InvalidFormat(nameof(modeString));
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

        /// <summary>
        /// Returns this <see cref="NfsFileMode"/> as a string in symbolic notation.
        /// </summary>
        public string ToSymbolicFileMode()
        {
            // https://en.wikipedia.org/wiki/File-system_permissions#Symbolic_notation
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Owner.ToSymbolicRolePermissions());
            stringBuilder.Append(Group.ToSymbolicRolePermissions());
            stringBuilder.Append(Other.ToSymbolicRolePermissions());

            if (EffectiveUserIdentity)
            {
                if (stringBuilder[2] == 'x')
                {
                    stringBuilder[2] = 's';
                }
                else
                {
                    stringBuilder[2] = 'S';
                }
            }

            if (EffectiveGroupIdentity)
            {
                if (stringBuilder[5] == 'x')
                {
                    stringBuilder[5] = 's';
                }
                else
                {
                    stringBuilder[5] = 'S';
                }
            }

            if (StickyBit)
            {
                if (stringBuilder[8] == 'x')
                {
                    stringBuilder[8] = 't';
                }
                else
                {
                    stringBuilder[8] = 'T';
                }
            }
            return stringBuilder.ToString();
        }
        /// <summary>
        /// Returns a <see cref="NfsFileMode"/> from the symbolic string representation.
        /// </summary>
        /// <param name="modeString">
        /// A 9-character symbolic string representation of a File Mode.
        /// </param>
        public static NfsFileMode ParseSymbolicFileMode(string modeString)
        {
            // https://en.wikipedia.org/wiki/File-system_permissions#Symbolic_notation
            if (modeString == null)
            {
                return null;
            }

            if (modeString.Length != 9)
            {
                throw Errors.InvalidFormat(nameof(modeString));
            }

            NfsFileMode nfsFileMode = new NfsFileMode();

            nfsFileMode.Owner = RolePermissionExtensions.ParseSymbolicRolePermissions(modeString.Substring(0, 3), out bool effectiveUserIdentity);
            nfsFileMode.EffectiveUserIdentity = effectiveUserIdentity;

            nfsFileMode.Group = RolePermissionExtensions.ParseSymbolicRolePermissions(modeString.Substring(3, 3), out bool effectiveGroupIdentity);
            nfsFileMode.EffectiveGroupIdentity = effectiveGroupIdentity;

            nfsFileMode.Other = RolePermissionExtensions.ParseSymbolicRolePermissions(modeString.Substring(6, 3), out bool stickyBit);
            nfsFileMode.StickyBit = stickyBit;

            return nfsFileMode;
        }

        /// <inheritdoc />
        public override string ToString() => ToSymbolicFileMode();
    }
}
