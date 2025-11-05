// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Generator.Extensions;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.ClientModel.Snippets;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    internal class LroVisitor : ScmLibraryVisitor
    {
        private const string FromLroResponseMethodName = "FromLroResponse";

        protected override ScmMethodProviderCollection? Visit(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods)
        {
            if (serviceMethod is InputLongRunningServiceMethod { Response.Type: InputModelType responseModel } lroServiceMethod)
            {
                AddFromLroResponseMethod(responseModel, lroServiceMethod, client);
            }

            return methods;
        }

        private static void AddFromLroResponseMethod(
            InputModelType responseModel,
            InputLongRunningServiceMethod lroServiceMethod,
            ClientProvider client)
        {
            var model = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            if (model == null)
            {
                return;
            }

            var resultSegment = lroServiceMethod.LongRunningServiceMetadata.ResultPath;
            if (string.IsNullOrEmpty(resultSegment))
            {
                return;
            }

            var serializationProvider = model.SerializationProviders[0];

            // Check if FromLroResponse method already exists with matching signature
            var existingMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == FromLroResponseMethodName &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Static) &&
                                     m.Signature.ReturnType?.Equals(model.Type) == true &&
                                     m.Signature.Parameters.Count == 1 &&
                                     m.Signature.Parameters[0].Type.Equals(typeof(Response)));
            if (existingMethod != null)
            {
                return;
            }

            // Create the FromLroResponse method
            var responseParameter = new ParameterProvider("response", $"The response to deserialize.", typeof(Response));
            var methodSignature = new MethodSignature(
                FromLroResponseMethodName,
                $"Converts a response to a {model.Type.Name} using the LRO result path.",
                MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
                model.Type,
                null,
                [responseParameter]);

            // Build method body similar to explicit operator but with result path
            var modelSerializationExtensions = Static(new ModelSerializationExtensionsDefinition().Type);
            var statements = new MethodBodyStatement[]
            {
                UsingDeclare("document", typeof(JsonDocument),
                    Static<JsonDocument>().Invoke(nameof(JsonDocument.Parse),
                        [responseParameter.Property("Content"),
                         modelSerializationExtensions.Property("JsonDocumentOptions")]),
                    out var documentVariable),
                Return(Static(model.Type).Invoke(
                    $"Deserialize{model.Type.Name}",
                    [
                        documentVariable.Property("RootElement").Invoke("GetProperty", Literal(resultSegment)),
                        modelSerializationExtensions.Property("WireOptions")
                    ]))
            };

            var fromLroResponseMethod = new MethodProvider(methodSignature, statements, serializationProvider);

            // Add the method to the serialization provider
            serializationProvider.Update(methods: [..serializationProvider.Methods, fromLroResponseMethod]);

            // Check if we should remove the explicit operator
            // Only remove it if the model is ONLY used in LRO contexts across all clients
            bool isOnlyUsedInLro = IsModelOnlyUsedInLro(responseModel);
            if (isOnlyUsedInLro)
            {
                var explicitOperator = serializationProvider.Methods
                    .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                         m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));

                if (explicitOperator != null)
                {
                    var updatedMethods = serializationProvider.Methods.Except([explicitOperator]).ToList();
                    serializationProvider.Update(methods: updatedMethods);
                }
            }
        }

        private static bool IsModelOnlyUsedInLro(InputModelType responseModel)
        {
            // Check all clients in the output library to see if any non-LRO method returns this model type
            var outputLibrary = AzureClientGenerator.Instance.OutputLibrary;
            var allClients = outputLibrary.TypeProviders.OfType<ClientProvider>();

            foreach (var client in allClients)
            {
                // Get all non-null service methods from the client
                var inputMethods = client.Methods.OfType<ScmMethodProvider>()
                    .Where(m => m.ServiceMethod != null)
                    .Select(m => m.ServiceMethod);

                foreach (var method in inputMethods)
                {
                    // Skip LRO methods
                    if (method is InputLongRunningServiceMethod)
                    {
                        continue;
                    }

                    // Check if this non-LRO method returns the response model
                    if (method!.Response?.Type == responseModel)
                    {
                        return false; // Model is used in non-LRO context, keep the explicit operator
                    }
                }
            }

            return true; // Model is only used in LRO contexts
        }

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (method.IsLroMethod())
            {
                UpdateMethodSignature(method);
            }

            return method;
        }

        private static void UpdateMethodSignature(ScmMethodProvider method)
        {
            var responseType = method.ServiceMethod!.Response.Type;

            var returnType = (responseType, method.Kind) switch
            {
                (null, _) => typeof(Operation),
                (not null, ScmMethodKind.Protocol) => new CSharpType(typeof(Operation<>), typeof(BinaryData)),
                _ => new CSharpType(typeof(Operation<>), AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(responseType)!),
            };
            var isAsync = method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async);

            // Update the method signature
            var parameters = new List<ParameterProvider>(method.Signature.Parameters);
            parameters.Insert(0, new ParameterProvider(
                name: "waitUntil",
                type: typeof(WaitUntil),
                description: FormattableStringFactory.Create(
                    "<see cref=\"WaitUntil.Completed\"/> if the method should wait to return until the long-running operation " +
                    "has completed on the service; <see cref=\"WaitUntil.Started\"/> if it should return after starting the operation. " +
                    "For more information on long-running operations, please see " +
                    "<see href=\"https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md\"> " +
                    "Azure.Core Long-Running Operation samples</see>.")));

            method.Signature.Update(
                parameters: parameters,
                returnType: isAsync
                    ? new CSharpType(typeof(Task<>), returnType!)
                    : returnType);

            // Needed to update the XML docs
            method.Update(signature: method.Signature);
        }

        protected override MethodBodyStatement? VisitExpressionStatement(
            ExpressionStatement expressionStatement,
            MethodProvider method)
        {
            if (method is ScmMethodProvider scmMethod && scmMethod.IsLroMethod() && scmMethod.Kind != ScmMethodKind.Protocol)
            {
                return UpdateConvenienceMethod(expressionStatement, scmMethod);
            }

            return expressionStatement;
        }

        private static MethodBodyStatement? UpdateConvenienceMethod(
            ExpressionStatement expressionStatement,
            ScmMethodProvider scmMethod)
        {
            var expression = expressionStatement.Expression;
            var serviceMethod = scmMethod.ServiceMethod!;
            switch (expression)
            {
                case AssignmentExpression { Value: AzureClientResponseProvider } assignmentExpression:
                {
                    var resultVariable = (assignmentExpression.Variable as DeclarationExpression)?.Variable!;
                    if (serviceMethod.Response.Type != null)
                    {
                        resultVariable.Update(type: new CSharpType(typeof(Operation<>), typeof(BinaryData)));
                    }
                    else
                    {
                        // Return the result of the protocol method directly for convenience methods having no response body
                        return new KeywordExpression("return", assignmentExpression.Value).Terminate();
                    }

                    break;
                }
                // Remove the extra return statement for convenience methods having no response body
                case KeywordExpression { Keyword: "return", Expression: InvokeMethodExpression { MethodName: "FromValue" } } when serviceMethod.Response.Type == null:
                    return null;
                case KeywordExpression { Keyword: "return", Expression: InvokeMethodExpression { MethodName: "FromValue" } invokeMethodExpression }:
                {
                    var response = new VariableExpression(typeof(Response), "response");
                    var responseType = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(serviceMethod.Response.Type)!;
                    var client = (ClientProvider)scmMethod.EnclosingType;
                    var diagnosticsProperty = client.GetClientDiagnosticProperty();
                    var scopeName = scmMethod.GetScopeName();

                    // Use FromLroResponse static method instead of explicit operator cast
                    var responseModel = serviceMethod.Response.Type as InputModelType;
                    var lroServiceMethod = scmMethod.ServiceMethod as InputLongRunningServiceMethod;
                    var resultSegment = lroServiceMethod?.LongRunningServiceMetadata.ResultPath;

                    ValueExpression conversionExpression;
                    if (!string.IsNullOrEmpty(resultSegment) && responseModel != null)
                    {
                        // Call the FromLroResponse static method
                        conversionExpression = Static(responseType).Invoke(FromLroResponseMethodName, [response]);
                    }
                    else
                    {
                        // Fall back to explicit operator cast for models without result path
                        conversionExpression = new CastExpression(response, responseType);
                    }

                    invokeMethodExpression.Update(
                        instanceReference: Static(typeof(ProtocolOperationHelpers)),
                        methodName: "Convert",
                        arguments:
                        [
                            (invokeMethodExpression.Arguments[0] as CastExpression)!.Inner,
                            new FuncExpression([response.Declaration], conversionExpression),
                            diagnosticsProperty,
                            Literal(scopeName),
                        ]);
                    break;
                }
            }

            return expressionStatement;
        }

        protected override InvokeMethodExpression? VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
        {
            if (method is ScmMethodProvider scmMethod && scmMethod.IsLroMethod())
            {
                if (scmMethod.Kind == ScmMethodKind.Protocol)
                {
                    return UpdateProcessCall(expression, scmMethod);
                }

                return UpdateProtocolMethodCall(expression, scmMethod);
            }

            return expression;
        }

        private static InvokeMethodExpression UpdateProcessCall(
            InvokeMethodExpression expression,
            ScmMethodProvider scmMethod)
        {
            // Update the process call to call the operation helper method
            if (expression.MethodName?.StartsWith("Process") == true)
            {
                var client = (ClientProvider)scmMethod.EnclosingType;
                var serviceMethod = scmMethod.ServiceMethod as InputLongRunningServiceMethod;
                var finalStateVia = (OperationFinalStateVia) serviceMethod!.LongRunningServiceMetadata.FinalStateVia;
                var finalStateEnumName = Enum.GetName(typeof(OperationFinalStateVia), finalStateVia);

                expression.Update(
                    instanceReference: Static(typeof(ProtocolOperationHelpers)),
                    arguments:
                    [
                        client.GetPipelineProperty(),
                        expression.Arguments[0],
                        client.GetClientDiagnosticProperty(),
                        Literal(scmMethod.GetScopeName()),
                        Static(typeof(OperationFinalStateVia)).Property(finalStateEnumName!),
                        expression.Arguments[1],
                        scmMethod.Signature.Parameters[0]
                    ]);
            }

            return expression;
        }

        private static InvokeMethodExpression UpdateProtocolMethodCall(
            InvokeMethodExpression expression,
            ScmMethodProvider scmMethod)
        {
            if (scmMethod.Signature.Name == expression.MethodName || scmMethod.Signature.Name == expression.MethodSignature?.Name)
            {
                expression.Update(
                    arguments:
                    [
                        scmMethod.Signature.Parameters[0],
                        ..expression.Arguments,
                    ]);
            }

            return expression;
        }
    }
}