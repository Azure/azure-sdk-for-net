// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if EXPERIMENTAL_DYNAMIC

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.Core
{
    /// <summary>
    /// Represents an untyped, structured document returned from or provided to
    /// service operations.  It can be accessed as either a dynamic object or a
    /// dictionary.
    /// </summary>
    public partial class DynamicData : IDynamicMetaObjectProvider
    {
        /// <summary>
        /// Initializes a new instance of the DynamicData class.
        /// </summary>
        public DynamicData() : this(null) { }

        /// <summary>
        /// Initializes a new instance of the DynamicData class with initial
        /// values.
        /// </summary>
        /// <param name="values">Initial values of the document.</param>
        public DynamicData(IDictionary<string, object> values) =>
            _values = values != null ?
                new Dictionary<string, object>(values) :
                new Dictionary<string, object>();

        /// <inheritdoc />
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) =>
            new MetaObject(parameter, this);

        /// <summary>
        /// Meta-object wrapping <see cref="DynamicData.GetValue(string, Type)"/>
        /// and <see cref="DynamicData.SetValue(string, object)"/>.
        ///
        /// Read "Implementing Dynamic Interfaces" by Bill Wagner for more
        /// information about what these meta-objects are doing.
        /// </summary>
        private class MetaObject : DynamicMetaObject
        {
            /// <summary>
            /// Reference to <see cref="DynamicData.GetValue(string, Type)"/>.
            /// </summary>
            private static readonly MethodInfo s_getter =
                typeof(DynamicData).GetMethod(
                    nameof(GetValue),
                    BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    new Type[] { typeof(string), typeof(Type) },
                    null);

            /// <summary>
            /// Reference to <see cref="DynamicData.SetValue(string, object)"/>.
            /// </summary>
            private static readonly MethodInfo s_setter =
                typeof(DynamicData).GetMethod(
                    nameof(SetValue),
                    BindingFlags.NonPublic | BindingFlags.Instance);

            /// <summary>
            /// Creates a new MetaObject.
            /// </summary>
            /// <param name="expression">The expression invoking the dynamic operation.</param>
            /// <param name="value">The <see cref="DynamicData"/> instance.</param>
            public MetaObject(Expression expression, IDynamicMetaObjectProvider value) :
                base(expression, BindingRestrictions.Empty, value)
            {
            }

            /// <summary>
            /// Build a dynamic meta-object that represents calling either
            /// GetValue(name, type) or SetValue(name, value).
            /// </summary>
            /// <param name="method">The method to invoke.</param>
            /// <param name="arguments">The argument expressions.</param>
            /// <returns>The meta-object for the invocation.</returns>
            private DynamicMetaObject BuildMetaObject(MethodInfo method, params Expression[] arguments) =>
                new DynamicMetaObject(
                    Expression.Call(
                        Expression.Convert(Expression, LimitType),
                        method,
                        arguments),
                    BindingRestrictions.GetTypeRestriction(Expression, LimitType));

            /// <inheritdoc />
            public override DynamicMetaObject BindGetMember(GetMemberBinder binder) =>
                BuildMetaObject(
                    s_getter,
                    Expression.Constant(binder.Name),
                    Expression.Constant(binder.ReturnType ?? typeof(object)));

            /// <inheritdoc />
            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value) =>
                BuildMetaObject(
                    s_setter,
                    Expression.Constant(binder.Name),
                    Expression.Convert(value.Expression, typeof(object)));
        }
    }
}
#endif
