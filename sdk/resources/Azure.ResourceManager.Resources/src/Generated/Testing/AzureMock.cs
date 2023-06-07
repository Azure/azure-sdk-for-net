// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Azure.Core;
using Moq;
using Moq.Language.Flow;

namespace Azure.ResourceManager.Resources.Testing
{
    internal class AzureMock<T> : Mock<T> where T : ArmResource
    {
        private const string _mockingMethodName = "SetupAzureExtensionMethod";

        public new ISetup<T, R> Setup<R>(Expression<Func<T, R>> expression)
        {
            if (ExpressionUtilities.IsExtensionMethod(expression, out var extensionMethodInfo))
            {
                // if it is extension method
                var name = typeof(T).Name;
                // find the type of extension client
                var extensionClientName = name + "ExtensionClient";
                var typeOfExtension = extensionMethodInfo.DeclaringType;
                // get the namespace of the current SDK dynamically
                var thisNamespace = typeOfExtension.Namespace;
                var extensionClientType = typeOfExtension.Assembly.GetType($"{thisNamespace}.{extensionClientName}");
                // calling the SetupAzureExtensionMethod
                var methodInfo = extensionClientType.GetMethod(_mockingMethodName, BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeof(R));
                var newExpression = ExpressionUtilities.ChangeType(expression, extensionClientType);
                var intermediateSetup = methodInfo.Invoke(null, new object[] { this, newExpression });

                return RedirectMock<R>(this, newExpression, extensionClientType);
                //return new AzureSetupAdapter<T, R>(intermediateSetup);
            }
            else
            {
                return base.Setup(expression);
            }
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

        //static AzureMock()
        //{
        //    var setupMethods = typeof(Mock<>).GetMethods(BindingFlags.Public | BindingFlags.Instance)
        //        .Where(m => m.Name == "Setup");
        //    setupWithReturn = setupMethods.First(m => m.IsGenericMethod);
        //    setupWithoutReturn = setupMethods.First(m => !m.IsGenericMethod);
        //}

        private static ISetup<T, R> RedirectMock<R>(Mock<T> originalMock, Expression newExpression, Type extensionClientType)
        {
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
            var expression = Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(T), extensionClientType), methodCallExpression, parameter);

            // calling originalMock.Setup(tenant => tenant.GetCachedClient(It.IsAny<Func<ArmClient, TenantResourceExtensionClient>>()))
            setupWithReturn = GetSetupWithReturnMethod(typeof(Mock<T>), extensionClientType);
            var getCachedClientResult = setupWithReturn.Invoke(originalMock, new object[] { expression });

            // TODO -- WIP need to call Returns(intermediateMock.Object) on above result

            return new AzureSetupAdapter<T, R>(intermediateSetup);
        }
    }
}
