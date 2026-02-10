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
                // Try to get RestClientProvider from different sources
                RestClientProvider? restClient = null;

                if (method.EnclosingType is RestClientProvider rc)
                {
                    restClient = rc;
                }

                if (restClient != null)
                {
                    UpdateCreateNextLinkRequestMethod(method, restClient);
                }
            }

            return method;
        }

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            // Visit RestClient types and check their methods
            if (type is RestClientProvider restClient)
            {
                foreach (var methodProvider in restClient.Methods)
                {
                    if (methodProvider is ScmMethodProvider method &&
                        _visited.Add(method) &&
                        IsCreateNextLinkRequestMethod(method))
                    {
                        UpdateCreateNextLinkRequestMethod(method, restClient);
                    }
                }
            }

            return type;
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

            var endpointField = enclosingType.Fields.FirstOrDefault(f => f.Name == "_endpoint");
            if (endpointField == null)
            {
                return;
            }

            var updatedStatements = new List<MethodBodyStatement>();
            VariableExpression? uriBuilderVariable = null;
            bool modified = false;

            foreach (var statement in method.BodyStatements)
            {
                // Try to find variable declaration for RawRequestUriBuilder
                if (uriBuilderVariable == null &&
                    statement is ExpressionStatement { Expression: AssignmentExpression assignment } &&
                    assignment.Variable is DeclarationExpression declaration &&
                    declaration.Variable.Type.Name == "RawRequestUriBuilder")
                {
                    uriBuilderVariable = declaration.Variable;
                    updatedStatements.Add(statement);
                    continue;
                }

                // If we found the uri builder, check if this statement is uri.Reset(nextPage)
                if (uriBuilderVariable != null &&
                    statement is ExpressionStatement { Expression: InvokeMethodExpression invoke } &&
                    invoke.MethodName == "Reset" &&
                    invoke.InstanceReference is VariableExpression varRef &&
                    varRef.Equals(uriBuilderVariable) &&
                    invoke.Arguments.Count == 1 &&
                    invoke.Arguments[0] is VariableExpression argVar &&
                    argVar.Equals(nextLinkParam))
                {
                    // Replace uri.Reset(nextPage) with:
                    // uri.Reset(_endpoint);
                    // uri.AppendRawNextLink(nextPage.AbsoluteUri, false);
                    updatedStatements.Add(uriBuilderVariable.Invoke("Reset", [endpointField]).Terminate());
                    updatedStatements.Add(uriBuilderVariable.Invoke("AppendRawNextLink",
                        [nextLinkParam.Property("AbsoluteUri"), Literal(false)]).Terminate());
                    modified = true;
                }
                else
                {
                    updatedStatements.Add(statement);
                }
            }

            if (modified)
            {
                method.Update(bodyStatements: updatedStatements);
            }
        }
    }
}
