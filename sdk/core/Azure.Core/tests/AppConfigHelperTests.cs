// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class AppConfigHelperTests
    {
        private const string switchName = "mySwitch";
        private const string envVarName = "myEnv";

        [Test]
        [NonParallelizable]
        public void GetConfigValue(
            [Values("true", "false", null)] string enableSwitch,
            [Values("true", "false", null)] string enableEnvVar)
        {
            TestAppContextSwitch ctx = null;
            TestEnvVar env = null;
            try
            {
                bool actual;
                bool expected = enableSwitch switch
                {
                    "true" => true,
                    "false" => false,
                    _ => bool.TryParse(enableEnvVar, out bool val) && val
                };
                if (enableSwitch != null)
                {
                    ctx = new TestAppContextSwitch(switchName, enableSwitch);
                }
                if (enableEnvVar != null)
                {
                    env = new TestEnvVar(envVarName, enableEnvVar);
                }

                actual = AppContextSwitchHelper.GetConfigValue(switchName, envVarName);

                Assert.AreEqual(expected, actual);
            }
            finally
            {
                ctx?.Dispose();
                env?.Dispose();
            }
        }

        [TestCase("true", true)]
        [TestCase("TrUe", true)]
        [TestCase("1", true)]
        [TestCase("false", false)]
        [TestCase("FaLsE", false)]
        [TestCase("0", false)]
        [NonParallelizable]
        public void GetConfigValueWithDefaultParsesEnvironmentVariable(string environmentValue, bool expected)
        {
            string appContextSwitchName = $"Azure.Core.Tests.{Guid.NewGuid():N}";
            using var environment = new TestEnvVar(envVarName, environmentValue);

            Assert.AreEqual(expected, AppContextSwitchHelper.GetConfigValue(appContextSwitchName, envVarName, defaultValue: false));
            Assert.AreEqual(expected, AppContextSwitchHelper.GetConfigValue(appContextSwitchName, envVarName, defaultValue: true));
        }

        [Test]
        [NonParallelizable]
        public void GetConfigValueWithDefaultUsesFallback(
            [Values(null, "", "invalid")] string environmentValue,
            [Values] bool defaultValue)
        {
            string appContextSwitchName = $"Azure.Core.Tests.{Guid.NewGuid():N}";
            using var environment = new TestEnvVar(envVarName, environmentValue);

            Assert.AreEqual(defaultValue, AppContextSwitchHelper.GetConfigValue(appContextSwitchName, envVarName, defaultValue));
        }

        [Test]
        [NonParallelizable]
        public void GetConfigValueWithDefaultPrefersAppContext(
            [Values] bool switchValue,
            [Values("true", "false", "1", "0", null)] string environmentValue,
            [Values] bool defaultValue)
        {
            string appContextSwitchName = $"Azure.Core.Tests.{Guid.NewGuid():N}";
            using var context = new TestAppContextSwitch(appContextSwitchName, switchValue.ToString());
            using var environment = new TestEnvVar(envVarName, environmentValue);

            Assert.AreEqual(switchValue, AppContextSwitchHelper.GetConfigValue(appContextSwitchName, envVarName, defaultValue));
        }
    }
}
