// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;
using Azure.Data.Tables.Queryable;
using EntityActivator = System.Func<object[], object>;

namespace Azure.Data.Tables
{
    internal static class EntityUtilities
    {
        internal static object InstantiateEntityFromType(Type type)
        {
            EntityActivator activator = compiledActivators.GetOrAdd(type, GenerateActivator);
            return activator(null /* no params */);
        }

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

        private static ConcurrentDictionary<Type, EntityActivator> compiledActivators = new ConcurrentDictionary<Type, EntityActivator>();
    }
}
