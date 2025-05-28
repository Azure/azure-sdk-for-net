// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class ExtensionProvider : TypeProvider
    {
        private const string GetCachedClient = "GetCachedClient";
        private const string IdProperty = "Id";

        private readonly IReadOnlyList<MockableResourceProvider> _mockableResources;
        public ExtensionProvider(IReadOnlyList<MockableResourceProvider> mockableResources)
        {
            _mockableResources = mockableResources;
        }

        protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Public | TypeSignatureModifiers.Static;

        protected override string BuildName() => $"{ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName}Extensions";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Extensions", $"{Name}.cs");

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
            var parameter = new ParameterProvider(coreType.Name.ToVariableName(), $"", coreType);
            var methodSignature = new MethodSignature(
                $"Get{mockableResource.Name}",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                mockableResource.Type,
                null,
                [parameter]);
            var clientVar = new CodeWriterDeclaration("client");
            var lambda = new FuncExpression([clientVar], New.Instance(mockableResource.Type, new ValueExpression[] { new VariableExpression(mockableResource.Type, clientVar), parameter.Property(IdProperty) }));
            var statements = new List<MethodBodyStatement>
            {
                Return(parameter.Invoke(GetCachedClient, lambda))
            };
            return new MethodProvider(methodSignature, statements, this);
        }

        private MethodProvider BuildRedirectMethod(CSharpType armCoreType, MethodProvider targetMethod, MethodProvider getCachedClientMethod)
        {
            var target = targetMethod.Signature;
            // TODO -- add mocking information in method description
            var extensionParameter = new ParameterProvider(
                armCoreType.Name.ToVariableName(),
                $"The {armCoreType:C} the method will execute against.",
                armCoreType,
                validation: ParameterValidationType.AssertNotNull);
            IReadOnlyList<ParameterProvider> parameters = [
                extensionParameter,
                ..target.Parameters
                ];
            var modifiers = (target.Modifiers & ~MethodSignatureModifiers.Virtual) | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension;
            var methodSignature = new MethodSignature(
                target.Name,
                target.Description,
                modifiers,
                target.ReturnType,
                target.ReturnDescription,
                parameters);

            var body = new MethodBodyStatement[]
            {
                Return(Static().Invoke(getCachedClientMethod.Signature, [extensionParameter]).Invoke(target))
            };

            return new MethodProvider(methodSignature, body, this);
        }
    }
}
