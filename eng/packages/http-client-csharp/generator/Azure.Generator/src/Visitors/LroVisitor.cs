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
        protected override ScmMethodProviderCollection? Visit(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods)
        {
            if (serviceMethod is InputLongRunningServiceMethod { Response.Type: InputModelType responseModel } lroServiceMethod)
            {
                UpdateExplicitOperatorMethod(responseModel, lroServiceMethod);
            }

            return methods;
        }

        private static void UpdateExplicitOperatorMethod(
            InputModelType responseModel,
            InputLongRunningServiceMethod lroServiceMethod)
        {
            var model = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            if (model == null)
            {
                return;
            }

            // Update the explicit cast from response in LRO models to use the result path
            var explicitOperator = model.SerializationProviders[0].Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));

            var resultSegment = lroServiceMethod.LongRunningServiceMetadata.ResultPath;
            if (explicitOperator == null || string.IsNullOrEmpty(resultSegment))
            {
                return;
            }

            foreach (var statement in explicitOperator.BodyStatements!)
            {
                if (statement is ExpressionStatement
                    {
                        Expression: KeywordExpression
                        {
                            Keyword: "return", Expression: InvokeMethodExpression invokeMethodExpression
                        }
                    })
                {
                    if (invokeMethodExpression.Arguments.Count > 0 && invokeMethodExpression.Arguments[0] is ScopedApi<JsonElement>)
                    {
                        invokeMethodExpression.Update(
                            arguments:
                            [
                                invokeMethodExpression.Arguments[0]
                                    .Invoke("GetProperty", Literal(resultSegment)),
                                ..invokeMethodExpression.Arguments.Skip(1)
                            ]);
                    }
                }
            }
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

            var returnType = (responseType, method.IsProtocolMethod) switch
            {
                (null, _) => typeof(Operation),
                (not null, true) => new CSharpType(typeof(Operation<>), typeof(BinaryData)),
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
            if (method is ScmMethodProvider scmMethod && scmMethod.IsLroMethod() && !scmMethod.IsProtocolMethod)
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
                    invokeMethodExpression.Update(
                        instanceReference: Static(typeof(ProtocolOperationHelpers)),
                        methodName: "Convert",
                        arguments:
                        [
                            (invokeMethodExpression.Arguments[0] as CastExpression)!.Inner,
                            new FuncExpression([response.Declaration], new CastExpression(response, responseType)),
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
                if (scmMethod.IsProtocolMethod)
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