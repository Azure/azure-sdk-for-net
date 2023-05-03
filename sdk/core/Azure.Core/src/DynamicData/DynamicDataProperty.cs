// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text.Json;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Represents a single property on a dynamic JSON object.
    /// </summary>
    internal readonly struct DynamicDataProperty : IDynamicMetaObjectProvider
    {
        internal DynamicDataProperty(string name, DynamicData value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets the name of this property.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of this property.
        /// </summary>
        public DynamicData Value { get; }

        /// <inheritdoc />
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) => new MetaObject(parameter, this);

        private class MetaObject : DynamicMetaObject
        {
            private static readonly string[] _memberNames = new string[] { "Name", "Value" };

            internal MetaObject(Expression parameter, IDynamicMetaObjectProvider value) : base(parameter, BindingRestrictions.Empty, value)
            {
            }

            public override IEnumerable<string> GetDynamicMemberNames()
            {
                return _memberNames;
            }

            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                UnaryExpression this_ = Expression.Convert(Expression, LimitType);
                MemberExpression property = Expression.Property(this_, binder.Name);

                //Expression[] getPropertyArgs = new Expression[] { Expression.Constant(binder.Name) };
                //MethodCallExpression getPropertyCall = Expression.Call(this_, GetPropertyMethod, getPropertyArgs);

                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(property, restrictions);
            }
        }
    }
}
