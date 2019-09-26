// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Storage.Files
{
    internal static class FileErrors
    {
        public static JsonException InvalidPermissionJson(string json) =>
            throw new JsonException("Expected { \"permission\": \"...\" }, not " + json);
    }
}
