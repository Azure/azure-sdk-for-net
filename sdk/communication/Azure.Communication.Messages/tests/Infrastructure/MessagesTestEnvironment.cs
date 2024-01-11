// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Tests;

namespace Azure.Communication.Messages.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class MessagesTestEnvironment : CommunicationTestEnvironment
    {
        public string SenderChannelRegistrationId => "75da05b7-831f-45cf-923d-98e9a9f4c16a";
        public string RecipientIdentifier => "+16043609258";
    }
}
