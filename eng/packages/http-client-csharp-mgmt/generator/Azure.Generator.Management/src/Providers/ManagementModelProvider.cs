// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// ModelProvider used for non-resource management-plane models.
    /// </summary>
    internal class ManagementModelProvider : ScmModelProvider
    {
        private readonly InputModelType _inputModel;

        public ManagementModelProvider(InputModelType inputModel)
            : base(inputModel)
        {
            _inputModel = inputModel;
        }

        protected override string BuildName() => PreserveContentSuffix(_inputModel.Name, base.BuildName());

        internal string NormalizeRequestModelName(string name)
            => PreserveContentSuffix(name, NormalizeTypeNameForNewContract(name));

        protected override IReadOnlyList<ConstructorProvider> BuildConstructorsForBackCompatibility(IEnumerable<ConstructorProvider> originalConstructors)
        {
            var original = originalConstructors.ToArray();
            return ConstructorProviderHelpers.RestoreValueTypeNullabilityOverloads(
                this, original, base.BuildConstructorsForBackCompatibility(original));
        }

        // Management request models retain Content rather than the data-plane Request suffix.
        private static string PreserveContentSuffix(string originalName, string normalizedName)
            => originalName.EndsWith("Content", StringComparison.OrdinalIgnoreCase)
                && normalizedName.EndsWith("Request", StringComparison.Ordinal)
                    ? normalizedName[..^"Request".Length] + "Content"
                    : normalizedName;

        // Non-resource management-plane models are emitted under .Models. Build their
        // Type there up front so references cached before namespace visitors run do not
        // keep a stale root namespace.
        protected override string BuildNamespace()
            => $"{ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace}.Models";

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", "Models", $"{Type.Name}.cs");
    }
}
