// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Messaging.WebPubSub;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class SocketIOAsyncCollectorTests
    {
        private Mock<WebPubSubServiceClient> _service;
        private SocketLifetimeStore _socketLifetimeStore;
        private WebPubSubForSocketIOAsyncCollector _collector;

        public SocketIOAsyncCollectorTests()
        {
        }

        [SetUp]
        public void Init()
        {
            _service = new();
            _socketLifetimeStore = new();
            _collector = new(new WebPubSubForSocketIOService(_service.Object), _socketLifetimeStore);
        }

        [Test]
        public void NullServiceThrows()
        {
            Assert.Throws<ArgumentNullException>(() => new WebPubSubForSocketIOAsyncCollector(null, null));
        }

        [Test]
        public void NullServiceThrows2()
        {
            Assert.Throws<ArgumentNullException>(() => new WebPubSubForSocketIOAsyncCollector(new WebPubSubForSocketIOService(_service.Object), null));
        }

        [Test]
        public void NullWebPubSubActionThrows()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _collector.AddAsync(null));
        }

        [Test]
        public async Task SendToRoomTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateSendToRoomsAction(new[] { "rm" }, "event", new string[] {"abc"}, @namespace: "/ns"));
            _service.Verify(x => x.SendToGroupAsync("0~L25z~cm0", It.Is<RequestContent>(c =>
            AssertContentData(c, "42/ns,[\"event\",\"abc\"]")),
            ContentType.TextPlain, It.IsAny<IList<string>>(), "", It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task SendToRoomParameterlessTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateSendToRoomsAction(new[] { "rm" }, "event", null, @namespace: "/ns"));
            _service.Verify(x => x.SendToGroupAsync("0~L25z~cm0", It.Is<RequestContent>(c =>
            AssertContentData(c, "42/ns,[\"event\"]")),
            ContentType.TextPlain, It.IsAny<IList<string>>(), "", It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task SendToRoomExcludeTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateSendToRoomsAction(new[] { "rm" }, "event", new string[] { "abc" }, new[] {"sid"}, @namespace: "/ns"));
            _service.Verify(x => x.SendToGroupAsync("0~L25z~cm0", It.Is<RequestContent>(c =>
            AssertContentData(c, "42/ns,[\"event\",\"abc\"]")),
            ContentType.TextPlain, It.IsAny<IList<string>>(), "not ('0~L25z~c2lk' in groups)", It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task SendToRoomWithComplexTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateSendToRoomsAction(new[] { "rm" }, "event", new object[] { 1, "abc" , new { a=1, b=true } }, @namespace: "/ns"));
            _service.Verify(x => x.SendToGroupAsync("0~L25z~cm0", It.Is<RequestContent>(c =>
            AssertContentData(c, "42/ns,[\"event\",1,\"abc\",{\"a\":1,\"b\":true}]")),
            ContentType.TextPlain, It.IsAny<IList<string>>(), "", It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task SendToRoomCtsTest()
        {
            using var cts = new CancellationTokenSource(1000);
            await _collector.AddAsync(SocketIOAction.CreateSendToRoomsAction(new[] { "rm" }, "event", new string[] { "abc" }, @namespace: "/ns"), cts.Token);
            _service.Verify(x => x.SendToGroupAsync("0~L25z~cm0", It.Is<RequestContent>(c =>
            AssertContentData(c, "42/ns,[\"event\",\"abc\"]")), ContentType.TextPlain, It.IsAny<IList<string>>(), "", It.Is<RequestContext>(x => x.CancellationToken == cts.Token)), Times.Once);
        }

        [Test]
        public async Task SendToRoomsTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateSendToRoomsAction(new[] { "rm", "rm2" }, "ev", new string[] { "abc" }, @namespace: "/ns"));
            _service.Verify(x => x.SendToAllAsync(It.Is<RequestContent>(c =>
            AssertContentData(c, "42/ns,[\"ev\",\"abc\"]")),
            ContentType.TextPlain, It.IsAny<IList<string>>(), It.Is<string>(f => f == "'0~L25z~cm0' in groups or '0~L25z~cm0y' in groups"), It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task SendToRoomsExceptTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateSendToRoomsAction(new[] { "rm", "rm2" }, "ev", new string[] { "abc" }, new[] {"ex1"}, @namespace: "/ns"));
            _service.Verify(x => x.SendToAllAsync(It.Is<RequestContent>(c =>
            AssertContentData(c, "42/ns,[\"ev\",\"abc\"]")),
            ContentType.TextPlain, It.IsAny<IList<string>>(), It.Is<string>(f => f == "'0~L25z~cm0' in groups or '0~L25z~cm0y' in groups and not ('0~L25z~ZXgx' in groups)"), It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task SendToLocalSocketTest()
        {
            // Simulate the socket is in local
            _socketLifetimeStore.AddSocket("socket1", "/ns", "conn1");
            await _collector.AddAsync(SocketIOAction.CreateSendToSocketAction("socket1", "event", new string[] { "abc" }, @namespace: "/ns"));
            _service.Verify(x => x.SendToConnectionAsync("conn1", It.Is<RequestContent>(c =>
            AssertContentData(c, "42/ns,[\"event\",\"abc\"]")),
            ContentType.TextPlain, It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task SendToGlobalSocketTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateSendToSocketAction("socket1", "event", new string[] { "abc" }, @namespace: "/ns"));
            _service.Verify(x => x.SendToGroupAsync("0~L25z~c29ja2V0MQ", It.Is<RequestContent>(c =>
            AssertContentData(c, "42/ns,[\"event\",\"abc\"]")),
            ContentType.TextPlain, It.IsAny<IList<string>>(), null, It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task SendToNamespaceTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("event", new string[] { "abc" }, @namespace: "/ns"));
            _service.Verify(x => x.SendToGroupAsync("0~L25z~", It.Is<RequestContent>(c =>
            AssertContentData(c, "42/ns,[\"event\",\"abc\"]")),
            ContentType.TextPlain, It.IsAny<IList<string>>(), "", It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task SendToNamespaceTestExclude()
        {
            await _collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("event", new string[] { "abc" }, new string[] { "sid" }, @namespace: "/ns"));
            _service.Verify(x => x.SendToGroupAsync("0~L25z~", It.Is<RequestContent>(c =>
            AssertContentData(c, "42/ns,[\"event\",\"abc\"]")),
            ContentType.TextPlain, It.IsAny<IList<string>>(), "not ('0~L25z~c2lk' in groups)", It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task AddLocalSocketToRoomTest()
        {
            _socketLifetimeStore.AddSocket("socket1", "/ns", "conn1");
            await _collector.AddAsync(SocketIOAction.CreateAddSocketToRoomAction("socket1", "rm1", "/ns"));
            _service.Verify(x => x.AddConnectionToGroupAsync("0~L25z~cm0x", "conn1", It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task AddGlobalSocketToRoomTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateAddSocketToRoomAction("socket1", "rm1", "/ns"));
            _service.Verify(x => x.AddConnectionsToGroupsAsync(It.Is<IEnumerable<string>>(x => x.Contains("0~L25z~cm0x")), "'0~L25z~c29ja2V0MQ' in groups", It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task RemoveLocalSocketToRoomTest()
        {
            _socketLifetimeStore.AddSocket("socket1", "/ns", "conn1");
            await _collector.AddAsync(SocketIOAction.CreateRemoveSocketFromRoomAction("socket1", "rm1", "/ns"));
            _service.Verify(x => x.RemoveConnectionFromGroupAsync("0~L25z~cm0x", "conn1", It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task RemoveGlobalSocketToRoomTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateRemoveSocketFromRoomAction("socket1", "rm1", "/ns"));
            _service.Verify(x => x.RemoveConnectionsFromGroupsAsync(It.Is<IEnumerable<string>>(x => x.Contains("0~L25z~cm0x")), "'0~L25z~c29ja2V0MQ' in groups", It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task DisconnectSocketsTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateDisconnectSocketsAction(new[] { "socket1", "socket2" }, false, @namespace: "/ns"));
            _service.Verify(x => x.SendToAllAsync(It.Is<RequestContent>(c => AssertContentData(c, "41/ns,")),
                ContentType.TextPlain,
                It.IsAny<IList<string>>(),
                It.Is<string>(f => f == "'0~L25z~c29ja2V0MQ' in groups or '0~L25z~c29ja2V0Mg' in groups"),
                It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task DisconnectSocketsInDefaultNsTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateDisconnectSocketsAction(new[] { "socket1", "socket2" }, false));
            _service.Verify(x => x.SendToAllAsync(It.Is<RequestContent>(c => AssertContentData(c, "41")),
                ContentType.TextPlain,
                It.IsAny<IList<string>>(),
                It.Is<string>(f => f == "'0~Lw~c29ja2V0MQ' in groups or '0~Lw~c29ja2V0Mg' in groups"),
                It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task DisconnectNamespaceTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateDisconnectSocketsAction(null, false, @namespace: "/ns"));
            _service.Verify(x => x.SendToAllAsync(It.Is<RequestContent>(c => AssertContentData(c, "41/ns,")),
                ContentType.TextPlain,
                It.IsAny<IList<string>>(),
                It.Is<string>(f => f == "'0~L25z~' in groups"),
                It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task DisconnectSocketsAndCloseConnectionTest()
        {
            await _collector.AddAsync(SocketIOAction.CreateDisconnectSocketsAction(new[] { "socket1", "socket2" }, true, @namespace: "/ns"));
            _service.Verify(x => x.SendToAllAsync(It.Is<RequestContent>(c => AssertContentData(c, "41/ns,{\"close\":true}")),
                ContentType.TextPlain,
                It.IsAny<IList<string>>(),
                It.Is<string>(f => f == "'0~L25z~c29ja2V0MQ' in groups or '0~L25z~c29ja2V0Mg' in groups"),
                It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        private bool AssertContentData(RequestContent content, string expected)
        {
            using var ms = new MemoryStream();
            content.WriteTo(ms, default);
            return expected == Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
