// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Administration;
using Azure.Communication.Administration.Models;
using Azure.Communication;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests.samples
{
    public partial class Sample1_ThreadOperations : SamplesBase<ChatTestEnvironment>
    {
        // This sample demonstrates the operations that can be performed on a thread: create, get, getThreads, update and delete
        [Test]
        public async Task CreateGetUpdateDeleteThreadAsync()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.ConnectionString);
            Response<CommunicationUserIdentifier> threadMember = await communicationIdentityClient.CreateUserAsync();
            CommunicationUserToken communicationUserToken = await communicationIdentityClient.IssueTokenAsync(threadMember.Value, new[] { CommunicationTokenScope.Chat });
            string userToken = communicationUserToken.Token;
            string endpoint = TestEnvironment.ChatApiUrl();
            string threadCreatorId = communicationUserToken.User.Id;

            #region Snippet:Azure_Communication_Chat_Tests_Samples_CreateChatClient
            ChatClient chatClient = new ChatClient(
                new Uri(endpoint),
                new CommunicationTokenCredential(userToken));
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_CreateChatClient

            #region Snippet:Azure_Communication_Chat_Tests_Samples_CreateThread
            var chatThreadMember = new ChatThreadMember(new CommunicationUserIdentifier(threadCreatorId))
            {
                DisplayName = "UserDisplayName"
            };
            ChatThreadClient chatThreadClient = await chatClient.CreateChatThreadAsync(topic: "Hello world!", members: new[] { chatThreadMember });
            string threadId = chatThreadClient.Id;
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
            var topic = "new topic";
            await chatThreadClient.UpdateThreadAsync(topic);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_UpdateThread

            #region Snippet:Azure_Communication_Chat_Tests_Samples_DeleteThread
            await chatClient.DeleteChatThreadAsync(threadId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_DeleteThread

            #region Snippet:Azure_Communication_Chat_Tests_Samples_Troubleshooting
            try
            {
                /*@@*/ chatThreadMember = new ChatThreadMember(new CommunicationUserIdentifier("invalid user"));
                ChatThreadClient chatThreadClient_ = await chatClient.CreateChatThreadAsync(topic: "Hello world!", members: new[] { chatThreadMember });
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
