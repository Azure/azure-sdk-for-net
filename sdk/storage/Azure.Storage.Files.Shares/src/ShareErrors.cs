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
            switch ((algorithm ?? ValidationAlgorithm.None).ResolveAuto())
            {
                case ValidationAlgorithm.None:
                case ValidationAlgorithm.MD5:
                    return;
                default:
                    throw new ArgumentException(null);
            }
        }
    }
}
