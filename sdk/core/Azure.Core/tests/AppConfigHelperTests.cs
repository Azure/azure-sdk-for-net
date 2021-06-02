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
    }
}
