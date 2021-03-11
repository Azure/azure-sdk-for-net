// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Tests;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientTestEnvironment : CommunicationTestEnvironment
    {
        internal const string ToPhoneNumberEnvironmentVariableName = "AZURE_PHONE_NUMBER";

        internal const string FromPhoneNumberEnvironmentVariableName = "AZURE_PHONE_NUMBER";

        internal const string LiveTestConnectionStringEnvironmentVariableName = "AZURE_COMMUNICATION_LIVETEST_CONNECTION_STRING";

        public string ToPhoneNumber => GetRecordedVariable(ToPhoneNumberEnvironmentVariableName);

        public string FromPhoneNumber => GetRecordedVariable(FromPhoneNumberEnvironmentVariableName);

        public string LiveTestConnectionString => GetRecordedVariable(LiveTestConnectionStringEnvironmentVariableName);
    }
}
