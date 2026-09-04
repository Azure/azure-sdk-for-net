// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class OptionalResponseBodyVisitorTests
    {
        [Test]
        public void UsesNullableResponseForOptionalResponseBody()
        {
            var operation = InputFactory.Operation(
                "GetLayout",
                responses:
                [
                    InputFactory.OperationResponse([200], InputPrimitiveType.String),
                    InputFactory.OperationResponse([204])
                ]);
            var serviceMethod = InputFactory.BasicServiceMethod("GetLayout", operation);
            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);

            MockHelpers.LoadMockGenerator(
                createCSharpTypeCore: inputType => inputType == InputPrimitiveType.String
                    ? new CSharpType(typeof(string))
                    : new CSharpType(typeof(bool)),
                clients: () => [inputClient]);

            var client = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(client);
            var methodCollection = new ScmMethodProviderCollection(serviceMethod, client!);
            var method = methodCollection.Single(
                m => m.Kind == ScmMethodKind.Convenience && m.Signature.Name == "GetLayout");

            new TestOptionalResponseBodyVisitor().Visit(method);

            Assert.AreEqual(
                new CSharpType(typeof(NullableResponse<>), typeof(string)),
                method.Signature.ReturnType);
            var methodBody = method.BodyStatements!.ToDisplayString();
            StringAssert.Contains("result.Status == 204", methodBody);
            StringAssert.Contains(
                "return new global::Azure.NoValueResponse<string>(result);",
                methodBody);
            StringAssert.Contains(
                "return global::Azure.Response.FromValue",
                methodBody);
        }

        [Test]
        public void CombinesMultipleNoBodyStatusCodes()
        {
            var operation = InputFactory.Operation(
                "GetLayout",
                responses:
                [
                    InputFactory.OperationResponse([200], InputPrimitiveType.String),
                    InputFactory.OperationResponse([204, 205])
                ]);
            var serviceMethod = InputFactory.BasicServiceMethod("GetLayout", operation);
            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);

            MockHelpers.LoadMockGenerator(
                createCSharpTypeCore: inputType => inputType == InputPrimitiveType.String
                    ? new CSharpType(typeof(string))
                    : new CSharpType(typeof(bool)),
                clients: () => [inputClient]);

            var client = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(client);
            var methodCollection = new ScmMethodProviderCollection(serviceMethod, client!);
            var method = methodCollection.Single(
                m => m.Kind == ScmMethodKind.Convenience && m.Signature.Name == "GetLayout");

            new TestOptionalResponseBodyVisitor().Visit(method);

            StringAssert.Contains(
                "if (((result.Status == 204) || (result.Status == 205)))",
                method.BodyStatements!.ToDisplayString());
        }

        [Test]
        public void DoesNotUseNullableResponseWhenStatusCodeCannotDiscriminateBody()
        {
            var operation = InputFactory.Operation(
                "GetLayout",
                responses:
                [
                    InputFactory.OperationResponse([200], InputPrimitiveType.String),
                    InputFactory.OperationResponse([200])
                ]);
            var serviceMethod = InputFactory.BasicServiceMethod("GetLayout", operation);
            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);

            MockHelpers.LoadMockGenerator(
                createCSharpTypeCore: inputType => inputType == InputPrimitiveType.String
                    ? new CSharpType(typeof(string))
                    : new CSharpType(typeof(bool)),
                clients: () => [inputClient]);

            var client = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(client);
            var methodCollection = new ScmMethodProviderCollection(serviceMethod, client!);
            var method = methodCollection.Single(
                m => m.Kind == ScmMethodKind.Convenience && m.Signature.Name == "GetLayout");
            var originalReturnType = method.Signature.ReturnType;
            var originalBody = method.BodyStatements!.ToDisplayString();

            new TestOptionalResponseBodyVisitor().Visit(method);

            Assert.AreEqual(originalReturnType, method.Signature.ReturnType);
            Assert.AreEqual(originalBody, method.BodyStatements!.ToDisplayString());
        }

        private sealed class TestOptionalResponseBodyVisitor : OptionalResponseBodyVisitor
        {
            public void Visit(ScmMethodProvider method) => VisitMethod(method);
        }
    }
}
