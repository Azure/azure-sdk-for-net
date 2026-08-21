// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ClientModel;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    internal class StreamingResponseVisitor : ScmLibraryVisitor
    {
        private readonly HashSet<ValueExpression> _processedStreamingResponses = new(ReferenceEqualityComparer.Instance);

        protected override MethodBodyStatement VisitStatements(MethodBodyStatements statements, MethodProvider method)
        {
            if (!IsStreamingResponseType(method.Signature.ReturnType))
            {
                return statements;
            }

            return AddPipelineProcessing(statements);
        }

        protected override TryExpression VisitTryExpression(TryExpression expression, MethodProvider method)
        {
            if (IsStreamingResponseType(method.Signature.ReturnType)
                && expression.Body is MethodBodyStatements statements)
            {
                expression.Update(AddPipelineProcessing(statements));
            }

            return base.VisitTryExpression(expression, method);
        }

        private MethodBodyStatements AddPipelineProcessing(MethodBodyStatements statements)
        {
            var updatedStatements = new List<MethodBodyStatement>(statements.Statements.Count + 1);
            foreach (MethodBodyStatement statement in statements.Statements)
            {
                if (TryGetStreamingResponse(statement, out ValueExpression response)
                    && _processedStreamingResponses.Add(response))
                {
                    updatedStatements.Add(new ExpressionStatement(response));
                }
                updatedStatements.Add(statement);
            }
            return new MethodBodyStatements(updatedStatements);
        }

        protected override ValueExpression? VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
        {
            if (expression.Arguments.Count > 0
                && IsStreamingResponseType(method.Signature.ReturnType)
                && FindAzureResponseMessage(expression.Arguments[0]) is { } message)
            {
                var arguments = expression.Arguments.ToList();
                arguments[0] = New.Instance<AzurePipelineResponse>(message);
                expression.Update(arguments: arguments);
                return expression;
            }

            return base.VisitInvokeMethodExpression(expression, method);
        }

        private static bool TryGetStreamingResponse(MethodBodyStatement statement, out ValueExpression response)
        {
            if (statement is ExpressionStatement
                {
                    Expression: KeywordExpression
                    {
                        Keyword: "return",
                        Expression: InvokeMethodExpression invocation
                    }
                }
                && invocation.Arguments.Count > 0
                && FindAzureResponseMessage(invocation.Arguments[0]) is not null)
            {
                response = invocation.Arguments[0];
                return true;
            }

            response = null!;
            return false;
        }

#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        private static bool IsStreamingResponseType(CSharpType? type)
            => UnwrapTask(type) is { IsFrameworkType: true, IsGenericType: true } streamingType &&
               streamingType.GetGenericTypeDefinition().Equals(typeof(AsyncStreamingClientResult<>));
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.

        private static ValueExpression? FindAzureResponseMessage(ValueExpression expression)
        {
            CSharpType? responseType = expression switch
            {
                ScopedApi api => api.Type,
                InvokeMethodExpression invocation => invocation.MethodSignature?.ReturnType,
                _ => null
            };

            return IsAzureResponseType(responseType) ? FindHttpMessage(expression) : null;
        }

        private static bool IsAzureResponseType(CSharpType? type)
            => UnwrapTask(type)?.Equals(typeof(Response)) == true;

        private static ValueExpression? FindHttpMessage(ValueExpression expression)
        {
            if (expression is ScopedApi api)
            {
                return FindHttpMessage(api.Original);
            }

            if (expression is InvokeMethodExpression invocation)
            {
                return invocation.Arguments.FirstOrDefault(IsHttpMessage);
            }

            return null;
        }

        private static bool IsHttpMessage(ValueExpression expression)
            => expression switch
            {
                ScopedApi api => api.Type.Equals(typeof(HttpMessage)),
                VariableExpression variable => variable.Type.Equals(typeof(HttpMessage)),
                _ => false
            };

        private static CSharpType? UnwrapTask(CSharpType? type)
            => type is { IsFrameworkType: true, Arguments.Count: 1 } &&
               (type.FrameworkType == typeof(Task<>) || type.FrameworkType == typeof(ValueTask<>))
                ? type.Arguments[0]
                : type;
    }
}
