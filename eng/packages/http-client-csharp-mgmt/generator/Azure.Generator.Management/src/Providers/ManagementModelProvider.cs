// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// ModelProvider used for non-resource management-plane models.
    /// </summary>
    internal class ManagementModelProvider : ScmModelProvider
    {
        private ConstructorProvider[]? _builtConstructors;

        public ManagementModelProvider(InputModelType inputModel)
            : base(inputModel)
        {
        }

        // ScmModelProvider.BuildConstructors mutates the cached FullConstructor in place when the
        // model is dynamic, appending the JsonPatch assignment, the SetPropagators call and the
        // SCME0001 suppression. Several TypeProvider.Update overloads clear the constructor cache
        // without clearing FullConstructor, so a rebuild would apply that mutation a second time and
        // emit duplicated statements. Cache the built result so the mutation happens exactly once.
        protected override ConstructorProvider[] BuildConstructors()
            => _builtConstructors ??= base.BuildConstructors();

        public override void Reset()
        {
            base.Reset();
            _builtConstructors = null;
        }

        // Non-resource management-plane models are emitted under .Models. Build their
        // Type there up front so references cached before namespace visitors run do not
        // keep a stale root namespace.
        protected override string BuildNamespace()
            => $"{ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace}.Models";

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", "Models", $"{Type.Name}.cs");
    }
}
