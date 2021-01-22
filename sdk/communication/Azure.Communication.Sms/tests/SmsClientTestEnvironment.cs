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
        internal const string EndpointEnvironmentVariableName = "COMMUNICATION_ENDPOINT_STRING";

        public string ConnectionString => GetRecordedVariable(ConnectionStringEnvironmentVariableName);
        public string PhoneNumber => GetRecordedVariable(PhoneNumberEnvironmentVariableName);
        public string EndpointString => GetRecordedVariable(EndpointEnvironmentVariableName);
    }
}
