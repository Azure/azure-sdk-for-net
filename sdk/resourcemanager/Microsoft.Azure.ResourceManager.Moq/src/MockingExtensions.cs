// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq.Expressions;
using System;
using Moq;
using Moq.Language.Flow;
using System.Reflection;
using System.Linq;
using System.Collections.Concurrent;

namespace Azure.ResourceManager.Moq
{
    /// <summary>
    /// Provides extensions to Moq.Mock{T}
    /// </summary>
    public static class MockingExtensions
    {
        internal static Type FindExtensionType(Type extendedType, MethodInfo extensionMethodInfo)
        {
            // find the type of extension client: using pattern: $"{T}Extension"
            // TODO -- update the pattern: $"{RPName}{T}Extension"
            var extensionClientName = extendedType.Name + MockingExtensionNameSuffix;
            var typeOfExtension = extensionMethodInfo.DeclaringType;
            // get the namespace of the current SDK dynamically
            var thisNamespace = $"{typeOfExtension.Namespace}.{MockingNamespaceSuffix}";
            return typeOfExtension.Assembly.GetType($"{thisNamespace}.{extensionClientName}");
        }

        private static string GetRPName(string @namespace)
        {

        }

        internal static ISetup<T> RedirectMock<T>(this Mock<T> originalMock, Expression<Action<T>> expression, Type extensionClientType) where T : class
        {
            var newDelegateType = typeof(Action<>).MakeGenericType(extensionClientType);
            var newExpression = ExpressionUtilities.ChangeType(expression, extensionClientType, newDelegateType);

            // create an intermediate mock - new Mock<TExtensionClient>()
            var intermediateMockType = typeof(Mock<>).MakeGenericType(extensionClientType);
            var intermediateMock = Activator.CreateInstance(intermediateMockType);
            // find the Setup(Expression<Action<T>>) method on the intermediateMock
            var setupWithoutReturn = GetSetupWithoutReturnMethod(intermediateMockType, newDelegateType);

            // call Setup on the intermediate mock object
            var intermediateSetup = setupWithoutReturn.Invoke(intermediateMock, new object[] { newExpression });

            // get intermediateMock.Object
            var intermediateMockObject = intermediateMock.GetType().GetProperty("Object", extensionClientType).GetValue(intermediateMock);

            MockGetCachedClient(originalMock, extensionClientType, intermediateMockObject);

            return new AzureVoidAdapter<T>(intermediateSetup);
        }

        internal static ISetup<T, R> RedirectMock<T, R>(this Mock<T> originalMock, Expression<Func<T, R>> expression, Type extensionClientType) where T : class
        {
            var newDelegateType = typeof(Func<,>).MakeGenericType(extensionClientType, typeof(R));
            var newExpression = ExpressionUtilities.ChangeType(expression, extensionClientType, newDelegateType);

            // create an intermediate mock - new Mock<TExtensionClient>()
            var intermediateMock = _cache.GetOrAdd(originalMock, mock => ConstructIntermediateMock(originalMock, extensionClientType));
            //var intermediateMock = ConstructIntermediateMock(originalMock, extensionClientType);
            // find the Setup<TResult>(Expression<Func<T, TResult>>) method on the intermediateMock
            var setupWithReturn = GetSetupWithReturnMethod(intermediateMock.GetType(), typeof(R));

            // call Setup on the intermediate mock object
            var intermediateSetup = setupWithReturn.Invoke(intermediateMock, new object[] { newExpression });

            return new AzureNonVoidAdapter<T, R>(intermediateSetup);
        }

        private static object ConstructIntermediateMock<T>(Mock<T> originalMock, Type extensionClientType) where T : class
        {
            // create an intermediate mock - new Mock<TExtensionClient>()
            var intermediateMockType = typeof(Mock<>).MakeGenericType(extensionClientType);
            var intermediateMock = Activator.CreateInstance(intermediateMockType);
            // get intermediateMock.Object
            var intermediateMockObject = intermediateMock.GetType().GetProperty("Object", extensionClientType).GetValue(intermediateMock);
            MockGetCachedClient(originalMock, extensionClientType, intermediateMockObject);

            return intermediateMock;
        }

        private static readonly ConcurrentDictionary<object, object> _cache = new ConcurrentDictionary<object, object>();

        private static void MockGetCachedClient<T>(Mock<T> originalMock, Type extensionClientType, object intermediateMockObject) where T : class
        {
            // first we need to construct the expression `It.IsAny<Func<ArmClient, TExtension>>()`
            var funcType = typeof(Func<,>).MakeGenericType(typeof(ArmClient), extensionClientType);
            var itIsAnyExpression = Expression.Call(isAnyMethod.MakeGenericMethod(funcType));
            // second get the expression of `tenant.GetCachedClient(It.IsAny<Func<ArmClient, TExtension>>())`
            var parameter = Expression.Parameter(typeof(T), "resource");
            var methodCallExpression = Expression.Call(parameter, "GetCachedClient", new[] { extensionClientType }, itIsAnyExpression);
            // then we have the lambda: `resource => resource.GetCachedClient(It.IsAny<Func<ArmClient, TExtension>>())`
            var getCachedClientExpression = Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(T), extensionClientType), methodCallExpression, parameter);

            // calling originalMock.Setup using the above lambda
            var setupMethodWithReturn = GetSetupWithReturnMethod(typeof(Mock<T>), extensionClientType);
            var getCachedClientResult = setupMethodWithReturn.Invoke(originalMock, new object[] { getCachedClientExpression });

            // calling Returns on the above result `.Result(intermediateMock.Object)`
            var returnsMethod = getCachedClientResult.GetType().GetMethod("Returns", new[] { extensionClientType });
            returnsMethod.Invoke(getCachedClientResult, new object[] { intermediateMockObject });
        }

        private static readonly MethodInfo isAnyMethod = typeof(It).GetMethod(nameof(It.IsAny), BindingFlags.Public | BindingFlags.Static);

        private static readonly MethodInfo getCachedClientMethod = typeof(ArmResource).GetMethod("GetCachedClient", BindingFlags.Public | BindingFlags.Instance);

        private static MethodInfo GetSetupWithReturnMethod(Type mockType, Type typeOfReturn)
        {
            // find the Setup(Expression<Func<T, TResult>>) method on Mock<T>
            // Because this method is not a generic method, we cannot simply use the `GetMethod(name, types)` method to get it
            var setupMethods = mockType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.Name == "Setup");
            return setupMethods.First(m => m.IsGenericMethod).MakeGenericMethod(typeOfReturn);
        }

        private static MethodInfo GetSetupWithoutReturnMethod(Type mockType, Type parameterType)
        {
            return mockType.GetMethod("Setup", new[] { parameterType });
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