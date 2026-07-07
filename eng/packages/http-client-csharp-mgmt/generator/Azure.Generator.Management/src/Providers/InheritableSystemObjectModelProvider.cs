// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;

namespace Azure.Generator.Management.Providers
{
    internal sealed class InheritableSystemObjectModelProvider : SystemObjectModelProvider
    {
        private readonly ModelProvider? _baseModelProvider;

        public InheritableSystemObjectModelProvider(
            CSharpType systemType,
            InputModelType inputModel,
            ModelProvider? baseModelProvider,
            IReadOnlyList<PropertyProvider>? inheritedProperties = null)
            : base(systemType, inputModel)
        {
            _baseModelProvider = baseModelProvider;
            InheritedProperties = inheritedProperties ?? [];
        }

        internal IReadOnlyList<PropertyProvider> InheritedProperties { get; }

        protected override CSharpType? BuildBaseType() => _baseModelProvider?.Type;

        protected override ModelProvider? BuildBaseModelProvider() => _baseModelProvider;
    }
}
