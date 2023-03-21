// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// Extensions to BinaryData for the ContainerRegistryClient.
    /// </summary>
    public static class ContainerRegistryBinaryDataExtensions
    {
        /// <summary>
        /// Deserializes a GetManifestResult payload to an OciImageManifest.
        /// </summary>
        /// <returns>The deserialized OciImageManifest.</returns>
        public static OciImageManifest AsOciImageManifest(this BinaryData manifest)
        {
            return OciImageManifest.DeserializeOciImageManifest(JsonDocument.Parse(manifest).RootElement);
        }
    }
}
