// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace Azure.ResourceManager.TestFramework
{
    public sealed partial class ModelReaderWriterImplementationValidation
    {
        private string[] ExceptionList { get; set; }

        private const string ModelNamespaceSuffix = ".Models";
        private const string AssemblyPrefix = "Azure.ResourceManager.";
        private const string ResourceManagerAssemblyName = "Azure.ResourceManager";
        private const string TestAssemblySuffix = ".Tests";

        [Test]
        public void ValidateModelReaderWriterPattern()
        {
            var testAssembly = Assembly.GetExecutingAssembly();
            var assemblyName = testAssembly.GetName().Name;
            Assert.IsTrue(assemblyName.EndsWith(TestAssemblySuffix), $"The test assembly should end with {TestAssemblySuffix}");
            var rpNamespace = assemblyName.Substring(0, assemblyName.Length - TestAssemblySuffix.Length);

            TestContext.WriteLine($"Testing assembly {rpNamespace}");

            if (!rpNamespace.StartsWith(AssemblyPrefix) && rpNamespace != ResourceManagerAssemblyName)
            {
                // this is not a MPG project
                return;
            }

            // find the SDK assembly by filtering the assemblies in the current domain, or load it if not found (when there is no test case)
            var sdkAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == rpNamespace) ?? Assembly.Load(rpNamespace);

            Assert.IsNotNull(sdkAssembly, $"The SDK assembly {rpNamespace} not found");

            List<Type> violatedTypes = new();
            var exceptionList = ExceptionList == null ? new HashSet<string>() : new HashSet<string>(ExceptionList);
            foreach (var type in sdkAssembly.GetTypes())
            {
                if (IsModelType(type, exceptionList))
                {
                    TestContext.WriteLine($"Verifying class {type}");
                    CheckModelType(type, violatedTypes);
                }
            }

            if (violatedTypes.Count > 0)
            {
                var builder = new StringBuilder();
                builder.AppendLine($"The following type should either implement {typeof(IJsonModel<>)} or {typeof(IPersistableModel<>)}:");
                foreach (var type in violatedTypes)
                {
                    builder.AppendLine(type.ToString());
                }
                Assert.Fail(builder.ToString());
            }
        }

        private static bool IsModelType(Type type, HashSet<string> exceptionList)
        {
            if (!type.IsPublic || type.IsInterface || IsStaticType(type) || !type.IsClass)
                return false;

            if (exceptionList.Contains($"{type.Namespace}.{type.Name}"))
                return false;

            // if the type is in the Models namespace, it is a model
            if (type.Namespace.EndsWith(ModelNamespaceSuffix))
                return true;

            return false;
        }

        private static void CheckModelType(Type type, List<Type> violatedTypes)
        {
            var interfaces = type.GetInterfaces();
            var iJsonModelType = typeof(IJsonModel<>).MakeGenericType(type);
            var iPersistableModelType = typeof(IPersistableModel<>).MakeGenericType(type);
            // check the type implements the IJsonModel<T> interface
            if (interfaces.Contains(iJsonModelType))
                return;
            // if not, it should implements the IPersistableModel<T> interface
            if (interfaces.Contains(iPersistableModelType))
                return;

            violatedTypes.Add(type);
        }

        private static bool IsStaticType(Type type) => type.IsSealed && type.IsAbstract; // CLR uses sealed and abstract to represent static classes
    }
}
