// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Azure.ResourceManager.Resources.Testing
{
    internal static class ExpressionUtilities
    {
        internal static bool IsExtensionMethod<T, R>(Expression<Func<T, R>> expression)
        {
            var parameter = expression.Parameters.Single(); // since the expression is strong-typed, this is guaranteed
            if (expression.Body is not MethodCallExpression methodCallExpression)
            {
                throw new InvalidOperationException("We only support methodCallExpression as the body of lambda expression for now");
            }
            return methodCallExpression.Method.IsDefined(typeof(ExtensionAttribute), false);
        }

        internal static Expression ChangeType<T, R>(Expression<Func<T, R>> expression, Type newType) where T : ArmResource
        {
            // we only support one parameter
            var parameter = expression.Parameters.Single();
            var body = expression.Body;
            if (body is not MethodCallExpression methodCallExpression)
            {
                throw new InvalidOperationException("We only support methodCallExpression as the body of lambda expression for now");
            }
            var originalMethod = methodCallExpression.Method;
            var originalParameterTypes = originalMethod.GetParameters().Select(p => p.ParameterType);
            var originalArguments = methodCallExpression.Arguments;
            // find the new method with the same name from the newType
            var methodInfo = newType.GetMethod(originalMethod.Name, originalParameterTypes.Skip(1).ToArray());
            // construct a new method call expression on the method with the same name from the newType
            if (methodInfo is null)
            {
                throw new InvalidOperationException($"The method {originalMethod} is not found on type {newType}");
            }
            var instanceExpression = Expression.Parameter(newType);
            var newMethodCallExpression = Expression.Call(instanceExpression, methodInfo, originalArguments.Skip(1));

            return Expression.Lambda(newMethodCallExpression, instanceExpression);
        }
    }
}
