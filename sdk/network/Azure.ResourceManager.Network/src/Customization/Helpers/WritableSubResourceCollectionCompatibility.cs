// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    internal static class WritableSubResourceCollectionCompatibility
    {
        // Adapt remaining NetworkSubResource-backed getters to the released read-only WritableSubResource contract.
        /// <summary> Invokes the ReadOnlyNetworkSubResourceList compatibility operation. </summary>
        public static IReadOnlyList<WritableSubResource> AsReadOnlyList(IReadOnlyList<NetworkSubResource> source) => source is null ? default : new ReadOnlyNetworkSubResourceList(source);
        // Share the same getter code when native storage already uses WritableSubResource, without copying its list.
        /// <summary> Invokes the AsReadOnlyList compatibility operation. </summary>
        public static IReadOnlyList<WritableSubResource> AsReadOnlyList(IReadOnlyList<WritableSubResource> source) => source;
        // Adapt mutable reference collections while writing list changes back to NetworkSubResource storage.
        /// <summary> Invokes the NetworkSubResourceList compatibility operation. </summary>
        public static IList<WritableSubResource> AsList(IList<NetworkSubResource> source) => source is null ? default : new NetworkSubResourceList(source);
        // Preserve native mutable list identity when no reference-type adapter is needed.
        /// <summary> Invokes the AsList compatibility operation. </summary>
        public static IList<WritableSubResource> AsList(IList<WritableSubResource> source) => source;
        // Legacy URI identity shim; no callers remain after this batch's authorization facade removal.
        // TODO: Review removal with the remaining compatibility helpers.
        /// <summary> Invokes the FormatUri compatibility operation. </summary>
        public static Uri FormatUri(Uri value) => value;
        // Bridge string-backed certificate data to the released BinaryData contract without base64 decoding.
        /// <summary> Invokes the ParseBinaryData compatibility operation. </summary>
        public static BinaryData ParseBinaryData(string value) => value is null ? default : BinaryData.FromString(value);
        // Keep the certificate getter compatible with native BinaryData storage without changing its bytes.
        /// <summary> Invokes the ParseBinaryData compatibility operation. </summary>
        public static BinaryData ParseBinaryData(BinaryData value) => value;
        // Pass certificate bytes unchanged to the native BinaryData-backed property used by the custom setter.
        /// <summary> Invokes the FormatBinaryData compatibility operation. </summary>
        public static BinaryData FormatBinaryData(BinaryData value) => value;
        // Project reference IDs to the released WritableSubResource type for the remaining list adapters.
        internal static WritableSubResource ToWritable(NetworkSubResource value) => value is null ? default : new WritableSubResource { Id = value.Id };
        // Convert adapter mutations back to the generated NetworkSubResource reference storage.
        internal static NetworkSubResource ToNetwork(WritableSubResource value) => value is null ? default : new NetworkSubResource { Id = value.Id };
    }
}
