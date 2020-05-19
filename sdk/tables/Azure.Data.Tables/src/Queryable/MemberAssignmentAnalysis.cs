// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    internal class MemberAssignmentAnalysis : LinqExpressionVisitor
    {
        internal static readonly Expression[] EmptyExpressionArray = Array.Empty<Expression>();

        private readonly Expression entity;
        private List<Expression> pathFromEntity;

        private MemberAssignmentAnalysis(Expression entity)
        {
            Debug.Assert(entity != null, "entity != null");

            this.entity = entity;
            pathFromEntity = new List<Expression>();
        }

        internal Exception IncompatibleAssignmentsException { get; private set; }

        internal bool MultiplePathsFound { get; private set; }

        internal static MemberAssignmentAnalysis Analyze(Expression entityInScope, Expression assignmentExpression)
        {
            Debug.Assert(entityInScope != null, "entityInScope != null");
            Debug.Assert(assignmentExpression != null, "assignmentExpression != null");

            MemberAssignmentAnalysis result = new MemberAssignmentAnalysis(entityInScope);
            result.Visit(assignmentExpression);
            return result;
        }

        internal Exception CheckCompatibleAssignments(Type targetType, ref MemberAssignmentAnalysis previous)
        {
            if (previous == null)
            {
                previous = this;
                return null;
            }

            Expression[] previousExpressions = previous.GetExpressionsToTargetEntity();
            Expression[] candidateExpressions = GetExpressionsToTargetEntity();
            return CheckCompatibleAssignments(targetType, previousExpressions, candidateExpressions);
        }

        internal override Expression Visit(Expression expression)
        {
            if (MultiplePathsFound || IncompatibleAssignmentsException != null)
            {
                return expression;
            }

            return base.Visit(expression);
        }

        internal override Expression VisitConditional(ConditionalExpression c)
        {
            Expression result;

            var nullCheck = ResourceBinder.PatternRules.MatchNullCheck(entity, c);
            if (nullCheck.Match)
            {
                Visit(nullCheck.AssignExpression);
                result = c;
            }
            else
            {
                result = base.VisitConditional(c);
            }

            return result;
        }

        internal override Expression VisitParameter(ParameterExpression p)
        {
            if (p == entity)
            {
                if (pathFromEntity.Count != 0)
                {
                    MultiplePathsFound = true;
                }
                else
                {
                    pathFromEntity.Add(p);
                }
            }

            return p;
        }

        internal override Expression VisitMemberInit(MemberInitExpression init)
        {
            Expression result = init;
            MemberAssignmentAnalysis previousNested = null;
            foreach (var binding in init.Bindings)
            {
                MemberAssignment assignment = binding as MemberAssignment;
                if (assignment == null)
                {
                    continue;
                }

                MemberAssignmentAnalysis nested = MemberAssignmentAnalysis.Analyze(entity, assignment.Expression);
                if (nested.MultiplePathsFound)
                {
                    MultiplePathsFound = true;
                    break;
                }

                Exception incompatibleException = nested.CheckCompatibleAssignments(init.Type, ref previousNested);
                if (incompatibleException != null)
                {
                    IncompatibleAssignmentsException = incompatibleException;
                    break;
                }

                if (pathFromEntity.Count == 0)
                {
                    pathFromEntity.AddRange(nested.GetExpressionsToTargetEntity());
                }
            }

            return result;
        }

        internal override Expression VisitMemberAccess(MemberExpression m)
        {
            Expression result = base.VisitMemberAccess(m);
            if (pathFromEntity.Contains(m.Expression))
            {
                pathFromEntity.Add(m);
            }

            return result;
        }

        internal override Expression VisitMethodCall(MethodCallExpression call)
        {
            if (ReflectionUtil.IsSequenceMethod(call.Method, SequenceMethod.Select))
            {
                Visit(call.Arguments[0]);
                return call;
            }

            return base.VisitMethodCall(call);
        }

        internal Expression[] GetExpressionsBeyondTargetEntity()
        {
            Debug.Assert(!MultiplePathsFound, "this.multiplePathsFound -- otherwise GetExpressionsToTargetEntity won't return reliable (consistent) results");

            if (pathFromEntity.Count <= 1)
            {
                return EmptyExpressionArray;
            }

            Expression[] result = new Expression[1];
            result[0] = pathFromEntity[pathFromEntity.Count - 1];
            return result;
        }

        internal Expression[] GetExpressionsToTargetEntity()
        {
            Debug.Assert(!MultiplePathsFound, "this.multiplePathsFound -- otherwise GetExpressionsToTargetEntity won't return reliable (consistent) results");

            if (pathFromEntity.Count <= 1)
            {
                return EmptyExpressionArray;
            }

            Expression[] result = new Expression[pathFromEntity.Count - 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = pathFromEntity[i];
            }

            return result;
        }

        private static Exception CheckCompatibleAssignments(Type targetType, Expression[] previous, Expression[] candidate)
        {
            Debug.Assert(targetType != null, "targetType != null");
            Debug.Assert(previous != null, "previous != null");
            Debug.Assert(candidate != null, "candidate != null");

            if (previous.Length != candidate.Length)
            {
                throw CheckCompatibleAssignmentsFail(targetType, previous, candidate);
            }

            for (int i = 0; i < previous.Length; i++)
            {
                Expression p = previous[i];
                Expression c = candidate[i];
                if (p.NodeType != c.NodeType)
                {
                    throw CheckCompatibleAssignmentsFail(targetType, previous, candidate);
                }

                if (p == c)
                {
                    continue;
                }

                if (p.NodeType != ExpressionType.MemberAccess)
                {
                    return CheckCompatibleAssignmentsFail(targetType, previous, candidate);
                }

                if (((MemberExpression)p).Member.Name != ((MemberExpression)c).Member.Name)
                {
                    return CheckCompatibleAssignmentsFail(targetType, previous, candidate);
                }
            }

            return null;
        }

        private static Exception CheckCompatibleAssignmentsFail(Type targetType, Expression[] previous, Expression[] candidate)
        {
            Debug.Assert(targetType != null, "targetType != null");
            Debug.Assert(previous != null, "previous != null");
            Debug.Assert(candidate != null, "candidate != null");

            return new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqProjectionMemberAssignmentMismatch, targetType.FullName, previous.LastOrDefault(), candidate.LastOrDefault()));
        }

    }
}
