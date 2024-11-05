// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#nullable disable

namespace Azure.ResourceManager.TestFramework
{
    public partial class InheritanceCheckTests
    {
        private string[] ExceptionList { get; set; }

        private const string TestFrameworkAssembly = "Azure.ResourceManager.TestFramework";
        private const string AssemblyPrefix = "Azure.ResourceManager.";
        private const string TestAssemblySuffix = ".Tests";

        [Test]
        public void ValidateInheritanceForResourceAndCollectionSuffix()
        {
            var testAssembly = Assembly.GetExecutingAssembly();
            var assemblyName = testAssembly.GetName().Name;
            Assert.IsTrue(assemblyName.EndsWith(TestAssemblySuffix), $"The test assembly should end with {TestAssemblySuffix}");
            var rpNamespace = assemblyName.Substring(0, assemblyName.Length - TestAssemblySuffix.Length);

            if (rpNamespace == TestFrameworkAssembly)
            {
                return;
            }

            TestContext.WriteLine($"Testing assembly {rpNamespace}");

            if (!rpNamespace.StartsWith(AssemblyPrefix))
            {
                return;
            }

            var sdkAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == rpNamespace) ?? Assembly.Load(rpNamespace);

            Assert.IsNotNull(sdkAssembly, $"The SDK assembly {rpNamespace} not found");

            // Verify all class end with `Resource` & `Collection`
            HashSet<string> exceptionList = ExceptionList == null ? new HashSet<string>() : new HashSet<string>(ExceptionList);
            List<string> errorList = new();

            foreach (var type in sdkAssembly.GetTypes())
            {
                if (type.IsClass && type.IsPublic && !exceptionList.Contains(type.Name))
                {
                    if (type.Name.EndsWith("Resource") && !typeof(ArmResource).IsAssignableFrom(type))
                    {
                        errorList.Add(type.Name);
                    }

                    if (type.Name.EndsWith("Collection") && !typeof(ArmCollection).IsAssignableFrom(type))
                    {
                        errorList.Add(type.Name);
                    }
                }

                // Remove the elements to verify there is nothing left in this list
                if (exceptionList.Contains(type.Name))
                {
                    exceptionList.Remove(type.Name);
                }
            }

            Assert.IsEmpty(exceptionList, "InheritanceCheck exception list have values which is not included in current package, please check: " + string.Join(",", exceptionList));
            Assert.IsEmpty(errorList, "InheritanceCheck failed with Type: " + string.Join(",", errorList));
        }
        [Test]
        public void ValidateIJsonModelImpCompliance()
        {
            const string TestAssemblySuffix = ".Tests";
            const string TestFrameworkAssembly = "Azure.ResourceManager.TestFramework";
            var testAssembly = Assembly.GetExecutingAssembly();
            var assemblyName = testAssembly.GetName().Name;
            var rpNamespace = assemblyName.Substring(0, assemblyName.Length - TestAssemblySuffix.Length);
            if (rpNamespace == TestFrameworkAssembly)
            {
                return;
            }
            TestContext.WriteLine($"Testing assembly {rpNamespace}");
            var sdkAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == rpNamespace) ?? Assembly.Load(rpNamespace);
            Assert.IsNotNull(sdkAssembly, $"The SDK assembly {rpNamespace} not found");
            var types = sdkAssembly.GetTypes();
            List<string> nonCompliantClasses = new List<string>();
            foreach (var type in types)
            {
                // Check if the type implements IJsonModel<T>
                var jsonModelInterface = type.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IJsonModel<>));
                if (jsonModelInterface == null)
                {
                    continue;
                }
                // Get the generic type argument T
                var genericArguments = jsonModelInterface.GetGenericArguments();
                if (genericArguments.Length == 1)
                {
                    var genericArgumentType = genericArguments[0];
                    bool isCompliant = false;
                        isCompliant = HasJsonModelWriteCoreMethod(genericArgumentType);
                    if (!isCompliant)
                    {
                        nonCompliantClasses.Add(type.Name);
                    }
                }
            }
            Assert.IsEmpty(nonCompliantClasses, "The following classes implement IJsonModel<T> but do not have a protected JsonModelWriteCore method:" + string.Join(",", nonCompliantClasses));
        }

        private static bool HasJsonModelWriteCoreMethod(Type type)
        {
            var method = type.GetMethod("JsonModelWriteCore", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            return method != null && method.IsFamily; // IsFamily checks for protected access
        }
    }
}