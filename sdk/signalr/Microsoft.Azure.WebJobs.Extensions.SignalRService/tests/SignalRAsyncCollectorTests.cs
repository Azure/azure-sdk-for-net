// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Tests.Common;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Moq;
using Xunit;

namespace SignalRServiceExtension.Tests
{
    public class SignalRAsyncCollectorTests
    {
        public static IEnumerable<object[]> GetEndpoints()
        {
            yield return new object[] { FakeEndpointUtils.GetFakeEndpoint(2).ToArray() };
            yield return new object[] { null };
        }

        [Theory]
        [MemberData(nameof(GetEndpoints))]
        public async Task AddAsync_WithBroadcastMessage_CallsSendToAll(ServiceEndpoint[] endpoints)
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<SignalRMessage>(signalRSenderMock.Object);

            await collector.AddAsync(new SignalRMessage
            {
                Target = "newMessage",
                Arguments = new object[] { "arg1", "arg2" },
                Endpoints = endpoints
            });

            signalRSenderMock.Verify(c => c.SendToAll(It.IsAny<SignalRData>()), Times.Once);
            signalRSenderMock.VerifyNoOtherCalls();
            var actualData = (SignalRData)signalRSenderMock.Invocations[0].Arguments[0];
            Assert.Equal("newMessage", actualData.Target);
            Assert.Equal("arg1", actualData.Arguments[0]);
            Assert.Equal("arg2", actualData.Arguments[1]);
            Assert.Equal(endpoints, actualData.Endpoints);
        }

        [Fact]
        public async Task AddAsync_WithUserId_CallsSendToUser()
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<SignalRMessage>(signalRSenderMock.Object);

            await collector.AddAsync(new SignalRMessage
            {
                UserId = "userId1",
                Target = "newMessage",
                Arguments = new object[] { "arg1", "arg2" }
            });

