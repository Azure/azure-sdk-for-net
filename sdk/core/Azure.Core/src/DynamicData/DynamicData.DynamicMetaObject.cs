// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using Azure.Core.Json;

namespace Azure.Core.Serialization
{
    public partial class DynamicData : IDynamicMetaObjectProvider
    {
        /// <inheritdoc />
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) => new MetaObject(parameter, this);

        internal const string SerializationRequiresUnreferencedCode = "This utilizes reflection-based JSON serialization and deserialization which is not compatible with trimming.";

        [RequiresUnreferencedCode(SerializationRequiresUnreferencedCode)]
        [RequiresDynamicCode(SerializationRequiresUnreferencedCode)]
        private class MetaObject : DynamicMetaObject
        {
            private DynamicData _value;

            internal MetaObject(Expression parameter, IDynamicMetaObjectProvider value) : base(parameter, BindingRestrictions.Empty, value)
            {
                _value = (DynamicData)value;
            }

            public override IEnumerable<string> GetDynamicMemberNames()
            {
                if (_value._element.ValueKind == JsonValueKind.Object)
                {
                    return _value._element.EnumerateObject().Select(p => p.Name);
                }

                return Array.Empty<string>();
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

                if (CastFromOperators.TryGetValue(binder.Type, out MethodInfo? castOperator))
                {
                    MethodCallExpression cast = Expression.Call(castOperator, this_);
                    return new DynamicMetaObject(cast, restrictions);
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
