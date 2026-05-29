// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Xml.Serialization;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    // These error messages are only used by client libraries and not by the common
    internal partial class Errors
    {
        public static ArgumentException CannotBothBeNotNull(string param0, string param1)
            => new ArgumentException($"{param0} and {param1} cannot both be set");

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

        public static ArgumentException InvalidDateTimeUtc(string dateTime) =>
            new ArgumentException($"{dateTime} must be UTC");

        public static ArgumentException StreamMustBeReadable(string paramName)
            => new ArgumentException("Stream must be readable", paramName);

        public static InvalidOperationException StreamMustBeAtPosition0()
            => new InvalidOperationException("Stream must be set to position 0");

        public static InvalidOperationException TokenCredentialsRequireHttps()
            => new InvalidOperationException("Use of token credentials requires HTTPS");

        public static ArgumentException SasCredentialRequiresUriWithoutSas<TUriBuilder>(Uri uri)
        {
            UriBuilder uriBuilder = new UriBuilder(uri);
            uriBuilder.Query = "[REDACTED]";
            Uri redactedUri = uriBuilder.Uri;

            return new ArgumentException(
                $"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature: {redactedUri}\n" +
                $"You can remove the shared access signature by creating a {typeof(TUriBuilder).Name}, setting {typeof(TUriBuilder).Name}.Sas to null," +
                $" and calling {typeof(TUriBuilder).Name}.ToUri.");
        }

        public static InvalidOperationException SasMissingData(string paramName)
            => new InvalidOperationException($"SAS is missing required parameter: {paramName}");

        public static InvalidOperationException SasDataNotAllowed(string paramName, string paramNameNotAllowed)
            => new InvalidOperationException($"SAS cannot have the {paramNameNotAllowed} parameter when the {paramName} parameter is present");

        public static InvalidOperationException SasDataInConjunction(string paramName, string paramName2)
            => new InvalidOperationException($"SAS cannot have the following parameters specified in conjunction: {paramName}, {paramName2}");

        public static InvalidOperationException SasNamesNotMatching(string builderParam, string builderName, string clientParam)
            => new InvalidOperationException($"SAS Uri cannot be generated. {builderName}.{builderParam} does not match {clientParam} in the Client. " +
                    $"{builderName}.{builderParam} must either be left empty or match the {clientParam} in the Client");

        public static InvalidOperationException SasNamesNotMatching(string builderParam, string builderName)
            => new InvalidOperationException($"SAS Uri cannot be generated. {builderName}.{builderParam} does not match snapshot value in the URI in the Client. " +
                    $"{builderName}.{builderParam} must either be left empty or match the snapshot value in the URI in the Client");

        public static InvalidOperationException SasServiceNotMatching(string builderParam, string builderName, string expectedService)
            => new InvalidOperationException($"SAS Uri cannot be generated. {builderName}.{builderParam} does specify {expectedService}. " +
                    $"{builderName}.{builderParam} must either specify {expectedService} or specify all Services are accessible in the value.");

        public static InvalidOperationException SasClientMissingData(string paramName)
            => new InvalidOperationException($"SAS Uri cannot be generated. {paramName} in the client has not been set");

        public static InvalidOperationException SasBuilderEmptyParam(string builderName, string paramName, string sasType)
            => new InvalidOperationException($"SAS Uri cannot be generated. {builderName}.{paramName} cannot be set to create a {sasType} SAS.");

        public static InvalidOperationException SasIncorrectResourceType(string builderName, string builderParam, string value, string clientName)
            => new InvalidOperationException($"SAS Uri cannot be generated. Expected {builderName}.{builderParam} to be set to {value} to generate " +
                $"the respective SAS for the client, {clientName}");

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

        public static RequestFailedException ClientRequestIdMismatch(Response response, string echo, string original)
            => new RequestFailedException(response.Status, $"Response x-ms-client-request-id '{echo}' does not match the original expected request id, '{original}'.", null);

        public static InvalidDataException StructuredMessageNotAcknowledgedGET(Response response)
            => new InvalidDataException($"Response does not acknowledge structured message was requested. Unknown data structure in response body.");

        public static InvalidDataException StructuredMessageNotAcknowledgedPUT(Response response)
            => new InvalidDataException($"Response does not acknowledge structured message was sent. Unexpected data may have been persisted to storage.");

        public static ArgumentException TransactionalHashingNotSupportedWithClientSideEncryption()
            => new ArgumentException("Client-side encryption and transactional hashing are not supported at the same time.");

        public static InvalidDataException ExpectedStructuredMessage()
            => new InvalidDataException($"Expected {Constants.StructuredMessage.StructuredMessageHeader} in response, but found none.");

        public static void VerifyHttpsTokenAuth(Uri uri)
        {
            if (uri.Scheme != Constants.Https)
            {
                throw new ArgumentException("Cannot use TokenCredential without HTTPS.");
            }
        }

        public static class ClientSideEncryption
        {
            public static ArgumentException UnrecognizedVersion()
                => new ArgumentException($"Unrecognized ClientSideEncryptionVersion");

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
