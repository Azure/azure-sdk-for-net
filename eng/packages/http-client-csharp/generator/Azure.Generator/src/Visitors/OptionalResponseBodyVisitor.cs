// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    internal class OptionalResponseBodyVisitor : ScmLibraryVisitor
    {
        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (method.Kind != ScmMethodKind.Convenience
                || method.ServiceMethod is null
                || method.BodyStatements is null
                || !TryGetOptionalResponse(method, out var responseBodyType, out var noBodyStatusCodes))
            {
                return method;
            }

            var statements = method.BodyStatements.ToList();
            VariableExpression? result = null;
            int resultDeclarationIndex = -1;
            for (int i = 0; i < statements.Count; i++)
            {
                if (statements[i] is ExpressionStatement
                    {
                        Expression: AssignmentExpression
                        {
                            Variable: DeclarationExpression declaration
                        }
                    }
                    && declaration.Variable.Type.Equals(typeof(Response)))
                {
                    result = declaration.Variable;
                    resultDeclarationIndex = i;
                    break;
                }
            }

            if (result is null)
            {
                return method;
            }

            ScopedApi<bool>? noBodyCondition = null;
            foreach (int statusCode in noBodyStatusCodes)
            {
                var statusCondition = result.Property(nameof(Response.Status)).As<int>().Equal(Literal(statusCode));
                noBodyCondition = noBodyCondition is null
                    ? statusCondition
                    : noBodyCondition.Or(statusCondition);
            }

            if (noBodyCondition is null)
            {
                return method;
            }

            statements.Insert(
                resultDeclarationIndex + 1,
                new IfStatement(noBodyCondition)
                {
                    Return(New.Instance(
                        new CSharpType(typeof(NoValueResponse<>), responseBodyType),
                        result))
                });

            var nullableResponseType = new CSharpType(typeof(NullableResponse<>), responseBodyType);
            var returnType = method.Signature.ReturnType is
                {
                    IsFrameworkType: true,
                    FrameworkType: not null,
                    Arguments.Count: 1
                } methodReturnType
                && methodReturnType.FrameworkType == typeof(Task<>)
                    ? new CSharpType(typeof(Task<>), nullableResponseType)
                    : nullableResponseType;

            method.Signature.Update(returnType: returnType);
            method.Update(signature: method.Signature, bodyStatements: statements);
            return method;
        }

        private static bool TryGetOptionalResponse(
            ScmMethodProvider method,
            out CSharpType responseBodyType,
            out IReadOnlyList<int> noBodyStatusCodes)
        {
            responseBodyType = null!;
            noBodyStatusCodes = [];

            var successResponses = method.ServiceMethod!.Operation.Responses
                .Where(response => !response.IsErrorResponse)
                .ToList();
            if (!successResponses.Any(response => response.BodyType is not null)
                || !successResponses.Any(response => response.BodyType is null))
            {
                return false;
            }

            var returnType = method.Signature.ReturnType;
            if (returnType is
                {
                    IsFrameworkType: true,
                    FrameworkType: not null,
                    Arguments.Count: 1
                }
                && returnType.FrameworkType == typeof(Task<>))
            {
                returnType = returnType.Arguments[0];
            }

            if (returnType is not
                {
                    IsFrameworkType: true,
                    FrameworkType: not null,
                    Arguments.Count: 1
                }
                || returnType.FrameworkType != typeof(Response<>))
            {
                return false;
            }

            responseBodyType = returnType.Arguments[0].WithNullable(false);
            var bodyStatusCodes = successResponses
                .Where(response => response.BodyType is not null)
                .SelectMany(response => response.StatusCodes)
                .ToHashSet();
            noBodyStatusCodes =
            [
                .. successResponses
                    .Where(response => response.BodyType is null)
                    .SelectMany(response => response.StatusCodes)
                    .Where(statusCode => !bodyStatusCodes.Contains(statusCode))
                    .Distinct()
            ];
            return noBodyStatusCodes.Count > 0;
        }
    }
}
