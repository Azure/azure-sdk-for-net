// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            string[] exceptionList = ExceptionList ?? Array.Empty<string>();
            List<string> errorList = new();

            foreach (var type in sdkAssembly.GetTypes())
            {
                if (type.IsClass && type.IsPublic && !exceptionList.Contains(type.Name))
                {
                    if (type.Name.EndsWith("Resource")
                        && !type.Name.Equals("ArmResource")
                        && !type.Name.Equals("WritableSubResource")
                        && !type.Name.Equals("SubResource")
                        && !type.BaseType.Name.Equals("ArmResource"))
                    {
                        errorList.Add(type.Name);
                    }

                    if (type.Name.EndsWith("Collection")
                        && !type.Name.Equals("ArmCollection")
                        && !type.BaseType.Name.Equals("ArmCollection"))
                    {
                        errorList.Add(type.Name);
                    }
                }
            }

            Assert.IsEmpty(errorList, "InherentCheck failed with Type: " + string.Join(",", errorList));
        }
    }
}