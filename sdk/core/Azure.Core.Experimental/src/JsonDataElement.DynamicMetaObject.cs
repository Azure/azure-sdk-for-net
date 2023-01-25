// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.Core.Dynamic
{
    public partial struct JsonDataElement : IDynamicMetaObjectProvider
    {
        internal static readonly MethodInfo GetPropertyMethod = typeof(JsonDataElement).GetMethod(nameof(GetProperty), BindingFlags.NonPublic | BindingFlags.Instance);
        internal static readonly MethodInfo SetDynamicMethod = typeof(JsonDataElement).GetMethod(nameof(SetDynamic), BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(object) }, null);

        // Binding machinery expects the call site signature to return an object
        internal object? SetDynamic(object value)
        {
            Set(value);
            return null;
        }

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

                Expression[] propertyNameArg = new Expression[] { Expression.Constant(binder.Name) };
                MethodCallExpression getPropertyCall = Expression.Call(this_, GetPropertyMethod, propertyNameArg);

                // Binding machinery expects the call site signature to return an object.
                UnaryExpression toObject = Expression.Convert(getPropertyCall, typeof(object));

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                return new DynamicMetaObject(toObject, restrictions);
            }

            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                UnaryExpression this_ = Expression.Convert(Expression, LimitType);

                Expression[] getPropertyArgs = new Expression[] { Expression.Constant(binder.Name) };
                MethodCallExpression getPropertyCall = Expression.Call(this_, GetPropertyMethod, getPropertyArgs);

                Expression[] setDynamicArgs = new Expression[] { Expression.Convert(value.Expression, typeof(object)) };
                MethodCallExpression setCall = Expression.Call(getPropertyCall, SetDynamicMethod, setDynamicArgs);

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(setCall, restrictions);
            }
        }
    }
}
