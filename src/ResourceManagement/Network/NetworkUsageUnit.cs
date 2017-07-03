// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class NetworkUsageUnit : ExpandableStringEnum<NetworkUsageUnit>
    {
        public static readonly NetworkUsageUnit Count = Parse("Count");
        public static readonly NetworkUsageUnit Bytes = Parse("Bytes");
        public static readonly NetworkUsageUnit Seconds = Parse("Seconds");
        public static readonly NetworkUsageUnit Percent= Parse("Percent");
        public static readonly NetworkUsageUnit CountsPerSecond = Parse("CountsPerSecond");
        public static readonly NetworkUsageUnit BytesPerSecond = Parse("BytesPerSecond");
    }
}
