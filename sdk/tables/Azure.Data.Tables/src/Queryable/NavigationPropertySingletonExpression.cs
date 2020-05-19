// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    internal class NavigationPropertySingletonExpression : ResourceExpression
    {
        private readonly Expression memberExpression;

        private readonly Type resourceType;

        internal NavigationPropertySingletonExpression(Type type, Expression source, Expression memberExpression, Type resourceType, List<string> expandPaths, CountOption countOption, Dictionary<ConstantExpression, ConstantExpression> customQueryOptions, ProjectionQueryOptionExpression projection)
            : base(source, (ExpressionType)ResourceExpressionType.ResourceNavigationPropertySingleton, type, expandPaths, countOption, customQueryOptions, projection)
        {
            Debug.Assert(memberExpression != null, "memberExpression != null");
            Debug.Assert(resourceType != null, "resourceType != null");

            this.memberExpression = memberExpression;
            this.resourceType = resourceType;
        }

        internal MemberExpression MemberExpression
        {
            get
            {
                return (MemberExpression)memberExpression;
            }
        }

        internal override Type ResourceType
        {
            get { return resourceType; }
        }

        internal override bool IsSingleton
        {
            get { return true; }
        }

        internal override bool HasQueryOptions
        {
            get
            {
                return ExpandPaths.Count > 0 ||
                    CountOption == CountOption.InlineAll ||
                    CustomQueryOptions.Count > 0 ||
                    Projection != null;
            }
        }

        internal override ResourceExpression CreateCloneWithNewType(Type type)
        {
            return new NavigationPropertySingletonExpression(
                type,
                Source,
                MemberExpression,
                TypeSystem.GetElementType(type),
                ExpandPaths.ToList(),
                CountOption,
                CustomQueryOptions.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                Projection);
        }
    }
}
