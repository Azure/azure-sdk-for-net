// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Moq;
using Moq.Language;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure.ResourceManager.TestFramework
{
    public sealed class ManagementMockingPatternTests
    {
        private const string AssemblyPrefix = "Azure.ResourceManager.";
        private const string ResourceManagerAssemblyName = "Azure.ResourceManager";
        private const string TestAssemblySuffix = ".Tests";

        [Test]
        public void ValidateMockingPattern()
        {
            var testAssembly = Assembly.GetExecutingAssembly();
            var assemblyName = testAssembly.GetName().Name;
            Assert.IsTrue(assemblyName.EndsWith(TestAssemblySuffix), $"The test assembly should end with {TestAssemblySuffix}");
            var rpNamespace = assemblyName.Substring(0, assemblyName.Length - TestAssemblySuffix.Length);

            if (rpNamespace == ResourceManagerAssemblyName)
            {
                // in Azure.ResourceManager, we do not have extension methods therefore there is nothing to validate
                return;
            }

            // other assemblies should start with `Azure.ResourceManager.`
            Assert.IsTrue(rpNamespace.StartsWith(AssemblyPrefix), $"The SDK assembly should start with {AssemblyPrefix}");

            // find the SDK assembly by filtering the assemblies in current domain, or load it if not found (when there is no test case)
            var sdkAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == rpNamespace) ?? Assembly.Load(rpNamespace);

            Assert.IsNotNull(sdkAssembly, $"The SDK assembly {rpNamespace} not found");

            // find the extension class
            var rpName = GetRPName(rpNamespace);
            var extensionName = $"{rpNamespace}.{rpName}Extensions";
            var extensionType = sdkAssembly.GetType(extensionName);

            Assert.IsNotNull(extensionType);

            foreach (var method in extensionType.GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                ValidateMethod(sdkAssembly, method, rpNamespace, rpName);
            }
        }

        private static string GetRPName(string rpNamespace)
        {
            // there is an assertion of the prefix, therefore this is safe.
            var trailing = rpNamespace.Substring(AssemblyPrefix.Length);
            var segments = trailing.Split('.');
            var rpName = string.Join("", segments.Select(s => char.ToUpper(s[0]) + s.Substring(1)));
            return rpName;
        }

        private static void ValidateMethod(Assembly assembly, MethodInfo method, string rpNamespace, string rpName)
        {
            // the method should be public, static and extension
            if (!method.IsStatic || !method.IsPublic || !method.IsDefined(typeof(ExtensionAttribute), true))
                return;

            // ignore those obsolete methods
            if (method.IsDefined(typeof(ObsoleteAttribute), true))
                return;

            // finds the corresponding mocking extension class
            var parameters = method.GetParameters();
            var extendeeType = parameters[0].ParameterType;

            var mockingExtensionTypeName = GetMockingExtensionTypeName(rpNamespace, rpName, extendeeType.Name);

            var mockingExtensionType = assembly.GetType(mockingExtensionTypeName);
            Assert.IsNotNull(mockingExtensionType, $"expect mocking extension class {mockingExtensionTypeName}, but found none");
            Assert.IsTrue(mockingExtensionType.IsPublic, $"The mocking extension class {mockingExtensionType} should be public");

            // validate the mocking extension class has a method with the exact name and parameter list
            var expectedTypes = parameters.Skip(1).Select(p => p.ParameterType).ToArray();
            var methodOnExtension = mockingExtensionType.GetMethod(method.Name, parameters.Skip(1).Select(p => p.ParameterType).ToArray());

            Assert.IsNotNull(methodOnExtension, $"expect class {mockingExtensionType} to have method {method}, but found none");
            Assert.IsTrue(methodOnExtension.IsVirtual, $"the method on {mockingExtensionType} must be virtual");
            Assert.IsTrue(methodOnExtension.IsPublic, $"the method on {mockingExtensionType} must be public");

            ValidateMocking(extendeeType, mockingExtensionType, method, methodOnExtension);
        }

        private static string GetMockingExtensionTypeName(string rpNamespace, string rpName, string extendeeName)
        {
            // trim resource suffix
            if (extendeeName.EndsWith("Resource"))
            {
                extendeeName = extendeeName.Substring(0, extendeeName.Length - 8);
            }

            return $"{rpNamespace}.Mocking.{rpName}{extendeeName}MockingExtension";
        }

        private static void ValidateMocking(Type extendeeType, Type mockingExtensionType, MethodInfo extensionMethod, MethodInfo methodOnExtension)
        {
            // construct a mock instance for the extendee
            var mock = (Mock)Activator.CreateInstance(typeof(Mock<>).MakeGenericType(extendeeType));
            // construct a mock instance for the mocking extension
            var extensionMock = (Mock)Activator.CreateInstance(typeof(Mock<>).MakeGenericType(mockingExtensionType));
            // mock the GetCachedClient
            MockGetCachedClientMethod(mock, extensionMock, extendeeType, mockingExtensionType);
            // mock the method on MockingExtension
            MockMethodOnMockingExtension(extensionMock, mockingExtensionType, methodOnExtension);

            // call the method on the mock result
            var arguments = new List<object>() { mock.Object };
            foreach (var p in extensionMethod.GetParameters().Skip(1))
            {
                object i = p.ParameterType.IsValueType ? Activator.CreateInstance(p.ParameterType) : null;
                arguments.Add(i);
            }
            var result = extensionMethod.Invoke(null, arguments.ToArray());

            Assert.IsNotNull(result, $"Mocking of extension method {extensionMethod} is not taking effect, please check the implementation to ensure it to call the method with same name and parameter list in {mockingExtensionType}");
        }

        private static void MockGetCachedClientMethod(Mock mock, Mock extensionMock, Type extendeeType, Type mockingExtensionType)
        {
            // get the setup method for Mock<T> so that we could call it.
            var setupMethod = FindSetupMethod(mock.GetType()).MakeGenericMethod(mockingExtensionType);
            // construct the expression to use in the Setup method `extendee => extendee.GetCachedClient(It.IsAny<Func<ArmClient, MockingExtensionType>>())`
            var expression = ConstructGetCachedClientExpression(extendeeType, mockingExtensionType);
            // invoke the setup method
            var getCachedClientResult = setupMethod.Invoke(mock, new object[] { expression });
            // find the Returns method on the result
            var returnsMethod = FindReturnsMethod(getCachedClientResult.GetType(), mockingExtensionType);
            // call the Returns method
            returnsMethod.Invoke(getCachedClientResult, new object[] { extensionMock.Object });
        }

        private static void MockMethodOnMockingExtension(object extensionMock, Type mockingExtensionType, MethodInfo methodOnExtension)
        {
            var returnType = methodOnExtension.ReturnType;
            var setupMethod = FindSetupMethod(extensionMock.GetType()).MakeGenericMethod(returnType);
            // construct the expression that calls this method
            var expression = ConstructMethodExpression(mockingExtensionType, methodOnExtension);
            // invoke the setup method
            var methodResult = setupMethod.Invoke(extensionMock, new object[] { expression });
            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                returnType = returnType.GenericTypeArguments.Single();
                // find the ReturnsAsync method on ReturnsExtensions
                var returnsMethod = GetReturnsAsyncMethod().MakeGenericMethod(mockingExtensionType, returnType);
                // construct a mock instance for the result so that the mock method no longer returns null
                var resultMock = (Mock)Activator.CreateInstance(typeof(Mock<>).MakeGenericType(returnType));
                // since ReturnsAsync is an extension method, we need to call it in the static method way
                returnsMethod.Invoke(null, new object[] { methodResult, resultMock.Object });
            }
            else
            {
                // find the Returns method on the result
                var returnsMethod = FindReturnsMethod(methodResult.GetType(), returnType);
                // construct a mock instance for the result so that the mock method no longer returns null
                var resultMock = (Mock)Activator.CreateInstance(typeof(Mock<>).MakeGenericType(returnType));
                // call the Returns method
                returnsMethod.Invoke(methodResult, new object[] { resultMock.Object });
            }
        }

        private static MethodInfo _returnsAsyncMethod = null;

        private static MethodInfo GetReturnsAsyncMethod()
        {
            if (_returnsAsyncMethod != null)
            {
                return _returnsAsyncMethod;
            }

            var returnsAsyncMethods = typeof(ReturnsExtensions).GetMethods().Where(m => m.Name == "ReturnsAsync");

            // Get the method with the desired type of the second generic parameter of the IReturns interface
            foreach (var method in returnsAsyncMethods)
            {
                // we want to find this method: IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, TResult value)
                if (!method.IsGenericMethod)
                    continue;
                var genericArguments = method.GetGenericArguments();
                if (genericArguments.Length != 2)
                    continue;
                var parameters = method.GetParameters();
                if (parameters.Length != 2)
                    continue;
                var firstType = typeof(IReturns<,>).MakeGenericType(genericArguments[0], typeof(Task<>).MakeGenericType(genericArguments[1]));
                var secondType = genericArguments[1];
                if (firstType == parameters[0].ParameterType && secondType == parameters[1].ParameterType)
                {
                    _returnsAsyncMethod = method;
                    break;
                }
            }

            return _returnsAsyncMethod;
        }

        private static LambdaExpression ConstructGetCachedClientExpression(Type extendeeType, Type mockingExtensionType)
        {
            // step 1: construct an expression: It.IsAny<Func<ArmClient, MockingExtensionType>>()
            var funcType = typeof(Func<,>).MakeGenericType(typeof(ArmClient), mockingExtensionType);
            var itIsAnyExpression = Expression.Call(isAnyMethod.MakeGenericMethod(funcType));
            // step 2: get the expression of `extendee.GetCachedClient(It.IsAny<Func<ArmClient, MockingExtensionType>>())`
            var parameter = Expression.Parameter(extendeeType, "extendee");
            var methodCallExpression = Expression.Call(parameter, "GetCachedClient", new[] { mockingExtensionType }, itIsAnyExpression);
            // step 3: get the lambda: `extendee => extendee.GetCachedClient(It.IsAny<Func<ArmClient, MockingExtensionType>>())`
            return Expression.Lambda(methodCallExpression, parameter);
        }

        private static LambdaExpression ConstructMethodExpression(Type mockingExtensionType, MethodInfo methodOnExtension)
        {
            var parameters = methodOnExtension.GetParameters();
            // construct an expression like `e.TheMethod(default, default, default, default);`
            var parameter = Expression.Parameter(mockingExtensionType, "e");
            var arguments = new List<Expression>();
            foreach (var p in parameters)
            {
                arguments.Add(Expression.Default(p.ParameterType));
            }
            var methodCallExpression = Expression.Call(parameter, methodOnExtension, arguments);
            // change it to a lambda
            return Expression.Lambda(methodCallExpression, parameter);
        }

        private static MethodInfo FindSetupMethod(Type mock)
        {
            var methods = mock.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            return methods.Single(m => m.Name == "Setup" && m.IsGenericMethod);
        }

        private static MethodInfo FindReturnsMethod(Type instance, Type resultType)
        {
            return instance.GetMethod("Returns", new[] { resultType });
        }

        private static readonly MethodInfo isAnyMethod = typeof(It).GetMethod(nameof(It.IsAny), BindingFlags.Public | BindingFlags.Static);
    }
}
