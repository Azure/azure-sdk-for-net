// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Testing;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationRecordedTestSanitizer : RecordedTestSanitizer
    {
        public override string SanitizeConnectionString(string connectionString)
        {
            const string secretKey = "secret";
            var parsed = Azure.Core.ConnectionString.Parse(connectionString, allowEmptyValues: true);

            // Configuration client expects secret to be base64 encoded so we can't use the placeholder
            parsed.Replace(secretKey, string.Empty);
            return parsed.ToString();
        }
    }
}
