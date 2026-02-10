// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that modifies CreateNext...Request methods to properly handle relative nextLink URLs
    /// by resetting the endpoint first and then appending the nextLink.
    /// </summary>
    internal class NextLinkEndpointVisitor : ScmLibraryVisitor
    {
        private readonly HashSet<ScmMethodProvider> _visited = [];

        protected override ScmMethodProvider? VisitCreateRequestMethod(
            InputServiceMethod serviceMethod,
            RestClientProvider enclosingType,
            ScmMethodProvider? createRequestMethodProvider)
        {
            if (createRequestMethodProvider != null &&
                _visited.Add(createRequestMethodProvider) &&
                IsCreateNextLinkRequestMethod(createRequestMethodProvider))
            {
                UpdateCreateNextLinkRequestMethod(createRequestMethodProvider, enclosingType);
            }

            return createRequestMethodProvider;
        }

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (_visited.Add(method) && IsCreateNextLinkRequestMethod(method))
            {
                var restClient = method.EnclosingType as RestClientProvider;
                if (restClient != null)
                {
                    UpdateCreateNextLinkRequestMethod(method, restClient);
                }
            }

            return method;
        }

        private static bool IsCreateNextLinkRequestMethod(ScmMethodProvider method)
        {
            // CreateNext...Request methods have a Uri parameter named "nextLink" or "nextPage"
            return method.Signature.Name.StartsWith("CreateNext", StringComparison.Ordinal) &&
                   method.Signature.Parameters.Any(p => p.Type.FrameworkType == typeof(Uri) &&
                                                        (p.Name.Equals("nextLink", StringComparison.OrdinalIgnoreCase) ||
                                                         p.Name.Equals("nextPage", StringComparison.OrdinalIgnoreCase)));
        }

        private static void UpdateCreateNextLinkRequestMethod(ScmMethodProvider method, RestClientProvider enclosingType)
        {
            if (method.BodyStatements == null)
            {
                return;
            }

            // Find the nextLink/nextPage parameter
            var nextLinkParam = method.Signature.Parameters.FirstOrDefault(p =>
                p.Type.FrameworkType == typeof(Uri) &&
                (p.Name.Equals("nextLink", StringComparison.OrdinalIgnoreCase) ||
                 p.Name.Equals("nextPage", StringComparison.OrdinalIgnoreCase)));

            if (nextLinkParam == null)
            {
                return;
            }

            var updatedStatements = new List<MethodBodyStatement>();
            bool uriBuilderFound = false;
            VariableExpression? uriBuilderVariable = null;

            foreach (var statement in method.BodyStatements)
            {
                // Check if this is a URI builder declaration: RawRequestUriBuilder uri = new RawRequestUriBuilder();
                if (!uriBuilderFound &&
                    statement is ExpressionStatement { Expression: AssignmentExpression { Variable: DeclarationExpression declaration } } &&
                    declaration.Variable.Type.Name == "RawRequestUriBuilder")
                {
                    // Found the URI builder declaration
                    uriBuilderVariable = declaration.Variable;
                    uriBuilderFound = true;
                    updatedStatements.Add(statement);
                }
                else if (uriBuilderFound && uriBuilderVariable != null &&
                         statement is ExpressionStatement exprStatement &&
                         IsUriResetWithNextLinkCall(exprStatement, uriBuilderVariable, nextLinkParam))
                {
                    // Replace uri.Reset(nextPage) with:
                    // uri.Reset(_endpoint);
                    // uri.AppendRawNextLink(nextPage.AbsoluteUri, false);

                    var endpointField = enclosingType.Fields.FirstOrDefault(f => f.Name == "_endpoint");
                    if (endpointField != null)
                    {
                        // uri.Reset(_endpoint);
                        updatedStatements.Add(uriBuilderVariable.Invoke("Reset", [endpointField]).Terminate());

                        // uri.AppendRawNextLink(nextPage.AbsoluteUri, false);
                        updatedStatements.Add(uriBuilderVariable.Invoke("AppendRawNextLink",
                            [nextLinkParam.Property("AbsoluteUri"), Literal(false)]).Terminate());
                    }
                    else
                    {
                        // If we can't find _endpoint field, keep the original statement
                        updatedStatements.Add(statement);
                    }
                }
                else
                {
                    updatedStatements.Add(statement);
                }
            }

            if (uriBuilderFound)
            {
                method.Update(bodyStatements: updatedStatements);
            }
        }

        private static bool IsUriResetWithNextLinkCall(
            ExpressionStatement statement,
            VariableExpression uriBuilderVariable,
            ParameterProvider nextLinkParam)
        {
            if (statement.Expression is not InvokeMethodExpression invoke)
            {
                return false;
            }

            // Check if this is uri.Reset(nextPage/nextLink)
            if (invoke.MethodName != "Reset")
            {
                return false;
            }

            if (invoke.InstanceReference is not VariableExpression varExpr ||
                !varExpr.Equals(uriBuilderVariable))
            {
                return false;
            }

            // Check if the argument is the nextLink parameter
            if (invoke.Arguments.Count != 1)
            {
                return false;
            }

            var arg = invoke.Arguments[0];
            return arg is VariableExpression argVar && argVar.Declaration.Equals(nextLinkParam);
        }
    }
}
