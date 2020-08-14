// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Iot.Hub.Service.Tests
{
    internal class TestConnectionStringSanitizer : RecordedTestSanitizer
    {
        private const string HOST_NAME = "HostName";
        private const string SHARED_ACCESS_KEY = "SharedAccessKey";
        private const string FAKE_HOST = "FakeHost.net";
        private const string FAKE_SECRET = "Kg==;";

        public override string SanitizeVariable(string variableName, string environmentVariableValue) =>
            variableName switch
            {
                TestSettings.IotHubConnectionString => SanitizeConnectionString(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };

        public override string SanitizeUri(string uri)
        {
            return uri.Replace(new Uri(uri).Host, FAKE_HOST);
        }

        private static string SanitizeConnectionString(string connectionString)
        {
            var parsed = ConnectionString.Parse(connectionString, allowEmptyValues: true);

            parsed.Replace(SHARED_ACCESS_KEY, FAKE_SECRET);
            parsed.Replace(HOST_NAME, FAKE_HOST);
            return parsed.ToString();
        }
    }
}
