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
        public static ISetup<T, R> SetupAzureExtensionMethod<T, R>(this Mock<T> mock, Expression<Func<T, R>> expression) where T : ArmResource
        {
            // we would like the customer to use this in this way:
            // tenantResourceMock.SetupAzureExtensionMethod(tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default)).Returns(Task.FromResult(Response.FromValue(mockResult, null)));
            // this setup method is accepting an expression: tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default), => tenantClient => tenantClient.CalculateDeploymentTemplateHashAsync(mockTemplate, default)
            // instead we need to hack it and create a new mock instance of the corresponding extension client (using reflection maybe)
            // for instance we get it like this: var tenantExtensionClient = new Mock<TenantExtensionClient>();
            // and then call this method instead:
            // tenantExtensionClient.Setup(tenant => tenant.CalculateDeploymentTemplateHashAsync(mockTemplate, default)) // using the same expression but change the type of the argument to extension client
            if (ExpressionUtilities.IsExtensionMethod(expression, out var extensionMethodInfo))
            {
                // find the type of extension client: using pattern: $"{T}Extension"
                // TODO -- update the pattern: $"{RPName}{T}Extension"
                var extensionClientName = typeof(T).Name + "ExtensionClient";
                var typeOfExtension = extensionMethodInfo.DeclaringType;
                // get the namespace of the current SDK dynamically
                var thisNamespace = typeOfExtension.Namespace;
                var extensionClientType = typeOfExtension.Assembly.GetType($"{thisNamespace}.{extensionClientName}");

                return mock.RedirectMock(expression, extensionClientType);
            }
            else
            {
                return mock.Setup(expression);
            }
        }

        private static Expression ChangeType<T, R>(Expression<Func<T, R>> expression, Type newType) where T : ArmResource
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

        internal static ISetup<T, R> RedirectMock<T, R>(this Mock<T> originalMock, Expression<Func<T, R>> expression, Type extensionClientType) where T : ArmResource
        {
            var newExpression = ExpressionUtilities.ChangeType(expression, extensionClientType);
            // create an intermediate mock - new Mock<TExtensionClient>()
            var intermediateMock = (Mock)Activator.CreateInstance(typeof(Mock<>).MakeGenericType(extensionClientType));
            // find the Setup(Expression<Func<T, TResult>>) method on the intermediateMock
            var setupWithReturn = GetSetupWithReturnMethod(intermediateMock.GetType(), typeof(R));

            // call Setup on the intermediate mock object
            var intermediateSetup = setupWithReturn.Invoke(intermediateMock, new object[] { newExpression });

            // call the Setup on the original mock object to Mock the GetCachedClient method
            // first get an instance of It.IsAny<Func<ArmClient, TExtensionClient>>
            var funcType = typeof(Func<,>).MakeGenericType(typeof(ArmClient), extensionClientType);
            var itIsAnyExpression = Expression.Call(isAnyMethod.MakeGenericMethod(funcType));

            // construct an expression of `tenant.GetCachedClient(itIsAnyResult)`
            var parameter = Expression.Parameter(typeof(T), "resource");
            var methodCallExpression = Expression.Call(parameter, "GetCachedClient", new[] { extensionClientType }, itIsAnyExpression);
            var getCachedClientExpression = Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(T), extensionClientType), methodCallExpression, parameter);

            // calling originalMock.Setup(tenant => tenant.GetCachedClient(It.IsAny<Func<ArmClient, TenantResourceExtensionClient>>()))
            setupWithReturn = GetSetupWithReturnMethod(typeof(Mock<T>), extensionClientType);
            var getCachedClientResult = setupWithReturn.Invoke(originalMock, new object[] { getCachedClientExpression });

            // get intermediateMock.Object
            var intermediateMockObject = intermediateMock.GetType().GetProperty("Object", extensionClientType).GetValue(intermediateMock);

            // call Returns on the getCachedClientResult
            var returnsMethod = getCachedClientResult.GetType().GetMethod("Returns", new[] { extensionClientType });
            returnsMethod.Invoke(getCachedClientResult, new object[] { intermediateMockObject });

            return new AzureSetupAdapter<T, R>(intermediateSetup);
        }

        private static readonly MethodInfo isAnyMethod = typeof(It).GetMethod(nameof(It.IsAny), BindingFlags.Public | BindingFlags.Static);

        private static readonly MethodInfo getCachedClientMethod = typeof(ArmResource).GetMethod("GetCachedClient", BindingFlags.Public | BindingFlags.Instance);

        private static MethodInfo GetSetupWithReturnMethod(Type mockType, Type typeOfReturn)
        {
            // find the Setup(Expression<Func<T, TResult>>) method on the Mock<T>
            var setupMethods = mockType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.Name == "Setup");
            var setupWithReturn = setupMethods.First(m => m.IsGenericMethod);
            var method = setupWithReturn.MakeGenericMethod(typeOfReturn);
            return method;
        }

        /// <summary>
        /// This method calls the method on _intermediateSetup with the same signature using the given arguments
        /// This implementation now has some issues, the GetCurrentMethod calling inside a method that belongs to a generic type always gives us a methodInfo with open generic parameters
        /// And since the generic parameters come from the type instead of the method, MethodInfo.MakeGenericType does not help
        /// </summary>
        /// <param name="intermediate"></param>
        /// <param name="currentMethod"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        internal static object RedirectMethodInvocation(object intermediate, MethodBase currentMethod, params object[] arguments)
        {
            var parameterTypes = currentMethod.GetParameters().Select(parameter => parameter.ParameterType).ToArray();
            // get the method with the same signature on _intermediateSetup
            var method = intermediate.GetType().GetMethod(currentMethod.Name, parameterTypes);
            return method.Invoke(intermediate, arguments);
        }

        internal static object RedirectMethodInvocation(object intermediate, string methodName, Type[] parameterTypes, object[] arguments)
        {
            var method = intermediate.GetType().GetMethod(methodName, parameterTypes);
            return method.Invoke(intermediate, arguments);
        }
    }
}
