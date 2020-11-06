// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientTestEnvironment : TestEnvironment
    {
        public SmsClientTestEnvironment() : base("communication")
        {
        }

        internal const string ConnectionStringEnvironmentVariableName = "COMMUNICATION_CONNECTION_STRING";
        internal const string ToPhoneNumberEnvironmentVariableName = "TO_PHONE_NUMBER";
        internal const string FromPhoneNumberEnvironmentVariableName = "FROM_PHONE_NUMBER";

        public string ConnectionString => GetRecordedVariable(ConnectionStringEnvironmentVariableName);

        public string ToPhoneNumber => GetRecordedVariable(ToPhoneNumberEnvironmentVariableName);

        public string FromPhoneNumber => GetRecordedVariable(FromPhoneNumberEnvironmentVariableName);
    }
}
