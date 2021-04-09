// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Tests;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientTestEnvironment : CommunicationTestEnvironment
    {
        // please find the allowed package value in tests.yml
        private const string SmsTestPackagesEnabled = "sms";

        public override string ExpectedTestPackagesEnabled { get { return SmsTestPackagesEnabled; } }

        public string ToPhoneNumber => GetRecordedVariable(AzurePhoneNumber);

        public string FromPhoneNumber => GetRecordedVariable(AzurePhoneNumber);
    }
}
