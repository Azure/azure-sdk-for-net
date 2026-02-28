// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;

namespace Azure.Generator.Management.Providers
{
    // Primary constructor captures 'type' before the base constructor runs,
    // ensuring BuildName/BuildNamespace can access it during base initialization.
    internal class InheritableSystemObjectModelProvider(Type type, InputModelType inputModel)
        : ModelProvider(inputModel)
    {
        internal Type ClrType => type;

        internal string CrossLanguageDefinitionId { get; } = inputModel.CrossLanguageDefinitionId;

        protected override string BuildName() => type.Name;

        protected override string BuildRelativeFilePath()
            => throw new InvalidOperationException("This type should not be writing in generation");

        protected override string BuildNamespace() => type.Namespace!;
    }
}
