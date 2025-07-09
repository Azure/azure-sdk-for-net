// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;

namespace Azure.Generator.Management.Utilities
{
    internal static class ConstructorProviderHelpers
    {
        /// <summary>
        /// Builds a constructor for the enclosing type for mocking purposes.
        /// </summary>
        /// <param name="enclosingType">The type provider to build the constructor for.</param>
        public static ConstructorProvider BuildMockingConstructor(TypeProvider enclosingType)
        {
            return new ConstructorProvider(
                new ConstructorSignature(enclosingType.Type, $"Initializes a new instance of {enclosingType.Name} for mocking.", MethodSignatureModifiers.Protected, []),
                new MethodBodyStatement[] { MethodBodyStatement.Empty },
                enclosingType);
        }
    }
}
