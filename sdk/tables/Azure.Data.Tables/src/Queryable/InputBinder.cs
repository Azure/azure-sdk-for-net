// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.Data.Tables.Queryable
{
    internal sealed class InputBinder : DataServiceLinqExpressionVisitor
    {
        private readonly HashSet<ResourceExpression> referencedInputs = new HashSet<ResourceExpression>(EqualityComparer<ResourceExpression>.Default);

        private readonly ResourceExpression input;

        private readonly ResourceSetExpression inputSet;

        private readonly ParameterExpression inputParameter;

        private InputBinder(ResourceExpression resource, ParameterExpression setReferenceParam)
        {
            input = resource;
            inputSet = resource as ResourceSetExpression;
            inputParameter = setReferenceParam;
        }

        internal static Expression Bind(Expression e, ResourceExpression currentInput, ParameterExpression inputParameter, List<ResourceExpression> referencedInputs)
        {
            Debug.Assert(e != null, "Expression cannot be null");
            Debug.Assert(currentInput != null, "A current input resource set is required");
            Debug.Assert(inputParameter != null, "The input lambda parameter is required");
            Debug.Assert(referencedInputs != null, "The referenced inputs list is required");

            InputBinder binder = new InputBinder(currentInput, inputParameter);
            Expression result = binder.Visit(e);
            referencedInputs.AddRange(binder.referencedInputs);
            return result;
        }

        internal override Expression VisitMemberAccess(MemberExpression m)
        {
            if (inputSet == null ||
                !inputSet.HasTransparentScope)
            {
                return base.VisitMemberAccess(m);
            }

            ParameterExpression innerParamRef = null;
            Stack<PropertyInfo> nestedAccesses = new Stack<PropertyInfo>();
            MemberExpression memberRef = m;
            while (memberRef != null &&
                   memberRef.Member.MemberType == MemberTypes.Property &&
                   memberRef.Expression != null)
            {
                nestedAccesses.Push((PropertyInfo)memberRef.Member);

                if (memberRef.Expression.NodeType == ExpressionType.Parameter)
                {
                    innerParamRef = (ParameterExpression)memberRef.Expression;
                }

                memberRef = memberRef.Expression as MemberExpression;
            }

            if (innerParamRef != inputParameter || nestedAccesses.Count == 0)
            {
                return m;
            }

            ResourceExpression target = input;
            ResourceSetExpression targetSet = inputSet;
            bool transparentScopeTraversed = false;

            while (nestedAccesses.Count > 0)
            {
                if (targetSet == null || !targetSet.HasTransparentScope)
                {
                    break;
                }

                PropertyInfo currentProp = nestedAccesses.Peek();

                if (currentProp.Name.Equals(targetSet.TransparentScope.Accessor, StringComparison.Ordinal))
                {
                    target = targetSet;
                    nestedAccesses.Pop();
                    transparentScopeTraversed = true;
                    continue;
                }

                if (!targetSet.TransparentScope.SourceAccessors.TryGetValue(currentProp.Name, out Expression source))
                {
                    break;
                }

                transparentScopeTraversed = true;
                nestedAccesses.Pop();
                Debug.Assert(source != null, "source != null -- otherwise ResourceBinder created an accessor to nowhere");
                if (!(source is InputReferenceExpression sourceReference))
                {
                    targetSet = source as ResourceSetExpression;
                    if (targetSet == null || !targetSet.HasTransparentScope)
                    {
                        target = (ResourceExpression)source;
                    }
                }
                else
                {
                    targetSet = sourceReference.Target as ResourceSetExpression;
                    target = targetSet;
                }
            }

            if (!transparentScopeTraversed)
            {
                return m;
            }

            Expression result = CreateReference(target);
            while (nestedAccesses.Count > 0)
            {
                result = Expression.Property(result, nestedAccesses.Pop());
            }

            return result;
        }

        internal override Expression VisitParameter(ParameterExpression p)
        {
            if ((inputSet == null || !inputSet.HasTransparentScope) &&
               p == inputParameter)
            {
                return CreateReference(input);
            }
            else
            {
                return base.VisitParameter(p);
            }
        }

        private Expression CreateReference(ResourceExpression resource)
        {
            referencedInputs.Add(resource);
            return resource.CreateReference();
        }
    }
}
