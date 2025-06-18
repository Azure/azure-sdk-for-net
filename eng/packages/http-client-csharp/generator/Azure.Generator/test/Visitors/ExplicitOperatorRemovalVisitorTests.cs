// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    internal class ExplicitOperatorRemovalVisitorTests
    {
        [Test]
        public void RemovesExplicitOperatorFromPagingModel()
        {
            var visitor = new TestExplicitOperatorRemovalVisitor();
            var inputModel = InputFactory.Model("cat", properties:
            [
                InputFactory.Property("color", InputPrimitiveType.String, isRequired: true),
            ]);
            var pagingMetadata = InputFactory.NextLinkPagingMetadata("cats", "nextCat", InputResponseLocation.Body);
            var responseArray = InputFactory.Array(inputModel);
            var response = InputFactory.OperationResponse(
                [200],
                InputFactory.Model(
                    "page",
                    properties: [InputFactory.Property("cats", responseArray), InputFactory.Property("nextCat", InputPrimitiveType.Url)]));
            var operation = InputFactory.Operation("getCats", responses: [response]);
            var inputServiceMethod = InputFactory.PagingServiceMethod("getCats", operation, pagingMetadata: pagingMetadata, response: InputFactory.ServiceMethodResponse(responseArray, ["cats"]));
            var inputClient = InputFactory.Client("catClient", methods: [inputServiceMethod]);

            MockHelpers.LoadMockPlugin(inputModels: () => [inputModel], clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(responseModelProvider);

            visitor.InvokeVisitLibrary(AzureClientGenerator.Instance.OutputLibrary);

            var serializationProvider = responseModelProvider!.SerializationProviders[0];
            var explicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));

            Assert.IsNull(explicitOperator);
        }

        [Test]
        public void DoesNotRemoveExplicitOperatorIfUsedInOtherOperation()
        {
            var visitor = new TestExplicitOperatorRemovalVisitor();
            var inputModel = InputFactory.Model("cat", properties:
            [
                InputFactory.Property("color", InputPrimitiveType.String, isRequired: true),
            ]);
            var pagingMetadata = InputFactory.NextLinkPagingMetadata("cats", "nextCat", InputResponseLocation.Body);
            var responseArray = InputFactory.Array(inputModel);
            var response = InputFactory.OperationResponse(
                [200],
                InputFactory.Model(
                    "page",
                    properties: [InputFactory.Property("cats", responseArray), InputFactory.Property("nextCat", InputPrimitiveType.Url)]));
            var operation = InputFactory.Operation("getCats", responses: [response]);
            var pagingMethod = InputFactory.PagingServiceMethod("getCats", operation, pagingMetadata: pagingMetadata, response: InputFactory.ServiceMethodResponse(responseArray, ["cats"]));
            var regularMethod = InputFactory.BasicServiceMethod("getCat", operation: InputFactory.Operation("getCat", responses: [InputFactory.OperationResponse([200], inputModel)]));
            var inputClient = InputFactory.Client("catClient", methods: [pagingMethod, regularMethod]);

            MockHelpers.LoadMockPlugin(inputModels: () => [inputModel], clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(responseModelProvider);

            visitor.InvokeVisitLibrary(AzureClientGenerator.Instance.OutputLibrary);

            var serializationProvider = responseModelProvider!.SerializationProviders[0];
            var explicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));

            Assert.IsNotNull(explicitOperator);
        }

        private class TestExplicitOperatorRemovalVisitor : ExplicitOperatorRemovalVisitor
        {
            public MethodProvider? InvokeVisitMethod(MethodProvider method)
            {
                return base.VisitMethod(method);
            }

            public ScmMethodProviderCollection? InvokeVisitServiceMethod(
                InputServiceMethod serviceMethod,
                ClientProvider client,
                ScmMethodProviderCollection? methodCollection)
            {
                return base.Visit(serviceMethod, client, methodCollection);
            }

            public void InvokeVisitLibrary(OutputLibrary library)
            {
                base.VisitLibrary(library);
            }
        }
    }
}