// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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

        private static (InputLongRunningServiceMethod Lro, InputClient Client, InputModelType[] Models) CreateStatusMetadataInput(bool hasResult)
        {
            var createdOn = InputFactory.Property("createdOn", new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String),
                isRequired: true, isReadOnly: true, wireName: "createdDateTime");
            var succeeded = InputFactory.Property("succeeded", InputPrimitiveType.Int32, isRequired: true, isReadOnly: true);
            var statisticsModel = InputFactory.Model("JobStatistics", usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json, properties: [succeeded]);
            var statistics = InputFactory.Property("statistics", statisticsModel, isReadOnly: true);
            var errors = InputFactory.Property("errors", InputFactory.Array(InputPrimitiveType.String), isReadOnly: true);
            var id = InputFactory.Property("id", InputPrimitiveType.String, isRequired: true, isReadOnly: true);
            var missing = InputFactory.Property("missing", InputPrimitiveType.String);
            var monitor = InputFactory.Model("JobStatus", usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties: [id, createdOn, statistics, errors]);
            var metadata = new InputLongRunningServiceMetadata(1, InputFactory.OperationResponse(), null, monitor,
                [
                    new InputLroStatusMetadata(createdOn, [createdOn]),
                    new InputLroStatusMetadata(succeeded, [statistics, succeeded]),
                    new InputLroStatusMetadata(errors, [errors]),
                    // Conflicts with Operation.Id and an unresolvable selection are skipped rather than generated.
                    new InputLroStatusMetadata(id, [id]),
                    new InputLroStatusMetadata(missing, [missing]),
                ]);
            var result = hasResult ? InputFactory.Model("JobResult") : null;
            var lro = InputFactory.LongRunningServiceMethod("startJob", InputFactory.Operation("startJob"),
                response: InputFactory.ServiceMethodResponse(result, null), longRunningServiceMetadata: metadata);
            var ordinary = InputFactory.LongRunningServiceMethod("ordinary", InputFactory.Operation("ordinary"));
            return (lro, InputFactory.Client("TestClient", methods: [lro, ordinary]),
                result is null ? [monitor, statisticsModel] : [monitor, statisticsModel, result]);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void StatusMetadataOperationIsInternalAndKeepsReturnTypes(bool hasResult)
        {
            var (lro, inputClient, models) = CreateStatusMetadataInput(hasResult);
            var plugin = MockHelpers.LoadMockGenerator(clients: () => [inputClient], inputModels: () => models);
            var output = plugin.Object.OutputLibrary;
            new TestLroVisitor().InvokeVisitLibrary(output);
            var client = output.TypeProviders.OfType<ClientProvider>().Single();
            var operation = output.TypeProviders.OfType<LroOperationProvider>().Single();

            Assert.AreEqual("StartJobOperation", operation.Name);
            Assert.IsTrue(operation.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Internal));
            Assert.IsFalse(operation.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public));
            Assert.IsFalse(output.TypeProviders.Any(t => t.Name.EndsWith("Metadata") || t.Name.EndsWith("RawOperation")));
            Assert.AreEqual(8, client.Methods.Count);
            foreach (var method in client.Methods.OfType<ScmMethodProvider>())
            {
                var returnType = method.Signature.ReturnType!;
                if (method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async))
                {
                    returnType = returnType.Arguments[0];
                }
                Assert.AreEqual("Operation", returnType.Name);
                var body = method.BodyStatements!.ToDisplayString();
                var wrapped = method.Kind != ScmMethodKind.Protocol && method.ServiceMethod == lro;
                Assert.AreEqual(wrapped, body.Contains(hasResult ? "ConvertWithMetadata" : "WrapWithMetadata"), body);
                Assert.AreEqual(wrapped, body.Contains("new global::Samples.StartJobOperation(operation, getStatusMonitorResponse)"), body);
            }

            var metadata = operation.Properties.Where(p => p.Modifiers.HasFlag(MethodSignatureModifiers.Virtual)).ToArray();
            CollectionAssert.AreEqual(new[] { "CreatedOn", "Succeeded", "Errors" }, metadata.Select(p => p.Name));
            Assert.AreEqual(new CSharpType(typeof(DateTimeOffset), isNullable: true), metadata[0].Type);
            Assert.AreEqual(new CSharpType(typeof(int), isNullable: true), metadata[1].Type);
            Assert.IsTrue(metadata.All(p => !p.Body.HasSetter && p.Modifiers.HasFlag(MethodSignatureModifiers.Public)));
            StringAssert.Contains("return this.GetStatusMonitorModel()?.Statistics?.Succeeded;", ((MethodPropertyBody)metadata[1].Body).Getter!.ToDisplayString());
            StringAssert.Contains("IsCollectionDefined(value)", ((MethodPropertyBody)metadata[2].Body).Getter!.ToDisplayString());

            var getModel = operation.Methods.Single(m => m.Signature.Name == "GetStatusMonitorModel").BodyStatements!.ToDisplayString();
            StringAssert.Contains("object.ReferenceEquals(cache.Item1, response)", getModel);
            StringAssert.Contains("global::System.ClientModel.Primitives.ModelReaderWriter.Read<global::Samples.Models.JobStatus>(response.Content", getModel);
            StringAssert.Contains("catch (global::System.Exception)", getModel);
            Assert.IsFalse(operation.Methods.Any(m => m.Signature.Name.Contains("Rehydrat") && m.Signature.Name != "GetRehydrationToken"));
            var waits = operation.Methods.Where(m => m.Signature.Name.StartsWith("WaitForCompletion")).ToArray();
            Assert.AreEqual(hasResult ? 12 : 6, waits.Length);
            Assert.IsTrue(waits.All(m => m.BodyExpression!.ToDisplayString().StartsWith($"_operation.{m.Signature.Name}(")));
        }

        [Test]
        public async Task StatusMetadataOperationCanBeRenamedAndMadePublic()
        {
            var (_, inputClient, models) = CreateStatusMetadataInput(hasResult: true);
            var plugin = await MockHelpers.LoadMockGeneratorAsync(clients: () => [inputClient], inputModels: () => models,
                compilation: () => Helpers.GetCompilationFromDirectoryAsync());
            var output = plugin.Object.OutputLibrary;
            new TestLroVisitor().InvokeVisitLibrary(output);
            var client = output.TypeProviders.OfType<ClientProvider>().Single();
            var operation = output.TypeProviders.OfType<LroOperationProvider>().Single();

            Assert.AreEqual("JobOperation", operation.Type.Name);
            Assert.IsTrue(operation.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public));
            foreach (var method in client.Methods.OfType<ScmMethodProvider>().Where(m => m.Signature.Name.StartsWith("StartJob")))
            {
                var returnType = method.Signature.ReturnType!;
                if (method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async))
                {
                    returnType = returnType.Arguments[0];
                }
                Assert.AreEqual(method.Kind == ScmMethodKind.Protocol ? "Operation" : "JobOperation", returnType.Name);
            }
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