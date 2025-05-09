// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using Azure.Core;
using Azure.Generator.Primitives;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;
using System;
using System.Linq;

namespace Azure.Generator.Visitors
{
    internal class PageableOperationVisitor : ScmLibraryVisitor
    {
        private const string NextPageParameterName = "nextPage";

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (method.EnclosingType is not RestClientProvider)
            {
                return base.VisitMethod(method);
            }

            if (method.IsCreateRequestMethod)
            {
                UpdateCreateRequestMethodForNextLinkPaging(method);
            }

            return method;
        }

        private static void UpdateCreateRequestMethodForNextLinkPaging(ScmMethodProvider method)
        {
            if (method.BodyStatements == null && method.BodyExpression == null)
            {
                return;
            }

            // Skip non-pageable methods
            ParameterProvider? originalNextPageParameter = null;
            foreach (var parameter in method.Signature.Parameters)
            {
                if (parameter.Name == NextPageParameterName && parameter.Type.Equals(typeof(Uri)))
                {
                    originalNextPageParameter = parameter;
                    break;
                }
            }

            if (originalNextPageParameter == null)
            {
                return;
            }

            // Update the method signature with the updated nextPage parameter
            var parameterCount = method.Signature.Parameters.Count;
            List<ParameterProvider> updatedParameters = new(parameterCount);
            bool replacedNextPageParameter = false;

            foreach (var parameter in method.Signature.Parameters)
            {
                if (!replacedNextPageParameter && parameter.Equals(originalNextPageParameter))
                {
                    updatedParameters.Add(KnownAzureParameters.NextPage);
                }
                else
                {
                    updatedParameters.Add(parameter);
                }
            }

            // Update the method signature
            var updatedSignature = new MethodSignature(
                method.Signature.Name,
                method.Signature.Description,
                method.Signature.Modifiers,
                method.Signature.ReturnType,
                method.Signature.ReturnDescription,
                updatedParameters,
                method.Signature.Attributes,
                method.Signature.GenericArguments,
                method.Signature.GenericParameterConstraints,
                method.Signature.ExplicitInterface,
                method.Signature.NonDocumentComment);

            // Update the body statements
            List<MethodBodyStatement> updatedCreateRequestStatements = [];
            var statementsToVisit = method.BodyStatements ?? new ExpressionStatement(method.BodyExpression!);
            var flattenedStatements = statementsToVisit.Flatten();
            var mutateUriStatements = CollectMutateUriStatements(flattenedStatements);
            MethodBodyStatement? updatedResetUriStatement = null;
            VariableExpression? uriBuilderVariable = null;

            foreach (var statement in flattenedStatements)
            {
                // Find URI builder variable declaration
                if (uriBuilderVariable == null &&
                    statement is ExpressionStatement { Expression: AssignmentExpression assignmentExpression } &&
                    assignmentExpression.Variable is DeclarationExpression declarationExpression &&
                    declarationExpression.Variable.Type.Equals(typeof(RawRequestUriBuilder)))
                {
                    uriBuilderVariable = declarationExpression.Variable;
                    updatedCreateRequestStatements.Add(statement);
                    continue;
                }

                // Find and update Reset URI statement
                if (updatedResetUriStatement == null &&
                    statement is ExpressionStatement { Expression: InvokeMethodExpression invokeMethodExpression } &&
                    invokeMethodExpression.MethodName?.Equals(nameof(RequestUriBuilder.Reset)) == true)
                {
                    if (invokeMethodExpression.Arguments.Count > 0
                        && invokeMethodExpression.Arguments[0] is BinaryOperatorExpression binaryOperatorExpression)
                    {
                        invokeMethodExpression.Update(arguments: [binaryOperatorExpression.Right]);
                    }

                    updatedResetUriStatement = invokeMethodExpression.Terminate();
                    continue;
                }

                // Update NextPage null check statement
                if (statement is IfStatement ifStatement &&
                    ifStatement.Condition.Equals(originalNextPageParameter.Equal(Null))
                    && uriBuilderVariable != null)
                {
                    MethodBodyStatements ifStatementBody = updatedResetUriStatement != null
                        ? new([updatedResetUriStatement, ifStatement.Body, mutateUriStatements])
                        : new([ifStatement.Body, mutateUriStatements]);

                    var updatedIfStatement = new IfStatement(
                        KnownAzureParameters.NextPage.Equal(Null),
                        ifStatement.Inline,
                        ifStatement.AddBraces)
                    {
                        ifStatementBody
                    };
                    var uriAppendRawNextLinkStatement = uriBuilderVariable.Invoke(
                        nameof(RawRequestUriBuilder.AppendRawNextLink),
                        [KnownAzureParameters.NextPage, False]).Terminate();

                    updatedCreateRequestStatements.Add(new IfElseStatement(updatedIfStatement, uriAppendRawNextLinkStatement));
                    continue;
                }

                if (!ContainsUriBuildStatement(statement))
                {
                    updatedCreateRequestStatements.Add(statement);
                }
            }

            method.Update(signature: updatedSignature, bodyStatements: updatedCreateRequestStatements);
        }

        private static List<MethodBodyStatement> CollectMutateUriStatements(IEnumerable<MethodBodyStatement> flattenedStatements)
        {
            List<MethodBodyStatement> collectedStatements = [];
            foreach (var statement in flattenedStatements)
            {
                if (ContainsUriBuildStatement(statement))
                {
                    collectedStatements.Add(statement);
                }
            }

            return collectedStatements;
        }

        private static bool ContainsUriBuildStatement(MethodBodyStatement statement)
        {
            HashSet<string> uriBuilderMethods =
            [
                nameof(RawRequestUriBuilder.AppendQuery),
                nameof(RawRequestUriBuilder.AppendQueryDelimited)
            ];

            if (statement is ExpressionStatement { Expression: InvokeMethodExpression { MethodName: not null } invokeMethodExpression })
            {
                return uriBuilderMethods.Contains(invokeMethodExpression.MethodName);
            }

            if (statement is IfStatement ifStatement)
            {
                var firstStatement = ifStatement.Body.Flatten().FirstOrDefault();
                return firstStatement != null && ContainsUriBuildStatement(firstStatement);
            }

            return false;
        }

        private static IfStatement CreateNextPageNullCheckStatement(IfStatement originalStatement, MethodBodyStatements bodyStatements)
        {
            return new IfStatement(
                KnownAzureParameters.NextPage.Equal(Null),
                originalStatement.Inline,
                originalStatement.AddBraces)
            {
                bodyStatements
            };
        }
    }
}
