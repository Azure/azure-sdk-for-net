// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Azure.ResourceManager.TestFramework
{
    public sealed class InherentCheckTests
    {
        private string[] ExceptionList { get; set; }

        private const string TestFrameworkAssembly = "Azure.ResourceManager.TestFramework";
        private const string AssemblyPrefix = "Azure.ResourceManager.";
        //private const string ResourceManagerAssemblyName = "Azure.ResourceManager";
        private const string TestAssemblySuffix = ".Tests";

        [Test]
        public void InherentCheck()
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

            // Verify all class end with `Resource` & Collection
            foreach (var type in sdkAssembly.GetTypes())
            {
                if (type.IsClass)
                {
                    if (type.Name.EndsWith("Resouces")
                        && !type.Name.Equals("ArmResource")
                        && !type.Name.Equals("WritableSubResource")
                        && !type.Name.Equals("SubResource"))
                    {
                        if (ExceptionList != null && !ExceptionList.Contains(type.Name))
                        {
                            Assert.AreEqual("ArmResource", type.BaseType.Name);
                        }
                    }

                    if (type.Name.EndsWith("Collection")
                        && !type.Name.Equals("ArmCollection"))
                    {
                        if (ExceptionList != null && !ExceptionList.Contains(type.Name))
                        {
                            Assert.AreEqual("ArmCollection", type.BaseType.Name);
                        }
                    }
                }
            }
        }
    }
}