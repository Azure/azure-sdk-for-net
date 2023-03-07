// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.Core.Dynamic
{
    public partial class DynamicData
    {
        private static readonly MethodInfo GetPropertyMethod = typeof(DynamicData).GetMethod(nameof(GetProperty), BindingFlags.Public | BindingFlags.Instance)!;
        private static readonly MethodInfo SetPropertyMethod = typeof(DynamicData).GetMethod(nameof(SetProperty), BindingFlags.Public | BindingFlags.Instance)!;
        private static readonly MethodInfo GetEnumerableMethod = typeof(DynamicData).GetMethod(nameof(GetEnumerable), BindingFlags.Public | BindingFlags.Instance)!;
        private static readonly MethodInfo GetViaIndexerMethod = typeof(DynamicData).GetMethod(nameof(GetViaIndexer), BindingFlags.Public | BindingFlags.Instance)!;
        private static readonly MethodInfo SetViaIndexerMethod = typeof(DynamicData).GetMethod(nameof(SetViaIndexer), BindingFlags.Public | BindingFlags.Instance)!;

        /// <inheritdoc />
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) => new MetaObject(parameter, this);

        private class MetaObject : DynamicMetaObject
        {
            internal MetaObject(Expression parameter, IDynamicMetaObjectProvider value) : base(parameter, BindingRestrictions.Empty, value)
            {
            }

            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                UnaryExpression this_ = Expression.Convert(Expression, LimitType);

                Expression[] getPropertyArgs = new Expression[] { Expression.Constant(binder.Name) };
                MethodCallExpression getPropertyCall = Expression.Call(this_, GetPropertyMethod, getPropertyArgs);

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(getPropertyCall, restrictions);
            }

            public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
            {
                UnaryExpression this_ = Expression.Convert(Expression, LimitType);

                Expression[] arguments = new Expression[] { Expression.Convert(indexes[0].Expression, typeof(object)) };
                MethodCallExpression getViaIndexerCall = Expression.Call(this_, GetViaIndexerMethod, arguments);

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(getViaIndexerCall, restrictions);
            }

            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                Expression this_ = Expression.Convert(Expression, LimitType);
                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                if (binder.Type == typeof(IEnumerable))
                {
                    MethodCallExpression getEnumerable = Expression.Call(this_, GetEnumerableMethod);
                    return new DynamicMetaObject(getEnumerable, restrictions);
                }

                if (binder.Type == typeof(IDisposable))
                {
                    UnaryExpression makeIDisposable = Expression.Convert(this_, binder.Type);
                    return new DynamicMetaObject(makeIDisposable, restrictions);
                }

                MethodCallExpression convertTo = Expression.Call(this_, nameof(ConvertTo), new Type[] { binder.Type });
                return new DynamicMetaObject(convertTo, restrictions);
            }

            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                UnaryExpression this_ = Expression.Convert(Expression, LimitType);

                Expression[] setArgs = new Expression[] { Expression.Constant(binder.Name), Expression.Convert(value.Expression, typeof(object)) };
                MethodCallExpression setCall = Expression.Call(this_, SetPropertyMethod, setArgs);

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(setCall, restrictions);
            }

            public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value)
            {
                UnaryExpression this_ = Expression.Convert(Expression, LimitType);

                Expression[] setArgs = new Expression[2] {
                    Expression.Convert(indexes[0].Expression, typeof(object)),
                    Expression.Convert(value.Expression, typeof(object))
                };
                MethodCallExpression setCall = Expression.Call(this_, SetViaIndexerMethod, setArgs);

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(setCall, restrictions);
            }
        }
    }
}
