// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.DigitalTwins.Core.Tests
{
    internal class TestUrlSanitizer : RecordedTestSanitizer
    {
        private const string FAKE_HOST = "fakeHost.api.wus2.digitaltwins.azure.net";

        public override string SanitizeVariable(string variableName, string environmentVariableValue) =>
            variableName switch
            {
                "DIGITALTWINS_URL" => SanitizeUri(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };

        public override string SanitizeUri(string uri)
        {
            return uri.Replace(new Uri(uri).Host, FAKE_HOST);
        }
    }
}
