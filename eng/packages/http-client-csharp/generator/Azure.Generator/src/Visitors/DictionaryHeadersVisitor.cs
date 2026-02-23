// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that modifies service methods to use the <see cref="RequestHeaders"/> extension method
    /// for dictionary header request parameters within the CreateRequest method of an operation.
    /// </summary>
    internal class DictionaryHeadersVisitor : ScmLibraryVisitor
    {
        protected override MethodBodyStatement? VisitExpressionStatement(ExpressionStatement statement, MethodProvider method)
        {
            if (statement.Expression is InvokeMethodExpression invokeMethod &&
                invokeMethod.MethodName == "SetDelimited" &&
                invokeMethod.Arguments.Count >= 2 &&
                invokeMethod.Arguments[1] is VariableExpression varExpr &&
                varExpr.Type.IsDictionary)
            {
                invokeMethod.Update(
                    methodName: nameof(RequestHeaders.Add),
                    arguments: [invokeMethod.Arguments[0], invokeMethod.Arguments[1]]);
            }

            return statement;
        }
    }
}
