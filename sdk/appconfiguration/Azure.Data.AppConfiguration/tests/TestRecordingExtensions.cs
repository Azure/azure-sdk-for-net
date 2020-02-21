// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public static class TestRecordingExtensions
    {
        public static string RequireVariableFromEnvironment(this TestRecording recording, string variableName)
        {
            var variable = recording.GetVariableFromEnvironment(variableName);
            Assert.NotNull(variable, $"Set {variableName} environment variable");
            return variable;
        }
    }
}
