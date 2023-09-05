// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Dynamic;
using System.Linq.Expressions;

namespace Azure
{
    public readonly partial struct Variant : IDynamicMetaObjectProvider
    {
        /// <inheritdoc />
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) => new MetaObject(parameter, this);

        private class MetaObject : DynamicMetaObject
        {
            private readonly Variant _value;

            internal MetaObject(Expression parameter, IDynamicMetaObjectProvider value) : base(parameter, BindingRestrictions.Empty, value)
            {
                _value = (Variant)value;
            }

            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                Expression this_ = Expression.Convert(Expression, LimitType);
                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                if (binder.Type == typeof(Variant))
                {
                    return new DynamicMetaObject(this_, restrictions);
                }

                MethodCallExpression asMethod = Expression.Call(this_, nameof(As), new Type[] { binder.Type });
                return new DynamicMetaObject(asMethod, restrictions);
            }

            public override DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg)
            {
                Expression this_ = Expression.Convert(Expression, LimitType);
                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                if (binder.Operation == ExpressionType.Equal)
                {
                    MethodCallExpression valueAsArgType = Expression.Call(this_, nameof(As), new Type[] { arg.LimitType });
                    UnaryExpression arg_ = Expression.Convert(arg.Expression, arg.LimitType);
                    BinaryExpression equals = Expression.Equal(valueAsArgType, arg_);
                    UnaryExpression equalsAsObject = Expression.Convert(equals, typeof(object));

                    restrictions.Merge(BindingRestrictions.GetTypeRestriction(arg.Expression, arg.LimitType));
                    return new DynamicMetaObject(equalsAsObject, restrictions);
                }

                return base.BindBinaryOperation(binder, arg);
            }
        }
    }
}
