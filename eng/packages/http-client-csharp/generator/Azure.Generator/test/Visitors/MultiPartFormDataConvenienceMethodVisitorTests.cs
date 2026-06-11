// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class MultiPartFormDataConvenienceMethodVisitorTests
    {
        [Test]
        public void ConvertsMultiPartConvenienceMethodPayload()
        {
            var inputModel = InputFactory.Model("cat", properties:
            [
                InputFactory.Property("name", InputPrimitiveType.String, isRequired: true),
                InputFactory.Property("age", InputPrimitiveType.Int32, isRequired: true),
            ],
            usage: InputModelTypeUsage.Input | InputModelTypeUsage.MultipartFormData,
            serializationOptions: new InputSerializationOptions(
                json: null,
                multipart: new InputMultipartOptions("cat", false, false, [], null, null)));
            var contentTypeParameter = InputFactory.ContentTypeParameter("multipart/form-data");
            var bodyParameter = InputFactory.BodyParameter("body", inputModel, isRequired: true, contentTypes: ["multipart/form-data"], defaultContentType: "multipart/form-data");
            var operation = InputFactory.Operation("Upload", parameters: [contentTypeParameter, bodyParameter], requestMediaTypes: ["multipart/form-data"]);
            var serviceMethod = InputFactory.BasicServiceMethod("Upload", operation, parameters: [InputFactory.MethodParameter("body", inputModel, isRequired: true)]);
            var client = InputFactory.Client("client", methods: [serviceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [client]);

            var visitor = new TestMultiPartFormDataConvenienceMethodVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var clientProvider = plugin.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().First();
            var convenienceMethod = clientProvider.Methods
                .OfType<ScmMethodProvider>()
                .Single(m => m.Kind == ScmMethodKind.Convenience && m.Signature.Name == "Upload");

            Assert.AreEqual(Helpers.GetExpectedFromFile(), convenienceMethod.BodyStatements!.ToDisplayString());
        }

        [Test]
        public void ConvertsMultiPartMixedConvenienceMethodPayload()
        {
            var inputModel = InputFactory.Model("cat", properties:
            [
                InputFactory.Property("name", InputPrimitiveType.String, isRequired: true),
                InputFactory.Property("age", InputPrimitiveType.Int32, isRequired: true),
            ],
            usage: InputModelTypeUsage.Input | InputModelTypeUsage.MultipartFormData,
            serializationOptions: new InputSerializationOptions(
                json: null,
                multipart: new InputMultipartOptions("cat", false, false, [], null, null)));
            var contentTypeParameter = InputFactory.ContentTypeParameter("multipart/mixed");
            var bodyParameter = InputFactory.BodyParameter("body", inputModel, isRequired: true, contentTypes: ["multipart/mixed"], defaultContentType: "multipart/mixed");
            var operation = InputFactory.Operation("Upload", parameters: [contentTypeParameter, bodyParameter], requestMediaTypes: ["multipart/mixed"]);
            var serviceMethod = InputFactory.BasicServiceMethod("Upload", operation, parameters: [InputFactory.MethodParameter("body", inputModel, isRequired: true)]);
            var client = InputFactory.Client("client", methods: [serviceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [client]);

            var visitor = new TestMultiPartFormDataConvenienceMethodVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var clientProvider = plugin.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().First();
            var convenienceMethod = clientProvider.Methods
                .OfType<ScmMethodProvider>()
                .Single(m => m.Kind == ScmMethodKind.Convenience && m.Signature.Name == "Upload");

            Assert.AreEqual(Helpers.GetExpectedFromFile(), convenienceMethod.BodyStatements!.ToDisplayString());
        }

        [Test]
        public void PreservesNonBodyParametersInProtocolInvocation()
        {
            var inputModel = InputFactory.Model("cat", properties:
            [
                InputFactory.Property("name", InputPrimitiveType.String, isRequired: true),
                InputFactory.Property("age", InputPrimitiveType.Int32, isRequired: true),
            ],
            usage: InputModelTypeUsage.Input | InputModelTypeUsage.MultipartFormData,
            serializationOptions: new InputSerializationOptions(
                json: null,
                multipart: new InputMultipartOptions("cat", false, false, [], null, null)));
            var pathParameter = InputFactory.PathParameter("collectionId", InputPrimitiveType.String, isRequired: true);
            var contentTypeParameter = InputFactory.ContentTypeParameter("multipart/form-data");
            var bodyParameter = InputFactory.BodyParameter("body", inputModel, isRequired: true, contentTypes: ["multipart/form-data"], defaultContentType: "multipart/form-data");
            var operation = InputFactory.Operation("CreateCollectionAsset", parameters: [pathParameter, contentTypeParameter, bodyParameter], requestMediaTypes: ["multipart/form-data"]);
            var serviceMethod = InputFactory.BasicServiceMethod(
                "CreateCollectionAsset",
                operation,
                parameters:
                [
                    InputFactory.MethodParameter("collectionId", InputPrimitiveType.String, isRequired: true, location: InputRequestLocation.Path),
                    InputFactory.MethodParameter("body", inputModel, isRequired: true),
                ]);
            var client = InputFactory.Client("client", methods: [serviceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [client]);

            var visitor = new TestMultiPartFormDataConvenienceMethodVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var clientProvider = plugin.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().First();
            var convenienceMethod = clientProvider.Methods
                .OfType<ScmMethodProvider>()
                .Single(m => m.Kind == ScmMethodKind.Convenience && m.Signature.Name == "CreateCollectionAsset");

            Assert.AreEqual(Helpers.GetExpectedFromFile(), convenienceMethod.BodyStatements!.ToDisplayString());
        }

        [Test]
        public void WrapsPayloadInValueReturningConvenienceMethod()
        {
            var inputModel = InputFactory.Model("cat", properties:
            [
                InputFactory.Property("name", InputPrimitiveType.String, isRequired: true),
                InputFactory.Property("age", InputPrimitiveType.Int32, isRequired: true),
            ],
            usage: InputModelTypeUsage.Input | InputModelTypeUsage.MultipartFormData,
            serializationOptions: new InputSerializationOptions(
                json: null,
                multipart: new InputMultipartOptions("cat", false, false, [], null, null)));
            var resultModel = InputFactory.Model("uploadResult", properties:
            [
                InputFactory.Property("id", InputPrimitiveType.String, isRequired: true),
            ],
            usage: InputModelTypeUsage.Output);
            var contentTypeParameter = InputFactory.ContentTypeParameter("multipart/form-data");
            var bodyParameter = InputFactory.BodyParameter("body", inputModel, isRequired: true, contentTypes: ["multipart/form-data"], defaultContentType: "multipart/form-data");
            var operation = InputFactory.Operation("Upload", parameters: [contentTypeParameter, bodyParameter], requestMediaTypes: ["multipart/form-data"], responses: [InputFactory.OperationResponse(bodytype: resultModel)]);
            var serviceMethod = InputFactory.BasicServiceMethod(
                "Upload",
                operation,
                parameters: [InputFactory.MethodParameter("body", inputModel, isRequired: true)],
                response: InputFactory.ServiceMethodResponse(resultModel, null));
            var client = InputFactory.Client("client", methods: [serviceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(inputModels: () => [inputModel, resultModel], clients: () => [client]);

            var visitor = new TestMultiPartFormDataConvenienceMethodVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            var clientProvider = plugin.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().First();
            var convenienceMethod = clientProvider.Methods
                .OfType<ScmMethodProvider>()
                .Single(m => m.Kind == ScmMethodKind.Convenience
                    && m.Signature.Name == "Upload");

            Assert.AreEqual(Helpers.GetExpectedFromFile(), convenienceMethod.BodyStatements!.ToDisplayString());
        }

        [Test]
        public void DoesNotModifyNonMultiPartConvenienceMethod()
        {
            var inputModel = InputFactory.Model("cat", properties: [InputFactory.Property("name", InputPrimitiveType.String, isRequired: true)]);
            var bodyParameter = InputFactory.BodyParameter("body", inputModel, isRequired: true);
            var operation = InputFactory.Operation("Upload", parameters: [bodyParameter]);
            var serviceMethod = InputFactory.BasicServiceMethod("Upload", operation, parameters: [InputFactory.MethodParameter("body", inputModel, isRequired: true)]);
            var client = InputFactory.Client("client", methods: [serviceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(clients: () => [client]);

            var clientProvider = plugin.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().First();
            var convenienceMethod = clientProvider.Methods
                .OfType<ScmMethodProvider>()
                .Single(m => m.Kind == ScmMethodKind.Convenience && m.Signature.Name == "Upload");
            var expected = convenienceMethod.BodyStatements!.ToDisplayString();

            var visitor = new TestMultiPartFormDataConvenienceMethodVisitor();
            visitor.InvokeVisitLibrary(plugin.Object.OutputLibrary);

            Assert.AreEqual(expected, convenienceMethod.BodyStatements!.ToDisplayString());
        }

        private class TestMultiPartFormDataConvenienceMethodVisitor : MultiPartFormDataConvenienceMethodVisitor
        {
            public void InvokeVisitLibrary(OutputLibrary library)
            {
                base.VisitLibrary(library);
            }
        }
    }
}
