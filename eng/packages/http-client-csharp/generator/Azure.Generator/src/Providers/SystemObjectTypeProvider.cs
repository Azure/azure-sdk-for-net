// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;

namespace Azure.Generator.Providers
{
    /// <summary>
    /// Represent a type that already exists in Azure
    /// </summary>
    public class SystemObjectTypeProvider : ModelProvider
    {
        private readonly Type _type;

        /// <inheritdoc/>
        public SystemObjectTypeProvider(Type type, InputModelType inputModel) : base(inputModel)
        {
            _type = type;
        }

        /// <inheritdoc/>
        protected override string BuildName() => _type.Name;

        /// <inheritdoc/>
        protected override string BuildRelativeFilePath()
            => throw new InvalidOperationException("This type should not be writing in generation");

        /// <inheritdoc/>
        protected override string BuildNamespace() => _type.Namespace!;
    }
}
