// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.Generator.Primitives;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    internal class PageableOperationVisitor : ScmLibraryVisitor
    {
        private const string NextPageParameterName = "nextPage";

        // Updated the code to avoid using LINQ methods on indexable collections
        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            // Skip non-pageable methods
            // TO-DO: Consider continuation token as well
            // TO-DO: Use ScmMethodProvider API
            if (method.EnclosingType is not RestClientProvider)
            {
                return base.VisitMethod(method);
            }

            // Update the CreateRequest method
            if (method.Signature.Name.StartsWith("Create"))
            {
                ParameterProvider? originalNextPageParameter = null;
                foreach (var parameter in method.Signature.Parameters)
                {
                    if (parameter.Name == NextPageParameterName)
                    {
                        originalNextPageParameter = parameter;
                        break;
                    }
                }

                if (originalNextPageParameter == null)
                {
                    return base.VisitMethod(method);
                }

                UpdateCreateRequestMethodForNextLinkPaging(method, originalNextPageParameter);
            }

            return method;
        }

        private static void UpdateCreateRequestMethodForNextLinkPaging(
            ScmMethodProvider method,
            ParameterProvider originalNextLinkParameter)
        {
            // Update the method signature with the updated nextPage parameter
            var parameterCount = method.Signature.Parameters.Count;
            List<ParameterProvider> updatedParameters = new(parameterCount);

            bool replacedNextPageParameter = false;
            for (var i = 0; i < parameterCount; i++)
            {
                if (!replacedNextPageParameter && method.Signature.Parameters[i].Equals(originalNextLinkParameter))
                {
                    updatedParameters.Add(KnownAzureParameters.NextPage);
                    replacedNextPageParameter = true;
                    continue;
                }

                updatedParameters.Add(method.Signature.Parameters[i]);
            }

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

            List<MethodBodyStatement> updatedCreateRequestStatements = [];
            var statementsToVisit = method.BodyStatements ?? new ExpressionStatement(method.BodyExpression!);
            MethodBodyStatement? updatedResetUriStatement = null;
            foreach (var statement in statementsToVisit.Flatten())
            {
                // update the uri.Reset statement
                if (updatedResetUriStatement is null &&
                    statement is ExpressionStatement { Expression: InvokeMethodExpression invokeMethodExpression } &&
                    invokeMethodExpression.MethodName?.Equals(nameof(RequestUriBuilder.Reset)) == true)
                {
                    if (invokeMethodExpression.Arguments.Count > 0
                        && invokeMethodExpression.Arguments[0] is BinaryOperatorExpression binaryOperatorExpression)
                    {
                        invokeMethodExpression.Update(arguments: [binaryOperatorExpression.Right]);
                    }

                    updatedResetUriStatement = invokeMethodExpression.Terminate();
                }
                else if (statement is IfStatement ifStatement &&
                         ifStatement.Condition.Equals(originalNextLinkParameter.Equal(Null)))
                {
                    var mutateUriStatements = CollectionMutateUriStatements(statementsToVisit);
                    var updatedIfStatement = new IfStatement(
                        KnownAzureParameters.NextPage.Equal(Null),
                        ifStatement.Inline,
                        ifStatement.AddBraces)
                    {
                        new MethodBodyStatements([ifStatement.Body, mutateUriStatements])
                    };

                    if (updatedResetUriStatement != null)
                    {
                        MethodBodyStatements updatedIfStatementBody = new([updatedResetUriStatement, ifStatement.Body, mutateUriStatements]);
                        updatedIfStatement = new IfStatement(
                            KnownAzureParameters.NextPage.Equal(Null),
                            ifStatement.Inline,
                            ifStatement.AddBraces)
                        {
                            updatedIfStatementBody
                        };
                    }

                    updatedCreateRequestStatements.Add(updatedIfStatement);
                }
                else
                {
                    updatedCreateRequestStatements.Add(statement);
                }
            }

            method.Update(signature: updatedSignature, bodyStatements: updatedCreateRequestStatements);
        }

        private static List<MethodBodyStatement> CollectionMutateUriStatements(MethodBodyStatement methodBody)
        {
            List<MethodBodyStatement> collectedStatements = [];
            foreach (var statement in methodBody.Flatten())
            {
                if (statement is ExpressionStatement { Expression: InvokeMethodExpression { MethodName: not null } invokeMethodExpression } &&
                    (invokeMethodExpression.MethodName.Equals(nameof(RawRequestUriBuilder.AppendQuery)) ||
                     invokeMethodExpression.MethodName.Equals(nameof(RawRequestUriBuilder.AppendQueryDelimited))))
                {
                    collectedStatements.Add(statement);
                }
            }

            return collectedStatements;
        }
    }
}
