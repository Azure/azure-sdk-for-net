// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Azure.Core;
using Azure.Data.Tables.Queryable;

namespace Azure.Data.Tables
{
    internal class TableQueryProvider : IQueryProvider
    {
        internal TableClient Table { get; private set; }

        public TableQueryProvider(TableClient table)
        {
            Table = table;
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            Argument.AssertNotNull(expression, nameof(expression));
            return new TableQuery<TElement>(expression, this);
        }

        public IQueryable CreateQuery(Expression expression)
        {
            //TODO: Improve this
            Argument.AssertNotNull(expression, nameof(expression));
            Type elementType = TypeSystem.GetElementType(expression.Type);

            Type queryType = typeof(TableQuery<>).MakeGenericType(elementType);
            object[] args = new object[] { expression, this };

            ConstructorInfo ci = queryType.GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new Type[] { typeof(Expression), typeof(TableQueryProvider) },
                null);

            return (IQueryable)ConstructorInvoke(ci, args);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining | System.Runtime.CompilerServices.MethodImplOptions.NoOptimization)]
        public object Execute(Expression expression)
        {
            Argument.AssertNotNull(expression, nameof(expression));

            return ReflectionUtil.TableQueryProviderReturnSingletonMethodInfo.MakeGenericMethod(expression.Type).Invoke(this, new object[] { expression });
        }

        public TResult Execute<TResult>(Expression expression)
        {
            Argument.AssertNotNull(expression, nameof(expression));

            return (TResult)ReflectionUtil.TableQueryProviderReturnSingletonMethodInfo.MakeGenericMethod(typeof(TResult)).Invoke(this, new object[] { expression });
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining | System.Runtime.CompilerServices.MethodImplOptions.NoOptimization)]
        internal static object ConstructorInvoke(ConstructorInfo constructor, object[] arguments)
        {
            if (constructor == null)
            {
                throw new MissingMethodException();
            }

            return constructor.Invoke(arguments);
        }
    }
}
