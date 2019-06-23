// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage
{
    /// <summary>
    /// Create exceptions for common error cases.
    /// </summary>
    internal static class Errors
    {
        public static ArgumentNullException ArgumentNull(string paramName) =>
            new ArgumentNullException(paramName);

        public static ArgumentOutOfRangeException MustBeGreaterThanOrEqualTo(string paramName, long value) =>
            new ArgumentOutOfRangeException(paramName, $"Value must be greater than or equal to {value}");

        public static ArgumentOutOfRangeException MustBeGreaterThanValueOrEqualToOtherValue(string paramName, long value0, long value1) =>
            new ArgumentOutOfRangeException(paramName, $"Value must be greater than {value0} or equal to {value1}");

        public static ArgumentException StreamMustBeReadable(string paramName) =>
            new ArgumentException("Stream must be readable", paramName);

        public static InvalidOperationException StreamMustBeAtPosition0() =>
            new InvalidOperationException("Stream must be set to position 0");

        public static InvalidOperationException TokenCredentialsRequireHttps() =>
            new InvalidOperationException("Use of token credentials requires HTTPS");

        public static InvalidOperationException AccountSasMissingData() =>
            new InvalidOperationException($"Account SAS is missing at least one of these: ExpiryTime, Permissions, Service, or ResourceType");

        public static ArgumentException InvalidService(char s) =>
            new ArgumentException($"Invalid service: '{s}'");

        public static ArgumentException InvalidPermission(char s) =>
            new ArgumentException($"Invalid permission: '{s}'");

        public static ArgumentException InvalidResourceType(char s) =>
            new ArgumentException($"Invalid resource type: '{s}'");

        public static ArgumentOutOfRangeException BlobConditionsMustBeDefault(params string[] conditions) =>
            new ArgumentOutOfRangeException($"The {String.Join(" and ", conditions)} conditions must have their default values because they are ignored by the blob service");        
    }
}
