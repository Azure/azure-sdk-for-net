// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.Data.Tables.Queryable
{
    internal static class ProjectionAnalyzer
    {
        internal static bool Analyze(LambdaExpression le, ResourceExpression re, bool matchMembers)
        {
            Debug.Assert(le != null, "le != null");

            if (le.Body.NodeType == ExpressionType.Constant)
            {
                if (CommonUtil.IsClientType(le.Body.Type))
                {
                    throw new NotSupportedException(SR.ALinqCannotCreateConstantEntity);
                }

                re.Projection = new ProjectionQueryOptionExpression(le.Body.Type, le, new List<string>());
                return true;
            }

            if (le.Body.NodeType == ExpressionType.Call)
            {
                MethodCallExpression mce = le.Body as MethodCallExpression;
                if (mce.Method == ReflectionUtil.ProjectMethodInfo.MakeGenericMethod(le.Body.Type))
                {
                    ConstantExpression paths = mce.Arguments[1] as ConstantExpression;

                    re.Projection = new ProjectionQueryOptionExpression(le.Body.Type, ProjectionQueryOptionExpression.DefaultLambda, new List<string>((string[])paths.Value));
                    return true;
                }
            }

            if (le.Body.NodeType == ExpressionType.MemberInit || le.Body.NodeType == ExpressionType.New)
            {
                AnalyzeResourceExpression(le, re);
                return true;
            }

            if (matchMembers)
            {
                Expression withoutConverts = SkipConverts(le.Body);
                if (withoutConverts.NodeType == ExpressionType.MemberAccess)
                {
                    AnalyzeResourceExpression(le, re);
                    return true;
                }
            }

            return false;
        }

        internal static void Analyze(LambdaExpression e, PathBox pb)
        {
            bool knownEntityType = CommonUtil.IsClientType(e.Body.Type);
            pb.PushParamExpression(e.Parameters.Last());

            if (!knownEntityType)
            {
                NonEntityProjectionAnalyzer.Analyze(e.Body, pb);
            }
            else
            {
                switch (e.Body.NodeType)
                {
                    case ExpressionType.MemberInit:
                        EntityProjectionAnalyzer.Analyze((MemberInitExpression)e.Body, pb);
                        break;
                    case ExpressionType.New:
                        throw new NotSupportedException(SR.ALinqCannotConstructKnownEntityTypes);
                    case ExpressionType.Constant:
                        throw new NotSupportedException(SR.ALinqCannotCreateConstantEntity);
                    default:
                        NonEntityProjectionAnalyzer.Analyze(e.Body, pb);
                        break;
                }
            }

            pb.PopParamExpression();
        }

        internal static bool IsMethodCallAllowedEntitySequence(MethodCallExpression call)
        {
            Debug.Assert(call != null, "call != null");
            return
                ReflectionUtil.IsSequenceMethod(call.Method, SequenceMethod.ToList) ||
                ReflectionUtil.IsSequenceMethod(call.Method, SequenceMethod.Select);
        }

        internal static void CheckChainedSequence(MethodCallExpression call, Type type)
        {
            if (ReflectionUtil.IsSequenceMethod(call.Method, SequenceMethod.Select))
            {
                MethodCallExpression insideCall = ResourceBinder.StripTo<MethodCallExpression>(call.Arguments[0]);
                if (insideCall != null && ReflectionUtil.IsSequenceMethod(insideCall.Method, SequenceMethod.Select))
                {
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, call.ToString()));
                }
            }
        }

        private static void Analyze(MemberInitExpression mie, PathBox pb)
        {
            Debug.Assert(mie != null, "mie != null");
            Debug.Assert(pb != null, "pb != null");

            bool knownEntityType = CommonUtil.IsClientType(mie.Type);
            if (knownEntityType)
            {
                EntityProjectionAnalyzer.Analyze(mie, pb);
            }
            else
            {
                NonEntityProjectionAnalyzer.Analyze(mie, pb);
            }
        }

        private static void AnalyzeResourceExpression(LambdaExpression lambda, ResourceExpression resource)
        {
            PathBox pb = new PathBox();
            ProjectionAnalyzer.Analyze(lambda, pb);
            resource.Projection = new ProjectionQueryOptionExpression(lambda.Body.Type, lambda, pb.ProjectionPaths.ToList());
            resource.ExpandPaths = pb.ExpandPaths.Union(resource.ExpandPaths, StringComparer.Ordinal).ToList();
        }

        private static Expression SkipConverts(Expression expression)
        {
            Expression result = expression;
            while (result.NodeType == ExpressionType.Convert || result.NodeType == ExpressionType.ConvertChecked)
            {
                result = ((UnaryExpression)result).Operand;
            }

            return result;
        }

        private class EntityProjectionAnalyzer : LinqExpressionVisitor
        {
            private readonly PathBox box;

            private readonly Type type;
            private EntityProjectionAnalyzer(PathBox pb, Type type)
            {
                Debug.Assert(pb != null, "pb != null");
                Debug.Assert(type != null, "type != null");

                box = pb;
                this.type = type;
            }

            internal static void Analyze(MemberInitExpression mie, PathBox pb)
            {
                Debug.Assert(mie != null, "mie != null");

                var epa = new EntityProjectionAnalyzer(pb, mie.Type);

                MemberAssignmentAnalysis targetEntityPath = null;
                foreach (MemberBinding mb in mie.Bindings)
                {
                    MemberAssignment ma = mb as MemberAssignment;
                    epa.Visit(ma.Expression);
                    if (ma != null)
                    {
                        var analysis = MemberAssignmentAnalysis.Analyze(pb.ParamExpressionInScope, ma.Expression);
                        if (analysis.IncompatibleAssignmentsException != null)
                        {
                            throw analysis.IncompatibleAssignmentsException;
                        }

                        Type targetType = GetMemberType(ma.Member);
                        Expression[] lastExpressions = analysis.GetExpressionsBeyondTargetEntity();
                        if (lastExpressions.Length == 0)
                        {
                            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, targetType, ma.Expression));
                        }

                        MemberExpression lastExpression = lastExpressions[lastExpressions.Length - 1] as MemberExpression;
                        Debug.Assert(
                            !analysis.MultiplePathsFound,
                            "!analysis.MultiplePathsFound -- the initializer has been visited, and cannot be empty, and expressions that can combine paths should have thrown exception during initializer analysis");
                        Debug.Assert(
                            lastExpression != null,
                            "lastExpression != null -- the initializer has been visited, and cannot be empty, and the only expressions that are allowed can be formed off the parameter, so this is always correlatd");
                        if (lastExpression != null && (lastExpression.Member.Name != ma.Member.Name))
                        {
                            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqPropertyNamesMustMatchInProjections, lastExpression.Member.Name, ma.Member.Name));
                        }

                        analysis.CheckCompatibleAssignments(mie.Type, ref targetEntityPath);

                        bool targetIsEntity = CommonUtil.IsClientType(targetType);
                        bool sourceIsEntity = CommonUtil.IsClientType(lastExpression.Type);
                        if (sourceIsEntity && !targetIsEntity)
                        {
                            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, targetType, ma.Expression));
                        }
                    }
                }
            }

            internal override Expression VisitUnary(UnaryExpression u)
            {
                Debug.Assert(u != null, "u != null");

                if (ResourceBinder.PatternRules.MatchConvertToAssignable(u))
                {
                    return base.VisitUnary(u);
                }

                if ((u.NodeType == ExpressionType.Convert) || (u.NodeType == ExpressionType.ConvertChecked))
                {
                    Type sourceType = Nullable.GetUnderlyingType(u.Operand.Type) ?? u.Operand.Type;
                    Type targetType = Nullable.GetUnderlyingType(u.Type) ?? u.Type;

                    if (ClientConvert.IsKnownType(sourceType) && ClientConvert.IsKnownType(targetType))
                    {
                        return base.Visit(u.Operand);
                    }
                }

                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, u.ToString()));
            }

            internal override Expression VisitBinary(BinaryExpression b)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, b.ToString()));
            }

            internal override Expression VisitTypeIs(TypeBinaryExpression b)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, b.ToString()));
            }

            internal override Expression VisitConditional(ConditionalExpression c)
            {
                var nullCheck = ResourceBinder.PatternRules.MatchNullCheck(box.ParamExpressionInScope, c);
                if (nullCheck.Match)
                {
                    Visit(nullCheck.AssignExpression);
                    return c;
                }

                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, c.ToString()));
            }

            internal override Expression VisitConstant(ConstantExpression c)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, c.ToString()));
            }

            internal override Expression VisitMemberAccess(MemberExpression m)
            {
                Debug.Assert(m != null, "m != null");

                if (!CommonUtil.IsClientType(m.Expression.Type))
                {
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, m.ToString()));
                }

                if (ResourceBinder.PatternRules.MatchNonPrivateReadableProperty(m, out PropertyInfo pi))
                {
                    Expression e = base.VisitMemberAccess(m);
                    box.AppendToPath(pi);
                    return e;
                }

                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, m.ToString()));
            }

            internal override Expression VisitMethodCall(MethodCallExpression m)
            {
                if (ProjectionAnalyzer.IsMethodCallAllowedEntitySequence(m))
                {
                    ProjectionAnalyzer.CheckChainedSequence(m, type);

                    return base.VisitMethodCall(m);
                }

                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, m.ToString()));
            }

            internal override Expression VisitInvocation(InvocationExpression iv)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, iv.ToString()));
            }

            internal override Expression VisitLambda(LambdaExpression lambda)
            {
                ProjectionAnalyzer.Analyze(lambda, box);
                return lambda;
            }

            internal override Expression VisitListInit(ListInitExpression init)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, init.ToString()));
            }

            internal override Expression VisitNewArray(NewArrayExpression na)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, na.ToString()));
            }

            internal override Expression VisitMemberInit(MemberInitExpression init)
            {
                ProjectionAnalyzer.Analyze(init, box);
                return init;
            }

            internal override NewExpression VisitNew(NewExpression nex)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjectionToEntity, type, nex.ToString()));
            }

            internal override Expression VisitParameter(ParameterExpression p)
            {
                if (p != box.ParamExpressionInScope)
                {
                    throw new NotSupportedException(SR.ALinqCanOnlyProjectTheLeaf);
                }

                box.StartNewPath();
                return p;
            }

            private static Type GetMemberType(MemberInfo member)
            {
                Debug.Assert(member != null, "member != null");

                PropertyInfo propertyInfo = member as PropertyInfo;
                if (propertyInfo != null)
                {
                    return propertyInfo.PropertyType;
                }

                FieldInfo fieldInfo = member as FieldInfo;
                Debug.Assert(fieldInfo != null, "fieldInfo != null -- otherwise Expression.Member factory should have thrown an argument exception");
                return fieldInfo.FieldType;
            }
        }

        private class NonEntityProjectionAnalyzer : DataServiceLinqExpressionVisitor
        {
            private PathBox box;

            private Type type;

            private NonEntityProjectionAnalyzer(PathBox pb, Type type)
            {
                box = pb;
                this.type = type;
            }

            internal static void Analyze(Expression e, PathBox pb)
            {
                var nepa = new NonEntityProjectionAnalyzer(pb, e.Type);


                if (e is MemberInitExpression mie)
                {
                    foreach (MemberBinding mb in mie.Bindings)
                    {
                        if (mb is MemberAssignment ma)
                        {
                            nepa.Visit(ma.Expression);
                        }
                    }
                }
                else
                {
                    nepa.Visit(e);
                }
            }

            internal override Expression VisitUnary(UnaryExpression u)
            {
                Debug.Assert(u != null, "u != null");

                if (!ResourceBinder.PatternRules.MatchConvertToAssignable(u))
                {
                    if (CommonUtil.IsClientType(u.Operand.Type))
                    {
                        throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, u.ToString()));
                    }
                }

                return base.VisitUnary(u);
            }

            internal override Expression VisitBinary(BinaryExpression b)
            {
                if (CommonUtil.IsClientType(b.Left.Type) || CommonUtil.IsClientType(b.Right.Type))
                {
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, b.ToString()));
                }

                return base.VisitBinary(b);
            }

            internal override Expression VisitTypeIs(TypeBinaryExpression b)
            {
                if (CommonUtil.IsClientType(b.Expression.Type))
                {
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, b.ToString()));
                }

                return base.VisitTypeIs(b);
            }

            internal override Expression VisitConditional(ConditionalExpression c)
            {
                var nullCheck = ResourceBinder.PatternRules.MatchNullCheck(box.ParamExpressionInScope, c);
                if (nullCheck.Match)
                {
                    Visit(nullCheck.AssignExpression);
                    return c;
                }

                if (CommonUtil.IsClientType(c.Test.Type) || CommonUtil.IsClientType(c.IfTrue.Type) || CommonUtil.IsClientType(c.IfFalse.Type))
                {
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, c.ToString()));
                }

                return base.VisitConditional(c);
            }

            internal override Expression VisitMemberAccess(MemberExpression m)
            {
                Debug.Assert(m != null, "m != null");

                if (ClientConvert.IsKnownNullableType(m.Expression.Type))
                {
                    return base.VisitMemberAccess(m);
                }

                if (!CommonUtil.IsClientType(m.Expression.Type))
                {
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, m.ToString()));
                }

                if (ResourceBinder.PatternRules.MatchNonPrivateReadableProperty(m, out PropertyInfo pi))
                {
                    Expression e = base.VisitMemberAccess(m);
                    box.AppendToPath(pi);
                    return e;
                }

                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, m.ToString()));
            }

            internal override Expression VisitMethodCall(MethodCallExpression m)
            {
                if (ProjectionAnalyzer.IsMethodCallAllowedEntitySequence(m))
                {
                    ProjectionAnalyzer.CheckChainedSequence(m, type);

                    return base.VisitMethodCall(m);
                }

                if ((m.Object != null && CommonUtil.IsClientType(m.Object.Type))
                    || m.Arguments.Any(a => CommonUtil.IsClientType(a.Type)))
                {
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, m.ToString()));
                }

                return base.VisitMethodCall(m);
            }

            internal override Expression VisitInvocation(InvocationExpression iv)
            {
                if (CommonUtil.IsClientType(iv.Expression.Type)
                    || iv.Arguments.Any(a => CommonUtil.IsClientType(a.Type)))
                {
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, iv.ToString()));
                }

                return base.VisitInvocation(iv);
            }

            internal override Expression VisitLambda(LambdaExpression lambda)
            {
                ProjectionAnalyzer.Analyze(lambda, box);
                return lambda;
            }

            internal override Expression VisitMemberInit(MemberInitExpression init)
            {
                ProjectionAnalyzer.Analyze(init, box);
                return init;
            }

            internal override NewExpression VisitNew(NewExpression nex)
            {
                if (CommonUtil.IsClientType(nex.Type))
                {
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, nex.ToString()));
                }

                return base.VisitNew(nex);
            }

            internal override Expression VisitParameter(ParameterExpression p)
            {
                if (p != box.ParamExpressionInScope)
                {
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, p.ToString()));
                }

                box.StartNewPath();
                return p;
            }

            internal override Expression VisitConstant(ConstantExpression c)
            {
                if (CommonUtil.IsClientType(c.Type))
                {
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqExpressionNotSupportedInProjection, type, c.ToString()));
                }

                return base.VisitConstant(c);
            }
        }

    }
}
