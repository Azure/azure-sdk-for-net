// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Mock
{
    public class MockingPatternValidationTests
    {
        private const string RPNamespace = "Azure.ResourceManager.PolicyInsights";
        private const string RPName = "PolicyInsights";

        // TODO -- after enough test cases on each individual RP, we should move this to mgmt test base class so that every RP will automatically get this test case
        [Test]
        public void ValidateMockingPattern()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == RPNamespace);

            Assert.IsNotNull(assembly);

            // find the extension class
            var extensionName = $"{RPNamespace}.{RPName}Extensions";
            var extensionType = assembly.GetType(extensionName);

            Assert.IsNotNull(extensionType);

            foreach (var method in extensionType.GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                ValidateMethod(assembly, method);
            }
        }

        private static void ValidateMethod(Assembly assembly, MethodInfo method)
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

            var mockingExtensionTypeName = GetMockingExtensionTypeName(RPNamespace, RPName, extendeeType.Name);

            var mockingExtensionType = assembly.GetType(mockingExtensionTypeName);
            Assert.IsNotNull(mockingExtensionType, $"expect mocking extension class {mockingExtensionTypeName}, but found none");

            // validate the mocking extension class has a method with the exact name and parameter list
            var expectedTypes = parameters.Skip(1).Select(p => p.ParameterType).ToArray();
            var methodOnExtension = mockingExtensionType.GetMethod(method.Name, parameters.Skip(1).Select(p => p.ParameterType).ToArray());

            Assert.IsNotNull(methodOnExtension, $"expect class {mockingExtensionType} to have method {method}, but found none");
            Assert.IsTrue(methodOnExtension.IsVirtual, $"the method on {mockingExtensionType} must be virtual");
            Assert.IsTrue(methodOnExtension.IsPublic, $"the method on {mockingExtensionType} must be public");
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
    }
}
