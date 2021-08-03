// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    internal class Nominator : LinqExpressionVisitor
    {
        private Func<Expression, bool> _functionCanBeEvaluated;

        private HashSet<Expression> _candidates;

        private bool _cannotBeEvaluated;

        internal Nominator(Func<Expression, bool> functionCanBeEvaluated)
        {
            _functionCanBeEvaluated = functionCanBeEvaluated;
        }

        internal HashSet<Expression> Nominate(Expression expression)
        {
            _candidates = new HashSet<Expression>(EqualityComparer<Expression>.Default);
            Visit(expression);
            return _candidates;
        }

        internal override Expression Visit(Expression expression)
        {
            if (expression != null)
            {
                bool saveCannotBeEvaluated = _cannotBeEvaluated;
                _cannotBeEvaluated = false;

                base.Visit(expression);

                if (!_cannotBeEvaluated)
                {
                    if (_functionCanBeEvaluated(expression))
                    {
                        _candidates.Add(expression);
                    }
                    else
                    {
                        _cannotBeEvaluated = true;
                    }
                }

                _cannotBeEvaluated |= saveCannotBeEvaluated;
            }

            return expression;
        }
    }
}
