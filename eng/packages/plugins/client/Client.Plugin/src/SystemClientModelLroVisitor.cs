// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ClientModel.Primitives;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Client.Plugin
{
    /// <summary>
    /// Updates long-running methods to use the System.ClientModel LRO abstraction.
    /// </summary>
    internal class SystemClientModelLroVisitor : ScmLibraryVisitor
    {
        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (IsLroMethod(method))
            {
                UpdateMethodSignature(method);
            }

            return method;
        }

        private static bool IsLroMethod(ScmMethodProvider method) =>
            method is { ServiceMethod: InputLongRunningServiceMethod, EnclosingType: ClientProvider };

        private static void UpdateMethodSignature(ScmMethodProvider method)
        {
            var operationResultType = new CSharpType(typeof(OperationResult));
            var isAsync = method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async);
            var parameters = new List<ParameterProvider>(method.Signature.Parameters);
            parameters.Insert(0, new ParameterProvider(
                "waitUntilCompleted",
                FormattableStringFactory.Create(
                    "Whether the method should wait until the long-running operation has completed on the service."),
                typeof(bool)));

            method.Signature.Update(
                parameters: parameters,
                returnType: isAsync
                    ? new CSharpType(typeof(Task<>), operationResultType)
                    : operationResultType);

            method.Update(signature: method.Signature);
        }

        protected override MethodBodyStatement? VisitExpressionStatement(
            ExpressionStatement expressionStatement,
            MethodProvider method)
        {
            if (method is not ScmMethodProvider scmMethod || !IsLroMethod(scmMethod))
            {
                return expressionStatement;
            }

            if (scmMethod.Kind == ScmMethodKind.Protocol)
            {
                if (expressionStatement.Expression is KeywordExpression
                    {
                        Keyword: "return",
                        Expression: InvokeMethodExpression
                        {
                            MethodName: "FromResponse",
                            Arguments: [ValueExpression operation, ..]
                        }
                    })
                {
                    return Return(operation);
                }

                return expressionStatement;
            }

            switch (expressionStatement.Expression)
            {
                case AssignmentExpression { Value: ClientResponseApi } assignment:
                    if (assignment.Variable is DeclarationExpression declaration)
                    {
                        declaration.Variable.Update(type: typeof(OperationResult));
                    }
                    break;

                case KeywordExpression
                {
                    Keyword: "return",
                    Expression: InvokeMethodExpression
                    {
                        MethodName: "FromValue",
                        Arguments: [CastExpression castArgument, ..]
                    }
                }:
                    return Return(castArgument.Inner);
            }

            return expressionStatement;
        }

        protected override InvokeMethodExpression? VisitInvokeMethodExpression(
            InvokeMethodExpression expression,
            MethodProvider method)
        {
            if (method is not ScmMethodProvider scmMethod || !IsLroMethod(scmMethod))
            {
                return expression;
            }

            if (scmMethod.Kind == ScmMethodKind.Protocol)
            {
                return UpdateProcessCall(expression, scmMethod);
            }

            return UpdateProtocolMethodCall(expression, scmMethod);
        }

        private static InvokeMethodExpression UpdateProcessCall(
            InvokeMethodExpression expression,
            ScmMethodProvider method)
        {
            if (expression.MethodName?.StartsWith("ProcessMessage") != true)
            {
                return expression;
            }

            var client = (ClientProvider)method.EnclosingType;
            var serviceMethod = (InputLongRunningServiceMethod)method.ServiceMethod!;
            var finalStateVia = (OperationFinalStateVia)serviceMethod.LongRunningServiceMetadata.FinalStateVia;
            var finalStateViaName = Enum.GetName(typeof(OperationFinalStateVia), finalStateVia);
            var pipeline = client.CanonicalView.Properties
                .First(p => p.Type.Equals(typeof(ClientPipeline)));

            expression.Update(
                instanceReference: Static(typeof(OperationResultHelpers)),
                arguments:
                [
                    pipeline,
                    expression.Arguments[0],
                    expression.Arguments[1],
                    Static(typeof(OperationFinalStateVia)).Property(finalStateViaName!),
                    method.Signature.Parameters[0]
                ]);

            return expression;
        }

        private static InvokeMethodExpression UpdateProtocolMethodCall(
            InvokeMethodExpression expression,
            ScmMethodProvider method)
        {
            if (method.Signature.Name == expression.MethodName ||
                method.Signature.Name == expression.MethodSignature?.Name)
            {
                expression.Update(arguments: [method.Signature.Parameters[0], .. expression.Arguments]);
            }

            return expression;
        }
    }
}
