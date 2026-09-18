// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Chat.Tests
{
    [TestFixture]
    public class WebPubSubChatServiceClientTests
    {
        private const string FakeAccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH";
        private static string FakeConnectionString => $"Endpoint=http://localhost;Port=8080;AccessKey={FakeAccessKey};Version=1.0;";

        private static readonly JwtSecurityTokenHandler s_jwtTokenHandler = new();

        [Test]
        public void ConnectionStringConstructor_NullConnectionString_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new WebPubSubChatServiceClient((string)null, "hub"));
        }

        [Test]
        public void ConnectionStringConstructor_NullHub_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new WebPubSubChatServiceClient(FakeConnectionString, null));
        }

        [Test]
        public void ConnectionStringConstructor_EmptyHub_Throws()
        {
            Assert.Throws<ArgumentException>(() => new WebPubSubChatServiceClient(FakeConnectionString, string.Empty));
        }

        [Test]
        public void KeyCredentialConstructor_NullCredential_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => new WebPubSubChatServiceClient(new Uri("http://localhost"), "hub", (AzureKeyCredential)null));
        }

        [Test]
        public void GetClientAccessUri_KeyCredential_ProducesTokenUri()
        {
            var client = new WebPubSubChatServiceClient(FakeConnectionString, "hub");

            Uri uri = client.GetClientAccessUri(new ClientAccessUriOptions
            {
                UserId = "user1",
                ExpiresAfter = TimeSpan.FromMinutes(5),
            });

            Assert.That(uri.ToString(), Does.StartWith("ws://localhost:8080/client/hubs/hub?access_token="));

            const string tokenPrefix = "access_token=";
            var token = uri.Query.Substring(uri.Query.IndexOf(tokenPrefix, StringComparison.Ordinal) + tokenPrefix.Length);
            Assert.That(token, Is.Not.Null);

            JwtSecurityToken jwt = s_jwtTokenHandler.ReadJwtToken(token);
            var subject = jwt.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            Assert.That(subject, Is.EqualTo("user1"));
            Assert.That(jwt.Audiences, Is.EquivalentTo(new[] { "http://localhost:8080/client/hubs/hub" }));
            Assert.That(
                jwt.Claims.Where(c => c.Type == "role").Select(c => c.Value),
                Is.EquivalentTo(new[] { "webpubsub.getGroupState", "webpubsub.setGroupState" }));
        }

        [Test]
        public async Task GetClientAccessUriAsync_KeyCredential_ProducesTokenUri()
        {
            var client = new WebPubSubChatServiceClient(FakeConnectionString, "hub");

            Uri uri = await client.GetClientAccessUriAsync(new ClientAccessUriOptions { UserId = "user1" });

            Assert.That(uri.ToString(), Does.StartWith("ws://localhost:8080/client/hubs/hub?access_token="));
        }

        [Test]
        public void GetClientAccessUri_DefaultOptions_ProducesTokenUri()
        {
            var client = new WebPubSubChatServiceClient(FakeConnectionString, "hub");

            Uri uri = client.GetClientAccessUri();

            Assert.That(uri.ToString(), Does.StartWith("ws://localhost:8080/client/hubs/hub?access_token="));
        }

        [Test]
        public void KeyCredentialRequest_ReverseProxyUsesOriginalEndpointForJwtAudience()
        {
            var transport = new MockTransport(new MockResponse(201));
            var originalEndpoint = new Uri("https://contoso.webpubsub.azure.com");
            var proxyEndpoint = new Uri("https://apim.contoso.com");
            var options = new WebPubSubChatServiceClientOptions
            {
                Transport = transport,
                ReverseProxyEndpoint = proxyEndpoint,
            };
            var client = new WebPubSubChatServiceClient(originalEndpoint, "hub", new AzureKeyCredential(FakeAccessKey), options);

            client.CreateOrReplaceRole("user.role", RequestContent.Create(BinaryData.FromString("{}")));

            Uri requestUri = transport.SingleRequest.Uri.ToUri();
            Assert.That(requestUri.Host, Is.EqualTo(proxyEndpoint.Host));
            Assert.That(requestUri.PathAndQuery, Does.StartWith("/api/hubs/hub/chat/roles/user.role"));

            Assert.That(transport.SingleRequest.Headers.TryGetValue("Authorization", out string authorization), Is.True);
            JwtSecurityToken jwt = s_jwtTokenHandler.ReadJwtToken(authorization.Substring("Bearer ".Length));
            Assert.That(jwt.Audiences, Is.EquivalentTo(new[] { "https://contoso.webpubsub.azure.com/api/hubs/hub/chat/roles/user.role?api-version=2026-02-01-preview" }));
        }

        [Test]
        public void TokenCredentialRequest_UsesBearerTokenAndReverseProxy()
        {
            var transport = new MockTransport(new MockResponse(201));
            var proxyEndpoint = new Uri("https://apim.contoso.com");
            var options = new WebPubSubChatServiceClientOptions
            {
                Transport = transport,
                ReverseProxyEndpoint = proxyEndpoint,
            };
            var client = new WebPubSubChatServiceClient(
                new Uri("https://contoso.webpubsub.azure.com"),
                "hub",
                new StaticTokenCredential(),
                options);

            client.CreateOrReplaceRole("user.role", RequestContent.Create(BinaryData.FromString("{}")));

            Assert.That(transport.SingleRequest.Uri.ToUri().Host, Is.EqualTo(proxyEndpoint.Host));
            Assert.That(transport.SingleRequest.Headers.TryGetValue("Authorization", out string authorization), Is.True);
            Assert.That(authorization, Is.EqualTo("Bearer test-token"));
        }

        [Test]
        public void GetMessages_MessageQueryOptions_AreAddedToRequest()
        {
            var response = new MockResponse(200);
            response.SetContent("{\"value\":[]}");
            var transport = new MockTransport(response);
            var clientOptions = new WebPubSubChatServiceClientOptions { Transport = transport };
            var client = new WebPubSubChatServiceClient(
                new Uri("https://contoso.webpubsub.azure.com"),
                "hub",
                new StaticTokenCredential(),
                clientOptions);

            client.GetMessages("conversation", new MessageQueryOptions
            {
                LatestMessageId = "30",
                EarliestMessageId = "10",
                MaxPageSize = 20,
            }).AsPages().Single();

            Assert.That(
                transport.SingleRequest.Uri.Query,
                Is.EqualTo("?api-version=2026-02-01-preview&latestMessageId=30&earliestMessageId=10&maxpagesize=20"));
        }

        [Test]
        public void ReverseProxyEndpoint_UsesValueAtClientConstruction()
        {
            var transport = new MockTransport(new MockResponse(201));
            var proxyEndpoint = new Uri("https://apim.contoso.com");
            var options = new WebPubSubChatServiceClientOptions
            {
                Transport = transport,
                ReverseProxyEndpoint = new Uri("https://initial.contoso.com"),
            };

            options.ReverseProxyEndpoint = proxyEndpoint;
            var client = new WebPubSubChatServiceClient(
                new Uri("https://contoso.webpubsub.azure.com"),
                "hub",
                new StaticTokenCredential(),
                options);

            client.CreateOrReplaceRole("user.role", RequestContent.Create(BinaryData.FromString("{}")));

            Assert.That(transport.SingleRequest.Uri.ToUri().Host, Is.EqualTo(proxyEndpoint.Host));
        }

        [Test]
        public void TokenCredentialGetClientAccessUri_UsesConfiguredTransport()
        {
            var response = new MockResponse(200);
            response.SetContent("{\"token\":\"test-client-token\"}");
            var transport = new MockTransport(response);
            var options = new WebPubSubChatServiceClientOptions { Transport = transport };
            var client = new WebPubSubChatServiceClient(
                new Uri("https://contoso.webpubsub.azure.com"),
                "hub",
                new StaticTokenCredential(),
                options);

            Uri accessUri = client.GetClientAccessUri(new ClientAccessUriOptions
            {
                UserId = "user1",
                ExpiresAfter = TimeSpan.FromMinutes(2),
            });

            Uri requestUri = transport.SingleRequest.Uri.ToUri();
            Assert.That(requestUri.AbsolutePath, Is.EqualTo("/api/hubs/hub/:generateToken"));
            Assert.That(
                requestUri.Query,
                Is.EqualTo("?userId=user1&role=webpubsub.getGroupState&role=webpubsub.setGroupState&minutesToExpire=2&api-version=2024-12-01&clientType=default"));
            Assert.That(accessUri.Query, Does.Contain("access_token=test-client-token"));
        }

        [Test]
        public void TokenCredentialGetClientAccessUri_UsesConfiguredPolicy()
        {
            var response = new MockResponse(200);
            response.SetContent("{\"token\":\"test-client-token\"}");
            var transport = new MockTransport(response);
            var options = new WebPubSubChatServiceClientOptions { Transport = transport };
            options.AddPolicy(new TestHeaderPolicy(), HttpPipelinePosition.PerCall);
            var client = new WebPubSubChatServiceClient(
                new Uri("https://contoso.webpubsub.azure.com"),
                "hub",
                new StaticTokenCredential(),
                options);

            client.GetClientAccessUri();

            Assert.That(transport.SingleRequest.Headers.TryGetValue("x-test-policy", out string value), Is.True);
            Assert.That(value, Is.EqualTo("applied"));
        }

        [Test]
        public void TokenCredentialGetClientAccessUri_UsesConfiguredRetryOptions()
        {
            var success = new MockResponse(200);
            success.SetContent("{\"token\":\"test-client-token\"}");
            var transport = new MockTransport(new MockResponse(500), success);
            var options = new WebPubSubChatServiceClientOptions { Transport = transport };
            options.Retry.MaxRetries = 1;
            var client = new WebPubSubChatServiceClient(
                new Uri("https://contoso.webpubsub.azure.com"),
                "hub",
                new StaticTokenCredential(),
                options);

            Uri accessUri = client.GetClientAccessUri();

            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(accessUri.Query, Does.Contain("access_token=test-client-token"));
        }

        private sealed class TestHeaderPolicy : HttpPipelineSynchronousPolicy
        {
            public override void OnSendingRequest(HttpMessage message)
            {
                message.Request.Headers.Add("x-test-policy", "applied");
            }
        }

        private sealed class StaticTokenCredential : TokenCredential
        {
            private static readonly AccessToken s_token = new("test-token", DateTimeOffset.MaxValue);

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return s_token;
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(s_token);
            }
        }
    }
}
