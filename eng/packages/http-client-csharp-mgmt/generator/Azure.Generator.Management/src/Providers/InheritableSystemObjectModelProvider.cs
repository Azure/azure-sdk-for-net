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
        public InheritableSystemObjectModelProvider(CSharpType systemType, InputModelType inputModel, IReadOnlyList<PropertyProvider> inheritedProperties)
            : base(systemType, inputModel)
        {
            InheritedProperties = inheritedProperties;
        }

        internal IReadOnlyList<PropertyProvider> InheritedProperties { get; }
    }
}
