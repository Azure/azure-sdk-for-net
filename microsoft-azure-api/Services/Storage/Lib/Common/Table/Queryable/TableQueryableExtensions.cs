// -----------------------------------------------------------------------------------------
// <copyright file="TableQueryableExtensions.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table.Queryable
{
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Provides a set of extension methods for objects of type <see cref="TableQuery"/>.
    /// </summary>
    public static class TableQueryableExtensions
    {
        internal static MethodInfo WithOptionsMethodInfo { get; set; }

        internal static MethodInfo WithContextMethodInfo { get; set; }

        internal static MethodInfo ResolveMethodInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = "Re-using method info collection improves performance.")]
        static TableQueryableExtensions()
        {
            Type extensionType = typeof(TableQueryableExtensions);
            MethodInfo[] methods = extensionType.GetMethods(BindingFlags.Public | BindingFlags.Static);

            TableQueryableExtensions.WithOptionsMethodInfo = methods.Where(m => m.Name == "WithOptions").FirstOrDefault();
            TableQueryableExtensions.WithContextMethodInfo = methods.Where(m => m.Name == "WithContext").FirstOrDefault();
            TableQueryableExtensions.ResolveMethodInfo = methods.Where(m => m.Name == "Resolve").FirstOrDefault();
        }

        /// <summary>
        /// Specifies a set of <see cref="TableRequestOptions"/> on the query.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <param name="query">A query that implements <see cref="IQueryable{TElement}"/>.</param>
        /// <param name="options">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <returns>A <see cref="TableQuery"/> object with the specified request options set.</returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public static TableQuery<TElement> WithOptions<TElement>(this IQueryable<TElement> query, TableRequestOptions options)
        {
            CommonUtility.AssertNotNull("options", options);

            if (!(query is TableQuery<TElement>))
            {
                throw new NotSupportedException(SR.IQueryableExtensionObjectMustBeTableQuery);
            }

            return (TableQuery<TElement>)query.Provider.CreateQuery<TElement>(Expression.Call(
                                                null,
                                               TableQueryableExtensions.WithOptionsMethodInfo.MakeGenericMethod(new Type[] { typeof(TElement) }),
                                                new Expression[] { query.Expression, Expression.Constant(options, typeof(TableRequestOptions)) }));
        }

        /// <summary>
        /// Specifies an <see cref="OperationContext"/> for the query.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <param name="query">A query that implements <see cref="IQueryable{TElement}"/>.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="TableQuery"/> object with the specified operation context.</returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public static TableQuery<TElement> WithContext<TElement>(this IQueryable<TElement> query, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("operationContext", operationContext);

            if (!(query is TableQuery<TElement>))
            {
                throw new NotSupportedException(SR.IQueryableExtensionObjectMustBeTableQuery);
            }

            return (TableQuery<TElement>)query.Provider.CreateQuery<TElement>(Expression.Call(
                                                null,
                                                TableQueryableExtensions.WithContextMethodInfo.MakeGenericMethod(new Type[] { typeof(TElement) }),
                                                new Expression[] { query.Expression, Expression.Constant(operationContext, typeof(OperationContext)) }));
        }

        /// <summary>
        /// Specifies an entity resolver for the query.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <typeparam name="TResolved">The type of the resolver.</typeparam>
        /// <param name="query">A query that implements <see cref="IQueryable{TElement}"/>.</param>
        /// <param name="resolver">The entity resolver, of type <see cref="EntityResolver{TResolved}"/>.</param>
        /// <returns>A <see cref="TableQuery"/> with the specified resolver.</returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public static TableQuery<TResolved> Resolve<TElement, TResolved>(this IQueryable<TElement> query, EntityResolver<TResolved> resolver)
        {
            CommonUtility.AssertNotNull("resolver", resolver);

            if (!(query is TableQuery<TElement>))
            {
                throw new NotSupportedException(SR.IQueryableExtensionObjectMustBeTableQuery);
            }

            return (TableQuery<TResolved>)query.Provider.CreateQuery<TResolved>(Expression.Call(
                                                null,
                                                TableQueryableExtensions.ResolveMethodInfo.MakeGenericMethod(new Type[] { typeof(TElement), typeof(TResolved) }),
                                                new Expression[] { query.Expression, Expression.Constant(resolver, typeof(EntityResolver<TResolved>)) }));
        }

        /// <summary>
        /// Specifies that a query be returned as a <see cref="TableQuery"/> object.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <param name="query">A query that implements <see cref="IQueryable{TElement}"/>.</param>
        /// <returns>An object of type <see cref="TableQuery"/>.</returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public static TableQuery<TElement> AsTableQuery<TElement>(this IQueryable<TElement> query)
        {
            TableQuery<TElement> retQuery = query as TableQuery<TElement>;

            if (retQuery == null)
            {
                throw new NotSupportedException(SR.IQueryableExtensionObjectMustBeTableQuery);
            }

            return retQuery;
        }
    }
}
