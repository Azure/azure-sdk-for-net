// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;

namespace Azure.Generator.Management.Providers
{
    internal class InheritableSystemObjectModelProvider : ModelProvider
    {
        // Use ThreadStatic to pass the type through to BuildName/BuildNamespace
        // before the base constructor completes (which may trigger lazy evaluation).
        [ThreadStatic]
        private static Type? s_pendingType;

        internal readonly Type _type;

        public InheritableSystemObjectModelProvider(Type type, InputModelType inputModel)
            : base(SetPending(type, inputModel))
        {
            _type = type;
            s_pendingType = null;
            CrossLanguageDefinitionId = inputModel.CrossLanguageDefinitionId;
        }

        private static InputModelType SetPending(Type type, InputModelType inputModel)
        {
            s_pendingType = type;
            return inputModel;
        }

        internal string CrossLanguageDefinitionId { get; }

        protected override string BuildName() => (s_pendingType ?? _type).Name;

        protected override string BuildRelativeFilePath()
            => throw new InvalidOperationException("This type should not be writing in generation");

        protected override string BuildNamespace() => (s_pendingType ?? _type).Namespace!;
    }
}
