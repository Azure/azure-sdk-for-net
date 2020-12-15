// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientTestEnvironment : TestEnvironment
    {
        internal const string ConnectionStringEnvironmentVariableName = "AZURE_COMMUNICATION_LIVETEST_CONNECTION_STRING";
        internal const string PhoneNumberEnvironmentVariableName = "AZURE_PHONE_NUMBER";

        public string ConnectionString => GetRecordedVariable(ConnectionStringEnvironmentVariableName);
        public string PhoneNumber => GetRecordedVariable(PhoneNumberEnvironmentVariableName);
    }
}
