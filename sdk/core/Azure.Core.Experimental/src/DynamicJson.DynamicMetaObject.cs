// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.Core.Dynamic
{
    public partial class DynamicJson : IDynamicMetaObjectProvider
    {
        internal static readonly MethodInfo GetPropertyMethod = typeof(DynamicJson).GetMethod(nameof(GetProperty), BindingFlags.NonPublic | BindingFlags.Instance);
        internal static readonly MethodInfo SetMethod = typeof(DynamicJson).GetMethod(nameof(Set), BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(object) }, null);

        internal object GetProperty(string name)
        {
            return new DynamicJson(_element.GetProperty(name));
        }

        internal object? Set(object value)
        {
            switch (value)
            {
                case int i:
                    _element.Set(i);
                    break;
                case double d:
                    _element.Set(d);
                    break;
                case string s:
                    _element.Set(s);
                    break;
                case bool b:
                    _element.Set(b);
                    break;
                case MutableJsonElement e:
                    _element.Set(e);
                    break;
                default:
                    _element.Set(value);
                    break;

                    // TODO: add support for other supported types
            }

            // Binding machinery expects the call site signature to return an object
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

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(getPropertyCall, restrictions);
            }

            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                UnaryExpression this_ = Expression.Convert(Expression, LimitType);

                Expression[] getPropertyArgs = new Expression[] { Expression.Constant(binder.Name) };
                MethodCallExpression getPropertyCall = Expression.Call(this_, GetPropertyMethod, getPropertyArgs);

                UnaryExpression property = Expression.Convert(getPropertyCall, typeof(DynamicJson));

                Expression[] setDynamicArgs = new Expression[] { Expression.Convert(value.Expression, typeof(object)) };
                MethodCallExpression setCall = Expression.Call(property, SetMethod, setDynamicArgs);

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(setCall, restrictions);
            }
        }
    }
}
