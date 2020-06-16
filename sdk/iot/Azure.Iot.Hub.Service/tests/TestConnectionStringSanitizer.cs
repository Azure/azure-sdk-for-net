// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Core;

namespace Azure.Iot.Hub.Service.Tests
{
    internal class TestConnectionStringSanitizer : RecordedTestSanitizer
    {
        public override string SanitizeVariable(string variableName, string environmentVariableValue) =>
            variableName switch
            {
                TestsConstants.IOT_HUB_CONNECTION_STRING => SanitizeConnectionString(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };

        private static string SanitizeConnectionString(string connectionString)
        {
            const string secretKey = "SharedAccessKey";
            var parsed = ConnectionString.Parse(connectionString, allowEmptyValues: true);

            // Configuration client expects secret to be base64 encoded so we can't use the placeholder
            parsed.Replace(secretKey, string.Empty);
            return parsed.ToString();
        }
    }
}
