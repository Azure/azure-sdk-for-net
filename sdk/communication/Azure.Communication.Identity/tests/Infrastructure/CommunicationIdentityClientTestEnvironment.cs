// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Tests;

namespace Azure.Communication.Identity.Tests
{
    public class CommunicationIdentityClientTestEnvironment : CommunicationTestEnvironment
    {
        // please find the allowed package value in tests.yml
        private const string IdentityTestPackagesEnabled = "identity";
        public override string ExpectedTestPackagesEnabled { get { return IdentityTestPackagesEnabled; } }
    }
}
