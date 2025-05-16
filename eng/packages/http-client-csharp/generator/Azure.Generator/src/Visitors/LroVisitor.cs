// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Primitives;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    internal class LroVisitor : ScmLibraryVisitor
    {
        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (method.IsLroMethod())
            {
                var responseType = method.ServiceMethod!.Response.Type;

                // No convenience method is needed for an LRO method that doesn't return a response type
                if (responseType == null && !method.IsProtocolMethod)
                {
                    return null;
                }

                var returnType = (responseType, method.IsProtocolMethod) switch
                {
                    (null, true) => typeof(Operation),
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

                if (method.IsProtocolMethod && responseType == null)
                {
                    // Make the requestContext parameter optional as there is no corresponding convenience method to worry about ambiguous calls
                    parameters[^1] = KnownAzureParameters.OptionalRequestContext;
                }
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
                (expression.Variable as DeclarationExpression)?.Variable.Update(
                    type: new CSharpType(typeof(Operation), typeof(BinaryData)));
            }

            return expression;
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
                var serviceMethod = scmMethod.ServiceMethod!;
                if (scmMethod.IsProtocolMethod && serviceMethod.Response.Type == null)
                {
                    // Make the requestContext parameter optional as there is no corresponding convenience method to worry about ambiguous calls
                    // update any args to use the optional request context
                    var newArgs = new List<ValueExpression>(expression.Arguments.Count);
                    foreach (var arg in expression.Arguments)
                    {
                        if (arg is VariableExpression variableExpression && variableExpression.Type.Equals(typeof(RequestContext)))
                        {
                            newArgs.Add(KnownAzureParameters.OptionalRequestContext);
                        }
                        else
                        {
                            newArgs.Add(arg);
                        }
                    }
                    expression.Update(arguments: newArgs);
                }

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
                            Static(typeof(OperationFinalStateVia)).Property("OriginalUri"),
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

                if (expression.MethodName == "FromValue")
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