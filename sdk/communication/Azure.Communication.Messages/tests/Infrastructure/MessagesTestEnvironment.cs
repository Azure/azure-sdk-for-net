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
        public string SenderChannelRegistrationId => GetRecordedVariable("SENDER_CHANNEL_REGISTRATION_ID");
        public string RecipientIdentifier => GetRecordedVariable("RECIPIENT_IDENTIFIER");
        public string MediaContentId => GetRecordedVariable("MEDIA_CONTENT_ID");
        public string DownloadDestinationLocalPath => GetRecordedVariable("DOWNLOAD_DESTINATION_LOCAL_PATH");
    }
}
