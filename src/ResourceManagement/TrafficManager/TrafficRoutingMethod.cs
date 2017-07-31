// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    /// <summary>
    /// Possible routing methods supported by Traffic manager profile.
    /// </summary>
    public class TrafficRoutingMethod : ExpandableStringEnum<TrafficRoutingMethod>
    {
        public static readonly TrafficRoutingMethod Performance = Parse("Performance");
        public static readonly TrafficRoutingMethod Weighted = Parse("Weighted");
        public static readonly TrafficRoutingMethod Priority = Parse("Priority");
        public static readonly TrafficRoutingMethod Geographic = Parse("Geographic");
    }
}