// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Azure.ResourceManager.Moq
{
    internal static class ExpressionUtilities
    {
        /// <summary>
        /// Returns the MethodInfo, if the given expression is calling a method, and the method is an extension method.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        internal static MethodInfo? GetExtensionMethod(LambdaExpression expression)
        {
            if (expression.Body is MethodCallExpression methodCallExpression && methodCallExpression.Method.IsDefined(typeof(ExtensionAttribute), false))
            {
                return methodCallExpression.Method;
            }

            return null;
        }

        /// <summary>
        /// This method gets an lambda expression on one type, for instance, foo.DoSomething(argument)
        /// This method returns a new lambda expression bar.DoSomething(argument), where the type of bar is newType, and DoSomething is a method on newType with the same signature
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="newType"></param>
        /// <param name="newDelegateType"></param>
        /// <returns></returns>
        internal static LambdaExpression ChangeType(LambdaExpression expression, Type newType, Type newDelegateType)
        {
            if (TryChangeType(expression, newType, newDelegateType, out var newExpression) && newExpression != null)
                return newExpression;

            throw new InvalidOperationException($"The method in {expression} is not found on type {newType}");
        }

        internal static bool TryChangeType(LambdaExpression expression, Type newType, Type newDelegateType, out LambdaExpression? newExpression)
        {
            newExpression = null;
            // we will call this method inside Setup(Expression<Func<T, R>>) or Setup(Expression<Action<T>>)
            // therefore we will always have only one parameter
            var parameter = expression.Parameters.Single();
            // we should always ensure the body is methodCallExpression
            var methodCallExpression = (MethodCallExpression)expression.Body;
            var originalMethod = methodCallExpression.Method;
            var originalParameterTypes = originalMethod.GetParameters().Select(p => p.ParameterType);
            var originalArguments = methodCallExpression.Arguments;
            // find the new mthod with the same name and the same parameter list
            // here we skip the first parameter because the originalMethod here should only be an extension method
            var methodOnNewType = newType.GetMethod(originalMethod.Name, originalParameterTypes.Skip(1).ToArray());
            if (methodOnNewType is null)
            {
                return false;
            }
            var instanceExpression = Expression.Parameter(newType);
            var newMethodCallExpression = Expression.Call(instanceExpression, methodOnNewType, originalArguments.Skip(1));

            newExpression = Expression.Lambda(newDelegateType, newMethodCallExpression, instanceExpression);
            return true;
        }
    }
}