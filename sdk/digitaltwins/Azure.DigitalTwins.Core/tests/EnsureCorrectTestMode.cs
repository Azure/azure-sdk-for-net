// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    [Category("Unit")]
    [Parallelizable(ParallelScope.All)]
    public class EnsureCorrectTestMode
    {
        [Test]
        // The PR tests use the value in the common.config.json to determine the mode to run the tests.
        // This test ensures that the value in common.config.json is not changed.
        public void CommonConfig_SetTo_PlaybackMode()
        {
            // arrange
            string codeBase = Assembly.GetExecutingAssembly().Location;
            string workingDirectory = Path.GetDirectoryName(codeBase);
            string testSettingsCommonPath = Path.Combine(
                workingDirectory,
                "config",
                "common.config.json");

            var testsSettingsConfigBuilder = new ConfigurationBuilder();
            testsSettingsConfigBuilder.AddJsonFile(testSettingsCommonPath);

            IConfiguration config = testsSettingsConfigBuilder.Build();

            // act
            var testSettings = config.Get<TestSettings>();

            // assert
            testSettings.TestMode.Should().Be(RecordedTestMode.Playback, "The PR pipeline should always run the e2e tests in the playback mode so the value of TestMode should not be changed in the common.config.json file.");
        }
    }
}
