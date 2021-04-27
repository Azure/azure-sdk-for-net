// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Tests;

namespace Azure.Communication.Chat.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class ChatTestEnvironment : CommunicationTestEnvironment
    {
        // please find the allowed package value in tests.yml
        private const string ChatTestPackagesEnabled = "chat";
        public override string ExpectedTestPackagesEnabled { get { return ChatTestPackagesEnabled; } }
    }
}
