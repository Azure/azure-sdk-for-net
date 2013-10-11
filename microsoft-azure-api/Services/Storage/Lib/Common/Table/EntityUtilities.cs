// -----------------------------------------------------------------------------------------
// <copyright file="EntityUtilities.cs" company="Microsoft">
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
    using System;
    using System.Collections.Generic;
#if WINDOWS_DESKTOP && !WINDOWS_PHONE
    using System.Collections.Concurrent;
    using System.Linq.Expressions;
    using System.Reflection;
    using EntityActivator = System.Func<object[], object>;
    using Microsoft.WindowsAzure.Storage.Core;
#endif

    internal static class EntityUtilities
    {
        internal static TElement ResolveEntityByType<TElement>(string partitionKey, string rowKey, DateTimeOffset timestamp, IDictionary<string, EntityProperty> properties, string etag)
        {
            ITableEntity entity = (ITableEntity)InstantiateEntityFromType(typeof(TElement));

            entity.PartitionKey = partitionKey;
            entity.RowKey = rowKey;
            entity.Timestamp = timestamp;
            entity.ReadEntity(properties, null);
            entity.ETag = etag;

            return (TElement)entity;
        }

        internal static DynamicTableEntity ResolveDynamicEntity(string partitionKey, string rowKey, DateTimeOffset timestamp, IDictionary<string, EntityProperty> properties, string etag)
        {
            DynamicTableEntity entity = new DynamicTableEntity(partitionKey, rowKey);
            entity.Timestamp = timestamp;
            entity.ReadEntity(properties, null);
            entity.ETag = etag;

            return entity;
        }

#if WINDOWS_DESKTOP && !WINDOWS_PHONE
        internal static object InstantiateEntityFromType(Type type)
        {
            EntityActivator activator = compiledActivators.GetOrAdd(type, GenerateActivator);
            return activator(null /* no params */);
        }
#else
        internal static object InstantiateEntityFromType(Type type)
        {
            return Activator.CreateInstance(type);
        }
#endif

#if WINDOWS_DESKTOP && !WINDOWS_PHONE
        private static EntityActivator GenerateActivator(Type type)
        {
            // Generate activator for parameterless constructor
            return GenerateActivator(type, System.Type.EmptyTypes);
        }

        private static EntityActivator GenerateActivator(Type type, Type[] ctorParamTypes)
        {
            ConstructorInfo constructorInfo = type.GetConstructor(ctorParamTypes);
            if (constructorInfo == null)
            {
                throw new InvalidOperationException(SR.TableQueryTypeMustHaveDefaultParameterlessCtor);
            }

            ParameterInfo[] parameterInfos = constructorInfo.GetParameters();

            // Create a single param of type object[]
            ParameterExpression parameterExpression = Expression.Parameter(typeof(object[]), "args");
            Expression[] argsExp = new Expression[parameterInfos.Length];

            // Pick each arg from the params array and create a typed expression of them
            for (int i = 0; i < parameterInfos.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = parameterInfos[i].ParameterType;
                Expression paramAccessorExp = Expression.ArrayIndex(parameterExpression, index);
                Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);
                argsExp[i] = paramCastExp;
            }

            // Make a NewExpression that calls the ctor with the args we just created
            NewExpression newExpression = Expression.New(constructorInfo, argsExp);

            // Create a lambda with the New Expression as body and our param object[] as arg
            LambdaExpression lambda = Expression.Lambda(typeof(EntityActivator), newExpression, parameterExpression);

            // Compile it
            return (EntityActivator)lambda.Compile();
        }

        // Per http://blogs.msdn.com/b/pfxteam/archive/2011/11/08/10235147.aspx not specifying default concurrency to allow for dynamic lock allocation based on size
        private static ConcurrentDictionary<Type, EntityActivator> compiledActivators = new ConcurrentDictionary<Type, EntityActivator>();
#endif
    }
}
