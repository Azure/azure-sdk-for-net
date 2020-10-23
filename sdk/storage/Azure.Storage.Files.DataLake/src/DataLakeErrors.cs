// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Files.DataLake.Models;

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

        public static ArgumentException RemovePathAccessControlItemInvalidString(string s)
            => new ArgumentException($"{nameof(s)} must have 1 to 3 parts delimited by colons.  Value is \"{s}\"");

        public static ArgumentException RemovePathAccessControlItemStringInvalidPrefix(string s)
            => new ArgumentException($"If {nameof(s)} is 3 parts, the first must be \"default\".  Value is \"{s}\"");

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

        public static DataLakeAclChangeFailedException ChangeAclRequestFailed(RequestFailedException exception, string continuationToken)
            => new DataLakeAclChangeFailedException(
                $"An error occurred while recursively changing the access control list. " +
                $"See the {nameof(exception.InnerException)} of type {exception.GetType().FullName} " +
                $"with {nameof(exception.Status)}={exception.Status} and " +
                $"{nameof(exception.ErrorCode)}={exception.ErrorCode} for more information.  " +
                $"You can resume changing the access control list using " +
                $"{nameof(DataLakeAclChangeFailedException.ContinuationToken)}={continuationToken} " +
                $"after addressing the error.",
                exception,
                continuationToken);

        public static DataLakeAclChangeFailedException ChangeAclFailed(Exception exception, string continuationToken)
            => new DataLakeAclChangeFailedException(
                $"An error occurred while recursively changing the access control list. See the {nameof(exception.InnerException)} " +
                $"of type {exception.GetType().FullName} for more information. You can resume changing the access control list using " +
                $"{nameof(DataLakeAclChangeFailedException.ContinuationToken)}={continuationToken} after addressing the error.",
                exception,
                continuationToken);
    }
}
