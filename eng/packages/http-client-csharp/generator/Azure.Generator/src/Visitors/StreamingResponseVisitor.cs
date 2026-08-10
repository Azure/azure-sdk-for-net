// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
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

#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        private static bool IsStreamingResponseType(CSharpType? type)
            => UnwrapTask(type) is { IsFrameworkType: true, IsGenericType: true } streamingType &&
               streamingType.GetGenericTypeDefinition().Equals(typeof(AsyncStreamingClientResult<>));
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.

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
    }
}
