// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// Compute usage units.
    /// </summary>
    public class ComputeUsageUnit : ExpandableStringEnum<ComputeUsageUnit>
    {
        public static readonly ComputeUsageUnit Count = Parse("Count");
        public static readonly ComputeUsageUnit Bytes = Parse("Bytes");
        public static readonly ComputeUsageUnit Seconds = Parse("Seconds");
        public static readonly ComputeUsageUnit Percent = Parse("Percent");
        public static readonly ComputeUsageUnit CountsPerSecond = Parse("CountsPerSecond");
        public static readonly ComputeUsageUnit BytesPerSecond = Parse("BytesPerSecond");
    }
}
