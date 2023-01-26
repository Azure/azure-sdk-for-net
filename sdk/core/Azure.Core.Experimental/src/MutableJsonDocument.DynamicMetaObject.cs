// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.Core.Dynamic
{
    public partial class MutableJsonDocument : IDynamicMetaObjectProvider
    {
        /// <inheritdoc />
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) => new MetaObject(parameter, this);

        private class MetaObject : DynamicMetaObject
        {
            //private static readonly MethodInfo GetDynamicValueMethod = typeof(JsonData).GetMethod(nameof(GetDynamicPropertyValue), BindingFlags.NonPublic | BindingFlags.Instance)!;

            //private static readonly MethodInfo GetDynamicEnumerableMethod = typeof(JsonData).GetMethod(nameof(GetDynamicEnumerable), BindingFlags.NonPublic | BindingFlags.Instance);

            //private static readonly MethodInfo SetValueMethod = typeof(JsonData).GetMethod(nameof(SetValue), BindingFlags.NonPublic | BindingFlags.Instance);

            //private static readonly MethodInfo GetViaIndexerMethod = typeof(JsonData).GetMethod(nameof(GetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance)!;

            //private static readonly MethodInfo SetViaIndexerMethod = typeof(JsonData).GetMethod(nameof(SetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance);

            //// Operators that cast from JsonData to another type
            //private static readonly Dictionary<Type, MethodInfo> CastFromOperators = GetCastFromOperators();

            internal MetaObject(Expression parameter, IDynamicMetaObjectProvider value) : base(parameter, BindingRestrictions.Empty, value)
            {
            }

            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                UnaryExpression this_ = Expression.Convert(Expression, LimitType);
                MemberExpression rootElement = Expression.Property(this_, "RootElement");

                Expression[] arguments = new Expression[] { Expression.Constant(binder.Name) };
                MethodCallExpression getPropertyCall = Expression.Call(rootElement, MutableJsonElement.GetPropertyMethod, arguments);

                // Binding machinery expects the call site signature to return an object.
                UnaryExpression toObject = Expression.Convert(getPropertyCall, typeof(object));

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(toObject, restrictions);
            }

            //public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
            //{
            //    var targetObject = Expression.Convert(Expression, LimitType);
            //    var arguments = new Expression[] { Expression.Convert(indexes[0].Expression, typeof(object)) };
            //    var getViaIndexerCall = Expression.Call(targetObject, GetViaIndexerMethod, arguments);

            //    var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
            //    return new DynamicMetaObject(getViaIndexerCall, restrictions);
            //}

            //public override DynamicMetaObject BindConvert(ConvertBinder binder)
            //{
            //    Expression targetObject = Expression.Convert(Expression, LimitType);
            //    BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

            //    Expression convertCall;

            //    //if (binder.Type == typeof(IEnumerable))
            //    //{
            //    //    convertCall = Expression.Call(targetObject, GetDynamicEnumerableMethod);
            //    //    return new DynamicMetaObject(convertCall, restrictions);
            //    //}

            //    if (CastFromOperators.TryGetValue(binder.Type, out MethodInfo? castOperator))
            //    {
            //        convertCall = Expression.Call(castOperator, targetObject);
            //        return new DynamicMetaObject(convertCall, restrictions);
            //    }

            //    convertCall = Expression.Call(targetObject, nameof(To), new Type[] { binder.Type });
            //    return new DynamicMetaObject(convertCall, restrictions);
            //}

            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                UnaryExpression this_ = Expression.Convert(Expression, LimitType);
                MemberExpression rootElement = Expression.Property(this_, "RootElement");

                Expression[] getPropertyArgs = new Expression[] { Expression.Constant(binder.Name) };
                MethodCallExpression getPropertyCall = Expression.Call(rootElement, MutableJsonElement.GetPropertyMethod, getPropertyArgs);

                Expression[] setDynamicArgs = new Expression[] { Expression.Convert(value.Expression, typeof(object)) };
                MethodCallExpression setCall = Expression.Call(getPropertyCall, MutableJsonElement.SetDynamicMethod, setDynamicArgs);

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(setCall, restrictions);
            }

            //public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value)
            //{
            //    var targetObject = Expression.Convert(Expression, LimitType);
            //    var arguments = new Expression[2] {
            //        Expression.Convert(indexes[0].Expression, typeof(object)),
            //        Expression.Convert(value.Expression, typeof(object))
            //    };
            //    var setCall = Expression.Call(targetObject, SetViaIndexerMethod, arguments);

            //    var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
            //    return new DynamicMetaObject(setCall, restrictions);
            //}

            //private static Dictionary<Type, MethodInfo> GetCastFromOperators()
            //{
            //    return typeof(JsonData)
            //        .GetMethods(BindingFlags.Public | BindingFlags.Static)
            //        .Where(method => method.Name == "op_Explicit" || method.Name == "op_Implicit")
            //        .ToDictionary(method => method.ReturnType);
            //}
        }
    }
}
