// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class BackupRestoreRecordedTestSanitizer : RecordedTestSanitizer
    {
        /// <summary>
        /// A RegEx to isolate a SAS token value.
        /// </summary>
        private Regex SignatureRegEx = new Regex(@"([\x0026|&|?]sig=)([\w\d%]+)", RegexOptions.Compiled);

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                KeyVaultTestEnvironment.PrimaryKeyEnvironmentVariableName => SanitizeValue,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }

        public override string SanitizeUri(string uri)
        {
            return SignatureRegEx.Replace(uri, $"$1{SanitizeValue}");
        }
    }
}
