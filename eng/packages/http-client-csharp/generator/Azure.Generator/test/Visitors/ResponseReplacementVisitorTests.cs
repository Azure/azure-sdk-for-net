// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
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
    public class ResponseReplacementVisitorTests
    {
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void ReplacesConvenienceResponse(bool replaceWithBytes, bool isAsync)
        {
            var method = CreateMethod(replaceWithBytes, isAsync);
            var operationResponse = method.ServiceMethod!.Operation.Responses.Single();

            new TestResponseReplacementVisitor().Visit(method);

            CSharpType responseType = replaceWithBytes
                ? new CSharpType(typeof(Response<>), typeof(BinaryData))
                : typeof(Response);
            Assert.AreEqual(isAsync ? new CSharpType(typeof(Task<>), responseType) : responseType, method.Signature.ReturnType);
            var body = method.BodyStatements!.ToDisplayString();
            StringAssert.Contains(isAsync ? "await this.GetAsync(" : "this.Get(", body);
            StringAssert.Contains(replaceWithBytes
                ? "return global::Azure.Response.FromValue(result.Content, result);"
                : "return result;", body);
            StringAssert.DoesNotContain("JsonDocument", body);
            Assert.AreSame(InputPrimitiveType.String, operationResponse.BodyType);
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void DoesNotModifyProtocolResponse(bool replaceWithBytes, bool isAsync)
        {
            var method = CreateMethod(replaceWithBytes, isAsync, kind: ScmMethodKind.Protocol);
            var originalReturnType = method.Signature.ReturnType;
            var originalBody = method.BodyStatements!.ToDisplayString();

            new TestResponseReplacementVisitor().Visit(method);

            Assert.AreEqual(originalReturnType, method.Signature.ReturnType);
            Assert.AreEqual(originalBody, method.BodyStatements!.ToDisplayString());
        }

        [TestCase(false)]
        [TestCase(true)]
        public void DoesNotModifyNonOverriddenResponse(bool replaceWithBytes)
        {
            var method = CreateMethod(replaceWithBytes, false, isOverride: false);
            var originalReturnType = method.Signature.ReturnType;
            var originalBody = method.BodyStatements!.ToDisplayString();

            new TestResponseReplacementVisitor().Visit(method);

            Assert.AreEqual(originalReturnType, method.Signature.ReturnType);
            Assert.AreEqual(originalBody, method.BodyStatements!.ToDisplayString());
        }

        [Test]
        public void DoesNotModifyOtherResponseOverrides()
        {
            var method = CreateMethod(false, false);
            method.ServiceMethod!.Update(response: InputFactory.ServiceMethodResponse(InputPrimitiveType.String, null));
            var originalReturnType = method.Signature.ReturnType;
            var originalBody = method.BodyStatements!.ToDisplayString();

            new TestResponseReplacementVisitor().Visit(method);

            Assert.AreEqual(originalReturnType, method.Signature.ReturnType);
            Assert.AreEqual(originalBody, method.BodyStatements!.ToDisplayString());
        }

        private static ScmMethodProvider CreateMethod(
            bool replaceWithBytes,
            bool isAsync,
            bool isOverride = true,
            ScmMethodKind kind = ScmMethodKind.Convenience)
        {
            var operation = InputFactory.Operation("Get", responses: [InputFactory.OperationResponse(bodytype: InputPrimitiveType.String)]);
            var serviceMethod = InputFactory.BasicServiceMethod(
                "Get",
                operation,
                response: InputFactory.ServiceMethodResponse(
                    replaceWithBytes ? new InputPrimitiveType(InputPrimitiveTypeKind.Bytes, "bytes", "TypeSpec.bytes", "base64") : null,
                    null));
            serviceMethod.Update(isOverride: isOverride);
            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var client = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(client);
            var methods = new ScmMethodProviderCollection(serviceMethod, client!);
            return methods.Single(m => m.Kind == kind && m.Signature.Name == (isAsync ? "GetAsync" : "Get"));
        }

        private sealed class TestResponseReplacementVisitor : ResponseReplacementVisitor
        {
            public void Visit(ScmMethodProvider method) => VisitMethod(method);
        }
    }
}
