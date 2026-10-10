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
        /// <summary> Invokes the ReadOnlyNetworkSubResourceList compatibility operation. </summary>
        public static IReadOnlyList<WritableSubResource> AsReadOnlyList(IReadOnlyList<NetworkSubResource> source) => source is null ? default : new ReadOnlyNetworkSubResourceList(source);
        /// <summary> Invokes the AsReadOnlyList compatibility operation. </summary>
        public static IReadOnlyList<WritableSubResource> AsReadOnlyList(IReadOnlyList<WritableSubResource> source) => source;
        /// <summary> Invokes the NetworkSubResourceList compatibility operation. </summary>
        public static IList<WritableSubResource> AsList(IList<NetworkSubResource> source) => source is null ? default : new NetworkSubResourceList(source);
        /// <summary> Invokes the AsList compatibility operation. </summary>
        public static IList<WritableSubResource> AsList(IList<WritableSubResource> source) => source;
        /// <summary> Invokes the ParseGuid compatibility operation. </summary>
        public static Guid? ParseGuid(string value) => ResourceGuidCompatibility.Parse(value);
        /// <summary> Invokes the ParseGuid compatibility operation. </summary>
        public static Guid? ParseGuid(Guid? value) => value;
        /// <summary> Invokes the FormatGuid compatibility operation. </summary>
        public static Guid? FormatGuid(Guid? value) => value;
        /// <summary> Invokes the ParseUri compatibility operation. </summary>
        public static Uri ParseUri(string value) => Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out Uri uri) ? uri : default;
        /// <summary> Invokes the ParseUri compatibility operation. </summary>
        public static Uri ParseUri(Uri value) => value;
        /// <summary> Invokes the FormatUri compatibility operation. </summary>
        public static Uri FormatUri(Uri value) => value;
        /// <summary> Invokes the ParseBinaryData compatibility operation. </summary>
        public static BinaryData ParseBinaryData(string value) => value is null ? default : BinaryData.FromString(value);
        /// <summary> Invokes the ParseBinaryData compatibility operation. </summary>
        public static BinaryData ParseBinaryData(BinaryData value) => value;
        /// <summary> Invokes the FormatBinaryData compatibility operation. </summary>
        public static BinaryData FormatBinaryData(BinaryData value) => value;
        internal static WritableSubResource ToWritable(NetworkSubResource value) => value is null ? default : new WritableSubResource { Id = value.Id };
        internal static NetworkSubResource ToNetwork(WritableSubResource value) => value is null ? default : new NetworkSubResource { Id = value.Id };
    }
}
