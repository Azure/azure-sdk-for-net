// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.SignalR.Serverless.Protocols;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Common;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using SignalRServiceExtension.Tests.Utils;
using Xunit;
using ExecutionContext = Microsoft.Azure.WebJobs.Extensions.SignalRService.ExecutionContext;

namespace SignalRServiceExtension.Tests.Trigger
{
    public class SignalRMethodExecutorTests
    {
        private static readonly IOptionsMonitor<SignatureValidationOptions> SignatureValidationOptions = Mock.Of<IOptionsMonitor<SignatureValidationOptions>>(o => o.CurrentValue == new SignatureValidationOptions() { RequireValidation = false });
        private readonly ITriggeredFunctionExecutor _triggeredFunctionExecutor;
        private readonly TaskCompletionSource<TriggeredFunctionData> _triggeredFunctionDataTcs;

        public SignalRMethodExecutorTests()
        {
            _triggeredFunctionDataTcs = new TaskCompletionSource<TriggeredFunctionData>(TaskCreationOptions.RunContinuationsAsynchronously);
            var executorMoc = new Mock<ITriggeredFunctionExecutor>();
            executorMoc.Setup(f => f.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .Returns<TriggeredFunctionData, CancellationToken>((data, token) =>
                {
                    _triggeredFunctionDataTcs.TrySetResult(data);
                    ((SignalRTriggerEvent)data.TriggerValue).TaskCompletionSource?.TrySetResult(string.Empty);
                    return Task.FromResult(new FunctionResult(true));
                });
            _triggeredFunctionExecutor = executorMoc.Object;
        }

        [Fact]
        public async Task SignalRConnectMethodExecutorTest()
        {
            var resolver = new SignalRRequestResolver();
            var methodExecutor = new SignalRConnectMethodExecutor(resolver, new ExecutionContext { Executor = _triggeredFunctionExecutor, SignatureValidationOptions = SignatureValidationOptions });
            var hub = Guid.NewGuid().ToString();
            var category = Guid.NewGuid().ToString();
            var @event = Guid.NewGuid().ToString();
            var connectionId = Guid.NewGuid().ToString();
            var content = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new OpenConnectionMessage { Type = 10 }));
            var request = TestHelpers.CreateHttpRequestMessage(hub, category, @event, connectionId, contentType: Constants.JsonContentType, content: content);
            await methodExecutor.ExecuteAsync(request);

            var result = await _triggeredFunctionDataTcs.Task;
            var triggerData = (SignalRTriggerEvent)result.TriggerValue;
            Assert.Null(triggerData.TaskCompletionSource);
            Assert.Equal(hub, triggerData.Context.Hub);
            Assert.Equal(category, triggerData.Context.Category);
            Assert.Equal(@event, triggerData.Context.Event);
            Assert.Equal(connectionId, triggerData.Context.ConnectionId);
            Assert.Equal(hub, triggerData.Context.Hub);
        }

        [Fact]
        public async Task SignalRDisconnectMethodExecutorTest()
        {
            var resolver = new SignalRRequestResolver();
            var methodExecutor = new SignalRDisconnectMethodExecutor(resolver, new ExecutionContext { Executor = _triggeredFunctionExecutor, SignatureValidationOptions = SignatureValidationOptions });
            var hub = Guid.NewGuid().ToString();
            var category = Guid.NewGuid().ToString();
            var @event = Guid.NewGuid().ToString();
            var connectionId = Guid.NewGuid().ToString();
            var error = Guid.NewGuid().ToString();
            var content = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new CloseConnectionMessage { Type = 11, Error = error }));
            var request = TestHelpers.CreateHttpRequestMessage(hub, category, @event, connectionId, contentType: Constants.JsonContentType, content: content);
            await methodExecutor.ExecuteAsync(request);

            var result = await _triggeredFunctionDataTcs.Task;
            var triggerData = (SignalRTriggerEvent)result.TriggerValue;
            Assert.Null(triggerData.TaskCompletionSource);
            Assert.Equal(hub, triggerData.Context.Hub);
            Assert.Equal(category, triggerData.Context.Category);
            Assert.Equal(@event, triggerData.Context.Event);
            Assert.Equal(connectionId, triggerData.Context.ConnectionId);
            Assert.Equal(hub, triggerData.Context.Hub);
            Assert.Equal(error, triggerData.Context.Error);
        }

        [Theory]
        [InlineData("json")]
        [InlineData("messagepack")]
        public async Task SignalRInvocationMethodExecutorTest(string protocolName)
        {
            var resolver = new SignalRRequestResolver();
            var methodExecutor = new SignalRInvocationMethodExecutor(resolver, new ExecutionContext { Executor = _triggeredFunctionExecutor, SignatureValidationOptions = SignatureValidationOptions });
            var hub = Guid.NewGuid().ToString();
            var category = Guid.NewGuid().ToString();
            var @event = Guid.NewGuid().ToString();
            var connectionId = Guid.NewGuid().ToString();
            var arguments = new object[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var message = new Microsoft.AspNetCore.SignalR.Protocol.InvocationMessage(Guid.NewGuid().ToString(), @event, arguments);
            var protocol = protocolName == "json" ? (IHubProtocol)new JsonHubProtocol() : new MessagePackHubProtocol();
            var contentType = protocolName == "json" ? Constants.JsonContentType : Constants.MessagePackContentType;
            var bytes = new ReadOnlySequence<byte>(protocol.GetMessageBytes(message));
            ReadOnlySequence<byte> payload;
            if (protocolName == "json")
            {
                TextMessageParser.TryParseMessage(ref bytes, out payload);
            }
            else
            {
                BinaryMessageParser.TryParseMessage(ref bytes, out payload);
            }

            var request = TestHelpers.CreateHttpRequestMessage(hub, category, @event, connectionId, contentType: contentType, content: payload.ToArray());
            await methodExecutor.ExecuteAsync(request);

            var result = await _triggeredFunctionDataTcs.Task;
            var triggerData = (SignalRTriggerEvent)result.TriggerValue;
            Assert.NotNull(triggerData.TaskCompletionSource);
            Assert.Equal(hub, triggerData.Context.Hub);
            Assert.Equal(category, triggerData.Context.Category);
            Assert.Equal(@event, triggerData.Context.Event);
            Assert.Equal(connectionId, triggerData.Context.ConnectionId);
            Assert.Equal(hub, triggerData.Context.Hub);
            Assert.Equal(arguments, triggerData.Context.Arguments);
        }
    }
}