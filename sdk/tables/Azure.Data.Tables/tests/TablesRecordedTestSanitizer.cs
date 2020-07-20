// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;
using Azure.Core.TestFramework;

namespace Azure.Data.Tables.Tests
{
    public class TablesRecordedTestSanitizer : RecordedTestSanitizer
    {
        private Regex SignatureRegEx = new Regex(@"([\x0026|&|?]sig=)([\w\d%]+)", RegexOptions.Compiled);

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                TablesTestEnvironment.PrimaryStorageKeyEnvironmentVariableName => string.Empty,
                TablesTestEnvironment.PrimaryCosmosKeyEnvironmentVariableName => string.Empty,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }

        public override string SanitizeUri(string uri)
        {
            return SignatureRegEx.Replace(uri, $"$1{SanitizeValue}");
        }
    }
}
