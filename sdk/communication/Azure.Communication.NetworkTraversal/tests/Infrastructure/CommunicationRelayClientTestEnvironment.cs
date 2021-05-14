// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Tests;

namespace Azure.Communication.NetworkTraversal.Tests
{
    public class CommunicationRelayClientTestEnvironment : CommunicationTestEnvironment
    {
        // please find the allowed package value in tests.yml
        private const string NetworkTraversalPackagesEnabled = "networktraversal";
        public override string ExpectedTestPackagesEnabled { get { return NetworkTraversalPackagesEnabled; } }
    }
}
