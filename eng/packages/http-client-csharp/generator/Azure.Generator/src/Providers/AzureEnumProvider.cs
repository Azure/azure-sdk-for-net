// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Extensions;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Providers
{
    internal sealed class AzureEnumProvider : EnumProvider
    {
        public AzureEnumProvider(InputEnumType? input) : base(input) { }

        protected override string BuildNamespace()
        {
            if (CodeModelGenerator.Instance.Configuration.UseModelNamespace())
            {
                return CodeModelGenerator.Instance.TypeFactory.GetCleanNameSpace(
                            $"{CodeModelGenerator.Instance.TypeFactory.PrimaryNamespace}.Models");
            }

            return base.BuildNamespace();
        }

        public static new EnumProvider Create(InputEnumType input, TypeProvider? declaringType = null)
        {
            bool isApiVersionEnum = input.Usage.HasFlag(InputModelTypeUsage.ApiVersionEnum);
            FixedEnumProvider fixedEnumProvider = isApiVersionEnum
                ? new ApiVersionEnumProvider(input, declaringType)
                : new AzureFixedEnumProvider(input, declaringType);
            var extensibleEnumProvider = new AzureExtensibleEnumProvider(input, declaringType);

            // Check to see if there is custom code that customizes the enum.
            var customCodeView = fixedEnumProvider.CustomCodeView ?? extensibleEnumProvider.CustomCodeView;

            EnumProvider provider = customCodeView switch
            {
                { Type: { IsValueType: true, IsStruct: true } } => extensibleEnumProvider,
                { Type: { IsValueType: true, IsStruct: false } } => fixedEnumProvider,
                _ => input.IsExtensible ? extensibleEnumProvider : fixedEnumProvider
            };

            if (input.Access == "public")
            {
                CodeModelGenerator.Instance.AddTypeToKeep(provider);
            }

            return provider;
        }
    }
}
