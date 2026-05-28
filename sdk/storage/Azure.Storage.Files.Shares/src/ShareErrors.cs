// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;

namespace Azure.Storage.Files.Shares
{
    internal static class ShareErrors
    {
        public static JsonException InvalidPermissionJson(string json) =>
            throw new JsonException("Expected { \"permission\": \"...\" }, not " + json);

        public static InvalidOperationException FileOrShareMissing(
            string leaseClient,
            string fileClient,
            string shareClient) =>
            new InvalidOperationException($"{leaseClient} requires either a {fileClient} or {shareClient}");
        public static void AssertAlgorithmSupport(StorageChecksumAlgorithm? algorithm)
        {
            StorageChecksumAlgorithm resolved = (algorithm ?? StorageChecksumAlgorithm.None).ResolveAuto();
            switch (resolved)
            {
                case StorageChecksumAlgorithm.None:
                case StorageChecksumAlgorithm.MD5:
                case StorageChecksumAlgorithm.StorageCrc64:
                    return;
                default:
                    throw new ArgumentException($"{nameof(StorageChecksumAlgorithm)} does not support value {Enum.GetName(typeof(StorageChecksumAlgorithm), resolved) ?? ((int)resolved).ToString(CultureInfo.InvariantCulture)}.");
            }
        }

        public static void AssertNotDevelopment(StorageConnectionString conn, string argumentName)
        {
            if (conn.IsDevStoreAccount)
            {
                throw new ArgumentException("Connection string for emulator is not valid for Azure File Shares", argumentName);
            }
        }
    }
}
