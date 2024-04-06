// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Identity;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.Communication.Chat.Tests
{
    public class ChatLiveTestBase : RecordedTestBase<ChatTestEnvironment>
    {
        public const string SanitizedUnsignedUserTokenValue = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        private const string URIDomainNameReplacerRegEx = @"https://([^/?]+)";
        private const string URIIdentityReplacerRegEx = @"/identities/([^/?]+)";

        public ChatLiveTestBase(bool isAsync) : base(isAsync)
        {
            JsonPathSanitizers.Add("$..token");
            SanitizedHeaders.Add("x-ms-content-sha256");
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainNameReplacerRegEx, "https://sanitized.communication.azure.com"));
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIIdentityReplacerRegEx, "/identities/Sanitized"));
        }

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateInstrumentedCommunicationIdentityClient()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestDynamicConnectionString,
                    InstrumentClientOptions(new CommunicationIdentityClientOptions(CommunicationIdentityClientOptions.ServiceVersion.V2023_10_01))));

        /// <summary>
        /// Creates a <see cref="ChatClient" /> with a static token and instruments it to make use of
        /// the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="ChatClient" />.</returns>
        protected ChatClient CreateInstrumentedChatClient(string token)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                token = SanitizedUnsignedUserTokenValue;
            }

            CommunicationTokenCredential communicationTokenCredential = new CommunicationTokenCredential(token);
            return InstrumentClient(new ChatClient(TestEnvironment.LiveTestDynamicEndpoint, communicationTokenCredential,
                InstrumentClientOptions(new ChatClientOptions())));
        }

        protected ChatThreadClient GetInstrumentedChatThreadClient(ChatClient chatClient, string threadId)
        {
            return InstrumentClient(chatClient.GetChatThreadClient(threadId));
        }
    }
}
