// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Tests.TestHelpers
{
    /// <summary>
    /// A lightweight <see cref="TypeProvider"/> with an explicit name, namespace, declaration modifiers, methods, and
    /// properties. Mirrors the upstream generator's test helper so a focused set of members can be rendered and
    /// validated against a TestData baseline.
    /// </summary>
    internal class TestTypeProvider : TypeProvider
    {
        private readonly TypeSignatureModifiers? _declarationModifiers;
        private readonly MethodProvider[] _methods;
        private readonly PropertyProvider[] _properties;
        private readonly string _name;
        private readonly string _namespace;

        protected override string BuildRelativeFilePath() => $"{Name}.cs";

        protected override string BuildName() => _name;

        protected override string BuildNamespace() => _namespace;

        protected override PropertyProvider[] BuildProperties() => _properties;

        protected override MethodProvider[] BuildMethods() => _methods;

        protected override TypeProvider[] BuildNestedTypes() => NestedTypesInternal ?? base.BuildNestedTypes();

        public static readonly TypeProvider Empty = new TestTypeProvider();

        internal TestTypeProvider(
            string? name = null,
            TypeSignatureModifiers? declarationModifiers = null,
            IEnumerable<MethodProvider>? methods = null,
            IEnumerable<PropertyProvider>? properties = null,
            string? ns = null)
        {
            _declarationModifiers = declarationModifiers;
            _methods = methods?.ToArray() ?? [];
            _properties = properties?.ToArray() ?? [];
            _name = name ?? "TestName";
            _namespace = ns ?? "Test";
        }

        internal TypeProvider[]? NestedTypesInternal { get; set; }

        protected override TypeSignatureModifiers BuildDeclarationModifiers() => _declarationModifiers ?? base.BuildDeclarationModifiers();
    }
}
