﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Security.Authentication;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    // These error messages are only used by client libraries and not by the common
    internal partial class Errors
    {
        public static ArgumentException CannotBothBeNotNull(string param0, string param1)
            => new ArgumentException($"{param0} and {param1} cannot both be set");

        public static ArgumentException InvalidArgument(string paramName)
            => new ArgumentException($"{paramName} is invalid");

        public static ArgumentOutOfRangeException MustBeGreaterThanOrEqualTo(string paramName, long value)
            => new ArgumentOutOfRangeException(paramName, $"Value must be greater than or equal to {value}");

        public static ArgumentOutOfRangeException MustBeLessThanOrEqualTo(string paramName, long value)
            => new ArgumentOutOfRangeException(paramName, $"Value must be less than or equal to {value}");

        public static ArgumentOutOfRangeException MustBeBetweenInclusive(
                string paramName,
                long lower,
                long upper,
                long actual)
            => new ArgumentOutOfRangeException(paramName, $"Value must be between {lower} and {upper} inclusive, not {actual}");

        public static ArgumentOutOfRangeException MustBeGreaterThanValueOrEqualToOtherValue(
                string paramName,
                long value0,
                long value1)
            => new ArgumentOutOfRangeException(paramName, $"Value must be greater than {value0} or equal to {value1}");

        public static ArgumentException StreamMustBeReadable(string paramName)
            => new ArgumentException("Stream must be readable", paramName);

        public static InvalidOperationException StreamMustBeAtPosition0()
            => new InvalidOperationException("Stream must be set to position 0");

        public static InvalidOperationException TokenCredentialsRequireHttps()
            => new InvalidOperationException("Use of token credentials requires HTTPS");

        public static InvalidOperationException SasMissingData(string paramName)
            => new InvalidOperationException($"SAS is missing required parameter: {paramName}");

        public static InvalidOperationException SasDataNotAllowed(string paramName, string paramNameNotAllowed)
            => new InvalidOperationException($"SAS cannot have the {paramNameNotAllowed} parameter when the {paramName} parameter is present");

        public static InvalidOperationException SasDataInConjunction(string paramName, string paramName2)
            => new InvalidOperationException($"SAS cannot have the following parameters specified in conjunction: {paramName}, {paramName2}");

        public static ArgumentException InvalidPermission(char s)
            => new ArgumentException($"Invalid permission: '{s}'");

        public static ArgumentException ParsingHttpRangeFailed()
            => new ArgumentException("Could not parse the serialized range.");

        public static AccessViolationException UnableAccessArray()
            => new AccessViolationException("Unable to get array from memory pool");

        public static NotImplementedException NotImplemented()
            => new NotImplementedException();

        public static AuthenticationException InvalidCredentials(string fullName)
            => new AuthenticationException($"Cannot authenticate credentials with {fullName}");

        public static ArgumentException SeekOutsideBufferRange(long index, long inclusiveRangeStart, long exclusiveRangeEnd)
            => new ArgumentException($"Tried to seek ouside buffer range. Gave index {index}, range is [{inclusiveRangeStart},{exclusiveRangeEnd}).");

        public static ArgumentException VersionNotSupported(string paramName)
            => new ArgumentException($"The version specified by {paramName} is not supported by this library.");

        public static RequestFailedException ClientRequestIdMismatch(ClientDiagnostics clientDiagnostics, Response response, string echo, string original)
            => clientDiagnostics.CreateRequestFailedExceptionWithContent(
                response,
                $"Response x-ms-client-request-id '{echo}' does not match the original expected request id, '{original}'.", errorCode: response.GetErrorCode(null));

        public static void VerifyHttpsTokenAuth(Uri uri)
        {
            if (uri.Scheme != Constants.Https)
            {
                throw new ArgumentException("Cannot use TokenCredential without HTTPS.");
            }
        }

        public static class ClientSideEncryption
        {
            public static InvalidOperationException ClientSideEncryptionVersionNotSupported(string versionString = default)
                => new InvalidOperationException("This library does not support the given version of client-side encryption." +
                    versionString == default ? "" : $" Version ID = {versionString}");

            public static InvalidOperationException TypeNotSupported(Type type)
                => new InvalidOperationException(
                    $"Client-side encryption is not supported for type \"{type.FullName}\". " +
                    "Please use a supported client type or create this client without specifying client-side encryption options.");

            public static InvalidOperationException MissingRequiredEncryptionResources(params string[] resourceNames)
                => new InvalidOperationException("Cannot encrypt without specifying " + string.Join(",", resourceNames.AsEnumerable()));

            public static ArgumentException KeyNotFound(string keyId)
            => new ArgumentException($"Resolution of id {keyId} returned null.");

            public static ArgumentException BadEncryptionAgent(string agent)
                => new ArgumentException("Invalid Encryption Agent. This version of the client library does not understand" +
                    $"the Encryption Agent protocol \"{agent}\" set on the blob.");

            public static ArgumentException BadEncryptionAlgorithm(string algorithm)
                => new ArgumentException($"Invalid Encryption Algorithm \"{algorithm}\" found on the resource. This version of the client" +
                    "library does not support the given encryption algorithm.");

            public static InvalidOperationException MissingEncryptionMetadata(string field)
                => new InvalidOperationException($"Missing field \"{field}\" in encryption metadata");
        }
    }
}
