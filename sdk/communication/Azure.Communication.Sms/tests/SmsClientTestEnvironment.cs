// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientTestEnvironment : TestEnvironment
    {
        public string ConnectionString => GetRecordedVariable(CommunicationRecordedTestSanitizer.ConnectionStringEnvironmentVariableName);

        internal const string PhoneNumberEnvironmentVariableName = "AZURE_PHONE_NUMBER";

        public string PhoneNumber => GetRecordedVariable(PhoneNumberEnvironmentVariableName);
    }
}
