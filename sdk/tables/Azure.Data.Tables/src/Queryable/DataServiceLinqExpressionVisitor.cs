// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    internal abstract class DataServiceLinqExpressionVisitor : LinqExpressionVisitor
    {
        internal override Expression Visit(Expression exp)
        {
            if (exp == null)
            {
                return null;
            }

            switch ((ResourceExpressionType)exp.NodeType)
            {
                case ResourceExpressionType.RootResourceSet:
                case ResourceExpressionType.ResourceNavigationProperty:
                    return this.VisitResourceSetExpression((ResourceSetExpression)exp);
                case ResourceExpressionType.ResourceNavigationPropertySingleton:
                    return this.VisitNavigationPropertySingletonExpression((NavigationPropertySingletonExpression)exp);
                case ResourceExpressionType.InputReference:
                    return this.VisitInputReferenceExpression((InputReferenceExpression)exp);
                default:
                    return base.Visit(exp);
            }
        }

        internal virtual Expression VisitResourceSetExpression(ResourceSetExpression rse)
        {
            Expression source = this.Visit(rse.Source);

            if (source != rse.Source)
            {
                rse = new ResourceSetExpression(rse.Type, source, rse.MemberExpression, rse.ResourceType, rse.ExpandPaths, rse.CountOption, rse.CustomQueryOptions, rse.Projection);
            }

            return rse;
        }

        internal virtual Expression VisitNavigationPropertySingletonExpression(NavigationPropertySingletonExpression npse)
        {
            Expression source = this.Visit(npse.Source);

            if (source != npse.Source)
            {
                npse = new NavigationPropertySingletonExpression(npse.Type, source, npse.MemberExpression, npse.MemberExpression.Type, npse.ExpandPaths, npse.CountOption, npse.CustomQueryOptions, npse.Projection);
            }

            return npse;
        }

        internal virtual Expression VisitInputReferenceExpression(InputReferenceExpression ire)
        {
            // Debug.Assert(ire != null, "ire != null -- otherwise caller never should have visited here");
            ResourceExpression re = (ResourceExpression)this.Visit(ire.Target);
            return re.CreateReference();
        }
    }
}
