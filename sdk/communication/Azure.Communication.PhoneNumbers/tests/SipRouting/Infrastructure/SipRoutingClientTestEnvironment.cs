// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;

namespace Azure.Communication.PhoneNumbers.SipRouting.Tests
{
    public class SipRoutingClientTestEnvironment: CommunicationTestEnvironment
    {
        public string GetTestDomain()
        {
            return GetOptionalVariable("AZURE_TEST_DOMAIN");
        }
    }
}
