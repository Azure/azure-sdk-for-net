// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.EmitterRpc;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Tests.Visitors
{
    public class LroVisitorTests
    {
        [TestCase("public", true)]
        [TestCase("public", false)]
        [TestCase("internal", true)]
        [TestCase("internal", false)]
        public void SelectedMetadataChangesOnlyAnnotatedOperationAndUsesWireSegments(string access, bool hasEnclosingModel)
        {
            var progress = InputFactory.Property("progress", InputPrimitiveType.Int32, isRequired: true,
                wireName: "percent_done", serializedName: "progress", access: access);
            var details = InputFactory.Property("details", InputFactory.Model("Details", properties: hasEnclosingModel ? [progress] : []), wireName: "wire_details");
            Assert.AreEqual(hasEnclosingModel, progress.EnclosingType is not null);
            var metadata = new InputLongRunningServiceMetadata(1, InputFactory.OperationResponse(), null,
                [new InputLroStatusMetadata(progress, [details, progress])], []);
            var selected = InputFactory.LongRunningServiceMethod("selected", InputFactory.Operation("selected"), access: access, longRunningServiceMetadata: metadata);
            var ordinary = InputFactory.LongRunningServiceMethod("ordinary", InputFactory.Operation("ordinary"));
            var inputClient = InputFactory.Client("TestClient", methods: [selected, ordinary]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var client = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;
            var visitor = new TestLroVisitor();
            foreach (var method in client.Methods.OfType<ScmMethodProvider>())
            {
                visitor.InvokeVisitMethod(method);
                var returnType = method.Signature.ReturnType!;
                if (method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async))
                {
                    returnType = returnType.Arguments[0];
                }
                Assert.AreEqual(method.ServiceMethod == selected && method.Kind != ScmMethodKind.Protocol
                    ? "SelectedOperation" : "Operation", returnType.Name);
            }
            var output = (AzureOutputLibrary)AzureClientGenerator.Instance.OutputLibrary;
            var operation = output.GetLroOperation(selected, client, protocol: false)!;
            Assert.AreEqual("SelectedOperationMetadata", operation.Properties.Single(p => p.Name == "Metadata").Type.Name);
            var metadataType = output.TypeProviders.OfType<LroStatusMetadataProvider>().Single();
            Assert.AreEqual(access == "public", operation.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public));
            Assert.AreEqual(access == "public", metadataType.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public));
            foreach (var name in new[] { "WaitForCompletionResponse", "WaitForCompletionResponseAsync" })
            {
                var waits = operation.Methods.Where(m => m.Signature.Name == name).ToArray();
                Assert.AreEqual(3, waits.Length);
                foreach (var wait in waits)
                {
                    StringAssert.Contains($"_operation.{name}(", wait.BodyExpression!.ToDisplayString());
                }
            }
            var property = metadataType.Properties.Single();
            Assert.AreEqual(access == "public", property.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.AreEqual(access == "internal", property.Modifiers.HasFlag(MethodSignatureModifiers.Internal));
            Assert.AreEqual(new CSharpType(typeof(int), isNullable: true), property.Type);
            var body = ((MethodPropertyBody)property.Body).Getter!.ToDisplayString();
            StringAssert.Contains("\"wire_details\", \"percent_done\"", body);
            Assert.IsNull(output.GetLroOperation(ordinary, client, protocol: false));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectedMetadataReadsCachedPollingResponseModel(bool hasPollingModel)
        {
            var progress = InputFactory.Property("progress", InputPrimitiveType.Int32, isRequired: true,
                wireName: "percent_done", serializedName: "progress");
            var detailsModel = InputFactory.Model("Details", properties: [progress]);
            var details = InputFactory.Property("details", detailsModel, wireName: "wire_details");
            var monitor = InputFactory.Model("JobStatus", properties: [details]);
            var metadata = new InputLongRunningServiceMetadata(1, InputFactory.OperationResponse(), null,
                [new InputLroStatusMetadata(progress, [details, progress])], [], hasPollingModel ? monitor : null);
            var selected = InputFactory.LongRunningServiceMethod("selected", InputFactory.Operation("selected"), longRunningServiceMetadata: metadata);
            var inputClient = InputFactory.Client("TestClient", methods: [selected]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient], inputModels: () => [monitor, detailsModel]);
            var client = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;
            var output = (AzureOutputLibrary)AzureClientGenerator.Instance.OutputLibrary;
            output.GetLroOperation(selected, client, protocol: false);
            var metadataType = output.TypeProviders.OfType<LroStatusMetadataProvider>().Single();
            var property = metadataType.Properties.Single();

            if (!hasPollingModel)
            {
                Assert.IsEmpty(metadataType.Methods);
                StringAssert.Contains("\"wire_details\", \"percent_done\"",
                    ((MethodPropertyBody)property.Body).Getter!.ToDisplayString());
                return;
            }

            var propertyBody = ((MethodPropertyBody)property.Body).Getter!.ToDisplayString();
            StringAssert.Contains("GetStatusMetadata", propertyBody);
            StringAssert.Contains("return this.GetMonitorModel(response)?.Details?.Progress;", propertyBody);
            Assert.AreEqual(1, propertyBody.Split("_getResponse.Invoke()", StringSplitOptions.None).Length - 1);
            StringAssert.Contains("GetStatusMetadata(response,", propertyBody);
            var cache = metadataType.Fields.Single(f => f.Name == "_monitorCache");
            Assert.AreEqual("JobStatus", cache.Type.Arguments[1].Name);
            var body = metadataType.Methods.Single(m => m.Signature.Name == "GetMonitorModel").BodyStatements!.ToDisplayString();
            StringAssert.Contains("object.ReferenceEquals(cache.Item1, response)", body);
            StringAssert.Contains("ModelReaderWriter.Read<global::Samples.Models.JobStatus>(response.Content", body);
            StringAssert.Contains("catch (global::System.Text.Json.JsonException)", body);
            StringAssert.Contains("catch (global::System.InvalidOperationException)", body);
            StringAssert.Contains("_monitorCache = new global::System.Tuple<global::Azure.Response, global::Samples.Models.JobStatus>(response, model);", body);
        }

        [Test]
        public void ModelValuedMetadataWithoutPollingResponseModel()
        {
            var value = InputFactory.Model("Details", properties: [InputFactory.Property("progress", InputPrimitiveType.Int32)]);
            var details = InputFactory.Property("details", value, isReadOnly: true);
            var metadata = new InputLongRunningServiceMetadata(1, InputFactory.OperationResponse(), null,
                [new InputLroStatusMetadata(details, [details])], []);
            var selected = InputFactory.LongRunningServiceMethod("selected", InputFactory.Operation("selected"), longRunningServiceMetadata: metadata);
            var inputClient = InputFactory.Client("TestClient", methods: [selected]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient], inputModels: () => [value]);
            var client = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;
            var output = (AzureOutputLibrary)AzureClientGenerator.Instance.OutputLibrary;
            output.GetLroOperation(selected, client, protocol: false);
            Assert.NotNull(AzureClientGenerator.Instance.TypeFactory.CreateModel(value));
            Assert.NotNull(AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(value));
            var metadataType = output.TypeProviders.OfType<LroStatusMetadataProvider>().Single();
            var body = ((MethodPropertyBody)metadataType.Properties.Single().Body).Getter!.ToDisplayString();
            Assert.IsEmpty(metadataType.Methods);
            StringAssert.Contains("\"details\"", body);
            StringAssert.Contains("Details.DeserializeDetails(element.Value", body);
            Assert.IsTrue(output.TypeProviders.OfType<ModelProvider>().Any(model => model.Name == "Details"));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void OperationIdOnlyPreservesMethodReturnTypes(bool hasResult)
        {
            var id = InputFactory.Property("id", InputPrimitiveType.String);
            var metadata = new InputLongRunningServiceMetadata(1, InputFactory.OperationResponse(), null,
                [], [new InputLroOperationIdPropertyMetadata(id, [id])]);
            var response = hasResult ? InputFactory.Model("Result") : null;
            var lro = InputFactory.LongRunningServiceMethod("start", InputFactory.Operation("start"),
                response: InputFactory.ServiceMethodResponse(response, null), longRunningServiceMetadata: metadata);
            var inputClient = InputFactory.Client("TestClient", methods: [lro]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var client = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;
            var visitor = new TestLroVisitor();
            var output = (AzureOutputLibrary)AzureClientGenerator.Instance.OutputLibrary;
            foreach (var method in client.Methods.OfType<ScmMethodProvider>())
            {
                visitor.InvokeVisitMethod(method);
                var returnType = method.Signature.ReturnType!;
                if (method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async))
                {
                    returnType = returnType.Arguments[0];
                }
                Assert.AreEqual("Operation", returnType.Name);
                if (hasResult)
                {
                    Assert.AreEqual(method.Kind == ScmMethodKind.Protocol ? "BinaryData" : "Result", returnType.Arguments[0].Name);
                }
                Assert.IsFalse(output.GetLroOperation(lro, client, method.Kind == ScmMethodKind.Protocol)!
                    .DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public));
            }
            _ = output.TypeProviders;
            _ = output.TypeProviders;
            var rehydrationMethods = client.Methods.Where(m => m.Signature.Name.StartsWith("Rehydrate", StringComparison.Ordinal)).ToArray();
            Assert.AreEqual(hasResult ? 2 : 1, rehydrationMethods.Length);
            Assert.AreEqual("Operation", rehydrationMethods[0].Signature.ReturnType!.Name);
            if (hasResult)
            {
                Assert.AreEqual("Result", rehydrationMethods[0].Signature.ReturnType!.Arguments[0].Name);
            }
            Assert.IsTrue(rehydrationMethods.All(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Static)));
            Assert.IsTrue(rehydrationMethods.All(m => m.BodyExpression!.ToDisplayString().Contains("FromRehydrationToken")));
        }

        [TestCase(InputPathParameterStyle.Unknown)]
        [TestCase(InputPathParameterStyle.Simple)]
        [TestCase(InputPathParameterStyle.Label)]
        [TestCase(InputPathParameterStyle.Matrix)]
        [TestCase(InputPathParameterStyle.Path)]
        [TestCase(InputPathParameterStyle.Fragment)]
        public void OperationIdPathPassesParameterStyle(InputPathParameterStyle style)
        {
            var parameter = InputFactory.PathParameter("id", InputPrimitiveType.String, serializedName: "wireId");
            typeof(InputPathParameter).GetProperty(nameof(InputPathParameter.Style))!.SetValue(parameter, style);
            var location = new InputOperationLink(InputOperationLinkLocation.ResponseHeader, InputFactory.Property("operationLocation", InputPrimitiveType.String));
            var metadata = new InputLongRunningServiceMetadata(1, InputFactory.OperationResponse(), null, [],
                [new InputLroOperationIdPathMetadata(location, parameter, "/jobs{wireId}/status")]);
            var method = InputFactory.LongRunningServiceMethod("start", InputFactory.Operation("start"), longRunningServiceMetadata: metadata);
            var inputClient = InputFactory.Client("TestClient", methods: [method]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var client = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;
            var operation = ((AzureOutputLibrary)AzureClientGenerator.Instance.OutputLibrary).GetLroOperation(method, client, protocol: false)!;
            var id = (ExpressionPropertyBody)operation.Properties.Single(p => p.Name == "Id").Body;
            StringAssert.Contains($"\"/jobs{{wireId}}/status\", \"wireId\", null, \"{style}\"", id.Getter.ToDisplayString());
        }

        [Test]
        public void RehydrationMethodAvoidsExistingClientMethod()
        {
            var id = InputFactory.Property("id", InputPrimitiveType.String);
            var metadata = new InputLongRunningServiceMetadata(1, InputFactory.OperationResponse(), null,
                [], [new InputLroOperationIdPropertyMetadata(id, [id])]);
            var lro = InputFactory.LongRunningServiceMethod("start", InputFactory.Operation("start"), longRunningServiceMetadata: metadata);
            var existing = InputFactory.BasicServiceMethod("rehydrateStartOperation", InputFactory.Operation("rehydrateStartOperation"));
            var inputClient = InputFactory.Client("TestClient", methods: [lro, existing]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var output = (AzureOutputLibrary)AzureClientGenerator.Instance.OutputLibrary;
            var client = output.TypeProviders.OfType<ClientProvider>().Single();
            Assert.AreEqual(1, client.Methods.Count(m => m.Signature.Name == "RehydrateStartOperation2"));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void VoidLroMetadataWrapsProtocolResult(bool hasStatusMetadata)
        {
            var property = InputFactory.Property("id", InputPrimitiveType.String);
            var monitor = InputFactory.Model("Monitor", properties: [property]);
            var metadata = new InputLongRunningServiceMetadata(1, InputFactory.OperationResponse(), null,
                hasStatusMetadata ? [new InputLroStatusMetadata(property, [property])] : [],
                hasStatusMetadata ? [] : [new InputLroOperationIdPropertyMetadata(property, [property])]);
            var method = InputFactory.LongRunningServiceMethod("start", InputFactory.Operation("start"),
                longRunningServiceMetadata: metadata);
            var inputClient = InputFactory.Client("TestClient", methods: [method]);
            var generator = MockHelpers.LoadMockGenerator(clients: () => [inputClient], inputModels: () => [monitor]);
            var output = generator.Object.OutputLibrary;
            new TestLroVisitor().InvokeVisitLibrary(output);
            var client = output.TypeProviders.OfType<ClientProvider>().Single();
            foreach (var convenience in client.Methods.OfType<ScmMethodProvider>()
                         .Where(m => m.Kind != ScmMethodKind.Protocol))
            {
                var body = convenience.BodyStatements!.ToDisplayString();
                StringAssert.Contains("WrapWithMetadata", body);
                StringAssert.Contains("new global::Samples.StartOperation", body);
            }
        }

        [Test]
        public void MetadataOperationNamesAvoidExistingTypesAndOtherOperations()
        {
            var status = InputFactory.Property("progress", InputPrimitiveType.Int32);
            var metadata = new InputLongRunningServiceMetadata(1, InputFactory.OperationResponse(), null,
                [new InputLroStatusMetadata(status, [status])], []);
            var first = InputFactory.LongRunningServiceMethod("start", InputFactory.Operation("start"), longRunningServiceMetadata: metadata);
            var second = InputFactory.LongRunningServiceMethod("start", InputFactory.Operation("start"), longRunningServiceMetadata: metadata);
            var firstClient = InputFactory.Client("FirstClient", methods: [first]);
            var secondClient = InputFactory.Client("SecondClient", methods: [second]);
            var existing = InputFactory.Model("StartOperation");
            MockHelpers.LoadMockGenerator(clients: () => [firstClient, secondClient], inputModels: () => [existing]);
            var output = (AzureOutputLibrary)AzureClientGenerator.Instance.OutputLibrary;
            var firstOperation = output.GetLroOperation(first, AzureClientGenerator.Instance.TypeFactory.CreateClient(firstClient)!, false)!;
            var secondOperation = output.GetLroOperation(second, AzureClientGenerator.Instance.TypeFactory.CreateClient(secondClient)!, false)!;

            Assert.AreEqual("FirstClientStartOperation", firstOperation.Name);
            Assert.AreEqual("SecondClientStartOperation", secondOperation.Name);
            Assert.AreNotEqual(firstOperation.Properties.Single(p => p.Name == "Metadata").Type.Name,
                secondOperation.Properties.Single(p => p.Name == "Metadata").Type.Name);
        }

        [TestCase("none")]
        [TestCase("status")]
        [TestCase("id")]
        public void WarnsWhenPagedLroHasSelectedMetadata(string selection)
        {
            var property = InputFactory.Property("id", InputPrimitiveType.String);
            var metadata = new InputLongRunningServiceMetadata(1, InputFactory.OperationResponse(), null,
                selection == "status" ? [new InputLroStatusMetadata(property, [property])] : [],
                selection == "id" ? [new InputLroOperationIdPropertyMetadata(property, [property])] : []);
            var paging = new InputLongRunningPagingServiceMethod(
                "list", "public", [], null, null, InputFactory.Operation("list"), [],
                InputFactory.ServiceMethodResponse(null, null), null, false, true, true, "Test.list",
                metadata, InputFactory.PagingMetadata([], null, null));
            var inputClient = InputFactory.Client("TestClient", methods: [paging]);
            var generator = MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            using var stream = new MemoryStream();
            using var emitter = (Emitter)Activator.CreateInstance(typeof(Emitter),
                BindingFlags.Instance | BindingFlags.NonPublic, null, [stream], null)!;
            generator.SetupGet(g => g.Emitter).Returns(emitter);
            var client = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;

            new TestLroVisitor().InvokeVisitServiceMethod(paging, client, null);
            var output = Encoding.UTF8.GetString(stream.ToArray());
            if (selection == "none")
            {
                Assert.IsEmpty(output);
            }
            else
            {
                StringAssert.Contains("AZLRO001", output);
                StringAssert.Contains("Test.list", output);
                StringAssert.Contains("not supported for paged operation", output);
            }
        }

        [Test]
        public void UpdatesLroSignatureNoResponseBody()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var lroServiceMethod = InputFactory.LongRunningServiceMethod("foo", lro, parameters: parameters);
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            foreach (var method in clientProvider!.Methods)
            {
                var updatedMethod = visitor.InvokeVisitMethod(method);
                Assert.IsNotNull(updatedMethod);
                var scmMethod = method as ScmMethodProvider;
                Assert.IsNotNull(scmMethod);
                var waitUntilParameter = scmMethod!.Signature.Parameters[0];
                Assert.IsTrue(waitUntilParameter.Type.Equals(typeof(WaitUntil)));
                Assert.AreEqual("waitUntil", waitUntilParameter.Name);

                Assert.IsTrue(scmMethod.Signature.ReturnType!.Equals(typeof(Operation)) ||
                              scmMethod.Signature.ReturnType!.Equals(new CSharpType(typeof(Task<>), typeof(Operation))));

                if (scmMethod.Kind == ScmMethodKind.Protocol)
                {
                    var requestContextParameter = scmMethod.Signature.Parameters[^1];
                    Assert.IsTrue(requestContextParameter.Type.Equals(typeof(RequestContext)));
                    Assert.AreEqual("context", requestContextParameter.Name);
                }
                else
                {
                    var cancellationTokenParameter = scmMethod.Signature.Parameters[^1];
                    Assert.IsTrue(cancellationTokenParameter.Type.Equals(typeof(CancellationToken)));
                    Assert.AreEqual("cancellationToken", cancellationTokenParameter.Name);
                }
            }
        }

        [Test]
        public void UpdatesLroSignatureWithResponseBody()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var responseModel = InputFactory.Model("foo");
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro, parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            foreach (var method in clientProvider!.Methods)
            {
                var updatedMethod = visitor.InvokeVisitMethod(method);
                Assert.IsNotNull(updatedMethod);
                var scmMethod = method as ScmMethodProvider;
                Assert.IsNotNull(scmMethod);
                var waitUntilParameter = scmMethod!.Signature.Parameters[0];
                Assert.IsTrue(waitUntilParameter.Type.Equals(typeof(WaitUntil)));
                Assert.AreEqual("waitUntil", waitUntilParameter.Name);

                if (scmMethod.Kind == ScmMethodKind.Protocol)
                {
                    var requestContextParameter = scmMethod.Signature.Parameters[^1];
                    Assert.IsTrue(requestContextParameter.Type.Equals(typeof(RequestContext)));
                    Assert.AreEqual("context", requestContextParameter.Name);
                }
                else
                {
                    var cancellationTokenParameter = scmMethod.Signature.Parameters[^1];
                    Assert.IsTrue(cancellationTokenParameter.Type.Equals(typeof(CancellationToken)));
                    Assert.AreEqual("cancellationToken", cancellationTokenParameter.Name);
                    Assert.IsTrue(scmMethod.Signature.ReturnType!.Equals(new CSharpType(typeof(Operation<>), responseModelProvider!.Type)) ||
                                  scmMethod.Signature.ReturnType!.Equals(new CSharpType(typeof(Task<>), new CSharpType(typeof(Operation<>), responseModelProvider.Type))));
                }
            }
        }

        [Test]
        public void AddsFromLroResponseMethodAndRemovesExplicitOperatorForLroOnlyModel()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var responseModel = InputFactory.Model("foo");
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro,
                parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]),
                longRunningServiceMetadata: InputFactory.LongRunningServiceMetadata(
                    finalState: 1,
                    finalResponse: InputFactory.OperationResponse(),
                    resultPath: "someResultPath"));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            var methodCollection = new ScmMethodProviderCollection(lroServiceMethod, clientProvider!);
            visitor.InvokeVisitServiceMethod(lroServiceMethod, clientProvider!, methodCollection);

            var serializationProvider = responseModelProvider!.SerializationProviders[0];

            // Check that FromLroResponse method was added
            var fromLroResponseMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "FromLroResponse");

            Assert.IsNotNull(fromLroResponseMethod);
            Assert.IsNotNull(fromLroResponseMethod!.BodyStatements);
            var result = fromLroResponseMethod!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), result);

            // Check that explicit operator was removed since model is only used in LRO
            var explicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));
            Assert.IsNull(explicitOperator);

            // does not add the method again on subsequent calls
            visitor.InvokeVisitServiceMethod(lroServiceMethod, clientProvider!, methodCollection);
            serializationProvider = responseModelProvider!.SerializationProviders[0];
            fromLroResponseMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "FromLroResponse");
            result = fromLroResponseMethod!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), result);
        }

        [Test]
        public void RetainsExplicitOperatorWhenModelUsedInNonLroContext()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var responseModel = InputFactory.Model("foo");

            // Create an LRO method
            var lro = InputFactory.Operation(
                "lroOp",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "lroOp",
                lro,
                parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]),
                longRunningServiceMetadata: InputFactory.LongRunningServiceMetadata(
                    finalState: 1,
                    finalResponse: InputFactory.OperationResponse(),
                    resultPath: "someResultPath"));

            // Create a non-LRO method that also returns the same model
            var nonLroOp = InputFactory.Operation(
                "nonLroOp",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var nonLroServiceMethod = InputFactory.BasicServiceMethod(
                "nonLroOp",
                nonLroOp,
                parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));

            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod, nonLroServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            var methodCollection = new ScmMethodProviderCollection(lroServiceMethod, clientProvider!);
            visitor.InvokeVisitServiceMethod(lroServiceMethod, clientProvider!, methodCollection);

            var serializationProvider = responseModelProvider!.SerializationProviders[0];

            // Check that FromLroResponse method was added
            var fromLroResponseMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "FromLroResponse");
            Assert.IsNotNull(fromLroResponseMethod);

            // Check that explicit operator was RETAINED since model is also used in non-LRO context
            var explicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));
            Assert.IsNotNull(explicitOperator);
        }

        [Test]
        public void DoesNotAddFromLroResponseMethodWhenNoResultPath()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var responseModel = InputFactory.Model("foo");
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            // LRO service method without result path
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro,
                parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]),
                longRunningServiceMetadata: InputFactory.LongRunningServiceMetadata(
                    finalState: 1,
                    finalResponse: InputFactory.OperationResponse(),
                    resultPath: null)); // No result path
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            var methodCollection = new ScmMethodProviderCollection(lroServiceMethod, clientProvider!);
            visitor.InvokeVisitServiceMethod(lroServiceMethod, clientProvider!, methodCollection);

            var serializationProvider = responseModelProvider!.SerializationProviders[0];

            // Check that FromLroResponse method was NOT added
            var fromLroResponseMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "FromLroResponse");
            Assert.IsNull(fromLroResponseMethod);

            // Explicit operator should still be present
            var explicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));
            Assert.IsNotNull(explicitOperator);
        }

        [Test]
        public void UpdatesConvenienceMethodBody()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var responseModel = InputFactory.Model("foo");
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro, parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var outputLibrary = plugin.Object.OutputLibrary;
            visitor.InvokeVisitLibrary(outputLibrary);

            var clientProvider = outputLibrary.TypeProviders.OfType<ClientProvider>().FirstOrDefault();
            Assert.IsNotNull(clientProvider);
            var convenienceMethod = clientProvider!.Methods
                .FirstOrDefault(m => m.Signature.Parameters.All(p => p.Name != "context"));

            Assert.IsNotNull(convenienceMethod);
            var actual = convenienceMethod!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), actual);
        }

        [Test]
        public void UpdatesConvenienceMethodBodyWithResultPath()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var responseModel = InputFactory.Model("foo");
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro, parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]),
                longRunningServiceMetadata: InputFactory.LongRunningServiceMetadata(
                    finalState: 1,
                    finalResponse: InputFactory.OperationResponse(),
                    resultPath: "result"));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var outputLibrary = plugin.Object.OutputLibrary;
            visitor.InvokeVisitLibrary(outputLibrary);

            var clientProvider = outputLibrary.TypeProviders.OfType<ClientProvider>().FirstOrDefault();
            Assert.IsNotNull(clientProvider);
            var convenienceMethod = clientProvider!.Methods
                .FirstOrDefault(m => m.Signature.Name == "Foo"
                    && m.Signature.Parameters.All(p => p.Name != "context"));

            Assert.IsNotNull(convenienceMethod);
            var actual = convenienceMethod!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), actual);
        }

        [Test]
        public void UpdatesAsyncConvenienceMethodBodyWithResultPath()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var responseModel = InputFactory.Model("foo");
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro, parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]),
                longRunningServiceMetadata: InputFactory.LongRunningServiceMetadata(
                    finalState: 1,
                    finalResponse: InputFactory.OperationResponse(),
                    resultPath: "result"));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var outputLibrary = plugin.Object.OutputLibrary;
            visitor.InvokeVisitLibrary(outputLibrary);

            var clientProvider = outputLibrary.TypeProviders.OfType<ClientProvider>().FirstOrDefault();
            Assert.IsNotNull(clientProvider);
            var asyncConvenienceMethod = clientProvider!.Methods
                .FirstOrDefault(m => m.Signature.Name == "FooAsync"
                    && m.Signature.Parameters.All(p => p.Name != "context"));

            Assert.IsNotNull(asyncConvenienceMethod);
            var actual = asyncConvenienceMethod!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), actual);
        }

        [Test]
        public void UpdatesProtocolMethodBody()
        {
            var visitor = new TestLroVisitor();
            List<InputParameter> parameters =
            [
                InputFactory.BodyParameter("p1", InputPrimitiveType.String)
            ];
            List<InputMethodParameter> methodParameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var responseModel = InputFactory.Model("foo");
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro, parameters: methodParameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var outputLibrary = plugin.Object.OutputLibrary;
            visitor.InvokeVisitLibrary(outputLibrary);

            var clientProvider = outputLibrary.TypeProviders.OfType<ClientProvider>().FirstOrDefault();
            Assert.IsNotNull(clientProvider);
            var protocolMethod = clientProvider!.Methods
                .FirstOrDefault(m => m.Signature.Parameters.Any(p => p.Name == "context"));

            Assert.IsNotNull(protocolMethod);
            var actual = protocolMethod!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), actual);
        }

        // Regression test for the Async-suffix scope-name bug: when both visitors run
        // (DistributedTracingVisitor adds the outer client-method scope, LroVisitor rewrites
        // the ProcessMessage call and injects the polling scope argument), the async protocol
        // method must use the stripped scope name ("TestClient.Foo") in BOTH places, never
        // "TestClient.FooAsync".
        [Test]
        public void AsyncProtocolMethodUsesStrippedScopeNameForOuterScopeAndScopeArg()
        {
            var lroVisitor = new TestLroVisitor();
            var tracingVisitor = new TestDistributedTracingVisitor();
            List<InputParameter> parameters =
            [
                InputFactory.BodyParameter("p1", InputPrimitiveType.String)
            ];
            List<InputMethodParameter> methodParameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var responseModel = InputFactory.Model("foo");
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro, parameters: methodParameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var outputLibrary = plugin.Object.OutputLibrary;

            // Run the visitors in the same order as the real generation pipeline:
            // DistributedTracingVisitor wraps the body with the outer scope first,
            // then LroVisitor rewrites the inner ProcessMessage call / scope argument.
            tracingVisitor.InvokeVisitLibrary(outputLibrary);
            lroVisitor.InvokeVisitLibrary(outputLibrary);

            var clientProvider = outputLibrary.TypeProviders.OfType<ClientProvider>().FirstOrDefault();
            Assert.IsNotNull(clientProvider);
            var asyncProtocolMethod = clientProvider!.Methods
                .FirstOrDefault(m => m.Signature.Name == "FooAsync"
                    && m.Signature.Parameters.Any(p => p.Name == "context"));

            Assert.IsNotNull(asyncProtocolMethod);
            var actual = asyncProtocolMethod!.BodyStatements!.ToDisplayString();

            // The expected snapshot captures both the outer scope (added by
            // DistributedTracingVisitor) and the ProcessMessageAsync scope argument (added by
            // LroVisitor), both of which must use the stripped scope name "TestClient.Foo"
            // rather than the Async-suffixed "TestClient.FooAsync".
            Assert.AreEqual(Helpers.GetExpectedFromFile(), actual);
        }

        // Regression: a convenience LRO method body whose `return Response.FromValue(...)` call has
        // an argument shape that does NOT match `(T)response` (i.e. Arguments[0] is not a CastExpression)
        // must not crash the visitor. Before the fix, the cast was unwrapped via
        // `(Arguments[0] as CastExpression)!.Inner`, which threw NullReferenceException for any
        // unexpected shape. The visitor should leave such statements unchanged.
        [Test]
        public void VisitExpressionStatement_FromValueWithNonCastArg_LeavesStatementUnchanged()
        {
            var (visitor, convenienceMethod) = BuildConvenienceMethodForExpressionStatementGuardTests();

            // return Response.FromValue("not-a-cast", "response");  // Arguments[0] is a Literal, not a Cast.
            var statement = new KeywordExpression(
                "return",
                Static(typeof(Response)).Invoke(
                    "FromValue",
                    [Literal("not-a-cast"), Literal("response")])).Terminate();
            var expressionStatement = (ExpressionStatement)statement;

            MethodBodyStatement? result = null;
            Assert.DoesNotThrow(() =>
                result = visitor.InvokeVisitExpressionStatement(expressionStatement, convenienceMethod));
            Assert.AreSame(expressionStatement, result);
        }

        // Regression: a `return Response.FromValue()` call with no arguments must not crash the
        // visitor on the Arguments[0] index access.
        [Test]
        public void VisitExpressionStatement_FromValueWithNoArgs_LeavesStatementUnchanged()
        {
            var (visitor, convenienceMethod) = BuildConvenienceMethodForExpressionStatementGuardTests();

            var statement = new KeywordExpression(
                "return",
                Static(typeof(Response)).Invoke("FromValue", System.Array.Empty<ValueExpression>())).Terminate();
            var expressionStatement = (ExpressionStatement)statement;

            MethodBodyStatement? result = null;
            Assert.DoesNotThrow(() =>
                result = visitor.InvokeVisitExpressionStatement(expressionStatement, convenienceMethod));
            Assert.AreSame(expressionStatement, result);
        }

        private static (TestLroVisitor Visitor, ScmMethodProvider ConvenienceMethod)
            BuildConvenienceMethodForExpressionStatementGuardTests()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var responseModel = InputFactory.Model("foo");
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro,
                parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            // Pick the synchronous convenience method (no `context` param) to satisfy the visitor's
            // gate `scmMethod.IsLroMethod() && scmMethod.Kind != ScmMethodKind.Protocol`.
            var convenienceMethod = clientProvider!.Methods
                .OfType<ScmMethodProvider>()
                .FirstOrDefault(m => m.Signature.Name == "Foo"
                    && m.Signature.Parameters.All(p => p.Name != "context"));
            Assert.IsNotNull(convenienceMethod);
            return (visitor, convenienceMethod!);
        }

        private class TestLroVisitor : LroVisitor
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

            public MethodBodyStatement? InvokeVisitExpressionStatement(
                ExpressionStatement expressionStatement,
                MethodProvider method)
            {
                return base.VisitExpressionStatement(expressionStatement, method);
            }
        }

        private class TestDistributedTracingVisitor : DistributedTracingVisitor
        {
            public TestDistributedTracingVisitor()
                : base(
                    new CSharpType(typeof(ClientDiagnostics)),
                    new CSharpType(typeof(DiagnosticScope)))
            {
            }

            public void InvokeVisitLibrary(OutputLibrary library)
            {
                base.VisitLibrary(library);
            }
        }
    }
}