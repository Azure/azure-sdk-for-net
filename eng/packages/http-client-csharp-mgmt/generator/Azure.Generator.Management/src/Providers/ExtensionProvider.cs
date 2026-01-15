// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
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
                    mockableResource.Methods.Select(m => BuildRedirectMethod(mockableResource, m, getCachedClientMethod))
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

        private MethodProvider BuildRedirectMethod(MockableResourceProvider mockableResource, MethodProvider targetMethod, MethodProvider getCachedClientMethod)
        {
            var coreType = mockableResource.ArmCoreType;
            var target = targetMethod.Signature;
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

            var method = new MethodProvider(methodSignature, body, this);

            // Add mocking documentation
            AddMockingDocumentation(method, mockableResource, targetMethod);

            return method;

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

        private void AddMockingDocumentation(MethodProvider method, MockableResourceProvider mockableResource, MethodProvider targetMethod)
        {
            if (method.XmlDocs == null)
            {
                return;
            }

            // Build the mocking documentation item
            // Format: To mock this method, please mock <see cref="MockableType.MethodName(params)"/> instead.
            var mockingDescription = BuildMockingDescription(mockableResource.Type, targetMethod.Signature);
            var mockingItem = new XmlDocStatement("item", [],
                new XmlDocStatement("term", [$"Mocking"]),
                new XmlDocStatement("description", [mockingDescription]));

            // Create a new summary with the existing description and the mocking item
            // The targetMethod already has the description we want to keep
            var descriptionText = targetMethod.Signature.Description ?? $"";
            var updatedSummary = new XmlDocSummaryStatement([descriptionText], mockingItem);
            method.XmlDocs.Update(summary: updatedSummary);
        }

        private FormattableString BuildMockingDescription(CSharpType mockableType, MethodSignature targetSignature)
        {
            // Build description: "To mock this method, please mock <see cref="MockableType.MethodName(params)"/> instead."
            // We need to construct a method reference that includes parameter types
            // In C# XML docs, method references look like: MethodName(TypeName1, TypeName2)

            // Build parameter type list as a simple string since XML doc cref attributes use simple type names
            var parameterTypeNames = string.Join(", ", targetSignature.Parameters.Select(p => p.Type.GetXmlDocTypeName()));
            var methodRef = $"{mockableType.Name}.{targetSignature.Name}({parameterTypeNames})";

            // Return a FormattableString that will be converted to: To mock this method, please mock <see cref="..."/> instead.
            // The :C formatter on mockableType will create the <see cref> tag
            return $"To mock this method, please mock <see cref=\"{methodRef}\"/> instead.";
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
