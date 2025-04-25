// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.Projects.Custom.Agent;

namespace Azure.AI.Projects.Tests
{
    public class ToolCallsResolverTests
    {
        private delegate string TestDelegate(string param);

        [Test]
        public void Resolve_ShouldHandleMultipleParameters()
        {
            var function = new Func<string, int, string>((param1, param2) => $"{param1} {param2}");
            string functionArguments = JsonSerializer.Serialize(new { param1 = "test", param2 = 123 });

            var result = ToolCallsResolver.Resolve(function, functionArguments);

            Assert.AreEqual("test 123", result);
        }

        [Test]
        public void Resolve_ShouldHandleDefaultParameterValues()
        {
            string MyFunction(string param1, int param2 = 0)
            {
                return $"{param1} {param2}";
            }

            // Create a Func delegate pointing to the method
            Func<string, int, string> function = MyFunction;

            string functionArguments = JsonSerializer.Serialize(new { param1 = "test" });

            var result = ToolCallsResolver.Resolve(function, functionArguments);

            Assert.AreEqual("test 0", result); // Assuming default value for int is 0
        }
    }
}
