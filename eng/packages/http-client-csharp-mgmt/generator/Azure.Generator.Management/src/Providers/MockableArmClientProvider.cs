// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using System.Collections.Generic;

namespace Azure.Generator.Management.Providers
{
    internal sealed class MockableArmClientProvider : MockableResourceProvider
    {
        public MockableArmClientProvider(CSharpType armCoreType, IReadOnlyList<ResourceClientProvider> resources) : base(armCoreType, resources)
        {
        }

        // TODO -- override the BuildMethods method to introduce the methods on this extension.
    }
}
