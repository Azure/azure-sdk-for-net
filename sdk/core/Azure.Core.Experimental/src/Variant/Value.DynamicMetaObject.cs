// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text;

namespace Azure
{
    public readonly partial struct Value : IDynamicMetaObjectProvider
    {
        /// <inheritdoc />
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) => new MetaObject(parameter, this);

        private class MetaObject : DynamicMetaObject
        {
            private readonly Value _value;

            internal MetaObject(Expression parameter, IDynamicMetaObjectProvider value) : base(parameter, BindingRestrictions.Empty, value)
            {
                _value = (Value)value;
            }

            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                Expression this_ = Expression.Convert(Expression, LimitType);
                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                if (binder.Type == typeof(Value))
                {
                    return new DynamicMetaObject(this_, restrictions);
                }

                MethodCallExpression asMethod = Expression.Call(this_, nameof(As), new Type[] { binder.Type });
                return new DynamicMetaObject(asMethod, restrictions);
            }
        }
    }
}
