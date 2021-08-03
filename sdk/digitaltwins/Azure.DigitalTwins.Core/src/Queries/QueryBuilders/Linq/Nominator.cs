// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    internal class Nominator : LinqExpressionVisitor
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
            candidates = new HashSet<Expression>(EqualityComparer<Expression>.Default);
            Visit(expression);
            return candidates;
        }

        internal override Expression Visit(Expression expression)
        {
            if (expression != null)
            {
                bool saveCannotBeEvaluated = cannotBeEvaluated;
                cannotBeEvaluated = false;

                base.Visit(expression);

                if (!cannotBeEvaluated)
                {
                    if (functionCanBeEvaluated(expression))
                    {
                        candidates.Add(expression);
                    }
                    else
                    {
                        cannotBeEvaluated = true;
                    }
                }

                cannotBeEvaluated |= saveCannotBeEvaluated;
            }

            return expression;
        }
    }
}
