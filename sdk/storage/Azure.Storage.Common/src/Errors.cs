// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Security.Authentication;

namespace Azure.Storage
{
    /// <summary>
    /// Create exceptions for common error cases.
    /// </summary>
    internal class Errors
    {
        public static ArgumentNullException ArgumentNull(string paramName)
            => new ArgumentNullException(paramName);

        public static ArgumentException CannotBothBeNotNull(string param0, string param1)
            => new ArgumentException($"{param0} and {param1} cannot both be set");

        public static ArgumentException InvalidArgument(string paramName)
            => new ArgumentException($"{paramName} is invalid");

        public static ArgumentOutOfRangeException MustBeGreaterThanOrEqualTo(string paramName, long value)
            => new ArgumentOutOfRangeException(paramName, $"Value must be greater than or equal to {value}");

        public static ArgumentOutOfRangeException MustBeLessThanOrEqualTo(string paramName, long value)
            => new ArgumentOutOfRangeException(paramName, $"Value must be less than or equal to {value}");

        public static ArgumentOutOfRangeException MustBeGreaterThanValueOrEqualToOtherValue(
                string paramName,
                long value0,
                long value1)
            => new ArgumentOutOfRangeException(paramName, $"Value must be greater than {value0} or equal to {value1}");

        public static ArgumentOutOfRangeException InvalidSasProtocol(string protocol, string sasProtocol)
            => new ArgumentOutOfRangeException(protocol, $"Invalid {sasProtocol} value");

        public static ArgumentException StreamMustBeReadable(string paramName)
            => new ArgumentException("Stream must be readable", paramName);

        public static InvalidOperationException StreamMustBeAtPosition0()
            => new InvalidOperationException("Stream must be set to position 0");

        public static InvalidOperationException TokenCredentialsRequireHttps()
            => new InvalidOperationException("Use of token credentials requires HTTPS");

        public static InvalidOperationException AccountSasMissingData()
            => new InvalidOperationException($"Account SAS is missing at least one of these: ExpiryTime, Permissions, Service, or ResourceType");

        public static InvalidOperationException SasMissingData(string paramName)
            => new InvalidOperationException($"SAS is missing required parameter: {paramName}");

        public static InvalidOperationException TaskIncomplete()
            => new InvalidOperationException("Task is not completed");

        public static ArgumentException InvalidService(char s)
            => new ArgumentException($"Invalid service: '{s}'");

        public static ArgumentException InvalidPermission(char s)
            => new ArgumentException($"Invalid permission: '{s}'");

        public static ArgumentException InvalidResourceType(char s)
            => new ArgumentException($"Invalid resource type: '{s}'");

        public static ArgumentException VersionNotSupported(string paramName)
           => new ArgumentException($"The version specified by {paramName} is not supported by this library.");

        public static ArgumentException AccountMismatch(string accountNameCredential, string accountNameValue)
            => new ArgumentException(string.Format(
                CultureInfo.CurrentCulture,
                "Account Name Mismatch: {0} != {1}",
                accountNameCredential,
                accountNameValue));

        public static ArgumentException ParsingConnectionStringFailed()
            => new ArgumentException("Connection string parsing error");

        public static ArgumentException ParsingHttpRangeFailed()
            => new ArgumentException("Could not parse the serialized range.");

        public static FormatException InvalidFormat(string err)
            => new FormatException(err);

        public static AccessViolationException UnableAccessArray()
            => new AccessViolationException("Unable to get array from memory pool");

        public static NotImplementedException NotImplemented()
            => new NotImplementedException();

        public static AuthenticationException InvalidCredentials(string fullName)
            => new AuthenticationException($"Cannot authenticate credentials with {fullName}");

        public static RequestFailedException ClientRequestIdMismatch(Response response, string echo, string original)
            => StorageExceptionExtensions.CreateException(
                    response,
                    $"Response x-ms-client-request-id '{echo}' does not match the original expected request id, '{original}'.");

        public static ArgumentException SeekOutsideBufferRange(long index, long inclusiveRangeStart, long exclusiveRangeEnd)
            => new ArgumentException($"Tried to seek ouside buffer range. Gave index {index}, range is [{inclusiveRangeStart},{exclusiveRangeEnd}).");
    }
}
