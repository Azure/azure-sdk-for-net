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
    private bool _isCollectionResultType;

    /// <summary>
    /// This method is the entrance of the visitor.
    /// We check the name of this type to ensure this visitor is only applied to the collection result types.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    protected override TypeProvider? VisitType(TypeProvider type)
    {
        _isCollectionResultType = type.Name.AsSpan().Contains("CollectionResult".AsSpan(), StringComparison.Ordinal);
        return base.VisitType(type);
    }

    protected override MethodBodyStatement? VisitStatements(MethodBodyStatements statements, MethodProvider method)
    {
        if (_isCollectionResultType && IsAsPagesMethod(method))
        {
            DoVisitAsPagesMethodStatements(statements, method);
        }
        return base.VisitStatements(statements, method);
    }

    private static bool IsAsPagesMethod(MethodProvider method) => method.Signature.Name.Equals("AsPages");
    private static bool IsGetNextResponseMethod(MethodProvider method) => method.Signature.Name.Equals("GetNextResponse");

    private void DoVisitAsPagesMethodStatements(MethodBodyStatements statements, MethodProvider method)
    {
        var doWhileStatement = statements.OfType<DoWhileStatement>().FirstOrDefault();
        if (doWhileStatement is not null)
        {
            var body = doWhileStatement.Body;

            // we manually go over the body statements because currently the framework does not do this.
            // TODO -- we do not have to do this once https://github.com/microsoft/typespec/issues/8177 is fixed.
            foreach (var statement in doWhileStatement.Body)
            {
                if (statement is ExpressionStatement { Expression: AssignmentExpression assignment } expressionStatement)
                {
                    var updatedExpression = DoVisitAssignmentExpressionForAsPagesMethod(assignment, method);
                    if (updatedExpression is not null)
                    {
                        // update the expression in the statement.
                        expressionStatement.Update(updatedExpression);
                    }
                }
            }
        }
    }

    protected override ValueExpression? VisitAssignmentExpression(AssignmentExpression expression, MethodProvider method)
    {
        if (_isCollectionResultType && IsAsPagesMethod(method))
        {
            var newExpression = DoVisitAssignmentExpressionForAsPagesMethod(expression, method);
            if (newExpression is not null)
            {
                // we have updated the expression, so we return it.
                return newExpression;
            }
        }

        if (_isCollectionResultType && IsGetNextResponseMethod(method))
        {
            var newExpression = DoVisitAssignmentExpressionForGetNextResponseMethod(expression, method);
            if (newExpression is not null)
            {
                // we have updated the expression, so we return it.
                return newExpression;
            }
        }
        return base.VisitAssignmentExpression(expression, method);
    }

    private ValueExpression? DoVisitAssignmentExpressionForAsPagesMethod(AssignmentExpression expression, MethodProvider method)
    {
        if (expression.Value is CastExpression castExpression && IsResponseToModelCastExpression(castExpression))
        {
            var value = Static(castExpression.Type!).Invoke(SerializationVisitor.FromResponseMethodName, [castExpression.Inner!]);
            var variable = expression.Variable;
            return variable.Assign(value);
        }
        // do nothing if nothing is changed.
        return null;

        static bool IsResponseToModelCastExpression(CastExpression castExpression)
        {
            if (castExpression.Inner is VariableExpression variableExpression &&
                variableExpression.Type is { IsFrameworkType: true, FrameworkType: { } frameworkType } &&
                frameworkType == typeof(Response))
            {
                return true;
            }
            return false;
        }
    }

    private ValueExpression? DoVisitAssignmentExpressionForGetNextResponseMethod(AssignmentExpression expression, MethodProvider method)
    {
        if (expression is
            {
                Variable: DeclarationExpression { Variable: { } variable, IsUsing: true } declaration,
                Value: InvokeMethodExpression invokeMethodExpression
            }
            && variable.Declaration.RequestedName == "scope")
        {
            // first we fetch the diagnostics scope from outputlibrary
            if (ManagementClientGenerator.Instance.OutputLibrary.PageableMethodScopes.TryGetValue(method.EnclosingType, out var diagnosticsScopeValue))
            {
                // change its first argument to be the new diagnostics scope value.
                invokeMethodExpression.Update(
                    arguments: [Literal(diagnosticsScopeValue)]);

                return expression;
            }
            return null;
        }
        // do nothing if nothing is changed.
        return null;
    }
}
