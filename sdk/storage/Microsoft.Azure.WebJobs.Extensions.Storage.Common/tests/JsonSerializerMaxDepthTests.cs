// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Protocols;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    [NonParallelizable]
    public class JsonSerializerMaxDepthTests
    {
        private const string MaxDepthVariable = "AZURE_WEBJOBS_STORAGE_JSONSERIALIZER_MAXDEPTH";

        [Test]
        public void MaxDepth_Default()
        {
            var originalEnvValue = Environment.GetEnvironmentVariable(MaxDepthVariable);
            try
            {
                // No environment variable used
                Environment.SetEnvironmentVariable(MaxDepthVariable, null);
                // Testing private static code ...
                var getMaxDepth = typeof(JsonSerialization).GetMethod("GetMaxDepth", BindingFlags.Static | BindingFlags.NonPublic);
                var maxDepth = (int)getMaxDepth.Invoke(null, new object[0]);
                Assert.AreEqual(Constants.MaxDepthDefault, maxDepth);
            }
            finally
            {
                Environment.SetEnvironmentVariable(MaxDepthVariable, originalEnvValue);
            }
        }

        [TestCase("4")]
        [TestCase("256")]
        [TestCase("10000")]
        public void MaxDepthFromEnvironment(string envVarValue)
        {
            var originalEnvValue = Environment.GetEnvironmentVariable(MaxDepthVariable);
            try
            {
                Environment.SetEnvironmentVariable(MaxDepthVariable, envVarValue);
                // Testing private static code ...
                var getMaxDepth = typeof(JsonSerialization).GetMethod("GetMaxDepth", BindingFlags.Static | BindingFlags.NonPublic);
                int maxDepth = (int)getMaxDepth.Invoke(null, new object[0]);
                Assert.AreEqual(envVarValue, maxDepth.ToString());
            }
            finally
            {
                Environment.SetEnvironmentVariable(MaxDepthVariable, originalEnvValue);
            }
        }

        [TestCase("SomeOtherType")]
        [TestCase("-12")]
        public void MaxDepthFromEnvironment_Fail(string envVarValue)
        {
            var originalEnvValue = Environment.GetEnvironmentVariable(MaxDepthVariable);
            try
            {
                Environment.SetEnvironmentVariable(MaxDepthVariable, envVarValue);
                // Testing private static code ...
                var getMaxDepth = typeof(JsonSerialization).GetMethod("GetMaxDepth", BindingFlags.Static | BindingFlags.NonPublic);
                try
                {
                    int result = (int)getMaxDepth.Invoke(null, new object[0]);
                    Assert.Fail("MaxDepth value should have thrown an exception");
                }
                catch (TargetInvocationException ex)
                {
                    string exceptionType = "System.ArgumentException";
                    Assert.AreEqual(exceptionType, ex.InnerException.ToString().Substring(0,exceptionType.Length));
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable(MaxDepthVariable, originalEnvValue);
            }
        }
    }
}
