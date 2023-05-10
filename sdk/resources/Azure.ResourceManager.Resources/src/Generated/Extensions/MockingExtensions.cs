// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq.Expressions;
using System;
using Moq;
using System.Reflection;
using System.Linq;

namespace Azure.ResourceManager.Resources.Mocking
{
    internal static class MockingExtensions
    {
        internal static Mock<T> SetupAzureExtensionMethod<T>(this Mock<T> mock, Expression<Action<T>> expression) where T : ArmResource
        {
            // we would like the customer to use this in this way:
            // tenantResourceMock.SetupAzureExtensionMethod(tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default)).Returns(Task.FromResult(Response.FromValue(mockResult, null)));
            // this setup method is accepting an expression: tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default),
            // instead we need to hack it and create a new mock instance of the corresponding extension client (using reflection maybe)
            // for instance we get it like this: var tenantExtensionClient = new Mock<TenantExtensionClient>();
            // and then call this method instead:
            // tenantExtensionClient.Setup(tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default)) // using the same expression but change the type of the argument to extension client

            // first find the type name we are using in the expression
            var name = typeof(T).Name;
            // construct a new name from the above name to its corresponding extension client
            var extensionClientName = name + "ExtensionClient";
            // TODO -- get the namespace of the current SDK dynamically
            var ns = "Azure.ResourceManager.Resources"; // maybe we need to find the extension method and get the namespace of its containing type
            var extensionClientType = Type.GetType($"{ns}.{extensionClientName}");

            var newMockType = typeof(Mock<>).MakeGenericType(extensionClientType);
            var ctor = newMockType.GetConstructor(Array.Empty<Type>());
            var newMock = ctor.Invoke(Array.Empty<object>());
            var parameterType = typeof(Expression<>).MakeGenericType(typeof(Action<>).MakeGenericType(extensionClientType));
            var setupMethod = newMockType.GetMethod("Setup", new[] { parameterType });

            // construct a new expression using the parameter of the new type from the old "expression"
            var newExpression = ChangeType(expression, extensionClientType);
            setupMethod.Invoke(newMock, new[] { newExpression });
            // TODO -- call the result method to set the return value if any.

            //mock.Setup(t => t.GetCachedClient(It.IsAny<Func<ArmClient, XXXExtensionClient>>()));
            // first create a Matcher to match anything like Func<ArmClient, XXXExtensionClient>
            var funcType = typeof(Func<,>).MakeGenericType(typeof(ArmClient), extensionClientType);
            // then create the matcher by calling the method It.IsAny<Func<ArmClient, XXXExtensionClient>>() using reflection
            var matcher = typeof(It).GetMethod("IsAny", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(funcType).Invoke(null, Array.Empty<object>());
            // put the matcher into the Setup method of Mock<T> to set it up
            parameterType = typeof(Expression<>).MakeGenericType(funcType);
            setupMethod = mock.GetType().GetMethod("Setup", new[] { parameterType });
            // build the expression that represents this: `t => t.GetCachedClient(It.IsAny<Func<ArmClient, XXXExtensionClient>>())`
            newExpression = ConstructGetCachedClientExpression(funcType, extensionClientType, matcher);
            setupMethod.Invoke(mock, new[] { newExpression });

            return mock;
        }

        private static Expression ConstructGetCachedClientExpression(Type delegateType, Type extensionClientType, object matcher)
        {
            var parameter = Expression.Parameter(typeof(ArmClient), "client");
            var method = typeof(ArmResource).GetMethod("GetCachedClient", BindingFlags.Instance | BindingFlags.Public).MakeGenericMethod(extensionClientType);
            var argument = Expression.Constant(matcher, delegateType);
            var methodCallExpression = Expression.Call(parameter, method, argument);
            return Expression.Lambda(delegateType, methodCallExpression, parameter);
        }

        private static Expression ChangeType<T>(Expression<Action<T>> expression, Type newType)
        {
            // we only support one parameter
            var parameter = expression.Parameters.Single();
            var body = expression.Body;
            if (body is not MethodCallExpression methodCallExpression)
            {
                throw new InvalidOperationException("We only support methodCallExpression as the body of lambda expression for now");
            }
            // TODO -- add some validation on the method, to ensure it is an extension method on an ArmResource
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

            // get the delegate type
            var delegateType = typeof(Action<>).MakeGenericType(newType);
            return Expression.Lambda(delegateType, newMethodCallExpression, instanceExpression);
        }
    }
}
