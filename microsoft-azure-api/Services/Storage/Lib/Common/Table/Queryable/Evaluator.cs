// -----------------------------------------------------------------------------------------
// <copyright file="Evaluator.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table.Queryable
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq.Expressions;

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

        private static bool CanBeEvaluatedLocally(Expression expression)
        {
            return expression.NodeType != ExpressionType.Parameter &&
                expression.NodeType != ExpressionType.Lambda
                && expression.NodeType != (ExpressionType)ResourceExpressionType.RootResourceSet;
        }

        internal class SubtreeEvaluator : DataServiceALinqExpressionVisitor
        {
            private HashSet<Expression> candidates;

            internal SubtreeEvaluator(HashSet<Expression> candidates)
            {
                this.candidates = candidates;
            }

            internal Expression Eval(Expression exp)
            {
                return this.Visit(exp);
            }

            internal override Expression Visit(Expression exp)
            {
                if (exp == null)
                {
                    return null;
                }

                if (this.candidates.Contains(exp))
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

#if ASTORIA_LIGHT
                LambdaExpression lambda = ExpressionHelpers.CreateLambda(e, new ParameterExpression[0]); 
#else
                LambdaExpression lambda = Expression.Lambda(e);
#endif
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

        internal class Nominator : DataServiceALinqExpressionVisitor
        {
            private Func<Expression, bool> functionCanBeEvaluated;

            private HashSet<Expression> candidates;

            private bool cannotBeEvaluated;

            internal Nominator(Func<Expression, bool> functionCanBeEvaluated)
            {
                this.functionCanBeEvaluated = functionCanBeEvaluated;
            }

            internal HashSet<Expression> Nominate(Expression expression)
            {
                this.candidates = new HashSet<Expression>(EqualityComparer<Expression>.Default);
                this.Visit(expression);
                return this.candidates;
            }

            internal override Expression Visit(Expression expression)
            {
                if (expression != null)
                {
                    bool saveCannotBeEvaluated = this.cannotBeEvaluated;
                    this.cannotBeEvaluated = false;

                    base.Visit(expression);

                    if (!this.cannotBeEvaluated)
                    {
                        if (this.functionCanBeEvaluated(expression))
                        {
                            this.candidates.Add(expression);
                        }
                        else
                        {
                            this.cannotBeEvaluated = true;
                        }
                    }

                    this.cannotBeEvaluated |= saveCannotBeEvaluated;
                }

                return expression;
            }
        }
    }
}
