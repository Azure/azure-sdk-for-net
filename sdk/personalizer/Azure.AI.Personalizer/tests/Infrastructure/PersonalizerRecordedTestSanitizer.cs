// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework;

namespace Azure.AI.Personalizer.Tests
{
    public class PersonalizerRecordedTestSanitizer : RecordedTestSanitizer
    {
        public PersonalizerRecordedTestSanitizer() : base()
        {
            AddJsonPathSanitizer("$..accessToken");
            AddJsonPathSanitizer("$..source");
            // TODO: Remove when re-recording
            LegacyConvertJsonDateTokens = true;
        }

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey("Ocp-Apim-Subscription-Key"))
            {
                headers["Ocp-Apim-Subscription-Key"] = new[] { SanitizeValue };
            }

            base.SanitizeHeaders(headers);
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                PersonalizerTestEnvironment.MultiSlotApiKeyEnvironmentVariableName => SanitizeValue,
                PersonalizerTestEnvironment.SingleSlotApiKeyEnvironmentVariableName => SanitizeValue,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }
    }
}
