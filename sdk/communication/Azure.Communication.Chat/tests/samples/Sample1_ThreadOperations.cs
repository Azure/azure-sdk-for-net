// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests.samples
{
    public partial class Sample1_ThreadOperations : SamplesBase<ChatTestEnvironment>
    {
        // This sample demonstrates the operations that can be performed on a thread: create, get, getThreads, update and delete.
        [Test]
        public async Task CreateGetUpdateDeleteThreadAsync()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.ConnectionString);
            Response<CommunicationUserIdentifier> threadCreatorIdentifier = await communicationIdentityClient.CreateUserAsync();
            CommunicationUserIdentifier kimberly = await communicationIdentityClient.CreateUserAsync();
            AccessToken communicationUserToken = await communicationIdentityClient.GetTokenAsync(threadCreatorIdentifier.Value, new[] { CommunicationTokenScope.Chat });
            string userToken = communicationUserToken.Token;
            var endpoint = TestEnvironment.Endpoint;

            #region Snippet:Azure_Communication_Chat_Tests_Samples_CreateChatClient
            ChatClient chatClient = new ChatClient(
                endpoint,
                new CommunicationTokenCredential(userToken));
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_CreateChatClient

            #region Snippet:Azure_Communication_Chat_Tests_Samples_CreateThread
            var chatParticipant = new ChatParticipant(identifier: kimberly)
            {
                DisplayName = "Kim"
            };
            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(topic: "Hello world!", participants: new[] { chatParticipant });
            string threadId = createChatThreadResult.ChatThread.Id;
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(threadId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_CreateThread

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetThread
            ChatThread chatThread = await chatClient.GetChatThreadAsync(threadId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetThread

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetThreads
            AsyncPageable<ChatThreadInfo> chatThreadsInfo = chatClient.GetChatThreadsInfoAsync();
            await foreach (ChatThreadInfo chatThreadInfo in chatThreadsInfo)
            {
                Console.WriteLine($"{ chatThreadInfo.Id}");
            }
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetThreads

            #region Snippet:Azure_Communication_Chat_Tests_Samples_UpdateThread
            await chatThreadClient.UpdateTopicAsync(topic: "new topic !");
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_UpdateThread

            #region Snippet:Azure_Communication_Chat_Tests_Samples_DeleteThread
            await chatClient.DeleteChatThreadAsync(threadId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_DeleteThread

            var josh = new ChatParticipant(new CommunicationUserIdentifier("invalid user"));
            #region Snippet:Azure_Communication_Chat_Tests_Samples_Troubleshooting
            try
            {
                CreateChatThreadResult createChatThreadErrorResult = await chatClient.CreateChatThreadAsync(topic: "Hello world!", participants: new[] { josh });
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_Troubleshooting
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
