// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.Administration;
using Azure.Communication;
using Azure.Core.TestFramework;

namespace Azure.Communication.Chat.Tests
{
    public class ChatLiveTestBase : RecordedTestBase<ChatTestEnvironment>
    {
        public ChatLiveTestBase(bool isAsync) : base(isAsync)
           => Sanitizer = new ChatRecordedTestSanitizer();

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
            return InstrumentClient(new ChatClient(new Uri(TestEnvironment.ChatApiUrl()), communicationTokenCredential,
                InstrumentClientOptions(new ChatClientOptions())));
        }

        protected ChatThreadClient CreateInstrumentedChatThreadClient(ChatClient chatClient, string topic, IEnumerable<ChatThreadMember> members)
        {
            return InstrumentClient(chatClient.CreateChatThread(topic, members));
        }

        protected ChatThreadClient GetInstrumentedChatThreadClient(ChatClient chatClient, string threadId)
        {
            return InstrumentClient(chatClient.GetChatThreadClient(threadId));
        }

        protected async Task<ChatThreadClient> CreateInstrumentedChatThreadClientAsync(ChatClient chatClient, string topic, IEnumerable<ChatThreadMember> members)
        {
            return InstrumentClient(await chatClient.CreateChatThreadAsync(topic, members));
        }
    }
}
