// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq.Expressions;
using System;
using Moq;
using Moq.Language.Flow;
using System.Reflection;
using System.Linq;

namespace Azure.ResourceManager.Resources.Testing
{
    /// <summary>
    /// Provides extensions to Moq.Mock{T}
    /// </summary>
    public static class MockingExtensions
    {
        private const string _mockingMethodName = "SetupAzureExtensionMethod";

        /// <summary>
        /// Because the APIs on azure will always return something (we never have a method that returns void), we only implements the `Expression{Func{T, R}}` version of the overload.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="mock"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static ISetup<T, R> SetupAzureExtensionMethod<T, R>(this Mock<T> mock, Expression<Func<T, R>> expression) where T : ArmResource // ISetup<TenantResource, R> => E
        {
            // we would like the customer to use this in this way:
            // tenantResourceMock.SetupAzureExtensionMethod(tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default)).Returns(Task.FromResult(Response.FromValue(mockResult, null)));
            // this setup method is accepting an expression: tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default), => tenantClient => tenantClient.CalculateDeploymentTemplateHashAsync(mockTemplate, default)
            // instead we need to hack it and create a new mock instance of the corresponding extension client (using reflection maybe)
            // for instance we get it like this: var tenantExtensionClient = new Mock<TenantExtensionClient>();
            // and then call this method instead:
            // tenantExtensionClient.Setup(tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default)) // using the same expression but change the type of the argument to extension client

            // first find the type name we are using in the expression
            var name = typeof(T).Name;
            // construct a new name from the above name to its corresponding extension client
            var extensionClientName = name + "ExtensionClient";
            // get the namespace of the current SDK dynamically
            var thisNamespace = typeof(MockingExtensions).Namespace;
            var ns = thisNamespace.Substring(0, thisNamespace.Length - 8);
            var extensionClientType = typeof(MockingExtensions).Assembly.GetType($"{ns}.{extensionClientName}");
            var methodInfo = extensionClientType.GetMethod(_mockingMethodName, BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeof(R));
            var newExpression = ChangeType(expression, extensionClientType);
            var intermediateSetup = methodInfo.Invoke(null, new object[] { mock, newExpression });

            return new AzureSetup<T, R>(intermediateSetup, extensionClientType);
        }

        private static Expression ChangeType<T, R>(Expression<Func<T, R>> expression, Type newType)
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

            return Expression.Lambda(newMethodCallExpression, instanceExpression);
        }
    }
}
