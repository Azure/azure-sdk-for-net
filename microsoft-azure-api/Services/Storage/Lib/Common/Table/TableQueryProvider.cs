// -----------------------------------------------------------------------------------------
// <copyright file="TableQueryProvider.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Table
{
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Table.Queryable;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    internal class TableQueryProvider : IQueryProvider
    {
        internal CloudTable Table { get; private set; }

        public TableQueryProvider(CloudTable table)
        {
            this.Table = table;
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            CommonUtility.AssertNotNull("expression", expression);
            return new TableQuery<TElement>(expression, this);
        }

        public IQueryable CreateQuery(Expression expression)
        {
            CommonUtility.AssertNotNull("expression", expression);
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
            CommonUtility.AssertNotNull("expression", expression);
            
            return ReflectionUtil.TableQueryProviderReturnSingletonMethodInfo.MakeGenericMethod(expression.Type).Invoke(this, new object[] { expression });
        }

        public TResult Execute<TResult>(Expression expression)
        {
            CommonUtility.AssertNotNull("expression", expression);

            return (TResult)ReflectionUtil.TableQueryProviderReturnSingletonMethodInfo.MakeGenericMethod(typeof(TResult)).Invoke(this, new object[] { expression });
        }

        internal TElement ReturnSingleton<TElement>(Expression expression)
        {
            IQueryable<TElement> query = new TableQuery<TElement>(expression, this);

            MethodCallExpression mce = expression as MethodCallExpression;

            SequenceMethod sequenceMethod;
            if (ReflectionUtil.TryIdentifySequenceMethod(mce.Method, out sequenceMethod))
            {
                switch (sequenceMethod)
                {
                    case SequenceMethod.Single:
                        return query.AsEnumerable().Single();
                    case SequenceMethod.SingleOrDefault:
                        return query.AsEnumerable().SingleOrDefault();
                    case SequenceMethod.First:
                        return query.AsEnumerable().First();
                    case SequenceMethod.FirstOrDefault:
                        return query.AsEnumerable().FirstOrDefault();
/*
if !ASTORIA_LIGHT
                    case SequenceMethod.LongCount:
                    case SequenceMethod.Count:
                        return (TElement)Convert.ChangeType(((TableQuery<TElement>)query).GetQuerySetCount(this.Context), typeof(TElement), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
#endif                   
*/
                }
            }

            throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, SR.ALinqMethodNotSupported, mce.Method.Name));
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining | System.Runtime.CompilerServices.MethodImplOptions.NoOptimization)]
        internal static object ConstructorInvoke(ConstructorInfo constructor, object[] arguments)
        {
            if (constructor == null)
            {
                throw new MissingMethodException();
            }

#if ASTORIA_LIGHT && !ASTORIA_LIGHT_WP
            int argumentCount = (arguments == null) ? 0 : arguments.Length;
            ParameterExpression argumentsExpression = Expression.Parameter(typeof(object[]), "arguments");
            Expression[] argumentExpressions = new Expression[argumentCount];
            ParameterInfo[] parameters = constructor.GetParameters();
            for (int i = 0; i < argumentExpressions.Length; i++)
            {
                argumentExpressions[i] = Expression.Constant(arguments[i], parameters[i].ParameterType);
            }

            Expression newExpression = Expression.New(constructor, argumentExpressions);
            Expression<Func<object[], object>> lambda = Expression.Lambda<Func<object[], object>>(
                Expression.Convert(newExpression, typeof(object)),
                argumentsExpression);
            object result = lambda.Compile()(arguments);
            return result;
#else
            return constructor.Invoke(arguments);
#endif
        }
    }
}
