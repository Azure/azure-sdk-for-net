// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
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
    private static bool IsGetNextResponseMethod(MethodProvider method)
        => method.Signature.Name.Equals("GetNextResponseAsync") || method.Signature.Name.Equals("GetNextResponse");

    private void DoVisitAsPagesMethodStatements(MethodBodyStatements statements, MethodProvider method)
    {
        var whileStatement = statements.OfType<WhileStatement>().FirstOrDefault();
        if (whileStatement is not null)
        {
            // we manually go over the body statements because currently the framework does not do this.
            // TODO -- we do not have to do this once https://github.com/microsoft/typespec/issues/8177 is fixed.
            foreach (var statement in whileStatement.Body)
            {
                if (statement is YieldReturnStatement
                    {
                        Value: InvokeMethodExpression
                        {
                            MethodName: "FromValues",
                            Arguments: [CastExpression castExpression, ..]
                        } invokeMethodExpression
                    } &&
                    castExpression.Inner is MemberExpression
                    {
                        Inner: CastExpression innerCastExpression,
                        MemberName: var memberName
                    } &&
                    IsResponseToModelCastExpression(innerCastExpression))
                {
                    // convert the implicit cast expression to a method call
                    var updatedExpression = ConvertCastToMethodCall(innerCastExpression)
                                            .Property(memberName) // wrap back by a MemberExpression
                                            .CastTo(castExpression.Type); // wrap back by the outer CastExpression
                    // use the above updated expression as the first argument of this method call inside the yield return
                    IReadOnlyList<ValueExpression> newArguments = [updatedExpression, .. invokeMethodExpression.Arguments.Skip(1)];
                    invokeMethodExpression.Update(arguments: newArguments);
                }
                else if (statement is ExpressionStatement
                {
                    Expression: AssignmentExpression
                    {
                        Variable: var variable,
                        Value: MemberExpression { Inner: CastExpression castExpression1, MemberName: var memberName1 }
                    }
                } expressionStatement)
                {
                    var updatedExpression = variable.Assign(
                                            ConvertCastToMethodCall(castExpression1)
                                            .Property(memberName1)); // wrap back by a MemberExpression
                    expressionStatement.Update(updatedExpression);
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
            var value = ConvertCastToMethodCall(castExpression);
            var variable = expression.Variable;
            return variable.Assign(value);
        }
        // do nothing if nothing is changed.
        return null;
    }

    private static ValueExpression ConvertCastToMethodCall(CastExpression castExpression)
    {
        return Static(castExpression.Type!).Invoke(SerializationVisitor.FromResponseMethodName, [castExpression.Inner!]);
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

    private static bool IsResponseToModelCastExpression(CastExpression castExpression)
        => castExpression.Inner is VariableExpression variableExpression
            && variableExpression.Type is { IsFrameworkType: true, FrameworkType: { } frameworkType }
            && frameworkType == typeof(Response);
}
