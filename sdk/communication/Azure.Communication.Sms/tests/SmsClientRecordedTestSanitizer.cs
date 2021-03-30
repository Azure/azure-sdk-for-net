// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        public SmsClientRecordedTestSanitizer()
        {
            JsonPathSanitizers.Add("$..from");
            JsonPathSanitizers.Add("$..to");
            JsonPathSanitizers.Add("$..repeatabilityRequestId");
            JsonPathSanitizers.Add("$..repeatabilityFirstSent");
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
            => variableName switch
            {
                SmsClientTestEnvironment.AzurePhoneNumber => "+14255550123",
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
    }
}
