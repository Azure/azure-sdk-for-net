// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
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
    }
}