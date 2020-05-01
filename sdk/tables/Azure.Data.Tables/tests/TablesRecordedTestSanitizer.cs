// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.Tables.Tests
{
    public class TablesRecordedTestSanitizer : RecordedTestSanitizer
    {
        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                TablesTestEnvironment.PrimaryKeyEnvironmentVariableName => string.Empty,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }
    }
}
