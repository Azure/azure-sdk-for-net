// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ConfigurationProfileVersionTestBase : AutomanageTestBase
    {
        protected ConfigurationProfileVersionTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Asserts multiple values
        /// </summary>
        /// <param name="version">ConfigurationProfileVersionResource to assert</param>
        /// <param name="versionName">ConfigurationProfileVersionResource name to verify</param>
        protected void AssertValues(ConfigurationProfileVersionResource version, string versionName)
        {
            Assert.NotNull(version);
            Assert.True(version.HasData);
            Assert.AreEqual(versionName, version.Id.Name);
            Assert.NotNull(version.Id);
            Assert.NotNull(version.Data);
            Assert.NotNull(version.Data.Configuration);
        }
    }
}
