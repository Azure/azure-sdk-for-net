// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Chat.Tests
{
    public partial class WebPubSubChatServiceClientLiveTests
    {
        [RecordedTest]
        public async Task DiscoverRoomsUsersAndMemberships()
        {
            string roomId = Recording.GenerateId("discovery", 32);
            string userId = Recording.GenerateId("user", 32);
            await _client.CreateOrReplaceRoomAsync(roomId, new WebPubSubChatRoom("Discovery"));
            try
            {
                await _client.CreateOrReplaceUserAsync(userId,
                    new WebPubSubHumanChatUser("Discovery user", BuiltInChatRoles.UserNormal));
                try
                {
                    await _client.CreateOrReplaceRoomMemberAsync(
                        roomId, userId, new WebPubSubChatRoomMember(BuiltInChatRoles.RoomMember));
                    try
                    {
                        var roomIds = new List<string>();
                        await foreach (WebPubSubChatRoom room in _client.GetRoomsAsync(maxPageSize: 1))
                        {
                            roomIds.Add(room.Id);
                        }
                        Assert.That(roomIds, Does.Contain(roomId));

                        var userIds = new List<string>();
                        await foreach (WebPubSubChatUser user in _client.GetUsersAsync(maxPageSize: 1))
                        {
                            userIds.Add(user.Id);
                        }
                        Assert.That(userIds, Does.Contain(userId));

                        var memberRoomIds = new List<string>();
                        await foreach (ChatUserRoom room in _client.GetRoomsForUserAsync(userId, maxPageSize: 1))
                        {
                            memberRoomIds.Add(room.Id);
                        }
                        Assert.That(memberRoomIds, Does.Contain(roomId));
                    }
                    finally
                    {
                        await _client.DeleteRoomMemberAsync(roomId, userId);
                    }
                }
                finally
                {
                    await _client.DeleteUserAsync(userId);
                }
            }
            finally
            {
                await _client.DeleteRoomAsync(roomId);
            }
        }

        [RecordedTest]
        public async Task ManageTopicLifecycle()
        {
            string roomId = Recording.GenerateId("topics", 32);
            await _client.CreateOrReplaceRoomAsync(roomId, new WebPubSubChatRoom("Topics"));
            try
            {
                ChatTopic created = await _client.CreateOrReplaceTopicAsync(
                    roomId, "planning", new ChatTopic("Planning") { State = ChatTopicState.Normal },
                    new MatchConditions { IfNoneMatch = ETag.All });
                Assert.That(created.Id, Is.EqualTo("planning"));
                Assert.That(created.ConversationId, Is.Not.Null.And.Not.Empty);
                Assert.That(created.State, Is.EqualTo(ChatTopicState.Normal));

                await _client.CreateOrReplaceTopicAsync(
                    roomId, "general", new ChatTopic("General") { State = ChatTopicState.Normal });
                var topicIds = new List<string>();
                int pageCount = 0;
                await foreach (Page<ChatTopic> page in _client.GetTopicsAsync(roomId, maxPageSize: 1).AsPages())
                {
                    pageCount++;
                    Assert.That(page.Values.Count, Is.LessThanOrEqualTo(1));
                    foreach (ChatTopic topic in page.Values)
                    {
                        topicIds.Add(topic.Id);
                    }
                }
                Assert.That(topicIds, Does.Contain("planning").And.Contain("general"));
                Assert.That(pageCount, Is.GreaterThanOrEqualTo(2));

                ChatTopic fetched = await _client.GetTopicAsync(roomId, "planning");
                Assert.That(fetched.Title, Is.EqualTo("Planning"));
                Assert.That(fetched.ConversationId, Is.EqualTo(created.ConversationId));

                ChatTopic archived = await _client.UpdateTopicAsync(
                    roomId, "planning", new UpdateTopicOptions { Title = "Archived planning", State = ChatTopicState.Archived },
                    new MatchConditions { IfMatch = fetched.Etag });
                Assert.That(archived.Title, Is.EqualTo("Archived planning"));
                Assert.That(archived.State, Is.EqualTo(ChatTopicState.Archived));

                Response deleted = await _client.DeleteTopicAsync(
                    roomId, "planning", new MatchConditions { IfMatch = archived.Etag });
                Assert.That(deleted.Status, Is.EqualTo(204));
                await _client.DeleteTopicAsync(roomId, "general");
            }
            finally
            {
                await _client.DeleteRoomAsync(roomId);
            }
        }
    }
}
