// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Tests;

namespace Azure.Communication.Email.Tests
{
    public class EmailClientTestEnvironment : CommunicationTestEnvironment
    {
        public const string AzureManagedFromEmailAddressKey = "AZURE_MANAGED_FROM_EMAIL_ADDRESS";
        public const string ToEmailAddressKey = "TO_EMAIL_ADDRESS";

        public string AzureManagedFromEmailAddress => GetRecordedVariable(AzureManagedFromEmailAddressKey);
        public string ToEmailAddress => GetRecordedVariable(ToEmailAddressKey);
    }
}
