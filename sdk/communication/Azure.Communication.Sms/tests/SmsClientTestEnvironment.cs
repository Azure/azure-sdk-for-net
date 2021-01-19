// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientTestEnvironment : TestEnvironment
    {
        internal const string ConnectionStringEnvironmentVariableName = "COMMUNICATION_CONNECTION_STRING";
        public string ConnectionString => GetRecordedVariable(ConnectionStringEnvironmentVariableName);

        internal const string PhoneNumberEnvironmentVariableName = "AZURE_PHONE_NUMBER";
        public string PhoneNumber => GetRecordedVariable(PhoneNumberEnvironmentVariableName);
    }
}
