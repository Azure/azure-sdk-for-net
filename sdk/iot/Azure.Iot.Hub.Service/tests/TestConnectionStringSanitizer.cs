// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Iot.Hub.Service.Tests
{
    internal class TestConnectionStringSanitizer : RecordedTestSanitizer
    {
        public override string SanitizeVariable(string variableName, string environmentVariableValue) =>
            variableName switch
            {
                TestSettings.IotHubConnectionString => SanitizeConnectionString(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };

        private static string SanitizeConnectionString(string connectionString)
        {
            const string secretKey = "SharedAccessKey";
            var parsed = ConnectionString.Parse(connectionString, allowEmptyValues: true);

            parsed.Replace(secretKey, "Kg==;");
            return parsed.ToString();
        }
    }
}
