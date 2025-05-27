// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.IO;

namespace Azure.Generator.Management.Providers
{
    internal class MockableResourceProvider : TypeProvider
    {
        private readonly CSharpType _armCoreType;
        private readonly IReadOnlyList<ResourceClientProvider> _resources;

        // TODO -- in the future we need to update this to include the operations this mockable resource should include.
        public MockableResourceProvider(CSharpType armCoreType, IReadOnlyList<ResourceClientProvider> resources)
        {
            _armCoreType = armCoreType;
            _resources = resources;
        }

        protected override string BuildName() => $"Mockable{ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName}{_armCoreType.Name}";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Extensions", $"{Name}.cs");

        protected override CSharpType? GetBaseType() => typeof(ArmResource);
    }
}
