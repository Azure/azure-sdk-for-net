// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    internal class StreamingResponseVisitor : ScmLibraryVisitor
    {
        private static readonly TypeProvider s_asyncStreamingClientResultProvider = new AsyncStreamingClientResultProvider();

        protected override ValueExpression? VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
        {
            if (expression.Arguments.Count > 0
                && IsStreamingResponseType(method.Signature.ReturnType)
                && IsAzureResponse(expression.Arguments[0]))
            {
                var arguments = expression.Arguments.ToList();
                arguments[0] = New.Instance<AzurePipelineResponse>(arguments[0]);
                expression.Update(arguments: arguments);
                return expression;
            }

            return base.VisitInvokeMethodExpression(expression, method);
        }

        private static bool IsStreamingResponseType(CSharpType? type)
        {
            var streamingType = UnwrapTask(type);
            var expectedType = s_asyncStreamingClientResultProvider.Type;
            return streamingType is { Arguments.Count: 1 } &&
                streamingType.Name == expectedType.Name &&
                streamingType.Namespace == expectedType.Namespace;
        }

        private static bool IsAzureResponse(ValueExpression expression)
            => expression switch
            {
                ScopedApi api => IsAzureResponseType(api.Type),
                VariableExpression variable => IsAzureResponseType(variable.Type),
                InvokeMethodExpression invocation => IsAzureResponseType(invocation.MethodSignature?.ReturnType),
                _ => false
            };

        private static bool IsAzureResponseType(CSharpType? type)
            => UnwrapTask(type)?.Equals(typeof(Response)) == true;

        private static CSharpType? UnwrapTask(CSharpType? type)
            => type is { IsFrameworkType: true, Arguments.Count: 1 } &&
               (type.FrameworkType == typeof(Task<>) || type.FrameworkType == typeof(ValueTask<>))
                ? type.Arguments[0]
                : type;

        private sealed class AsyncStreamingClientResultProvider : TypeProvider
        {
            protected override string BuildName() => "AsyncStreamingClientResult";
            protected override string BuildNamespace() => "System.ClientModel";
            protected override string BuildRelativeFilePath() => throw new System.InvalidOperationException("This type should not be written.");
        }
    }
}
