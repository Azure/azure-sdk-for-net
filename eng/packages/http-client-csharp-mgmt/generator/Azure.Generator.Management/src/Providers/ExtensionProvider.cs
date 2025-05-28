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
            var methods = new List<MethodProvider>(_mockableResources.Count + _mockableResources.Sum(m => m.Methods.Count));

            // we have a few methods to get the cached clients for those mockable resources
            foreach (var mockableResource in _mockableResources)
            {
                methods.Add(BuildGetCachedClientMethod(mockableResource));
            }

            // then all the methods are just forwarding to the mockable resource methods
            foreach (var mockableResource in _mockableResources)
            {
                //methods.AddRange(mockableResource.Methods);
            }

            return [.. methods];
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
    }
}
