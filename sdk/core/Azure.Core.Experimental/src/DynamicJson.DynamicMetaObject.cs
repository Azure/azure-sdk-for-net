// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;

namespace Azure.Core.Dynamic
{
    public partial class DynamicJson : IDynamicMetaObjectProvider
    {
        private static readonly MethodInfo GetPropertyMethod = typeof(DynamicJson).GetMethod(nameof(GetProperty), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo SetPropertyMethod = typeof(DynamicJson).GetMethod(nameof(SetProperty), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo GetViaIndexerMethod = typeof(DynamicJson).GetMethod(nameof(GetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo SetViaIndexerMethod = typeof(DynamicJson).GetMethod(nameof(SetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance)!;

        private object GetProperty(string name)
        {
            return new DynamicJson(_element.GetProperty(name));
        }

        private object GetViaIndexer(object index)
        {
            switch (index)
            {
                case string propertyName:
                    return GetProperty(propertyName);
                case int arrayIndex:
                    return new DynamicJson(_element.GetIndexElement(arrayIndex));
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private object? SetProperty(string name, object value)
        {
            _element = _element.SetProperty(name, value);

            // Binding machinery expects the call site signature to return an object
			return null;
        }

        private object? SetViaIndexer(object index, object value)
        {
            switch (index)
            {
                case string propertyName:
                    return SetProperty(propertyName, value);
                case int arrayIndex:
                    MutableJsonElement element = _element.GetIndexElement(arrayIndex);
                    element.Set(value);
                    return new DynamicJson(element);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private T ConvertTo<T>()
        {
            // TODO: Respect user-provided serialization options

#if NET6_0_OR_GREATER
            return JsonSerializer.Deserialize<T>(_element.GetJsonElement(), MutableJsonDocument.DefaultJsonSerializerOptions)!;
#else
            // TODO: Could we optimize this by serializing from the byte array instead?  We don't currently slice into this in WriteTo(), but could look at storing that.
            return JsonSerializer.Deserialize<T>(_element.ToString(), MutableJsonDocument.DefaultJsonSerializerOptions);
#endif
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
                Expression targetObject = Expression.Convert(Expression, LimitType);
                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                Expression convertCall;

                //if (binder.Type == typeof(IEnumerable))
                //{
                //    convertCall = Expression.Call(targetObject, GetDynamicEnumerableMethod);
                //    return new DynamicMetaObject(convertCall, restrictions);
                //}

                if (CastFromOperators.TryGetValue(binder.Type, out MethodInfo? castOperator))
                {
                    convertCall = Expression.Call(castOperator, targetObject);
                    return new DynamicMetaObject(convertCall, restrictions);
                }

                convertCall = Expression.Call(targetObject, nameof(ConvertTo), new Type[] { binder.Type });
                return new DynamicMetaObject(convertCall, restrictions);
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
