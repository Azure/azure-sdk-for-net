// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationRecordedTestSanitizer : RecordedTestSanitizer
    {
        public override string SanitizeVariable(string variableName, string environmentVariableValue) =>
            variableName switch
            {
                "APPCONFIGURATION_CONNECTION_STRING" => SanitizeConnectionString(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };

        private static string SanitizeConnectionString(string connectionString)
        {
            const string secretKey = "secret";
            var parsed = ConnectionString.Parse(connectionString, allowEmptyValues: true);

            // Configuration client expects secret to be base64 encoded so we can't use the placeholder
            parsed.Replace(secretKey, string.Empty);
            return parsed.ToString();
        }
    }
}
