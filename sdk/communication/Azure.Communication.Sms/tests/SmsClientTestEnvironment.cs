// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Tests;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientTestEnvironment : CommunicationTestEnvironment
    {
        internal const string PhoneNumberEnvironmentVariableName = "AZURE_PHONE_NUMBER";

        public string PhoneNumber => GetRecordedVariable(PhoneNumberEnvironmentVariableName);
    }
}
