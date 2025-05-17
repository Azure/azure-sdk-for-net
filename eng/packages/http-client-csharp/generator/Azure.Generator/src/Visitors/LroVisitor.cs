// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
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
                var model = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
                if (model == null)
                {
                    return methods;
                }

                // Update the explicit cast from response in LRO models to use the result path
                var explicitOperator = model.SerializationProviders[0].Methods
                    .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                         m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));

                var resultSegment = lroServiceMethod.LongRunningServiceMetadata.ResultPath;
                if (explicitOperator == null || string.IsNullOrEmpty(resultSegment))
                {
                    return methods;
                }

                foreach (var statement in explicitOperator.BodyStatements!)
                {
                    if (statement is ExpressionStatement { Expression: KeywordExpression
                            { Keyword: "return", Expression: InvokeMethodExpression invokeMethodExpression } })
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

            return methods;
        }
        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (method.IsLroMethod())
            {
                var responseType = method.ServiceMethod!.Response.Type;

                var returnType = (responseType, method.IsProtocolMethod) switch
                {
                    (null, _) => typeof(Operation),
                    (not null, true) => new CSharpType(typeof(Operation), typeof(BinaryData)),
                    _ => new CSharpType(typeof(Operation<>), AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(responseType!)!),
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

            return method;
        }

        protected override ValueExpression? VisitAssignmentExpression(AssignmentExpression expression,
            MethodProvider method)
        {
            if (method is ScmMethodProvider scmMethod && scmMethod.IsLroMethod() && !scmMethod.IsProtocolMethod &&
                expression.Value is AzureClientResponseProvider)
            {
                var resultVariable = (expression.Variable as DeclarationExpression)?.Variable!;
                if (scmMethod.ServiceMethod!.Response.Type != null)
                {
                    resultVariable.Update(type: new CSharpType(typeof(Operation), typeof(BinaryData)));
                }
                else
                {
                    // Return the result of the protocol method directly
                    return new KeywordExpression("return", expression.Value);
                }
            }

            return expression;
        }

        protected override MethodBodyStatement? VisitExpressionStatement(ExpressionStatement expressionStatement,
            MethodProvider method)
        {
            // Delete the extraneous return statement for convenience methods that return an Operation.
            // This is because we are already updating the previous statement that calls the protocol method to return an Operation directly.
            if (method is ScmMethodProvider scmMethodProvider && scmMethodProvider.IsLroMethod() &&
                scmMethodProvider.ServiceMethod!.Response.Type == null && !scmMethodProvider.IsProtocolMethod &&
                expressionStatement.Expression is KeywordExpression
                {
                    Keyword: "return", Expression: InvokeMethodExpression { MethodName: "FromValue" }
                })
            {
                return null;
            }
            return expressionStatement;
        }

        protected override ValueExpression? VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
        {
            if (method is ScmMethodProvider scmMethod && scmMethod.IsLroMethod())
            {
                var waitUntil = scmMethod.Signature.Parameters[0];
                var client = (ClientProvider)scmMethod.EnclosingType;
                var pipelineProperty = client.GetPipelineProperty();
                var diagnosticsProperty = client.GetClientDiagnosticProperty();
                var scopeName = scmMethod.GetScopeName();
                var serviceMethod = scmMethod.ServiceMethod as InputLongRunningServiceMethod;
                var finalStateVia = (OperationFinalStateVia) serviceMethod!.LongRunningServiceMetadata.FinalStateVia;
                var finalStateEnumName = Enum.GetName(typeof(OperationFinalStateVia), finalStateVia);
                // Update the process call to call the operation helper method
                if (expression.MethodName?.StartsWith("Process") == true)
                {
                    expression.Update(
                        instanceReference: Static(typeof(ProtocolOperationHelpers)),
                        arguments:
                        [
                            pipelineProperty,
                            expression.Arguments[0],
                            diagnosticsProperty,
                            Literal(scopeName),
                            Static(typeof(OperationFinalStateVia)).Property(finalStateEnumName!),
                            expression.Arguments[1],
                            waitUntil
                        ]);
                    return expression;
                }

                if (!scmMethod.IsProtocolMethod && (scmMethod.Signature.Name == expression.MethodName || scmMethod.Signature.Name == expression.MethodSignature?.Name))
                {
                    // Update the call to the protocol method to include the waitUntil argument
                    expression.Update(
                        arguments:
                        [
                            waitUntil,
                            ..expression.Arguments,
                        ]);
                    return expression;
                }

                if (expression.MethodName == "FromValue" && serviceMethod.Response.Type != null)
                {
                    var response = new VariableExpression(typeof(Response), "response");
                    var responseType = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(serviceMethod.Response.Type!)!;
                    expression.Update(
                        instanceReference: Static(typeof(ProtocolOperationHelpers)),
                        methodName: "Convert",
                        arguments:
                        [
                            (expression.Arguments[0] as CastExpression)!.Inner,
                            new FuncExpression([response.Declaration], new CastExpression(response, responseType)),
                            diagnosticsProperty,
                            Literal(scopeName),
                        ]);
                }
            }

            return expression;
        }
    }
}