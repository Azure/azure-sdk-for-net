// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    [NonParallelizable]
    public class SkuUtilityTests
    {
        private const string AzureWebsiteSku = "WEBSITE_SKU";

        [TestCase("Dynamic", true)]
        [TestCase("dynamic", true)]
        [TestCase("DYNAMIC", true)]
        [TestCase("SomeOtherType", false)]
        [TestCase(null, false)]
        public void ShouldReadSkuFromEnvironment(string envVarValue, bool expectedResult)
        {
            var originalEnvValue = Environment.GetEnvironmentVariable(AzureWebsiteSku);
            try
            {
                Environment.SetEnvironmentVariable(AzureWebsiteSku, envVarValue);
                // Testing private static code ...
                var readIsDynamicSku = typeof(SkuUtility).GetMethod("ReadIsDynamicSku", BindingFlags.Static | BindingFlags.NonPublic);
                var isSku = (bool)readIsDynamicSku.Invoke(null, new object[0]);
                Assert.That(isSku, Is.EqualTo(expectedResult));
            }
            finally
            {
                Environment.SetEnvironmentVariable(AzureWebsiteSku, originalEnvValue);
            }
        }

        [Test]
        public void ShouldReturnOneProcessorIfDynamicSku()
        {
            // Testing private static code ...
            var getProcessorCount = typeof(SkuUtility).GetMethod("GetProcessorCount", BindingFlags.Static | BindingFlags.NonPublic);
            var processorCount = (int)getProcessorCount.Invoke(null, new object[] { true });
            Assert.That(processorCount, Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnEnvironmentProcessorsIfNotDynamicSku()
        {
            // Testing private static code ...
            var getProcessorCount = typeof(SkuUtility).GetMethod("GetProcessorCount", BindingFlags.Static | BindingFlags.NonPublic);
            var processorCount = (int)getProcessorCount.Invoke(null, new object[] { false });
            Assert.That(processorCount, Is.EqualTo(Environment.ProcessorCount));
        }
    }
}
