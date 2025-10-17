// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;
using System;
using System.IO;

namespace Azure.AI.VoiceLive.Tests
{
    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeSetUp]
        public void SetupOnce()
        {
            // Ensure test audio directories exist
            string testAudioPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Audio");
            TestDataValidator.EnsureTestDataDirectoryStructure(testAudioPath);

            // Validate required test files
            TestDataValidator.ValidateRequiredTestFiles(testAudioPath);

            TestContext.WriteLine($"Test environment setup complete. Audio path: {testAudioPath}");
        }
    }
}
