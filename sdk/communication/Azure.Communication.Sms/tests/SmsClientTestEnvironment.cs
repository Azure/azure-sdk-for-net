// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Tests;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientTestEnvironment : CommunicationTestEnvironment
    {
        public string ToPhoneNumber => GetRecordedVariable(AzurePhoneNumber);

        public string FromPhoneNumber => GetRecordedVariable(AzurePhoneNumber);
    }
}