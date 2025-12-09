// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Extensions;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Providers
{
    internal class AzureFixedEnumProvider : FixedEnumProvider
    {
        public AzureFixedEnumProvider(InputEnumType? input, TypeProvider? declaringType) : base(input, declaringType) { }

        protected override string BuildNamespace()
        {
            if (CodeModelGenerator.Instance.Configuration.UseModelNamespace())
            {
                return CodeModelGenerator.Instance.TypeFactory.GetCleanNameSpace(
                            $"{CodeModelGenerator.Instance.TypeFactory.PrimaryNamespace}.Models");
            }

            return base.BuildNamespace();
        }
    }
}
