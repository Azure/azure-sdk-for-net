// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests.samples
{
    public partial class Sample1_ThreadOperations : SamplesBase<ChatTestEnvironment>
    {
        // This sample demonstrates the operations that can be performed on a thread: create, get, getThreads, update and delete.
        [Test]
        public async Task CreateGetUpdateDeleteThreadAsync()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.LiveTestDynamicConnectionString);
            Response<CommunicationUserIdentifier> threadCreatorIdentifier = await communicationIdentityClient.CreateUserAsync();
            CommunicationUserIdentifier kimberly = await communicationIdentityClient.CreateUserAsync();
            AccessToken communicationUserToken = await communicationIdentityClient.GetTokenAsync(threadCreatorIdentifier.Value, new[] { CommunicationTokenScope.Chat });
            string userToken = communicationUserToken.Token;
            var endpoint = TestEnvironment.LiveTestDynamicEndpoint;

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

            chatParticipant.Metadata.Add("MetadataKey1", "MetadataValue1");
            chatParticipant.Metadata.Add("MetadataKey2", "MetadataValue2");

            CreateChatThreadOptions createChatThreadOptions = new CreateChatThreadOptions("Hello world!");

            createChatThreadOptions.Participants.Add(chatParticipant);

            createChatThreadOptions.Metadata.Add("MetadataKey1", "MetadataValue1");
            createChatThreadOptions.Metadata.Add("MetadataKey2", "MetadataValue2");

            createChatThreadOptions.RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(60);

            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(createChatThreadOptions);
            string threadId = createChatThreadResult.ChatThread.Id;
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(threadId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_CreateThread

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetThread
            ChatThreadProperties chatThread = await chatThreadClient.GetPropertiesAsync();
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetThread

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetThreads
            AsyncPageable<ChatThreadItem> chatThreadItems = chatClient.GetChatThreadsAsync();
            await foreach (ChatThreadItem chatThreadItem in chatThreadItems)
            {
                Console.WriteLine($"{ chatThreadItem.Id}");
            }
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetThreads

            #region Snippet:Azure_Communication_Chat_Tests_Samples_UpdateThread
            UpdateChatThreadPropertiesOptions updateChatThreadPropertiesOptions = new UpdateChatThreadPropertiesOptions();
            updateChatThreadPropertiesOptions.Topic = "new topic !";
            updateChatThreadPropertiesOptions.Metadata.Add("UpdateMetadataKey", "UpdateMetadataValue");

            updateChatThreadPropertiesOptions.RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(60);

            await chatThreadClient.UpdatePropertiesAsync(updateChatThreadPropertiesOptions);
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
