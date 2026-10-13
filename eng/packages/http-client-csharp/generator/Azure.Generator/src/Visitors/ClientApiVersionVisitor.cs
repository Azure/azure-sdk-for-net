// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Applies API-version overrides when constructing subclients.
    /// </summary>
    internal class ClientApiVersionVisitor : ScmLibraryVisitor
    {
        private const string OverrideApiVersionDecoratorName = "Azure.Core.Legacy.@overrideApiVersion";
        private Dictionary<CSharpType, InputConstant>? _apiVersionOverrides;

        protected override ClientProvider? Visit(InputClient client, ClientProvider? clientProvider)
        {
            if (clientProvider != null && client.Parent != null &&
                client.Decorators.Any(d => d.Name == OverrideApiVersionDecoratorName) &&
                client.Parameters.FirstOrDefault(p => p.IsApiVersion && p.DefaultValue?.Value != null)
                    ?.DefaultValue is { } defaultValue)
            {
                (_apiVersionOverrides ??= new()).TryAdd(clientProvider.Type, defaultValue);
            }

            return clientProvider;
        }

        // Rewrites subclient factory returns from new SubClient(..., _apiVersion) to
        // new SubClient(..., "<override>") using the subclient's API-version default.
        // The surrounding Volatile.Read/Interlocked.CompareExchange caching expression is preserved.
        protected override ValueExpression? VisitKeywordExpression(KeywordExpression expression, MethodProvider method)
        {
            if (_apiVersionOverrides == null ||
                expression is not { Keyword: "return", Expression: { } value } ||
                method.EnclosingType is not ClientProvider client ||
                method.Signature.ReturnType is not { } returnType ||
                !_apiVersionOverrides.TryGetValue(returnType, out var defaultValue) ||
                !client.SubClients.Any(c => c.Type.Equals(returnType)))
            {
                return expression;
            }

            var apiVersionFields = client.Fields.Where(f => f.WireInfo?.IsApiVersion == true)
                .Select(f => f.Name).ToHashSet();
            expression.Update(expression.Keyword, ReplaceApiVersion(value, returnType, apiVersionFields, Literal(defaultValue.Value)));
            return expression;
        }

        private static ValueExpression ReplaceApiVersion(
            ValueExpression expression,
            CSharpType subClientType,
            HashSet<string> apiVersionFields,
            ValueExpression apiVersion)
        {
            switch (expression)
            {
                case NewInstanceExpression instance when subClientType.Equals(instance.Type):
                    return instance with
                    {
                        Parameters = instance.Parameters.Select(p =>
                            p is MemberExpression member && apiVersionFields.Contains(member.MemberName) ? apiVersion : p).ToArray()
                    };
                case BinaryOperatorExpression binary:
                    return binary with
                    {
                        Left = ReplaceApiVersion(binary.Left, subClientType, apiVersionFields, apiVersion),
                        Right = ReplaceApiVersion(binary.Right, subClientType, apiVersionFields, apiVersion)
                    };
                case InvokeMethodExpression invocation:
                    invocation.Update(arguments: invocation.Arguments.Select(a =>
                        ReplaceApiVersion(a, subClientType, apiVersionFields, apiVersion)).ToArray());
                    return invocation;
                default:
                    return expression;
            }
        }
    }
}
