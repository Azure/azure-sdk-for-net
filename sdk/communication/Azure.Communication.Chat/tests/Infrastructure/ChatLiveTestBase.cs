// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Identity;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests
{
    public class ChatLiveTestBase : RecordedTestBase<ChatTestEnvironment>
    {
        public ChatLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new ChatRecordedTestSanitizer();

        [OneTimeSetUp]
        public void Setup()
        {
            if (TestEnvironment.ShouldIgnoreTests)
            {
                Assert.Ignore("Chat tests are skipped " +
                    "because chat package is not included in the TEST_PACKAGES_ENABLED variable");
            }
        }

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateInstrumentedCommunicationIdentityClient()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new CommunicationIdentityClientOptions())));

        /// <summary>
        /// Creates a <see cref="ChatClient" /> with a static token and instruments it to make use of
        /// the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="ChatClient" />.</returns>
        protected ChatClient CreateInstrumentedChatClient(string token)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                token = ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue;
            }

            CommunicationTokenCredential communicationTokenCredential = new CommunicationTokenCredential(token);
            return InstrumentClient(new ChatClient(TestEnvironment.Endpoint, communicationTokenCredential,
                CreateChatClientOptionsWithCorrelationVectorLogs()));
        }

        protected ChatThreadClient GetInstrumentedChatThreadClient(ChatClient chatClient, string threadId)
        {
            return InstrumentClient(chatClient.GetChatThreadClient(threadId));
        }

        private ChatClientOptions CreateChatClientOptionsWithCorrelationVectorLogs()
        {
            ChatClientOptions chatClientOptions = new ChatClientOptions();
            chatClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(chatClientOptions);
        }
    }
}