            signalRSenderMock.Verify(
                c => c.SendToUser("userId1", It.IsAny<SignalRData>()),
                Times.Once);
            signalRSenderMock.VerifyNoOtherCalls();
            var actualData = (SignalRData)signalRSenderMock.Invocations[0].Arguments[1];
            Assert.Equal("newMessage", actualData.Target);
            Assert.Equal("arg1", actualData.Arguments[0]);
            Assert.Equal("arg2", actualData.Arguments[1]);
        }

        [Fact]
        public async Task AddAsync_WithUserId_CallsSendToGroup()
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<SignalRMessage>(signalRSenderMock.Object);

            await collector.AddAsync(new SignalRMessage
            {
                GroupName = "group1",
                Target = "newMessage",
                Arguments = new object[] { "arg1", "arg2" }
            });

            signalRSenderMock.Verify(
                c => c.SendToGroup("group1", It.IsAny<SignalRData>()),
                Times.Once);
            signalRSenderMock.VerifyNoOtherCalls();
            var actualData = (SignalRData)signalRSenderMock.Invocations[0].Arguments[1];
            Assert.Equal("newMessage", actualData.Target);
            Assert.Equal("arg1", actualData.Arguments[0]);
            Assert.Equal("arg2", actualData.Arguments[1]);
        }

        [Theory]
        [MemberData(nameof(GetEndpoints))]
        public async Task AddAsync_WithUserId_CallsAddUserToGroup(ServiceEndpoint[] endpoints)
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<SignalRGroupAction>(signalRSenderMock.Object);

            var action = new SignalRGroupAction
            {
                UserId = "userId1",
                GroupName = "group1",
                Action = GroupAction.Add,
                Endpoints = endpoints
            };
            await collector.AddAsync(action);

            signalRSenderMock.Verify(
                c => c.AddUserToGroup(action),
                Times.Once);
            signalRSenderMock.VerifyNoOtherCalls();
            var actualData = signalRSenderMock.Invocations[0].Arguments[0];
            Assert.Equal(action, actualData);
        }

        [Fact]
        public async Task AddAsync_WithUserId_CallsRemoveUserFromGroup()
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<SignalRGroupAction>(signalRSenderMock.Object);

            var action = new SignalRGroupAction
            {
                UserId = "userId1",
                GroupName = "group1",
                Action = GroupAction.Remove
            };
            await collector.AddAsync(action);

            signalRSenderMock.Verify(
                c => c.RemoveUserFromGroup(action),
                Times.Once);
            signalRSenderMock.VerifyNoOtherCalls();
            var actualData = signalRSenderMock.Invocations[0].Arguments[0];
            Assert.Equal(action, actualData);
        }

        [Fact]
        public async Task AddAsync_WithUserId_CallsRemoveUserFromAllGroups()
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<SignalRGroupAction>(signalRSenderMock.Object);

            var action = new SignalRGroupAction
            {
                UserId = "userId1",
                Action = GroupAction.RemoveAll
            };
            await collector.AddAsync(action);

            signalRSenderMock.Verify(
                c => c.RemoveUserFromAllGroups(action),
                Times.Once);
            signalRSenderMock.VerifyNoOtherCalls();
            var actualData = signalRSenderMock.Invocations[0].Arguments[0];
            Assert.Equal(action, actualData);
        }

        [Fact]
        public async Task AddAsync_InvalidTypeThrowException()
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<object[]>(signalRSenderMock.Object);

            var item = new object[] { "arg1", "arg2" };

            await Assert.ThrowsAsync<ArgumentException>(() => collector.AddAsync(item));
        }

        [Fact]
        public async Task AddAsync_SendMessage_WithBothUserIdAndGroupName_UsePriorityOrder()
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<SignalRMessage>(signalRSenderMock.Object);

            await collector.AddAsync(new SignalRMessage
            {
                UserId = "user1",
                GroupName = "group1",
                Target = "newMessage",
                Arguments = new object[] { "arg1", "arg2" }
            });

            signalRSenderMock.Verify(
                c => c.SendToUser("user1", It.IsAny<SignalRData>()),
                Times.Once);
            signalRSenderMock.VerifyNoOtherCalls();
            var actualData = (SignalRData)signalRSenderMock.Invocations[0].Arguments[1];
            Assert.Equal("newMessage", actualData.Target);
            Assert.Equal("arg1", actualData.Arguments[0]);
            Assert.Equal("arg2", actualData.Arguments[1]);
        }

        [Fact]
        public async Task AddAsync_WithConnectionId_CallsSendToUser()
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<SignalRMessage>(signalRSenderMock.Object);

            await collector.AddAsync(new SignalRMessage
            {
                ConnectionId = "connection1",
                Target = "newMessage",
                Arguments = new object[] { "arg1", "arg2" }
            });

            signalRSenderMock.Verify(
                c => c.SendToConnection("connection1", It.IsAny<SignalRData>()),
                Times.Once);
            signalRSenderMock.VerifyNoOtherCalls();
            var actualData = (SignalRData)signalRSenderMock.Invocations[0].Arguments[1];
            Assert.Equal("newMessage", actualData.Target);
            Assert.Equal("arg1", actualData.Arguments[0]);
            Assert.Equal("arg2", actualData.Arguments[1]);
        }

        [Fact]
        public async Task AddAsync_WithConnectionId_CallsAddConnectionToGroup()
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<SignalRGroupAction>(signalRSenderMock.Object);

            var action = new SignalRGroupAction
            {
                ConnectionId = "connection1",
                GroupName = "group1",
                Action = GroupAction.Add
            };
            await collector.AddAsync(action);

            signalRSenderMock.Verify(
                c => c.AddConnectionToGroup(It.IsAny<SignalRGroupAction>()),
                Times.Once);
            signalRSenderMock.VerifyNoOtherCalls();
            var actualData = signalRSenderMock.Invocations[0].Arguments[0];
            Assert.Equal(action, actualData);
        }

        [Fact]
        public async Task AddAsync_WithConnectionId_CallsRemoveConnectionFromGroup()
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<SignalRGroupAction>(signalRSenderMock.Object);

            var action = new SignalRGroupAction
            {
                ConnectionId = "connection1",
                GroupName = "group1",
                Action = GroupAction.Remove
            };
            await collector.AddAsync(action);

            signalRSenderMock.Verify(
                c => c.RemoveConnectionFromGroup(action),
                Times.Once);
            signalRSenderMock.VerifyNoOtherCalls();
            var actualData = signalRSenderMock.Invocations[0].Arguments[0];
            Assert.Equal(action, actualData);
        }

        [Fact]
        public async Task AddAsync_GroupOperation_WithoutParametersThrowException()
        {
            var signalRSenderMock = new Mock<IAzureSignalRSender>();
            var collector = new SignalRAsyncCollector<SignalRGroupAction>(signalRSenderMock.Object);

            var item = new SignalRGroupAction
            {
                GroupName = "group1",
                Action = GroupAction.Add
            };

            await Assert.ThrowsAsync<ArgumentException>(() => collector.AddAsync(item));
        }
    }
}