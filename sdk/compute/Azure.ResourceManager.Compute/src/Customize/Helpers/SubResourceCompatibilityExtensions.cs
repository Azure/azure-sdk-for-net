// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    internal static class SubResourceCompatibilityExtensions
    {
        public static IReadOnlyList<SubResource> ToSubResources(this IReadOnlyList<ComputeSubResourceData> values)
            => values?.Select(value => ResourceManagerModelFactory.SubResource(value.Id)).ToArray();

        public static IList<WritableSubResource> ToWritableSubResources(this IEnumerable<ComputeWriteableSubResourceData> values)
            => values?.Select(value => new WritableSubResource { Id = value.Id }).ToList();

        public static IList<WritableSubResource> ToWritableSubResources(this IEnumerable<ComputeApiEntityReference> values)
            => values?.Select(value => new WritableSubResource { Id = value.Id }).ToList();
    }
}
