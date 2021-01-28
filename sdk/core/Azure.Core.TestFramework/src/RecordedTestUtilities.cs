// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    public static class RecordedTestUtilities
    {
        private const string ModeEnvironmentVariableName = "AZURE_TEST_MODE";

        public static RecordedTestMode GetModeFromEnvironment()
        {
            string modeString = TestContext.Parameters["TestMode"] ?? Environment.GetEnvironmentVariable(ModeEnvironmentVariableName);

            RecordedTestMode mode = RecordedTestMode.Playback;
            if (!string.IsNullOrEmpty(modeString))
            {
                mode = (RecordedTestMode)Enum.Parse(typeof(RecordedTestMode), modeString, true);
            }

            return mode;
        }
    }
}
