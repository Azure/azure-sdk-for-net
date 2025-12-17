// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Generator.Management.Models
{
    /// <summary>
    /// Represents the unified ARM provider schema containing all resource metadata and non-resource methods.
    /// This consolidates information previously scattered across @resourceSchema and @nonResourceMethodSchema decorators.
    /// </summary>
    internal class ArmProviderSchema
    {
        public IReadOnlyList<ResourceMetadata> Resources { get; }
        public IReadOnlyList<NonResourceMethod> NonResourceMethods { get; }

        public ArmProviderSchema(IReadOnlyList<ResourceMetadata> resources, IReadOnlyList<NonResourceMethod> nonResourceMethods)
        {
            Resources = resources;
            NonResourceMethods = nonResourceMethods;
        }
    }
}
