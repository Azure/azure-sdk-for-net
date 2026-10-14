// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Chat.Tests
{
    public class WebPubSubChatServiceClientVersionTests : ClientTestBase
    {
        private const string Endpoint = "https://contoso.webpubsub.azure.com";
        private const string ApiVersion = "2026-08-01-preview";
        private const string RoomJson = """{"id":"room1","title":"General","defaultConversation":"c.room1.default","etag":"room-etag"}""";
        private const string UserJson = """{"kind":"Human","id":"alice","nickname":"Alice","roleName":"user.normal","etag":"user-etag"}""";
        private const string TopicJson = """{"id":"topic1","title":"Planning","createdAt":"2026-08-01T12:00:00Z","createdBy":"alice","state":"Normal","conversationId":"c.room1.topic1","etag":"topic-etag"}""";

        public WebPubSubChatServiceClientVersionTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetRoomsDeserializesRooms()
        {
            var transport = CreatePagedTransport("rooms", RoomJson);
            var client = CreateClient(transport);
            var rooms = new List<WebPubSubChatRoom>();
            await foreach (WebPubSubChatRoom room in client.GetRoomsAsync(maxPageSize: 1))
            {
                rooms.Add(room);
            }

            Assert.That(rooms, Has.Count.EqualTo(2));
            Assert.That(rooms[0].Id, Is.EqualTo("room1"));
            Assert.That(rooms[0].Title, Is.EqualTo("General"));
            Assert.That(rooms[0].DefaultConversation, Is.EqualTo("c.room1.default"));
            Assert.That(rooms[0].Etag, Is.EqualTo(new ETag("room-etag")));
            AssertPagingRequests(transport, "rooms");
        }

        [Test]
        public async Task GetUsersDeserializesHumanUsers()
        {
            var transport = CreatePagedTransport("users", UserJson);
            var client = CreateClient(transport);
            var users = new List<WebPubSubChatUser>();
            await foreach (WebPubSubChatUser user in client.GetUsersAsync(maxPageSize: 1))
            {
                users.Add(user);
            }

            Assert.That(users, Has.Count.EqualTo(2));
            Assert.That(users[0], Is.TypeOf<WebPubSubHumanChatUser>());
            Assert.That(users[0].Id, Is.EqualTo("alice"));
            Assert.That(users[0].Nickname, Is.EqualTo("Alice"));
            Assert.That(((WebPubSubHumanChatUser)users[0]).RoleName, Is.EqualTo("user.normal"));
            AssertPagingRequests(transport, "users");
        }

        [Test]
        public async Task GetTopicsDeserializesTopics()
        {
            var transport = CreatePagedTransport("rooms/room1/topics", TopicJson);
            var client = CreateClient(transport);
            var topics = new List<ChatTopic>();
            await foreach (ChatTopic topic in client.GetTopicsAsync("room1", maxPageSize: 1))
            {
                topics.Add(topic);
            }

            Assert.That(topics, Has.Count.EqualTo(2));
            AssertTopic(topics[0]);
            AssertPagingRequests(transport, "rooms/room1/topics");
        }

        [Test]
        public async Task GetRoomsForUserDeserializesRoomsAndEscapesUserId()
        {
            var transport = CreatePagedTransport("users/alice%20smith/rooms", RoomJson);
            var client = CreateClient(transport);
            var rooms = new List<ChatUserRoom>();
            await foreach (ChatUserRoom room in client.GetRoomsForUserAsync("alice smith", maxPageSize: 1))
            {
                rooms.Add(room);
            }

            Assert.That(rooms, Has.Count.EqualTo(2));
            Assert.That(rooms[0].Id, Is.EqualTo("room1"));
            Assert.That(rooms[0].Title, Is.EqualTo("General"));
            Assert.That(rooms[0].DefaultConversation, Is.EqualTo("c.room1.default"));
            Assert.That(rooms[0].Etag, Is.EqualTo(new ETag("room-etag")));
            AssertPagingRequests(transport, "users/alice%20smith/rooms");
        }

        [TestCase("rooms")]
        [TestCase("users")]
        [TestCase("rooms/room1/topics")]
        [TestCase("users/alice/rooms")]
        public async Task ProtocolListsResumeFromContinuationLink(string path)
        {
            var transport = new MockTransport(JsonResponse(200, """{"value":[]}"""));
            var client = CreateClient(transport);
            AsyncPageable<BinaryData> results = path switch
            {
                "rooms" => client.GetRoomsAsync(null, null, new RequestContext()),
                "users" => client.GetUsersAsync(null, null, new RequestContext()),
                "rooms/room1/topics" => client.GetTopicsAsync("room1", null, null, new RequestContext()),
                "users/alice/rooms" => client.GetRoomsForUserAsync("alice", null, null, new RequestContext()),
                _ => throw new ArgumentOutOfRangeException(nameof(path))
            };
            string nextLink = $"{Endpoint}/api/hubs/hub/chat/{path}?api-version={ApiVersion}&continuationToken=next%2Bpage";
            var pages = new List<Page<BinaryData>>();
            await foreach (Page<BinaryData> page in results.AsPages(nextLink))
            {
                pages.Add(page);
            }

            Assert.That(pages, Has.Count.EqualTo(1));
            Assert.That(pages[0].Values, Is.Empty);
            Assert.That(pages[0].ContinuationToken, Is.Null);
            Assert.That(transport.SingleRequest.Uri.ToUri().AbsoluteUri, Is.EqualTo(nextLink));
        }

        [TestCase("rooms")]
        [TestCase("users")]
        [TestCase("topics")]
        [TestCase("userRooms")]
        public async Task ListsSendContinuationTokenAndPageSizeHint(string collection)
        {
            var transport = new MockTransport(JsonResponse(200, """{"value":[]}"""));
            var client = CreateClient(transport);
            AsyncPageable<BinaryData> results = collection switch
            {
                "rooms" => client.GetRoomsAsync(10, "next+page", new RequestContext()),
                "users" => client.GetUsersAsync(10, "next+page", new RequestContext()),
                "topics" => client.GetTopicsAsync("room1", 10, "next+page", new RequestContext()),
                "userRooms" => client.GetRoomsForUserAsync("alice", 10, "next+page", new RequestContext()),
                _ => throw new ArgumentOutOfRangeException(nameof(collection))
            };
            await foreach (Page<BinaryData> page in results.AsPages(pageSizeHint: 2))
            {
                Assert.That(page.Values, Is.Empty);
            }

            Assert.That(transport.SingleRequest.Uri.Query, Does.Contain("maxpagesize=2"));
            Assert.That(transport.SingleRequest.Uri.Query, Does.Contain("continuationToken=next%2Bpage"));
        }

        [TestCase(200)]
        [TestCase(201)]
        public async Task CreateOrReplaceTopicSendsResourceAndConditions(int status)
        {
            var transport = new MockTransport(JsonResponse(status, TopicJson));
            var client = CreateClient(transport);
            ChatTopic topic = await client.CreateOrReplaceTopicAsync(
                "room1", "topic1", new ChatTopic("Planning", ChatTopicState.Normal),
                new MatchConditions { IfNoneMatch = ETag.All });

            AssertTopic(topic);
            AssertTopicRequest(transport.SingleRequest, RequestMethod.Put);
            AssertHeader(transport.SingleRequest, "If-None-Match", "*");
            AssertHeader(transport.SingleRequest, "Content-Type", "application/json");
            using JsonDocument body = await ReadBodyAsync(transport.SingleRequest);
            Assert.That(body.RootElement.GetProperty("title").GetString(), Is.EqualTo("Planning"));
            Assert.That(body.RootElement.TryGetProperty("id", out _), Is.False);
            Assert.That(body.RootElement.TryGetProperty("createdAt", out _), Is.False);
            Assert.That(body.RootElement.TryGetProperty("createdBy", out _), Is.False);
            Assert.That(body.RootElement.TryGetProperty("conversationId", out _), Is.False);
            Assert.That(body.RootElement.TryGetProperty("etag", out _), Is.False);
        }

        [TestCase("Normal")]
        [TestCase("Archived")]
        [TestCase("SoftDeleted")]
        [TestCase("FutureState")]
        public async Task GetTopicPreservesExtensibleState(string state)
        {
            var transport = new MockTransport(JsonResponse(200, TopicJson.Replace("\"Normal\"", $"\"{state}\"")));
            ChatTopic topic = await CreateClient(transport).GetTopicAsync("room1", "topic1");
            Assert.That(topic.State, Is.EqualTo(new ChatTopicState(state)));
            AssertTopicRequest(transport.SingleRequest, RequestMethod.Get);
        }

        [Test]
        public async Task UpdateTopicSendsOnlyPatchFieldsAndConditions()
        {
            var transport = new MockTransport(JsonResponse(200, TopicJson.Replace("\"Normal\"", "\"Archived\"")));
            var client = CreateClient(transport);
            using RequestContent patch = RequestContent.Create(new { state = "Archived" });
            Response response = await client.UpdateTopicAsync(
                "room1", "topic1", patch, new MatchConditions { IfMatch = new ETag("topic-etag") });

            Assert.That(((ChatTopic)response).State, Is.EqualTo(ChatTopicState.Archived));
            AssertTopicRequest(transport.SingleRequest, RequestMethod.Patch);
            AssertHeader(transport.SingleRequest, "If-Match", "\"topic-etag\"");
            AssertHeader(transport.SingleRequest, "Content-Type", "application/merge-patch+json");
            using JsonDocument body = await ReadBodyAsync(transport.SingleRequest);
            Assert.That(body.RootElement.EnumerateObject().Select(p => p.Name), Is.EqualTo(new[] { "state" }));
            Assert.That(body.RootElement.GetProperty("state").GetString(), Is.EqualTo("Archived"));
        }

        [Test]
        public async Task DeleteTopicSendsConditionalDelete()
        {
            var transport = new MockTransport(new MockResponse(204));
            Response response = await CreateClient(transport).DeleteTopicAsync(
                "room1", "topic1", new MatchConditions { IfMatch = new ETag("topic-etag") });
            Assert.That(response.Status, Is.EqualTo(204));
            AssertTopicRequest(transport.SingleRequest, RequestMethod.Delete);
            AssertHeader(transport.SingleRequest, "If-Match", "\"topic-etag\"");
        }

        [TestCase(404)]
        [TestCase(412)]
        public void TopicServiceErrorsAreSurfaced(int status)
        {
            var transport = new MockTransport(JsonResponse(status, """{"error":{"code":"TopicError","message":"Topic operation failed."}}"""));
            var client = CreateClient(transport);
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.DeleteTopicAsync("room1", "topic1"));
            Assert.That(exception.Status, Is.EqualTo(status));
            Assert.That(exception.ErrorCode, Is.EqualTo("TopicError"));
        }

        [TestCase(null, "topic1")]
        [TestCase("", "topic1")]
        [TestCase("room1", null)]
        [TestCase("room1", "")]
        public void TopicIdentifiersAreRequired(string roomId, string topicId)
        {
            var transport = new MockTransport();
            var client = CreateClient(transport);
            Assert.That(async () => await client.GetTopicAsync(roomId, topicId),
                Throws.InstanceOf<ArgumentException>());
            Assert.That(transport.Requests, Is.Empty);
        }

        private WebPubSubChatServiceClient CreateClient(MockTransport transport)
        {
            var options = new WebPubSubChatServiceClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            return InstrumentClient(new WebPubSubChatServiceClient(
                new Uri(Endpoint), "hub", new AzureKeyCredential("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH"), options));
        }

        private static MockResponse JsonResponse(int status, string json)
        {
            var response = new MockResponse(status);
            response.SetContent(json);
            response.AddHeader("Content-Type", "application/json");
            return response;
        }

        private static MockTransport CreatePagedTransport(string path, string item)
        {
            string nextLink = $"{Endpoint}/api/hubs/hub/chat/{path}?api-version={ApiVersion}&continuationToken=next%2Bpage";
            return new MockTransport(
                JsonResponse(200, $"{{\"value\":[{item}],\"nextLink\":\"{nextLink}\"}}"),
                JsonResponse(200, $"{{\"value\":[{item}]}}"));
        }

        private static void AssertPagingRequests(MockTransport transport, string path, bool hasPageSize = true)
        {
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            foreach (Request request in transport.Requests)
            {
                Assert.That(request.Method, Is.EqualTo(RequestMethod.Get));
                Assert.That(request.Uri.ToUri().AbsolutePath, Is.EqualTo($"/api/hubs/hub/chat/{path}"));
                Assert.That(request.Uri.Query, Does.Contain($"api-version={ApiVersion}"));
                if (hasPageSize)
                {
                    Assert.That(request.Uri.Query, Does.Contain("maxpagesize=1"));
                }
            }
            Assert.That(transport.Requests[1].Uri.Query, Does.Contain("continuationToken=next%2Bpage"));
        }

        private static void AssertTopic(ChatTopic topic)
        {
            Assert.That(topic.Id, Is.EqualTo("topic1"));
            Assert.That(topic.Title, Is.EqualTo("Planning"));
            Assert.That(topic.CreatedOn, Is.EqualTo(new DateTimeOffset(2026, 8, 1, 12, 0, 0, TimeSpan.Zero)));
            Assert.That(topic.CreatedBy, Is.EqualTo("alice"));
            Assert.That(topic.State, Is.EqualTo(ChatTopicState.Normal));
            Assert.That(topic.ConversationId, Is.EqualTo("c.room1.topic1"));
            Assert.That(topic.Etag, Is.EqualTo(new ETag("topic-etag")));
        }

        private static void AssertTopicRequest(Request request, RequestMethod method)
        {
            Assert.That(request.Method, Is.EqualTo(method));
            Assert.That(request.Uri.ToUri().AbsoluteUri,
                Is.EqualTo($"{Endpoint}/api/hubs/hub/chat/rooms/room1/topics/topic1?api-version={ApiVersion}"));
        }

        private static void AssertHeader(Request request, string name, string expected)
        {
            Assert.That(request.Headers.TryGetValue(name, out string actual), Is.True);
            Assert.That(actual, Is.EqualTo(expected));
        }

        private static async Task<JsonDocument> ReadBodyAsync(Request request)
        {
            using var stream = new MemoryStream();
            await request.Content.WriteToAsync(stream, CancellationToken.None);
            return JsonDocument.Parse(stream.ToArray());
        }
    }
}
