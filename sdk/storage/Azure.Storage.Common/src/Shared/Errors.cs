// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;

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
            => new ArgumentException($"Cannot upload {streamLength} bytes with a maximum transfer size of {statedMaxBlockSize} bytes per block. Please increase the StorageTransferOptions.MaximumTransferSize to at least {necessaryMinBlockSize}.");

        internal static void VerifyStreamPosition(Stream stream, string streamName)
        {
            if (stream != null && stream.CanSeek && stream.Length > 0 && stream.Position >= stream.Length)
            {
                throw new ArgumentException($"{streamName}.{nameof(stream.Position)} must be less than {streamName}.{nameof(stream.Length)}. Please set {streamName}.{nameof(stream.Position)} to the start of the data to upload.");
            }
        }
    }
}
