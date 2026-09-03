// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    internal static class StorageResponseFormatExtensions
    {
        public static StorageResponseFormat ResolveAuto(this StorageResponseFormat responseFormat)
        {
            // Auto maps to Xml today, may change in the future.
            if (responseFormat == StorageResponseFormat.Auto)
            {
                return StorageResponseFormat.Xml;
            }
            return responseFormat;
        }
    }
}
