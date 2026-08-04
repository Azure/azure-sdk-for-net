// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ClientModel;
using System.ClientModel.Primitives;
using System;
using System.Diagnostics.CodeAnalysis;
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
    internal class UnbrandedLroVisitor : ScmLibraryVisitor
    {
        private static readonly CSharpType OperationResultType = new(typeof(OperationResult));
        private readonly Dictionary<ClientProvider, List<MethodProvider>> _compatibilityMethods = [];

        protected override TypeProvider? PostVisitType(TypeProvider type)
        {
            if (type is ClientProvider client &&
                _compatibilityMethods.TryGetValue(client, out List<MethodProvider>? methods))
            {
                client.Update(methods: [.. client.Methods, .. methods]);
            }

            return base.PostVisitType(type);
        }

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (IsLroMethod(method))
            {
                if (method.Kind == ScmMethodKind.Protocol && RequiresCompatibilityMethod(method))
                {
                    AddCompatibilityMethod(method);
                }

                UpdateMethodSignature(method);
            }

            return method;
        }

        private void AddCompatibilityMethod(ScmMethodProvider method)
        {
            MethodSignature original = method.Signature;
            bool isAsync = original.Modifiers.HasFlag(MethodSignatureModifiers.Async);
            MethodSignature signature = new(
                original.Name,
                original.Description,
                original.Modifiers & ~MethodSignatureModifiers.Async,
                original.ReturnType,
                original.ReturnDescription,
                original.Parameters,
                original.Attributes,
                original.GenericArguments,
                original.GenericParameterConstraints,
                original.ExplicitInterface,
                original.NonDocumentComment);

            ValueExpression operation = This.Invoke(
                original.Name,
                [Literal(false), .. original.Parameters]);
            MethodProvider compatibilityMethod = new(
                signature,
                Return(Static(typeof(OperationResultHelpers)).Invoke(
                    isAsync ? nameof(OperationResultHelpers.ToClientResultAsync) : nameof(OperationResultHelpers.ToClientResult),
                    operation)),
                method.EnclosingType,
                method.XmlDocs);

            var client = (ClientProvider)method.EnclosingType;
            if (!_compatibilityMethods.TryGetValue(client, out List<MethodProvider>? methods))
            {
                methods = [];
                _compatibilityMethods.Add(client, methods);
            }
            methods.Add(compatibilityMethod);
        }

        private static bool IsLroMethod(ScmMethodProvider method) =>
            method is { ServiceMethod: InputLongRunningServiceMethod, EnclosingType: ClientProvider };

        private static bool RequiresCompatibilityMethod(ScmMethodProvider method)
        {
            var client = (ClientProvider)method.EnclosingType;
            return client.LastContractView?.Methods.Any(previous =>
                MethodSignature.MethodSignatureComparer.Equals(previous.Signature, method.Signature)) == true;
        }

        private static void UpdateMethodSignature(ScmMethodProvider method)
        {
            var isAsync = method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async);
            List<ParameterProvider> parameters =
            [
                new(
                    "waitUntilCompleted",
                    FormattableStringFactory.Create(
                        "Whether the method should wait until the long-running operation has completed on the service."),
                    typeof(bool)),
                .. method.Signature.Parameters
            ];

            method.Signature.Update(
                parameters: parameters,
                returnType: isAsync
                    ? new CSharpType(typeof(Task<>), OperationResultType)
                    : OperationResultType,
                attributes:
                [
                    .. method.Signature.Attributes,
                    new AttributeStatement(typeof(ExperimentalAttribute), Literal("SCME0006"))
                ]);

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
