// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Tests;
using Azure.Core.TestFramework;

namespace Azure.Communication.PhoneNumbers.SipRouting.Tests.Infrastructure
{
    public class SipRoutingClientTestEnvironment: TestEnvironment
    {
        public string ConnectionString => "endpoint=https://e2e_test.communication.azure.com/;accesskey=qGUv+J0z5Xv8TtjC0qZhy34sodSOMKG5HS7NfsjhqxaB/ZP4UnuS4FspWPo3JowuqAb+75COGi4ErREkB76/UQ==";
    }
}
