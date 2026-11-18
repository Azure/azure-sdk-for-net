// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;
using System.Linq;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// ModelProvider used for non-resource management-plane models.
    /// </summary>
    internal class ManagementModelProvider : ScmModelProvider, IUnfilteredInitializationConstructorProvider
    {
        ConstructorProvider? IUnfilteredInitializationConstructorProvider.UnfilteredInitializationConstructor => _unfilteredInitializationConstructor;
        private ConstructorProvider? _unfilteredInitializationConstructor;

        protected override ConstructorProvider[] BuildConstructors()
        {
            var constructors = base.BuildConstructors();
            _unfilteredInitializationConstructor = constructors.FirstOrDefault(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            return constructors;
        }

        public ManagementModelProvider(InputModelType inputModel)
            : base(inputModel)
        {
        }

        internal string NormalizeRequestModelName(string name) => NormalizeTypeNameForNewContract(name);

        // Non-resource management-plane models are emitted under .Models. Build their
        // Type there up front so references cached before namespace visitors run do not
        // keep a stale root namespace.
        protected override string BuildNamespace()
            => $"{ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace}.Models";

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", "Models", $"{Type.Name}.cs");
    }
}
