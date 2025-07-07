// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors;

internal class PaginationVisitor : ScmLibraryVisitor
{
    protected override MethodBodyStatement? VisitStatements(MethodBodyStatements statements, MethodProvider method)
    {
        if (method.EnclosingType.Name.AsSpan().Contains("CollectionResult".AsSpan(), StringComparison.Ordinal) && method.Signature.Name.Equals("AsPages"))
        {
            var doWhileStatement = statements.OfType<DoWhileStatement>().FirstOrDefault();
            if (doWhileStatement is not null)
            {
                var body = doWhileStatement.Body;

                // get the response to model casting expression
                var responseToModelStatement = body.OfType<ExpressionStatement>().FirstOrDefault();
                if (responseToModelStatement is not null)
                {
                    responseToModelStatement.Update(ConstructFromResponseExpression(responseToModelStatement));
                }
            }
        }
        return base.VisitStatements(statements, method);
    }

    private static AssignmentExpression ConstructFromResponseExpression(ExpressionStatement responseToModelStatement)
    {
        var assignmentExpression = responseToModelStatement.Expression as AssignmentExpression;
        var castExpression = assignmentExpression?.Value as CastExpression;
        var value = Static(castExpression?.Type!).Invoke("FromResponse", [castExpression?.Inner!]);
        var variable = assignmentExpression!.Variable;
        return variable.Assign(value);
    }
}
