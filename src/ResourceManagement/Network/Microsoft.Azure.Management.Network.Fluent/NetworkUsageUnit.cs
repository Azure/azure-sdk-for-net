// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class NetworkUsageUnit : ExpandableStringEnum<NetworkUsageUnit>
    {
        public static readonly NetworkUsageUnit Count = new NetworkUsageUnit() { Value = "Count" };
        public static readonly NetworkUsageUnit Bytes = new NetworkUsageUnit() { Value = "Bytes" };
        public static readonly NetworkUsageUnit Seconds = new NetworkUsageUnit() { Value = "Seconds" };
        public static readonly NetworkUsageUnit Percent= new NetworkUsageUnit() { Value = "Percent" };
        public static readonly NetworkUsageUnit CountsPerSecond = new NetworkUsageUnit() { Value = "CountsPerSecond" };
        public static readonly NetworkUsageUnit BytesPerSecond = new NetworkUsageUnit() { Value = "BytesPerSecond" };
    }
}
