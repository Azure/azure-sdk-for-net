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
        private readonly Dictionary<CSharpType, InputConstant> _apiVersionOverrides = new();

        protected override ClientProvider? Visit(InputClient client, ClientProvider? clientProvider)
        {
            if (clientProvider != null && client.Parent != null &&
                client.Parameters.FirstOrDefault(p => p.IsApiVersion && p.DefaultValue?.Value != null)
                    ?.DefaultValue is { } defaultValue)
            {
                _apiVersionOverrides[clientProvider.Type] = defaultValue;
            }

            return clientProvider;
        }

        protected override ValueExpression? VisitKeywordExpression(KeywordExpression expression, MethodProvider method)
        {
            if (expression is not { Keyword: "return", Expression: { } value } ||
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
