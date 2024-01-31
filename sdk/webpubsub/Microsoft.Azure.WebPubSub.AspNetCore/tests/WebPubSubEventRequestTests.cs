// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests
{
    [TestFixture]
    public class WebPubSubEventRequestTests
    {
        private static readonly Uri TestUri = new Uri("https://my-host.com");
        private static readonly RequestValidator TestValidator = new(Options.Create(new WebPubSubOptions()));

        [Test]
        public void TestUpdateConnectionState()
        {
            var exist = new Dictionary<string, BinaryData>
            {
                { "aaa", BinaryData.FromObjectAsJson("aaa") },
                { "bbb", BinaryData.FromObjectAsJson("bbb") }
            };
            var connectionContext = new WebPubSubConnectionContext(eventType: WebPubSubEventType.System, null, null, null, connectionStates: exist);

            var response = new ConnectEventResponse
            {
                UserId = "aaa"
            };
            response.SetState("test", BinaryData.FromObjectAsJson("ddd"));
            response.SetState("bbb", BinaryData.FromObjectAsJson("bbb1"));
            var updated = connectionContext.UpdateStates(response.ConnectionStates);

            // new
            Assert.AreEqual("ddd", updated["test"].ToObjectFromJson<string>());
            // no change
            Assert.AreEqual("aaa", updated["aaa"].ToObjectFromJson<string>());
            // update
            Assert.AreEqual("bbb1", updated["bbb"].ToObjectFromJson<string>());

            response.ClearStates();
            updated = connectionContext.UpdateStates(response.ConnectionStates);

            // After clear is null.
            Assert.IsNull(updated);
        }

        [Test]
        public void TestEncodeAndDecodeState()
        {
            var state = new Dictionary<string, BinaryData>
            {
                { "aaa", BinaryData.FromObjectAsJson("aaa") },
                { "bbb", BinaryData.FromObjectAsJson("bbb") }
            };

            var encoded = state.EncodeConnectionStates();

            var decoded = encoded.DecodeConnectionStates();

            CollectionAssert.AreEquivalent(
                state.Values.Select(d => d.ToObjectFromJson<string>()),
                decoded.Values.Select(d => d.ToObjectFromJson<string>()));
        }

        [Test]
        public void TestConnectEventDeserialize()
        {
            var request = "{\"claims\":{\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"ddd\"],\"nbf\":[\"1629183374\"],\"exp\":[\"1629186974\"],\"iat\":[\"1629183374\"],\"aud\":[\"http://localhost:8080/client/hubs/chat\"],\"sub\":[\"ddd\"]},\"query\":{\"access_token\":[\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkZGQiLCJuYmYiOjE2MjkxODMzNzQsImV4cCI6MTYyOTE4Njk3NCwiaWF0IjoxNjI5MTgzMzc0LCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjgwODAvY2xpZW50L2h1YnMvY2hhdCJ9.tqD8ykjv5NmYw6gzLKglUAv-c-AVWu-KNZOptRKkgMM\"]},\"subprotocols\":[\"protocol1\",\"protocol2\"],\"clientCertificates\":[],\"headers\":{\"request-id\":[\"aaa\"],\"bbb\":[\"bbb\"]}}";

            var converted = JsonSerializer.Deserialize<ConnectEventRequest>(request);

            Assert.AreEqual(6, converted.Claims.Count);
            Assert.AreEqual(1, converted.Query.Count);
            Assert.AreEqual(2, converted.Subprotocols.Count);
            Assert.AreEqual(2, converted.Headers.Count);
            Assert.AreEqual(new string[] { "protocol1", "protocol2" }, converted.Subprotocols);
            Assert.NotNull(converted.ClientCertificates);
            Assert.AreEqual(0, converted.ClientCertificates.Count);
        }

        [Test]
        public void TestConnectEventRequestSerialize()
        {
            var connectionContext = new WebPubSubConnectionContext(
                WebPubSubEventType.System,
                null, null, "0f9c97a2f0bf4706afe87a14e0797b11",
                signature: "sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561",
                origin: TestUri.Host);

            var claims = new Dictionary<string, string[]>
            {
                {"aaa", new string[]{"a1", "a2"} },
                {"bbb", new string[]{"b1", "b2"} },
                {"ccc", new string[]{"c1", "c2"} },
            };
            var query = new Dictionary<string, string[]>
            {
                {"query1", new string[]{"a1", "a2"} },
                {"query2", new string[]{"b1"} },
            };
            var certs = new List<WebPubSubClientCertificate>
            {
                new WebPubSubClientCertificate("111"),
                new WebPubSubClientCertificate("222")
            };
            var request = new ConnectEventRequest(connectionContext, claims, query, new string[] { "protocol1", "protocol2" }, certs);

            var serilized = JsonSerializer.Serialize(request);

            var converted = JsonSerializer.Deserialize<ConnectEventRequest>(serilized);

            Assert.AreEqual(3, converted.Claims.Count);
            Assert.AreEqual(2, converted.Query.Count);
            Assert.AreEqual(2, converted.Subprotocols.Count);
            Assert.AreEqual(new string[] { "protocol1", "protocol2" }, converted.Subprotocols);
            Assert.NotNull(converted.ClientCertificates);
            Assert.AreEqual(2, converted.ClientCertificates.Count);
        }

        [Test]
        public void TestUserEventRequestSerialize()
        {
            var connectionContext = new WebPubSubConnectionContext(
                WebPubSubEventType.System,
                null, null, "0f9c97a2f0bf4706afe87a14e0797b11",
                signature: "sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561",
                origin: TestUri.Host);

            var request = new UserEventRequest(connectionContext, BinaryData.FromString("Hello World"), WebPubSubDataType.Text);

            var serialized = JsonSerializer.Serialize(request);
        }

        [Test]
        public void TestDisconnectedEventDeserialize()
        {
            var request = "{\"reason\":\"invalid\"}";

            var converted = JsonSerializer.Deserialize<DisconnectedEventRequest>(request);

            Assert.AreEqual("invalid", converted.Reason);
        }

        [Test]
        public async Task TestParseConnectRequest()
        {
            var body = "{\"claims\":{\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"ddd\"],\"nbf\":[\"1629183374\"],\"exp\":[\"1629186974\"],\"iat\":[\"1629183374\"],\"aud\":[\"http://localhost:8080/client/hubs/chat\"],\"sub\":[\"ddd\"]},\"query\":{\"access_token\":[\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkZGQiLCJuYmYiOjE2MjkxODMzNzQsImV4cCI6MTYyOTE4Njk3NCwiaWF0IjoxNjI5MTgzMzc0LCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjgwODAvY2xpZW50L2h1YnMvY2hhdCJ9.tqD8ykjv5NmYw6gzLKglUAv-c-AVWu-KNZOptRKkgMM\"]},\"subprotocols\":[\"protocol1\", \"protocol2\"],\"clientCertificates\":[],\"headers\":{\"request-id\":[\"aaa\"],\"bbb\":[\"bbb\"]}}";
            var context = PrepareHttpContext(TestUri, WebPubSubEventType.System, Constants.Events.ConnectEvent, body: body);

            var request = await context.Request.ReadWebPubSubEventAsync(TestValidator);

            Assert.AreEqual(typeof(ConnectEventRequest), request.GetType());

            var connectRequest = request as ConnectEventRequest;

            Assert.NotNull(connectRequest.ConnectionContext);
            Assert.NotNull(connectRequest.Headers);
            Assert.AreEqual(2, connectRequest.Headers.Count);
            Assert.AreEqual(TestUri.Host, connectRequest.ConnectionContext.Origin);
        }

        [Test]
        public async Task TestParseConnectedRequest()
        {
            var context = PrepareHttpContext(TestUri, WebPubSubEventType.System, Constants.Events.ConnectedEvent);
            var validator = new RequestValidator(Options.Create(new WebPubSubOptions()));

            var request = await context.Request.ReadWebPubSubEventAsync(validator);

            Assert.AreEqual(typeof(ConnectedEventRequest), request.GetType());

            var connectedRequest = request as ConnectedEventRequest;

            Assert.NotNull(connectedRequest.ConnectionContext);
            Assert.AreEqual(TestUri.Host, connectedRequest.ConnectionContext.Origin);
        }

        [Test]
        public async Task TestParseUserRequest()
        {
            var text = "hello world";
            var context = PrepareHttpContext(TestUri, WebPubSubEventType.User, "message", body: text);

            var request = await context.Request.ReadWebPubSubEventAsync(TestValidator);

            Assert.AreEqual(typeof(UserEventRequest), request.GetType());

            var userRequest = request as UserEventRequest;

            Assert.NotNull(userRequest.ConnectionContext);
            Assert.AreEqual(TestUri.Host, userRequest.ConnectionContext.Origin);
            Assert.AreEqual(text, userRequest.Data.ToString());
        }

        [TestCase("7aab239577fd4f24bc919802fb629f5f", true)]
        [TestCase("ccc", false)]
        public void TestSignatureCheck(string accessKey, bool valid)
        {
            var connectionContext = new WebPubSubConnectionContext(
                WebPubSubEventType.System,
                null, null, "0f9c97a2f0bf4706afe87a14e0797b11",
                signature: "sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561",
                origin: TestUri.Host);
            var options = new RequestValidator(Options.Create(new WebPubSubOptions { ServiceEndpoint = new WebPubSubServiceEndpoint($"Endpoint={TestUri};AccessKey={accessKey};Version=1.0;") }));
            var result = options.IsValidSignature(connectionContext);
            Assert.AreEqual(valid, result);
        }

        [Test]
        public void TestSignatureCheck_OptionsEmptySuccess()
        {
            var connectionContext = new WebPubSubConnectionContext(
                WebPubSubEventType.System,
                null, null, "0f9c97a2f0bf4706afe87a14e0797b11",
                signature: "sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561",
                origin: TestUri.Host);
            var result = TestValidator.IsValidSignature(connectionContext);
            Assert.True(result);
        }

        [Test]
        public void TestSignatureCheck_AccessKeyEmptySuccess()
        {
            var connectionContext = new WebPubSubConnectionContext(
                WebPubSubEventType.System,
                null, null, "0f9c97a2f0bf4706afe87a14e0797b11",
                signature: "sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561",
                origin: TestUri.Host);
            var validator = new RequestValidator(Options.Create(new WebPubSubOptions{ ServiceEndpoint = new WebPubSubServiceEndpoint($"Endpoint={TestUri};Version=1.0;") }));
            var result = validator.IsValidSignature(connectionContext);
            Assert.True(result);
        }

        [Test]
        public void TestSignatureCheck_SignatureNullFail()
        {
            var connectionContext = new WebPubSubConnectionContext(
                WebPubSubEventType.System,
                null, null, "0f9c97a2f0bf4706afe87a14e0797b11",
                origin: TestUri.Host);
            var validator = new RequestValidator(Options.Create(new WebPubSubOptions { ServiceEndpoint = new WebPubSubServiceEndpoint($"Endpoint={TestUri};AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;") }));
            var result = validator.IsValidSignature(connectionContext);
            Assert.False(result);
        }

        [TestCase("sha256=something,sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561")]
        [TestCase("sha256=something, sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561")]
        [TestCase("sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561, sha256=something")]
        [TestCase("sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561,sha256=something")]
        public void TestSignatureCheck_MultiSignatureSuccess(string signatures)
        {
            var connectionContext = new WebPubSubConnectionContext(
                WebPubSubEventType.System,
                null, null, "0f9c97a2f0bf4706afe87a14e0797b11",
                signature: signatures,
                origin: TestUri.Host);
            var validator = new RequestValidator(Options.Create(new WebPubSubOptions { ServiceEndpoint = new WebPubSubServiceEndpoint($"Endpoint={TestUri};Version=1.0;") }));
            var result = validator.IsValidSignature(connectionContext);
            Assert.True(result);
        }

        [TestCase("OPTIONS", true)]
        [TestCase("DELETE", false)]
        [TestCase("OPTIONS", true, true)]
        public void TestAbuseProtection(string httpMethod, bool valid, bool multiDomains = false)
        {
            var context = PrepareHttpContext(TestUri, WebPubSubEventType.System, Constants.Events.ConnectEvent, httpMethod: httpMethod, multiDomains: multiDomains);

            var result = context.Request.IsPreflightRequest(out var requestHosts);

            Assert.AreEqual(valid, result);

            if (valid)
            {
                Assert.NotNull(requestHosts);
                Assert.AreEqual(TestUri.Host, requestHosts[0]);
                if (multiDomains)
                {
                    Assert.AreEqual(2, requestHosts.Count);
                }
                else
                {
                    Assert.AreEqual(1, requestHosts.Count);
                }
            }
        }

        [TestCase("my-host.com", true)]
        [TestCase("my-host1.com", false)]
        [TestCase("localhost", false)]
        [TestCase("http://localhost", false)]
        public void TestAbuseProtectionCompare(string requestHost, bool expected)
        {
            var validator = new RequestValidator(Options.Create(new WebPubSubOptions { ServiceEndpoint = new WebPubSubServiceEndpoint($"Endpoint=https://my-host.com;AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;") }));

            Assert.AreEqual(expected, validator.IsValidOrigin(new List<string> { requestHost }));
        }

        private static HttpContext PrepareHttpContext(
            Uri uri,
            WebPubSubEventType type,
            string eventName,
            string connectionId = "0f9c97a2f0bf4706afe87a14e0797b11",
            string signatures = "sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561",
            string hub = "testhub",
            string httpMethod = "POST",
            string userId = "testuser",
            string body = null,
            string contentType = Constants.ContentTypes.PlainTextContentType,
            bool multiDomains = false)
        {
            var context = new DefaultHttpContext();
            var services = new ServiceCollection();
            var sp = services.BuildServiceProvider();
            context.RequestServices = sp;

            var request = context.Request;
            var requestFeature = request.HttpContext.Features.Get<IHttpRequestFeature>();
            requestFeature.Method = httpMethod;
            requestFeature.Scheme = uri.Scheme;
            requestFeature.PathBase = uri.Host;
            requestFeature.Path = uri.GetComponents(UriComponents.KeepDelimiter | UriComponents.Path, UriFormat.Unescaped);
            requestFeature.PathBase = "/";
            requestFeature.QueryString = uri.GetComponents(UriComponents.KeepDelimiter | UriComponents.Query, UriFormat.Unescaped);

            var headers = new HeaderDictionary
            {
                { Constants.Headers.CloudEvents.Hub, hub },
                { Constants.Headers.CloudEvents.Type, GetFormedType(type, eventName) },
                { Constants.Headers.CloudEvents.EventName, eventName },
                { Constants.Headers.CloudEvents.ConnectionId, connectionId },
                { Constants.Headers.CloudEvents.Signature, signatures }
            };

            if (!string.IsNullOrEmpty(uri.Host))
            {
                headers.Add("Host", uri.Host);
                var origins = uri.Host;
                if (multiDomains)
                {
                    origins += ", custom.domain.com";
                }
                headers.Add(Constants.Headers.WebHookRequestOrigin, origins);
            }

            if (userId != null)
            {
                headers.Add(Constants.Headers.CloudEvents.UserId, userId);
            }

            if (body != null)
            {
                requestFeature.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
                request.ContentLength = request.Body.Length;
                headers.Add("Content-Length", request.Body.Length.ToString());
                request.ContentType = contentType;
                headers.Add("Content-Type", contentType);
            }

            requestFeature.Headers = headers;

            return context;
        }

        private static string GetFormedType(WebPubSubEventType type, string eventName)
        {
            return type == WebPubSubEventType.User ?
                $"{Constants.Headers.CloudEvents.TypeUserPrefix}{eventName}" :
                $"{Constants.Headers.CloudEvents.TypeSystemPrefix}{eventName}";
        }
    }
}
#endif