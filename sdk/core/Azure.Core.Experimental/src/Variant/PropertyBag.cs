// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure
{
    /// <summary>
    /// Used to hold instances of Value as a dictionary and a dynamic.
    /// </summary>
    public class PropertyBag : Dictionary<string, Value>, IDynamicMetaObjectProvider
    {
        private static readonly MethodInfo GetPropertyMethod = typeof(PropertyBag).GetMethod(nameof(GetProperty), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo SetPropertyMethod = typeof(PropertyBag).GetMethod(nameof(SetProperty), BindingFlags.NonPublic | BindingFlags.Instance)!;

        private object GetProperty(string name)
        {
            // TODO: do it without boxing
            return this[name];
        }
        private object? SetProperty(string name, object value)
        {
            // TODO: do it without boxing
            this[name] = new(value);

            // Binding machinery expects the call site signature to return an object
            return null;
        }

        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) => new PropertyBagMetaObject(parameter, this);

        private class PropertyBagMetaObject : DynamicMetaObject
        {
            private PropertyBag _value;

            internal PropertyBagMetaObject(Expression parameter, IDynamicMetaObjectProvider value) : base(parameter, BindingRestrictions.Empty, value)
            {
                _value = (PropertyBag)value;
            }

            public override IEnumerable<string> GetDynamicMemberNames()
            {
                return _value.Keys;
            }

            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                UnaryExpression this_ = Expression.Convert(Expression, LimitType);

                Expression[] getPropertyArgs = new Expression[] { Expression.Constant(binder.Name) };
                MethodCallExpression getPropertyCall = Expression.Call(this_, GetPropertyMethod, getPropertyArgs);

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                // TODO: Idea - return a ValueMetaObject that handles all the conversions Value can handle?
                return new DynamicMetaObject(getPropertyCall, restrictions);
            }

            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                UnaryExpression this_ = Expression.Convert(Expression, LimitType);

                Expression[] setArgs = new Expression[] { Expression.Constant(binder.Name), Expression.Convert(value.Expression, typeof(object)) };
                MethodCallExpression setCall = Expression.Call(this_, SetPropertyMethod, setArgs);

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(setCall, restrictions);
            }
        }
    }
}
