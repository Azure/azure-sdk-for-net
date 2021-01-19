// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        public SmsClientRecordedTestSanitizer() : base()
        {
            JsonPathSanitizers.Add("$..token");
            JsonPathSanitizers.Add("$..id");
            JsonPathSanitizers.Add("$..from");
            JsonPathSanitizers.Add("$..to");
            JsonPathSanitizers.Add("$..messageId");
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
            => variableName switch
            {
                SmsClientTestEnvironment.ConnectionStringEnvironmentVariableName => SanitizeConnectionString(environmentVariableValue),
                SmsClientTestEnvironment.PhoneNumberEnvironmentVariableName => "+18005555555",
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
    }
}
