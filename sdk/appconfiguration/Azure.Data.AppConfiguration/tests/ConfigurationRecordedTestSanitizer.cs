// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationRecordedTestSanitizer : RecordedTestSanitizer
    {
        public override void SanitizeConnectionString(ConnectionString connectionString)
        {
            const string secretKey = "secret";

            // Configuration client expects secret to be base64 encoded so we can't use the placeholder
            if (connectionString.Pairs.ContainsKey(secretKey))
            {
                connectionString.Pairs[secretKey] = "";
            }
        }
    }
}
