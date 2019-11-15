// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake
{
    internal class DataLakeErrors
    {
        public static ArgumentException EntityIdAndInvalidAccessControlType(string s)
            => new ArgumentException($"AccessControlType must be User or Group if entityId is specified.  Value is \"{s}\"");

        public static ArgumentException PathAccessControlItemStringInvalidLength(string s)
            => new ArgumentException($"{nameof(s)} should have 3 or 4 parts delimited by colons.  Value is \"{s}\"");

        public static ArgumentException PathAccessControlItemStringInvalidPrefix(string s)
            => new ArgumentException($"If {nameof(s)} is 4 parts, the first must be \"default\".  Value is \"{s}\"");

        public static ArgumentException PathPermissionsOctalInvalidLength(string s)
            => new ArgumentException($"{nameof(s)} must be 4 characters.  Value is \"{s}\"");

        public static ArgumentException PathPermissionsOctalInvalidFirstDigit(string s)
            => new ArgumentException($"First digit of {nameof(s)} must be 0 or 1.  Value is \"{s}\"");

        public static ArgumentException PathPermissionsSymbolicInvalidLength(string s)
            => new ArgumentException($"{nameof(s)} must be 9 or 10 characters.  Value is \"{s}\"");

        public static ArgumentException RolePermissionsSymbolicInvalidCharacter(string s)
            => new ArgumentException($"Role permission contains an invalid character.  Value is \"{s}\"");

        public static ArgumentException RolePermissionsSymbolicInvalidLength(string s)
            => new ArgumentException($"Role permission must be 3 characters.  Value is \"{s}\"");
    }
}
