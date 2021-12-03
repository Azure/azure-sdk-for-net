// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Dns.Tests
{
    public class DnsManagementTestEnvironment : TestEnvironment
    {
        public string TestDomain => GetRecordedVariable("DNS_TEST_DOMAIN");
    }
}
