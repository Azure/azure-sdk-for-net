// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Tests;

namespace Azure.Communication.PhoneNumbers.Tests
{
    public class PhoneNumbersClientTestEnvironment : CommunicationTestEnvironment
    {
        // please find the allowed package value in tests.yml
        private const string PhoneNumberTestPackagesEnabled = "phonenumber";
        public override string ExpectedTestPackagesEnabled { get { return PhoneNumberTestPackagesEnabled; } }
    }
}
