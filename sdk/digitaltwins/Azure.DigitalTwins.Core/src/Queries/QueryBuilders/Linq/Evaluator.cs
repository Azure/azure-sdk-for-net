// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics;

namespace Azure.DigitalTwins.Core.QueryBuilder.Linq
{
    /// <summary>
    /// Partially evaluate subexpressions that don't depend on the query parameter.
    /// This allows queries to use arbitrary C# code that are turned into constants before
    /// we build our queries. This code is taken from <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/tables/Azure.Data.Tables/src/Queryable">Azure SDK for .NET repository</see>.
    /// </summary>
    internal static class Evaluator
    {
        internal static Expression PartialEval(Expression expression, Func<Expression, bool> canBeEvaluated)
        {
            Nominator nominator = new Nominator(canBeEvaluated);
            HashSet<Expression> candidates = nominator.Nominate(expression);
            return new SubtreeEvaluator(candidates).Eval(expression);
        }

        internal static Expression PartialEval(Expression expression)
        {
            return PartialEval(expression, Evaluator.CanBeEvaluatedLocally);
        }

        internal static bool CanBeEvaluatedLocally(Expression expression)
        {
            int rootResourceSet = 10000;
            return expression.NodeType != ExpressionType.Parameter &&
                expression.NodeType != ExpressionType.Lambda &&
                expression.NodeType != (ExpressionType)rootResourceSet;
        }

        internal class SubtreeEvaluator : LinqExpressionVisitor
        {
            private HashSet<Expression> candidates;

            internal SubtreeEvaluator(HashSet<Expression> candidates)
            {
                this.candidates = candidates;
            }

            internal Expression Eval(Expression exp)
            {
                return Visit(exp);
            }

            internal override Expression Visit(Expression exp)
            {
                if (exp == null)
                {
                    return null;
                }

                if (candidates.Contains(exp))
                {
                    return Evaluate(exp);
                }

                return base.Visit(exp);
            }

            private static Expression Evaluate(Expression e)
            {
                if (e.NodeType == ExpressionType.Constant)
                {
                    return e;
                }

                LambdaExpression lambda = Expression.Lambda(e);
                Delegate fn = lambda.Compile();
                object constantValue = fn.DynamicInvoke(null);
                Debug.Assert(!(constantValue is Expression), "!(constantValue is Expression)");

                Type constantType = e.Type;
                if (constantValue != null && constantType.IsArray && constantType.GetElementType() == constantValue.GetType().GetElementType())
                {
                    constantType = constantValue.GetType();
                }

                return Expression.Constant(constantValue, constantType);
            }
        }
    }
}
