// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        public static void AssertAlgorithmSupport(ValidationAlgorithm? algorithm)
        {
            ValidationAlgorithm resolved = (algorithm ?? ValidationAlgorithm.None).ResolveAuto();
            switch (resolved)
            {
                case ValidationAlgorithm.None:
                case ValidationAlgorithm.MD5:
                    return;
                case ValidationAlgorithm.StorageCrc64:
                    throw new ArgumentException("Azure File Shares do not support CRC-64.");
                default:
                    throw new ArgumentException($"SDK does not support ValidationAlgorithm value {Enum.GetName(typeof(ValidationAlgorithm), resolved)}.");
            }
        }
    }
}
