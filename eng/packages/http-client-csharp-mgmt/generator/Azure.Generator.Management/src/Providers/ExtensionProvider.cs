// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class ExtensionProvider : TypeProvider
    {
        private readonly IReadOnlyList<MockableResourceProvider> _mockableResources;
        public ExtensionProvider(IReadOnlyList<MockableResourceProvider> mockableResources)
        {
            _mockableResources = mockableResources;
        }

        protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Public | TypeSignatureModifiers.Static;

        protected override string BuildName() => $"{ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName}Extensions";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Extensions", $"{Name}.cs");

        protected override FormattableString BuildDescription() => $"A class to add extension methods to {ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace}.";

        protected override MethodProvider[] BuildMethods()
        {
            // we have a few methods to get the cached clients for those mockable resources
            var getCachedClientMethods = new Dictionary<CSharpType, MethodProvider>();
            foreach (var mockableResource in _mockableResources)
            {
                var getCachedClientMethod = BuildGetCachedClientMethod(mockableResource);
                getCachedClientMethods.Add(mockableResource.ArmCoreType, getCachedClientMethod);
            }

            // then all the methods are just forwarding to the mockable resource methods
            var redirectedMethods = new List<MethodProvider>(_mockableResources.Sum(m => m.Methods.Count));
            foreach (var mockableResource in _mockableResources)
            {
                var getCachedClientMethod = getCachedClientMethods[mockableResource.ArmCoreType];
                redirectedMethods.AddRange(
                    mockableResource.Methods.Select(m => BuildRedirectMethod(mockableResource.ArmCoreType, m, getCachedClientMethod))
                    );
            }

            return [
                .. getCachedClientMethods.Values,
                .. redirectedMethods
                ];
        }

        private MethodProvider BuildGetCachedClientMethod(MockableResourceProvider mockableResource)
        {
            var coreType = mockableResource.ArmCoreType;
            var parameter = new ParameterProvider(GetArmCoreTypeVariableName(coreType), $"", coreType);
            var methodSignature = new MethodSignature(
                $"Get{mockableResource.Name}",
                null,
                MethodSignatureModifiers.Private | MethodSignatureModifiers.Static,
                mockableResource.Type,
                null,
                [parameter]);
            var resource = parameter.As<ArmResource>();
            var statements = new List<MethodBodyStatement>
            {
                Return(resource.GetCachedClient(
                    new CodeWriterDeclaration("client"),
                    client => New.Instance(mockableResource.Type,
                                    coreType.Equals(typeof(ArmClient)) ? [client, ResourceIdentifierSnippets.Root()] : [client, resource.Id()]))),
            };
            return new MethodProvider(methodSignature, statements, this);
        }

        private MethodProvider BuildRedirectMethod(CSharpType coreType, MethodProvider targetMethod, MethodProvider getCachedClientMethod)
        {
            var target = targetMethod.Signature;
            // TODO -- add mocking information in method description
            var extensionParameter = new ParameterProvider(
                GetArmCoreTypeVariableName(coreType),
                $"The {coreType:C} the method will execute against.",
                coreType,
                validation: ParameterValidationType.AssertNotNull);
            IReadOnlyList<ParameterProvider> parameters = [
                extensionParameter,
                ..target.Parameters.Select(DuplicateParameter)
                ];
            var modifiers = (target.Modifiers & ~MethodSignatureModifiers.Virtual) | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension;
            var methodSignature = new MethodSignature(
                target.Name,
                target.Description,
                modifiers,
                target.ReturnType,
                target.ReturnDescription,
                parameters,
                Attributes: target.Attributes);

            IReadOnlyList<ValueExpression> arguments = [.. parameters.Skip(1).Select(p => (ValueExpression)p)];
            var body = new MethodBodyStatement[]
            {
                Return(Static().Invoke(getCachedClientMethod.Signature, [extensionParameter]).Invoke(target.Name, arguments, async: target.Modifiers.HasFlag(MethodSignatureModifiers.Async)))
            };

            foreach (var p in methodSignature.Parameters)
            {
                if (p.Location == ParameterLocation.Body)
                {
                    p.Update(name: "content");
                }
            }

            return new MethodProvider(methodSignature, body, this);

            static ParameterProvider DuplicateParameter(ParameterProvider original)
            {
                return new ParameterProvider(
                    original.Name,
                    original.Description,
                    original.Type,
                    defaultValue: original.DefaultValue,
                    isRef: original.IsRef,
                    isOut: original.IsOut,
                    isParams: original.IsParams,
                    attributes: original.Attributes,
                    initializationValue: original.InitializationValue,
                    location: original.Location,
                    validation: null);
            }
        }

        private string GetArmCoreTypeVariableName(CSharpType armCoreType)
        {
            if (armCoreType.Equals(typeof(ArmClient)))
            {
                // For ArmClient, we use "client" as the variable name
                return "client";
            }
            else
            {
                // The variable name for the ArmCoreType is the same as the type name, but in camelCase
                return armCoreType.Name.ToVariableName();
            }
        }
    }
}
