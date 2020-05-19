// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    internal class ProjectionRewriter : LinqExpressionVisitor
    {
        private readonly ParameterExpression newLambdaParameter;

        private ParameterExpression oldLambdaParameter;

        private bool successfulRebind;

        private ProjectionRewriter(Type proposedParameterType)
        {
            Debug.Assert(proposedParameterType != null, "proposedParameterType != null");
            newLambdaParameter = Expression.Parameter(proposedParameterType, "it");
        }

        internal static LambdaExpression TryToRewrite(LambdaExpression le, Type proposedParameterType)
        {
            LambdaExpression result;
            if (!ResourceBinder.PatternRules.MatchSingleArgumentLambda(le, out le) ||
                /* TODO Fix ME !  CommonUtil.IsClientType(le.Parameters[0].Type) || */
                !le.Parameters[0].Type.GetProperties().Any(p => p.PropertyType == proposedParameterType))
            {
                result = le;
            }
            else
            {
                ProjectionRewriter rewriter = new ProjectionRewriter(proposedParameterType);
                result = rewriter.Rebind(le);
            }

            return result;
        }

        internal LambdaExpression Rebind(LambdaExpression lambda)
        {
            successfulRebind = true;
            oldLambdaParameter = lambda.Parameters[0];

            Expression body = Visit(lambda.Body);
            if (successfulRebind)
            {
                Type delegateType = typeof(Func<,>).MakeGenericType(new Type[] { newLambdaParameter.Type, lambda.Body.Type });
                return Expression.Lambda(delegateType, body, new ParameterExpression[] { newLambdaParameter });
            }
            else
            {
                throw new NotSupportedException(SR.ALinqCanOnlyProjectTheLeaf);
            }
        }

        internal override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m.Expression == oldLambdaParameter)
            {
                if (m.Type == newLambdaParameter.Type)
                {
                    return newLambdaParameter;
                }
                else
                {
                    successfulRebind = false;
                }
            }

            return base.VisitMemberAccess(m);
        }
    }
}
