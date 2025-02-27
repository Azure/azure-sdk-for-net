// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;

namespace Azure.Storage
{
    /// <summary>
    /// Create exceptions for common error cases.
    /// </summary>
    internal partial class Errors
    {
        public static ArgumentException AccountMismatch(string accountNameCredential, string accountNameValue)
            => new ArgumentException(string.Format(
                CultureInfo.CurrentCulture,
                "Account Name Mismatch: {0} != {1}",
                accountNameCredential,
                accountNameValue));

        public static InvalidOperationException AccountSasMissingData()
            => new InvalidOperationException($"Account SAS is missing at least one of these: ExpiryTime, Permissions, Service, or ResourceType");

        public static ArgumentNullException ArgumentNull(string paramName)
            => new ArgumentNullException(paramName);

        public static ArgumentException InvalidArgument(string paramName)
            => new ArgumentException($"{paramName} is invalid");

        public static ArgumentException InvalidResourceType(char s)
            => new ArgumentException($"Invalid resource type: '{s}'");

        public static InvalidOperationException TaskIncomplete()
            => new InvalidOperationException("Task is not completed");

        public static FormatException InvalidFormat(string err)
            => new FormatException(err);

        public static ArgumentException ParsingConnectionStringFailed()
            => new ArgumentException("Connection string parsing error");

        public static ArgumentOutOfRangeException InvalidSasProtocol(string protocol, string sasProtocol)
            => new ArgumentOutOfRangeException(protocol, $"Invalid {sasProtocol} value");

        public static ArgumentException InvalidService(char s)
            => new ArgumentException($"Invalid service: '{s}'");

        public static ArgumentException InsufficientStorageTransferOptions(long streamLength, long statedMaxBlockSize, long necessaryMinBlockSize)
            => new ArgumentException($"Cannot transfer {streamLength} bytes with a maximum transfer size of {statedMaxBlockSize} bytes per block. Please increase the TransferOptions.MaximumTransferChunkSize to at least {necessaryMinBlockSize}.");

        public static InvalidDataException HashMismatch(string hashHeaderName)
            => new InvalidDataException($"{hashHeaderName} did not match hash of recieved data.");

        public static InvalidDataException ChecksumMismatch(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
            => new InvalidDataException($"Compared checksums did not match. Invalid data may have been written to the destination. Left: {Convert.ToBase64String(left)} Right: {Convert.ToBase64String(right)}");
#else
            => new InvalidDataException($"Compared checksums did not match. Invalid data may have been written to the destination. Left: {Convert.ToBase64String(left.ToArray())} Right: {Convert.ToBase64String(right.ToArray())}");
#endif

        public static InvalidDataException HashMismatchOnStreamedDownload(string mismatchedRange)
            => new InvalidDataException($"Detected invalid data while streaming to the destination. Range {mismatchedRange} produced mismatched checksum.");

        public static ArgumentException PrecalculatedHashNotSupportedOnSplit()
            => new ArgumentException("Precalculated checksum not supported when potentially partitioning an upload.");

        public static ArgumentException CannotDeferTransactionalHashVerification()
            => new ArgumentException("Cannot defer transactional hash verification. Returned hash is unavailable to caller.");

        public static ArgumentException CannotInitializeWriteStreamWithData()
            => new ArgumentException("Initialized buffer for StorageWriteStream must be empty.");

        internal static void VerifyStreamPosition(Stream stream, string streamName)
        {
            if (stream != null && stream.CanSeek && stream.Length > 0 && stream.Position >= stream.Length)
            {
                throw new ArgumentException($"{streamName}.{nameof(stream.Position)} must be less than {streamName}.{nameof(stream.Length)}. Please set {streamName}.{nameof(stream.Position)} to the start of the data to upload.");
            }
        }

        public static void ThrowIfParamNull(object obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"Param: \"{paramName}\" is null");
            }
        }

        internal static void CheckCryptKeySize(int keySizeInBytes)
        {
            if (keySizeInBytes != (128 / 8) && keySizeInBytes != (192 / 8) && keySizeInBytes != (256 / 8))
            {
                throw new CryptographicException("Specified key is not a valid size for this algorithm.");
            }
        }

        /// <summary>
        /// From
        /// https://github.com/dotnet/runtime/blob/032a7dcbe1056493e8bab51e6b5b9503de727273/src/libraries/System.Security.Cryptography/src/Resources/Strings.resx#L202
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CryptographicException"></exception>
        public static CryptographicException CryptographyAuthTagMismatch()
            => throw new CryptographicException("The computed authentication tag did not match the input authentication tag.");

        /// <summary>
        /// From
        /// https://github.com/dotnet/runtime/blob/032a7dcbe1056493e8bab51e6b5b9503de727273/src/libraries/System.Security.Cryptography/src/Resources/Strings.resx#L514
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ArgumentException CryptographyPlaintextCiphertextLengthMismatch()
            => throw new ArgumentException("Plaintext and ciphertext must have the same length.");

        /// <summary>
        /// From
        /// https://github.com/dotnet/runtime/blob/032a7dcbe1056493e8bab51e6b5b9503de727273/src/libraries/System.Security.Cryptography/src/Resources/Strings.resx#L400
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ArgumentException CryptographyInvalidNonceLength()
            => throw new ArgumentException("The specified nonce is not a valid size for this algorithm.");

        /// <summary>
        /// From
        /// https://github.com/dotnet/runtime/blob/032a7dcbe1056493e8bab51e6b5b9503de727273/src/libraries/System.Security.Cryptography/src/Resources/Strings.resx#L418
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ArgumentException CryptographyInvalidTagLength()
            => throw new ArgumentException("The specified tag is not a valid size for this algorithm.");
    }
}
