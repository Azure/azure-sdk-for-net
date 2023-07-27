// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Mock
{
    public class MockingPatternValidationTests
    {
        // TODO -- after enough test cases on each individual RP, we should move this to mgmt test base class so that every RP will automatically get this test case
        [Test]
        public void ValidateMockingPattern()
        {
            var current = Assembly.GetExecutingAssembly();
            var assemblyName = current.GetName().Name;
            if (!assemblyName.EndsWith(".Tests"))
                throw new InvalidOperationException("Wrong assembly");

            var sdkAssemblyName = assemblyName.Substring(0, assemblyName.Length - 6);
            var sdkAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == sdkAssemblyName);
            Assert.IsNotNull(sdkAssembly);

            // find the extension class
            Assert.IsTrue(sdkAssemblyName.StartsWith("Azure.ResourceManager"));
            sdkAssemblyName = sdkAssemblyName.Substring("Azure.ResourceManager".Length);
            //var rpName = string.Join("", sdkAssemblyName.Split(".", StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
