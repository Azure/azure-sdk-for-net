// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Tests
{
    internal class PaginationVisitorTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public void PagingDeserializesResponseWithFromResponse(bool isAsync)
        {
            var item = InputFactory.Model("Item");
            var page = InputFactory.Model("ItemListResult", properties:
            [
                InputFactory.Property("value", InputFactory.Array(item), isRequired: true),
                InputFactory.Property("nextLink", InputPrimitiveType.Url)
            ]);
            var operation = InputFactory.Operation("ListItems",
                responses: [InputFactory.OperationResponse(bodytype: page)]);
            var method = InputFactory.PagingServiceMethod("ListItems", operation,
                pagingMetadata: InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body));
            var client = InputFactory.Client("Items", methods: [method]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [item, page], clients: () => [client]).Object;
            var clientProvider = plugin.TypeFactory.CreateClient(client)!;
            var collection = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(
                clientProvider, method, plugin.TypeFactory.CreateCSharpType(item)!, isAsync);

            var visitTypeCore = typeof(LibraryVisitor).GetMethod("VisitTypeCore", BindingFlags.NonPublic | BindingFlags.Instance)!;
            visitTypeCore.Invoke(new PaginationVisitor(), [collection]);
            var code = new TypeProviderWriter(collection).Write().Content;

            if (isAsync)
            {
                Assert.That(collection.Methods.Any(m => m.Signature.Name == "AsPagesAsync"), Is.True,
                    "Exercise the private async iterator introduced by the new dependency.");
            }
            Assert.That(code, Does.Contain("ItemListResult.FromResponse(response)"));
            Assert.That(code, Does.Not.Match(@"\bItemListResult\)response\b"),
                "Azure.Response cannot be cast to the list-result model.");
        }

        [TestCase("TestCollectionResult", "AsPages", true)]
        [TestCase("TestAsyncCollectionResult", "AsPagesAsync", true)]
        [TestCase("TestCollectionResult", "OtherMethod", false)]
        [TestCase("TestClient", "AsPages", false)]
        [TestCase("TestClient", "AsPagesAsync", false)]
        public void RewritesWhileBodyResponseCasts(string typeName, string methodName, bool shouldRewrite)
        {
            ManagementMockHelpers.LoadMockPlugin();
            var type = new TestTypeProvider(typeName);
            var method = CreateMethod(type, methodName);
            var visitor = new TestablePaginationVisitor();
            visitor.InvokeVisitType(type);
            var modelType = new TestTypeProvider("TestResponse").Type;
            var response = new VariableExpression(typeof(Response), "response");
            var nextPage = new VariableExpression(typeof(string), "nextPage");
            var valuesType = new CSharpType(typeof(IReadOnlyList<string>));
            var modelCast = response.CastTo(modelType);
            var fromValues = Static(typeof(Page<string>)).Invoke(
                "FromValues", [modelCast.Property("Values").CastTo(valuesType), nextPage, response]);
            var assignment = nextPage.Assign(modelCast.Property("NextLink")).Terminate();
            var loop = new WhileStatement(True)
            {
                new YieldReturnStatement(fromValues),
                assignment
            };
            var statements = new MethodBodyStatements([loop]);

            visitor.InvokeVisitStatements(statements, method);

            ValueExpression model = shouldRewrite ? Static(modelType).Invoke("FromResponse", [response]) : modelCast;
            Assert.That(fromValues.Arguments[0].ToDisplayString(),
                Is.EqualTo(model.Property("Values").CastTo(valuesType).ToDisplayString()));
            Assert.That(fromValues.Arguments[1], Is.SameAs(nextPage));
            Assert.That(fromValues.Arguments[2], Is.SameAs(response));
            Assert.That(assignment.ToDisplayString(),
                Is.EqualTo(nextPage.Assign(model.Property("NextLink")).Terminate().ToDisplayString()));
        }

        [TestCase("TestCollectionResult", "AsPages", true)]
        [TestCase("TestAsyncCollectionResult", "AsPagesAsync", true)]
        [TestCase("TestCollectionResult", "OtherMethod", false)]
        [TestCase("TestClient", "AsPages", false)]
        [TestCase("TestClient", "AsPagesAsync", false)]
        public void RewritesSinglePageResponseAssignment(string typeName, string methodName, bool shouldRewrite)
        {
            ManagementMockHelpers.LoadMockPlugin();
            var type = new TestTypeProvider(typeName);
            var method = CreateMethod(type, methodName);
            var visitor = new TestablePaginationVisitor();
            visitor.InvokeVisitType(type);
            var modelType = new TestTypeProvider("TestResponse").Type;
            var response = new VariableExpression(typeof(Response), "response");
            var result = new VariableExpression(modelType, "result");
            var assignment = result.Assign(response.CastTo(modelType));

            var updated = visitor.InvokeVisitAssignmentExpression(assignment, method);

            Assert.That(updated!.ToDisplayString(), Is.EqualTo(shouldRewrite
                ? result.Assign(Static(modelType).Invoke("FromResponse", [response])).ToDisplayString()
                : assignment.ToDisplayString()));
        }

        [TestCase("AsPages")]
        [TestCase("AsPagesAsync")]
        public void PreservesNonResponseAssignment(string methodName)
        {
            ManagementMockHelpers.LoadMockPlugin();
            var type = new TestTypeProvider("TestCollectionResult");
            var method = CreateMethod(type, methodName);
            var visitor = new TestablePaginationVisitor();
            visitor.InvokeVisitType(type);
            var value = new VariableExpression(typeof(object), "value");
            var result = new VariableExpression(typeof(string), "result");
            var assignment = result.Assign(value.CastTo(typeof(string)));

            var updated = visitor.InvokeVisitAssignmentExpression(assignment, method);

            Assert.That(updated, Is.SameAs(assignment));
        }

        private static MethodProvider CreateMethod(TypeProvider type, string methodName)
        {
            var modifiers = methodName == "AsPagesAsync"
                ? MethodSignatureModifiers.Private | MethodSignatureModifiers.Async
                : MethodSignatureModifiers.Public;
            return new MethodProvider(new MethodSignature(methodName, null, modifiers, null, null, []), MethodBodyStatement.Empty, type);
        }

        private class TestablePaginationVisitor : PaginationVisitor
        {
            public TypeProvider? InvokeVisitType(TypeProvider type) => base.VisitType(type);
            public MethodBodyStatement? InvokeVisitStatements(MethodBodyStatements statements, MethodProvider method)
                => base.VisitStatements(statements, method);
            public ValueExpression? InvokeVisitAssignmentExpression(AssignmentExpression expression, MethodProvider method)
                => base.VisitAssignmentExpression(expression, method);
        }

        private class TestTypeProvider(string name) : TypeProvider
        {
            protected override string BuildName() => name;
            protected override string BuildNamespace() => "Samples";
            protected override string BuildRelativeFilePath() => $"{Name}.cs";
        }
    }
}
