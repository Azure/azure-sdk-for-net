// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;

namespace Azure.Generator.Management.Providers
{
    // TODO: Replace with SystemObjectModelProvider from MTG once it fully supports
    // inheritable system object models. This class and InheritableSystemObjectModelVisitor
    // should be cleaned up together.
    internal class InheritableSystemObjectModelProvider : ModelProvider
    {
        internal readonly Type _type;
        public InheritableSystemObjectModelProvider(Type type, InputModelType inputModel) : base(inputModel)
        {
            _type = type;
            CrossLanguageDefinitionId = inputModel.CrossLanguageDefinitionId;
        }

        internal string CrossLanguageDefinitionId { get; }

        protected override string BuildName() => _type?.Name ?? string.Empty;

        protected override string BuildRelativeFilePath()
            => throw new InvalidOperationException("This type should not be writing in generation");

        // _type may be null when called from base constructor before field assignment.
        // The visitor's UpdateNamespace corrects this to _type.Namespace after construction.
        protected override string BuildNamespace() => _type?.Namespace ?? string.Empty;
    }
}
